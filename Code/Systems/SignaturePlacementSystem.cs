// <copyright file="SignaturePlacementSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignaturePlacementSystem.cs
// One-shot Signature Unique-rule reconciliation.
// Runs only on city load, SBC setting changes, or an explicit refresh.

namespace SignatureBuildingControl
{
    using System.Collections.Generic;
    using Colossal.Serialization.Entities;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Game.UI.InGame;
    using Unity.Collections;
    using Unity.Entities;

    public sealed partial class SignaturePlacementSystem : GameSystemBase
    {
        private EntityQuery m_SignaturePrefabQuery;

        // Only prefabs whose Unique flag SBC itself removed.
        private readonly HashSet<Entity> m_UniqueRemovedBySbc = new();

        private bool m_ReconcileRequested;
        private bool m_RequestedAllowMultiple;
        private string m_RequestReason = string.Empty;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_SignaturePrefabQuery = GetEntityQuery(
                ComponentType.ReadOnly<SignatureBuildingData>(),
                ComponentType.ReadWrite<PlaceableObjectData>(),
                ComponentType.ReadOnly<PrefabData>());

            Enabled = false;
        }

        protected override void OnGameLoaded(Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);

            ScheduleReconcile(
                Mod.Setting?.AllowMultipleSignatureBuildings ?? false,
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
                    $"{Mod.ModTag} Signature placement reconcile failed: " +
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
            using NativeArray<Entity> prefabs =
                m_SignaturePrefabQuery.ToEntityArray(Allocator.Temp);

            int total = prefabs.Length;
            int restrictedBefore = CountUniqueRestricted(prefabs);
            int changedBySbc = 0;
            int restoredBySbc = 0;

            AnarchyMultipleUniqueState anarchyState =
                AnarchyCompatibility.GetMultipleUniqueState();

            if (allowMultiple)
            {
                for (int i = 0; i < prefabs.Length; i++)
                {
                    Entity entity = prefabs[i];

                    PlaceableObjectData data =
                        EntityManager.GetComponentData<PlaceableObjectData>(entity);

                    if ((data.m_Flags & PlacementFlags.Unique) == 0)
                        continue;

                    data.m_Flags &= ~PlacementFlags.Unique;
                    EntityManager.SetComponentData(entity, data);

                    m_UniqueRemovedBySbc.Add(entity);
                    changedBySbc++;

                    NotifyUniqueUi(entity);
                }
            }
            else
            {
                restoredBySbc = RestoreOwnedUniqueFlags(notifyUi: true);
            }

            int restrictedAfter = CountUniqueRestricted(prefabs);

            SignaturePlacementState.SetSnapshot(
                total,
                restrictedAfter,
                anarchyState);

            int unrestrictedBefore = total - restrictedBefore;

            LogUtils.Info(
                $"{Mod.ModTag} Placement reconcile ({reason}): " +
                $"SBC={(allowMultiple ? "ON" : "OFF")} | " +
                $"SignaturePrefabs={total} | " +
                $"UniqueBefore={restrictedBefore} | " +
                $"AlreadyUnrestricted={unrestrictedBefore} | " +
                $"ChangedBySBC={changedBySbc} | " +
                $"RestoredBySBC={restoredBySbc} | " +
                $"UniqueAfter={restrictedAfter} | " +
                $"OwnedBySBC={m_UniqueRemovedBySbc.Count} | " +
                $"Anarchy={AnarchyCompatibility.GetLogText(anarchyState)}.");
        }

        private int RestoreOwnedUniqueFlags(bool notifyUi)
        {
            if (m_UniqueRemovedBySbc.Count == 0)
                return 0;

            List<Entity> remove = new(m_UniqueRemovedBySbc.Count);
            int restored = 0;

            foreach (Entity entity in m_UniqueRemovedBySbc)
            {
                remove.Add(entity);

                if (!EntityManager.Exists(entity) ||
                    !EntityManager.HasComponent<SignatureBuildingData>(entity) ||
                    !EntityManager.HasComponent<PlaceableObjectData>(entity))
                {
                    continue;
                }

                PlaceableObjectData data =
                    EntityManager.GetComponentData<PlaceableObjectData>(entity);

                if ((data.m_Flags & PlacementFlags.Unique) != 0)
                    continue;

                data.m_Flags |= PlacementFlags.Unique;
                EntityManager.SetComponentData(entity, data);

                restored++;

                if (notifyUi)
                    NotifyUniqueUi(entity);
            }

            for (int i = 0; i < remove.Count; i++)
                m_UniqueRemovedBySbc.Remove(remove[i]);

            return restored;
        }

        private int CountUniqueRestricted(NativeArray<Entity> prefabs)
        {
            int count = 0;

            for (int i = 0; i < prefabs.Length; i++)
            {
                PlaceableObjectData data =
                    EntityManager.GetComponentData<PlaceableObjectData>(prefabs[i]);

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
