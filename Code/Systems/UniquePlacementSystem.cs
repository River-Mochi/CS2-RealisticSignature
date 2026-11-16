// <copyright file="UniquePlacementSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/UniquePlacementSystem.cs
// One-shot Unique placement-rule reconciliation for all placeable Unique prefabs.

namespace UniqueBuildings
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
        private EntityQuery m_PlaceablePrefabQuery;

        // All prefabs we know are normally Unique.
        private readonly HashSet<Entity> m_KnownUniquePrefabs = new();

        // Only flags actually removed by this mod.
        private readonly HashSet<Entity> m_UniqueRemovedByUs = new();

        private Entity m_LastCheckedBuildingPrefab;
        private bool m_HasLastCheckedBuildingPrefab;
        private bool m_LastCheckedBuildingIsUnique;

        private bool m_ReconcileRequested;
        private bool m_RequestedAllowMultiple;
        private string m_RequestReason = string.Empty;

        protected override void OnCreate()
        {
            base.OnCreate();

            // Intentionally broad, matching game's PlaceableObjectData
            // Unique flag rather than restricting this feature to buildings.
            m_PlaceablePrefabQuery = GetEntityQuery(
                ComponentType.ReadWrite<PlaceableObjectData>());

            Enabled = false;
        }

        protected override void OnGameLoaded(Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);

            m_KnownUniquePrefabs.Clear();
            m_UniqueRemovedByUs.Clear();
            m_HasLastCheckedBuildingPrefab = false;

            ToggleableOverlaysCompatibility.Invalidate();

            UniquePlacementState.Clear();

            ScheduleReconcile(
                Mod.Setting?.AllowMultipleUniqueBuildings ?? true,
                "city load");

            try
            {
                ToggleableOverlaysCompatibility.Initialize();
            }
            catch (System.Exception ex)
            {
                LogUtils.Warn(
                    $"{Mod.ModTag} Could not watch mod-set changes.", ex);
            }
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

        public bool IsKnownUniqueBuilding(Entity prefab)
        {
            if (m_HasLastCheckedBuildingPrefab &&
                prefab == m_LastCheckedBuildingPrefab)
            {
                return m_LastCheckedBuildingIsUnique;
            }

            bool isUnique = ClassifyUniqueBuilding(prefab);
            m_LastCheckedBuildingPrefab = prefab;
            m_LastCheckedBuildingIsUnique = isUnique;
            m_HasLastCheckedBuildingPrefab = true;
            return isUnique;
        }

        private bool ClassifyUniqueBuilding(Entity prefab)
        {
            if (!EntityManager.Exists(prefab) ||
                !EntityManager.HasComponent<BuildingData>(prefab) ||
                !EntityManager.HasComponent<PlaceableObjectData>(prefab))
            {
                return false;
            }

            if (m_KnownUniquePrefabs.Contains(prefab) ||
                m_UniqueRemovedByUs.Contains(prefab))
            {
                return true;
            }

            PlaceableObjectData data =
                EntityManager.GetComponentData<PlaceableObjectData>(prefab);
            return IsUniquePrefab(prefab, data);
        }

        private void ReconcileNow(bool allowMultiple, string reason)
        {
            UniqueModsCompatibility.LogDetectedMods();

            using NativeArray<Entity> placeablePrefabs =
                m_PlaceablePrefabQuery.ToEntityArray(Allocator.Temp);

            RefreshKnownUniquePrefabs(placeablePrefabs);

            int totalKnownUnique = m_KnownUniquePrefabs.Count;
            int restrictedBefore = CountRestrictedUnique();

            int changedByUs = 0;
            int restoredByUs = 0;

            AnarchyMultipleUniqueState anarchyState =
                AnarchyCompatibility.GetMultipleUniqueState();

            if (allowMultiple)
            {
                foreach (Entity entity in m_KnownUniquePrefabs)
                {
                    if (!EntityManager.Exists(entity) ||
                        !EntityManager.HasComponent<PlaceableObjectData>(entity))
                    {
                        continue;
                    }

                    PlaceableObjectData data =
                        EntityManager.GetComponentData<PlaceableObjectData>(
                            entity);

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

            RefreshKnownUniquePrefabs(placeablePrefabs);

            totalKnownUnique = m_KnownUniquePrefabs.Count;
            int restrictedAfter = CountRestrictedUnique();

            UniquePlacementState.SetSnapshot(
                totalKnownUnique,
                restrictedAfter,
                anarchyState,
                UniqueModsCompatibility.GetUiVersion());

            int unrestrictedBefore =
                totalKnownUnique - restrictedBefore;

#if DEBUG
            LogUtils.Info(
                $"{Mod.ModTag} Unique placement reconcile ({reason}): " +
                $"Mod={(allowMultiple ? "ON" : "OFF")} | " +
                $"UniquePlaceables={totalKnownUnique} | " +
                $"RestrictedBefore={restrictedBefore} | " +
                $"AlreadyUnrestricted={unrestrictedBefore} | " +
                $"ChangedByMod={changedByUs} | " +
                $"RestoredByMod={restoredByUs} | " +
                $"RestrictedAfter={restrictedAfter} | " +
                $"OwnedByMod={m_UniqueRemovedByUs.Count} | " +
                $"Anarchy={AnarchyCompatibility.GetLogText(anarchyState)} | " +
                $"RedundantMods={UniqueModsCompatibility.StatusText}.");
#endif
        }

        private void RefreshKnownUniquePrefabs(
            NativeArray<Entity> placeablePrefabs)
        {
            m_HasLastCheckedBuildingPrefab = false;
            m_KnownUniquePrefabs.Clear();

            for (int i = 0; i < placeablePrefabs.Length; i++)
            {
                Entity entity = placeablePrefabs[i];

                if (!EntityManager.Exists(entity) ||
                    !EntityManager.HasComponent<PlaceableObjectData>(entity))
                {
                    continue;
                }

                PlaceableObjectData data =
                    EntityManager.GetComponentData<PlaceableObjectData>(
                        entity);

                if (IsUniquePrefab(entity, data))
                {
                    m_KnownUniquePrefabs.Add(entity);
                }
            }
        }

        private bool IsUniquePrefab(Entity entity, PlaceableObjectData data)
        {
            return (data.m_Flags & PlacementFlags.Unique) != 0 ||
                   m_UniqueRemovedByUs.Contains(entity) ||
                   EntityManager.HasComponent<SignatureBuildingData>(entity) ||
                   EntityManager.HasComponent<UniqueObjectData>(entity);
        }

        private int RestoreOwnedUniqueFlags(bool notifyUi)
        {
            if (m_UniqueRemovedByUs.Count == 0)
                return 0;

            // A dedicated Unlimited/Multiple Unique mod is explicitly trying
            // to keep these restrictions removed. Do not fight it.
            if (UniqueModsCompatibility.HasRedundantMods)
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

        private int CountRestrictedUnique()
        {
            int count = 0;

            foreach (Entity entity in m_KnownUniquePrefabs)
            {
                if (!EntityManager.Exists(entity) ||
                    !EntityManager.HasComponent<PlaceableObjectData>(entity))
                {
                    continue;
                }

                PlaceableObjectData data =
                    EntityManager.GetComponentData<PlaceableObjectData>(
                        entity);

                if ((data.m_Flags & PlacementFlags.Unique) != 0)
                    count++;
            }

            return count;
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
