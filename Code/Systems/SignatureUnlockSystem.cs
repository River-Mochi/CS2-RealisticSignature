// <copyright file="SignatureUnlockSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignatureUnlockSystem.cs
// One-shot bypass of Signature building progression requirements.

namespace UniqueBuildings
{
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
        private EntityQuery m_SignatureQuery;

        private bool m_ReconcileRequested;
        private bool m_RequestedUnlock;
        private string m_RequestReason = string.Empty;

        protected override void OnCreate()
        {
            base.OnCreate();

            // Include Signature prefabs whether Locked is currently
            // enabled or disabled.
            m_SignatureQuery = SystemAPI.QueryBuilder()
                .WithAll<SignatureBuildingData, Locked>()
                .WithOptions(EntityQueryOptions.IgnoreComponentEnabledState)
                .Build();

            Enabled = false;
        }

        protected override void OnGameLoaded(Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);

            ScheduleReconcile(
                Mod.Setting?.UnlockSignatureRequirements ?? false,
                "city load");
        }

        protected override void OnDestroy()
        {
            try
            {
                RestoreVanillaLockState(logResult: false);
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

        // Keep this method name because Mod.cs already calls it.
        public void RestoreOwnedChangesForDispose()
        {
            RestoreVanillaLockState(logResult: true);
        }

        private void ReconcileNow(bool unlock, string reason)
        {
            CompleteDependency();

            using NativeArray<Entity> signatures =
                m_SignatureQuery.ToEntityArray(Allocator.Temp);

            ComponentLookup<Locked> lockedLookup =
                SystemAPI.GetComponentLookup<Locked>(isReadOnly: false);

            BufferLookup<UnlockRequirement> requirementLookup =
                SystemAPI.GetBufferLookup<UnlockRequirement>(isReadOnly: true);

            int lockedBefore =
                CountLocked(signatures, ref lockedLookup);

            int changed = 0;
            int vanillaLocked = 0;
            int vanillaAvailable = 0;

            // Default: hide this mod's mass-unlock popups.
            // Vanilla progression notifications are never changed.
            bool showBulk = unlock &&
                !(Mod.Setting?.HideBulkUnlockNotifications ?? true);
            SignatureBuildingUISystem signatureUi = showBulk
                ? World.GetExistingSystemManaged<SignatureBuildingUISystem>()
                : null;
            int popupsQueued = 0;

            for (int i = 0; i < signatures.Length; i++)
            {
                Entity entity = signatures[i];

                bool currentlyLocked =
                    lockedLookup.IsComponentEnabled(entity);

                bool shouldBeLocked;

                if (unlock)
                {
                    shouldBeLocked = false;
                }
                else
                {
                    shouldBeLocked =
                        ShouldBeLockedByVanilla(
                            entity,
                            ref lockedLookup,
                            ref requirementLookup);

                    if (shouldBeLocked)
                        vanillaLocked++;
                    else
                        vanillaAvailable++;
                }

                if (currentlyLocked == shouldBeLocked)
                    continue;

                lockedLookup.SetComponentEnabled(
                    entity,
                    shouldBeLocked);

                changed++;

                NotifyToolbar(entity);

                if (showBulk && signatureUi != null &&
                    EntityManager.HasComponent<UIObjectData>(entity))
                {
                    signatureUi.AddUnlockedSignature(entity);
                    popupsQueued++;
                }
            }

            int lockedAfter =
                CountLocked(signatures, ref lockedLookup);

            LogUtils.Info(
                $"{Mod.ModTag} Signature unlock reconcile ({reason}): " +
                $"Unlock={(unlock ? "ON" : "OFF")} | " +
                $"SignaturePrefabs={signatures.Length} | " +
                $"LockedBefore={lockedBefore} | " +
                $"Changed={changed} | " +
                $"VanillaLocked={vanillaLocked} | " +
                $"VanillaAvailable={vanillaAvailable} | " +
                $"LockedAfter={lockedAfter} | " +
                $"BulkPopupsQueued={popupsQueued}.");
        }

        private void RestoreVanillaLockState(bool logResult)
        {
            CompleteDependency();

            using NativeArray<Entity> signatures =
                m_SignatureQuery.ToEntityArray(Allocator.Temp);

            ComponentLookup<Locked> lockedLookup =
                SystemAPI.GetComponentLookup<Locked>(isReadOnly: false);

            BufferLookup<UnlockRequirement> requirementLookup =
                SystemAPI.GetBufferLookup<UnlockRequirement>(isReadOnly: true);

            int changed = 0;

            for (int i = 0; i < signatures.Length; i++)
            {
                Entity entity = signatures[i];

                bool shouldBeLocked =
                    ShouldBeLockedByVanilla(
                        entity,
                        ref lockedLookup,
                        ref requirementLookup);

                bool currentlyLocked =
                    lockedLookup.IsComponentEnabled(entity);

                if (currentlyLocked == shouldBeLocked)
                    continue;

                lockedLookup.SetComponentEnabled(
                    entity,
                    shouldBeLocked);

                changed++;

                NotifyToolbar(entity);
            }

            if (logResult)
            {
                LogUtils.Info(
                    $"{Mod.ModTag} Restored vanilla Signature lock state: " +
                    $"SignaturePrefabs={signatures.Length} | " +
                    $"Changed={changed}.");
            }
        }

        private static bool ShouldBeLockedByVanilla(
            Entity entity,
            ref ComponentLookup<Locked> lockedLookup,
            ref BufferLookup<UnlockRequirement> requirementLookup)
        {
            if (!requirementLookup.HasBuffer(entity))
                return false;

            DynamicBuffer<UnlockRequirement> requirements =
                requirementLookup[entity];

            if (requirements.Length == 0)
                return false;

            bool blockedRequireAll = false;
            bool hasLockedRequireAny = false;
            bool hasUnlockedRequireAny = false;

            for (int i = 0; i < requirements.Length; i++)
            {
                UnlockRequirement requirement =
                    requirements[i];

                bool requirementLocked =
                    lockedLookup.HasComponent(requirement.m_Prefab) &&
                    lockedLookup.IsComponentEnabled(requirement.m_Prefab);

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
            bool requirementsSatisfied =
                !blockedRequireAll &&
                (hasUnlockedRequireAny ||
                 !hasLockedRequireAny);

            return !requirementsSatisfied;
        }

        private static int CountLocked(
            NativeArray<Entity> signatures,
            ref ComponentLookup<Locked> lockedLookup)
        {
            int count = 0;

            for (int i = 0; i < signatures.Length; i++)
            {
                if (lockedLookup.IsComponentEnabled(signatures[i]))
                    count++;
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
