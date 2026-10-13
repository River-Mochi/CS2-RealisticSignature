// <copyright file="UniquePlacementSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/UniquePlacementSystem.cs
// One-shot Unique building placement-rule reconciliation.

namespace SignatureBuildingControl
{
    using System.Collections.Generic;
    using Colossal.Serialization.Entities;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Objects;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Game.UI.InGame;
    using Unity.Collections;
    using Unity.Entities;

    public sealed partial class UniquePlacementSystem : GameSystemBase
    {
        private EntityQuery m_BuildingPrefabQuery;

        // Only Unique flags actually removed by this mod.
        private readonly HashSet<Entity> m_UniqueRemovedByUs = new();

        private bool m_ReconcileRequested;
        private bool m_RequestedAllowMultiple;
        private string m_RequestReason = string.Empty;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_BuildingPrefabQuery = GetEntityQuery(
                ComponentType.ReadOnly<BuildingData>(),
                ComponentType.ReadWrite<PlaceableObjectData>(),
                ComponentType.ReadOnly<PrefabData>());

            Enabled = false;
        }

        protected override void OnGameLoaded(Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);

            UniquePlacementState.Clear();

            ScheduleReconcile(
                Mod.Setting?.AllowMultipleUniqueBuildings ?? true,
                "city load");
        }

        protected override void OnDestroy()
        {
            try
            {
                RestoreOwnedUniqueFlags(notifyUi: false);
            }
            catch
            {
            }

            base.OnDestroy();
        }

        protected override void OnUpdate()
        {
            if (!m_ReconcileRequested)
            {
                Enabled = false;
                return;
            }

            m_ReconcileRequested = false;

            GameManager? gameManager = GameManager.instance;

            if (gameManager == null || !gameManager.gameMode.IsGame())
            {
                Enabled = false;
                return;
            }

            try
            {
                ReconcileNow(
                    m_RequestedAllowMultiple,
                    m_RequestReason);
            }
            catch (System.Exception ex)
            {
                LogUtils.Warn(
                    $"{Mod.ModTag} Unique placement reconcile failed: " +
                    $"{ex.GetType().Name}: {ex.Message}",
                    ex);
            }

            Enabled = false;
        }

        public void ScheduleReconcile(bool allowMultiple, string reason)
        {
            m_RequestedAllowMultiple = allowMultiple;
            m_RequestReason = reason ?? string.Empty;

            m_ReconcileRequested = true;
            Enabled = true;
        }

        public void RestoreOwnedChangesForDispose()
        {
            RestoreOwnedUniqueFlags(notifyUi: true);
        }

        private void ReconcileNow(bool allowMultiple, string reason)
        {
            using NativeArray<Entity> buildingPrefabs =
                m_BuildingPrefabQuery.ToEntityArray(Allocator.Temp);

            CountUniqueBuildings(
                buildingPrefabs,
                out int totalUnique,
                out int restrictedBefore);

            int changedByUs = 0;
            int restoredByUs = 0;

            AnarchyMultipleUniqueState anarchyState =
                AnarchyCompatibility.GetMultipleUniqueState();

            bool unlimitedUniqueBuildingsInstalled =
                UnlimitedUniqueBuildingsCompatibility.IsInstalled();

            if (allowMultiple)
            {
                for (int i = 0; i < buildingPrefabs.Length; i++)
                {
                    Entity entity = buildingPrefabs[i];

                    PlaceableObjectData data =
                        EntityManager.GetComponentData<PlaceableObjectData>(
                            entity);

                    if (!IsKnownUniqueBuilding(entity, data))
                        continue;

                    if ((data.m_Flags & PlacementFlags.Unique) == 0)
                        continue;

                    data.m_Flags &= ~PlacementFlags.Unique;
                    EntityManager.SetComponentData(entity, data);

                    m_UniqueRemovedByUs.Add(entity);
                    changedByUs++;

                    NotifyUniqueUi(entity);
                }
            }
            else
            {
                restoredByUs =
                    RestoreOwnedUniqueFlags(notifyUi: true);
            }

            CountUniqueBuildings(
                buildingPrefabs,
                out totalUnique,
                out int restrictedAfter);

            UniquePlacementState.SetSnapshot(
                totalUnique,
                restrictedAfter,
                anarchyState,
                unlimitedUniqueBuildingsInstalled);

            int unrestrictedBefore =
                totalUnique - restrictedBefore;

            LogUtils.Info(
                $"{Mod.ModTag} Unique placement reconcile ({reason}): " +
                $"Mod={(allowMultiple ? "ON" : "OFF")} | " +
                $"UniqueBuildings={totalUnique} | " +
                $"RestrictedBefore={restrictedBefore} | " +
                $"AlreadyUnrestricted={unrestrictedBefore} | " +
                $"ChangedByMod={changedByUs} | " +
                $"RestoredByMod={restoredByUs} | " +
                $"RestrictedAfter={restrictedAfter} | " +
                $"OwnedByMod={m_UniqueRemovedByUs.Count} | " +
                $"Anarchy={AnarchyCompatibility.GetLogText(anarchyState)} | " +
                $"UnlimitedUniqueBuildings=" +
                $"{(unlimitedUniqueBuildingsInstalled ? "installed" : "not installed")}.");
        }

        private int RestoreOwnedUniqueFlags(bool notifyUi)
        {
            if (m_UniqueRemovedByUs.Count == 0)
                return 0;

            // This mod is always-on when installed and clears Unique itself.
            // Do not fight it when our own toggle is switched OFF.
            if (UnlimitedUniqueBuildingsCompatibility.IsInstalled())
            {
                m_UniqueRemovedByUs.Clear();
                return 0;
            }

            List<Entity> remove =
                new(m_UniqueRemovedByUs.Count);

            int restored = 0;

            foreach (Entity entity in m_UniqueRemovedByUs)
            {
                remove.Add(entity);

                if (!EntityManager.Exists(entity) ||
                    !EntityManager.HasComponent<BuildingData>(entity) ||
                    !EntityManager.HasComponent<PlaceableObjectData>(entity))
                {
                    continue;
                }

                PlaceableObjectData data =
                    EntityManager.GetComponentData<PlaceableObjectData>(
                        entity);

                if ((data.m_Flags & PlacementFlags.Unique) != 0)
                    continue;

                data.m_Flags |= PlacementFlags.Unique;
                EntityManager.SetComponentData(entity, data);

                restored++;

                if (notifyUi)
                    NotifyUniqueUi(entity);
            }

            for (int i = 0; i < remove.Count; i++)
                m_UniqueRemovedByUs.Remove(remove[i]);

            return restored;
        }

        private void CountUniqueBuildings(
            NativeArray<Entity> buildingPrefabs,
            out int totalUnique,
            out int restricted)
        {
            totalUnique = 0;
            restricted = 0;

            for (int i = 0; i < buildingPrefabs.Length; i++)
            {
                Entity entity = buildingPrefabs[i];

                PlaceableObjectData data =
                    EntityManager.GetComponentData<PlaceableObjectData>(
                        entity);

                if (!IsKnownUniqueBuilding(entity, data))
                    continue;

                totalUnique++;

                if ((data.m_Flags & PlacementFlags.Unique) != 0)
                    restricted++;
            }
        }

        private bool IsKnownUniqueBuilding(
            Entity entity,
            PlaceableObjectData data)
        {
            if ((data.m_Flags & PlacementFlags.Unique) != 0)
                return true;

            if (EntityManager.HasComponent<SignatureBuildingData>(entity))
                return true;

            return EntityManager.HasComponent<UniqueObjectData>(entity);
        }

        private void NotifyUniqueUi(Entity prefabEntity)
        {
            try
            {
                UniqueAssetTrackingSystem? trackingSystem =
                    World.GetExistingSystemManaged<UniqueAssetTrackingSystem>();

                if (trackingSystem == null)
                    return;

                bool placed =
                    trackingSystem.placedUniqueAssets.IsCreated &&
                    trackingSystem.placedUniqueAssets.Contains(prefabEntity);

                trackingSystem.EventUniqueAssetStatusChanged?.Invoke(
                    prefabEntity,
                    placed);
            }
            catch
            {
            }
        }
    }
}
