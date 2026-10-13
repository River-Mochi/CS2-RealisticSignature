// <copyright file="SignatureUnlockSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignatureUnlockSystem.cs
// One-shot bypass of Signature building progression requirements.

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

    public sealed partial class SignatureUnlockSystem : GameSystemBase
    {
        private EntityQuery m_AllSignatureQuery;

        // Only Signature locks actually disabled by this mod this session.
        private readonly HashSet<Entity> m_UnlockedByUs = new();

        private bool m_ReconcileRequested;
        private bool m_RequestedUnlock;
        private string m_RequestReason = string.Empty;

        protected override void OnCreate()
        {
            base.OnCreate();

            EntityQueryBuilder builder = new(Allocator.Temp);

            builder = builder
                .WithAll<SignatureBuildingData, Locked>()
                .WithOptions(EntityQueryOptions.IgnoreComponentEnabledState);

            m_AllSignatureQuery = builder.Build(this);
            builder.Dispose();

            Enabled = false;
        }

        protected override void OnGameLoaded(Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);

            m_UnlockedByUs.Clear();

            ScheduleReconcile(
                Mod.Setting?.UnlockSignatureRequirements ?? false,
                "city load");
        }

        protected override void OnDestroy()
        {
            try
            {
                RestoreOwnedLocks();
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
                    m_RequestedUnlock,
                    m_RequestReason);
            }
            catch (System.Exception ex)
            {
                LogUtils.Warn(
                    $"{Mod.ModTag} Signature unlock reconcile failed: " +
                    $"{ex.GetType().Name}: {ex.Message}",
                    ex);
            }

            Enabled = false;
        }

        public void ScheduleReconcile(bool unlock, string reason)
        {
            m_RequestedUnlock = unlock;
            m_RequestReason = reason ?? string.Empty;

            m_ReconcileRequested = true;
            Enabled = true;
        }

        public void RestoreOwnedChangesForDispose()
        {
            RestoreOwnedLocks();
        }

        private void ReconcileNow(bool unlock, string reason)
        {
            using NativeArray<Entity> signatures =
                m_AllSignatureQuery.ToEntityArray(Allocator.Temp);

            int total = signatures.Length;
            int lockedBefore = CountLocked(signatures);

            int unlockedByUs = 0;
            int restoredByUs = 0;
            int earnedWhileEnabled = 0;

            if (unlock)
            {
                for (int i = 0; i < signatures.Length; i++)
                {
                    Entity entity = signatures[i];

                    if (!EntityManager.HasEnabledComponent<Locked>(entity))
                        continue;

                    EntityManager.SetComponentEnabled<Locked>(
                        entity,
                        false);

                    m_UnlockedByUs.Add(entity);
                    unlockedByUs++;

                    NotifyToolbar(entity);
                }
            }
            else
            {
                restoredByUs =
                    RestoreOwnedLocks(out earnedWhileEnabled);
            }

            int lockedAfter = CountLocked(signatures);

            LogUtils.Info(
                $"{Mod.ModTag} Signature unlock reconcile ({reason}): " +
                $"Unlock={(unlock ? "ON" : "OFF")} | " +
                $"SignaturePrefabs={total} | " +
                $"LockedBefore={lockedBefore} | " +
                $"UnlockedByMod={unlockedByUs} | " +
                $"RestoredByMod={restoredByUs} | " +
                $"EarnedWhileEnabled={earnedWhileEnabled} | " +
                $"LockedAfter={lockedAfter} | " +
                $"OwnedByMod={m_UnlockedByUs.Count}.");
        }

        private int RestoreOwnedLocks()
        {
            return RestoreOwnedLocks(out _);
        }

        private int RestoreOwnedLocks(out int earnedWhileEnabled)
        {
            earnedWhileEnabled = 0;

            if (m_UnlockedByUs.Count == 0)
                return 0;

            List<Entity> remove =
                new(m_UnlockedByUs.Count);

            int restored = 0;

            foreach (Entity entity in m_UnlockedByUs)
            {
                remove.Add(entity);

                if (!EntityManager.Exists(entity) ||
                    !EntityManager.HasComponent<Locked>(entity))
                {
                    continue;
                }

                if (EntityManager.HasEnabledComponent<Locked>(entity))
                    continue;

                // The player may have legitimately satisfied the normal
                // requirements while our bypass was enabled.
                if (AreVanillaRequirementsSatisfied(entity))
                {
                    earnedWhileEnabled++;
                    continue;
                }

                EntityManager.SetComponentEnabled<Locked>(
                    entity,
                    true);

                restored++;
                NotifyToolbar(entity);
            }

            for (int i = 0; i < remove.Count; i++)
                m_UnlockedByUs.Remove(remove[i]);

            return restored;
        }

        private bool AreVanillaRequirementsSatisfied(Entity entity)
        {
            if (!EntityManager.HasBuffer<UnlockRequirement>(entity))
                return false;

            DynamicBuffer<UnlockRequirement> requirements =
                EntityManager.GetBuffer<UnlockRequirement>(entity);

            bool blockedRequireAll = false;
            bool hasLockedRequireAny = false;
            bool hasUnlockedRequireAny = false;

            for (int i = 0; i < requirements.Length; i++)
            {
                UnlockRequirement requirement =
                    requirements[i];

                bool requirementLocked =
                    EntityManager.HasEnabledComponent<Locked>(
                        requirement.m_Prefab);

                bool requireAll =
                    (requirement.m_Flags & UnlockFlags.RequireAll) != 0;

                bool requireAny =
                    (requirement.m_Flags & UnlockFlags.RequireAny) != 0;

                blockedRequireAll |=
                    requirementLocked && requireAll;

                hasLockedRequireAny |=
                    requirementLocked && requireAny;

                hasUnlockedRequireAny |=
                    !requirementLocked && requireAny;

                if (blockedRequireAll)
                    break;
            }

            // Mirrors vanilla UnlockSystem.CheckUnlockRequirementsJob.
            return
                !blockedRequireAll &&
                (hasUnlockedRequireAny ||
                 !hasLockedRequireAny);
        }

        private int CountLocked(NativeArray<Entity> signatures)
        {
            int count = 0;

            for (int i = 0; i < signatures.Length; i++)
            {
                if (EntityManager.HasEnabledComponent<Locked>(
                    signatures[i]))
                {
                    count++;
                }
            }

            return count;
        }

        private void NotifyToolbar(Entity prefabEntity)
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
