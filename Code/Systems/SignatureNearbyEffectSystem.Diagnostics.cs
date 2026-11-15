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
    using System.Collections.Generic;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Buildings;
    using Game.Objects;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Unity.Collections;
    using Unity.Entities;
    using Unity.Jobs;

    public sealed partial class SignatureNearbyEffectSystem
    {
        public void RunStatusReport()
        {
            if (GameManager.instance?.gameMode.IsGame() != true)
            {
                LogUtils.Warn($"{Mod.ModTag} Load a city before running the nearby status report.");
                return;
            }

            NearbySignatureMode selected = Normalize(
                Mod.Setting?.NearbySignatureEffects ?? NearbySignatureMode.Vanilla);
            LogUtils.Info($"{Mod.ModTag} ===== NEARBY STATUS (READ ONLY) =====");
            LogUtils.Info($"{Mod.ModTag} Selected: {ModeLabel(selected)}.");
            LogEffectCounts(selected, "CURRENT");
            LogUtils.Info($"{Mod.ModTag} Abandoned-building effects are unchanged.");
            LogUtils.Info($"{Mod.ModTag} Report did not change any settings or effects.");
            LogUtils.Info($"{Mod.ModTag} ===== END NEARBY STATUS =====");
        }

        public void RunNearbyReport()
        {
            if (GameManager.instance?.gameMode.IsGame() != true)
            {
                LogUtils.Warn($"{Mod.ModTag} Load a city before running Nearby Report.");
                return;
            }

            NearbySignatureMode selected = Normalize(
                Mod.Setting?.NearbySignatureEffects ?? NearbySignatureMode.Vanilla);
            LogUtils.Info($"{Mod.ModTag} ===== COMPARE NEARBY EFFECT MODES =====");
            LogUtils.Info($"{Mod.ModTag} Selected: {ModeLabel(selected)}. Comparing 3 modes, then restoring.");
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
                    ReconcileNow(selected, "nearby report: restore selected mode", logResult: false);
                    LogEffectCounts(selected, "RESTORED");
                    LogUtils.Info($"{Mod.ModTag} Selected nearby mode restored.");
                }
                catch (Exception ex)
                {
                    m_NeedsReconcile = true;
                    LogUtils.Warn($"{Mod.ModTag} Nearby restore failed: {ex.Message}", ex);
                }
                LogUtils.Info($"{Mod.ModTag} ===== END NEARBY COMPARISON =====");
            }
        }

        private void TestMode(NearbySignatureMode mode)
        {
            ReconcileNow(mode, "nearby report test", logResult: false);
            LogEffectCounts(mode, "TEST");
        }

        private void LogEffectCounts(NearbySignatureMode mode, string phase)
        {
            using NativeArray<Entity> buildings =
                m_EligibleQuery.ToEntityArray(Allocator.Temp);

            // Use the same first-copy rule as the actual nearby-effect system.
            Dictionary<Entity, Entity> firstByPrefab = new();
            foreach (Entity building in buildings)
            {
                Entity prefab =
                    EntityManager.GetComponentData<PrefabRef>(building).m_Prefab;

                if (!firstByPrefab.TryGetValue(prefab, out Entity first) ||
                    building.Index < first.Index ||
                    (building.Index == first.Index && building.Version < first.Version))
                {
                    firstByPrefab[prefab] = building;
                }
            }

            var tree = m_LocalEffects.GetSearchTree(
                readOnly: true, out JobHandle dependencies);
            dependencies.Complete();

            using NativeList<LocalModifierData> modifiers =
                new(10, Allocator.Temp);

            int available = 0;
            int active = 0;
            int expected = 0;

            foreach (Entity building in buildings)
            {
                Entity prefab =
                    EntityManager.GetComponentData<PrefabRef>(building).m_Prefab;

                bool keep = mode == NearbySignatureMode.Vanilla ||
                    (mode == NearbySignatureMode.FirstCopyOnly &&
                     firstByPrefab[prefab] == building);

                FillModifiers(building, prefab, modifiers);
                Transform transform =
                    EntityManager.GetComponentData<Transform>(building);

                for (int i = 0; i < modifiers.Length; i++)
                {
                    LocalModifierData modifier = modifiers[i];
                    available++;

                    if (keep && LocalEffectSystem.GetEffectBounds(
                        transform, modifier, out _))
                    {
                        expected++;
                    }

                    if (tree.TryGet(
                        new LocalEffectSystem.EffectItem(building, modifier.m_Type),
                        out _))
                    {
                        active++;
                    }
                }
            }

            LogUtils.Info($"{Mod.ModTag}   {phase}: {ModeLabel(mode)}");
            LogUtils.Info($"{Mod.ModTag}     Signature buildings: {buildings.Length} | " +
                $"Types: {firstByPrefab.Count}");
            LogUtils.Info($"{Mod.ModTag}     Nearby effects: {active}/{available} active | " +
                $"{available - active} disabled");
            LogUtils.Info($"{Mod.ModTag}     Rule check: " +
                (active == expected ? "PASS" : $"CHECK - expected {expected} active"));
        }

        private static string ModeLabel(NearbySignatureMode mode)
        {
            return mode switch
            {
                NearbySignatureMode.Vanilla => "Vanilla nearby effects",
                NearbySignatureMode.FirstCopyOnly => "First copy only",
                NearbySignatureMode.NoEffects => "No nearby effects",
                _ => mode.ToString(),
            };
        }
    }
}
