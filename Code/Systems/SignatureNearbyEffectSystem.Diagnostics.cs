// <copyright file="SignatureNearbyEffectSystem.Diagnostics.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignatureNearbyEffectSystem.Diagnostics.cs
// One-click nearby-effect diagnostic; always restores selected mode.

namespace UniqueBuildings
{
    using System;
    using CS2Shared.RiverMochi;
    using Game.Buildings;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Unity.Collections;
    using Unity.Entities;
    using Unity.Jobs;

    public sealed partial class SignatureNearbyEffectSystem
    {
        public void RunNearbyReport()
        {
            if (GameManager.instance?.gameMode.IsGame() != true)
            {
                LogUtils.Warn($"{Mod.ModTag} Load a city before running Nearby Report.");
                return;
            }

            NearbySignatureMode selected = Normalize(
                Mod.Setting?.NearbySignatureEffects ?? NearbySignatureMode.Vanilla);
            LogUtils.Info($"{Mod.ModTag} ===== NEARBY EFFECT REPORT START =====");
            LogUtils.Info($"{Mod.ModTag} Selected: {selected}; checking three modes and restoring.");
            try
            {
                TestMode(NearbySignatureMode.Vanilla);
                TestMode(NearbySignatureMode.FirstCopyOnly);
                TestMode(NearbySignatureMode.NoEffects);
            }
            catch (Exception ex)
            {
                LogUtils.Warn($"{Mod.ModTag} Nearby report failed: {ex.Message}", ex);
            }
            finally
            {
                try
                {
                    ReconcileNow(selected, "nearby report: restore selected mode");
                    LogEffectCounts(selected, "RESTORED");
                }
                catch (Exception ex)
                {
                    m_NeedsReconcile = true;
                    LogUtils.Warn($"{Mod.ModTag} Nearby restore failed: {ex.Message}", ex);
                }
                LogUtils.Info($"{Mod.ModTag} ===== NEARBY EFFECT REPORT END =====");
            }
        }

        private void TestMode(NearbySignatureMode mode)
        {
            ReconcileNow(mode, "nearby report test");
            LogEffectCounts(mode, "TEST");
        }

        private void LogEffectCounts(NearbySignatureMode mode, string phase)
        {
            using NativeArray<Entity> buildings =
                m_EligibleQuery.ToEntityArray(Allocator.Temp);
            var tree = m_LocalEffects.GetSearchTree(
                readOnly: true, out JobHandle dependencies);
            dependencies.Complete();

            using NativeList<LocalModifierData> modifiers =
                new(10, Allocator.Temp);
            int available = 0;
            int active = 0;
            foreach (Entity building in buildings)
            {
                Entity prefab =
                    EntityManager.GetComponentData<PrefabRef>(building).m_Prefab;
                FillModifiers(building, prefab, modifiers);
                for (int i = 0; i < modifiers.Length; i++)
                {
                    LocalModifierData modifier = modifiers[i];
                    available++;
                    if (tree.TryGet(
                        new LocalEffectSystem.EffectItem(building, modifier.m_Type),
                        out _))
                        active++;
                }
            }

            LogUtils.Info($"{Mod.ModTag} [{phase} {mode}] " +
                $"EligibleSignatureBuildings={buildings.Length} | " +
                $"NormalEffectEntries={available} | ActiveInSpatialTree={active}. " +
                "Abandoned providers are deliberately excluded from this test.");
        }
    }
}
