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
    using System.Text;
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
            StringBuilder report = new();
            report.AppendLine("===== NEARBY STATUS (READ ONLY) =====");
            report.AppendLine($"Selected: {ModeLabel(selected)}.");
            LogEffectCounts(selected, "CURRENT", report);
            report.AppendLine($"Abandoned-building effects are unchanged.");
            report.AppendLine($"Report did not change any settings or effects.");
            report.AppendLine("===== END NEARBY STATUS =====");
            LogUtils.Info($"{Mod.ModTag} {report.ToString().TrimEnd()}");
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
            StringBuilder report = new();
            report.AppendLine("===== COMPARE NEARBY EFFECT MODES =====");
            report.AppendLine($"Selected: {ModeLabel(selected)}. Comparing 3 modes, then restoring.");
            try
            {
                TestMode(NearbySignatureMode.Vanilla, report);
                TestMode(NearbySignatureMode.FirstCopyOnly, report);
                TestMode(NearbySignatureMode.NoEffects, report);
            }
            catch (Exception ex)
            {
                LogUtils.Warn($"{Mod.ModTag} Nearby report failed: {ex.Message}", ex);
            }
            finally
            {
                try
                {
                    report.AppendLine();
                    ReconcileNow(selected, "nearby report: restore selected mode", logResult: false);
                    LogEffectCounts(selected, "RESTORED", report);
                    report.AppendLine($"Selected nearby mode restored.");
                }
                catch (Exception ex)
                {
                    m_NeedsReconcile = true;
                    LogUtils.Warn($"{Mod.ModTag} Nearby restore failed: {ex.Message}", ex);
                }
                report.AppendLine("===== END NEARBY COMPARISON =====");
                LogUtils.Info($"{Mod.ModTag} {report.ToString().TrimEnd()}");
            }
        }

        private void TestMode(NearbySignatureMode mode, StringBuilder report)
        {
            report.AppendLine();
            ReconcileNow(mode, "nearby report test", logResult: false);
            LogEffectCounts(mode, "TEST", report);
        }

        private void LogEffectCounts(NearbySignatureMode mode, string phase, StringBuilder report)
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

            report.AppendLine($"  {phase}: {ModeLabel(mode)}");
            report.AppendLine($"    Signature buildings: {buildings.Length} | " +
                $"Types: {firstByPrefab.Count}");
            report.AppendLine($"    Nearby effects: {active}/{available} active | " +
                $"{available - active} disabled");
            report.AppendLine($"    Rule check: " +
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
