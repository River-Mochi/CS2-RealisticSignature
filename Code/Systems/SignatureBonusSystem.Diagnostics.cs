// <copyright file="SignatureBonusSystem.Diagnostics.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignatureBonusSystem.Diagnostics.cs
// One-click diagnostics of Signature city-wide bonus modes.

namespace UniqueBuildings
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Buildings;
    using Game.City;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Unity.Collections;
    using Unity.Entities;
    using Unity.Mathematics;

    public sealed partial class SignatureBonusSystem
    {
        public void ApplyFromOptions(SignatureBonusMode value)
        {
            SignatureBonusMode mode = NormalizeMode(value);
            if (GameManager.instance?.gameMode.IsGame() != true)
            {
                ScheduleReconcile(mode, "Options setting changed");
                return;
            }

            try
            {
                ReconcileNow(mode, "Options setting changed");
                m_RequestedMode = mode;
                m_ReconcileRequested = false;
                Enabled = false;
            }
            catch (Exception ex)
            {
                LogUtils.Warn($"{Mod.ModTag} Live bonus update failed: {ex.Message}", ex);
                ScheduleReconcile(mode, "Retry Options setting change");
            }
        }

        public void RunStatusReport()
        {
            if (GameManager.instance?.gameMode.IsGame() != true)
            {
                LogUtils.Warn($"{Mod.ModTag} Load a city before running the status report.");
                return;
            }

            SignatureBonusMode selected = NormalizeMode(
                Mod.Setting?.SignatureBonuses ?? SignatureBonusMode.FirstCopyOnly);
            StringBuilder report = new();
            report.AppendLine("===== CITY-WIDE STATUS (READ ONLY) =====");
            report.AppendLine($"Selected mode: {ModeLabel(selected)}.");
            LogSnapshot(selected, "CURRENT", report);
            report.AppendLine($"Report did not change any settings or bonuses.");
            report.AppendLine("===== END CITY-WIDE STATUS =====");
            LogUtils.Info($"{Mod.ModTag} {report.ToString().TrimEnd()}");
        }

        public void RunBonusReport()
        {
            if (GameManager.instance?.gameMode.IsGame() != true)
            {
                LogUtils.Warn($"{Mod.ModTag} Load a city before running the bonus report.");
                return;
            }

            SignatureBonusMode selected = NormalizeMode(
                Mod.Setting?.SignatureBonuses ?? SignatureBonusMode.FirstCopyOnly);
            float2[]? selectedModifiers = null;
            StringBuilder report = new();
            report.AppendLine("===== COMPARE CITY-WIDE BONUS MODES =====");
            report.AppendLine($"Selected: {ModeLabel(selected)}. Comparing 3 modes, then restoring.");
            try
            {
                float2[] vanilla = TestMode(SignatureBonusMode.VanillaStacking, report);
                float2[] first = TestMode(SignatureBonusMode.FirstCopyOnly, report);
                float2[] none = TestMode(SignatureBonusMode.NoBonuses, report);
                selectedModifiers = selected switch
                {
                    SignatureBonusMode.VanillaStacking => vanilla,
                    SignatureBonusMode.NoBonuses => none,
                    _ => first,
                };
                LogDifference("Vanilla vs First copy", vanilla, first, report);
                LogDifference("First copy vs No bonuses", first, none, report);
            }
            catch (Exception ex)
            {
                LogUtils.Warn($"{Mod.ModTag} Bonus report failed: {ex.Message}", ex);
            }
            finally
            {
                try
                {
                    report.AppendLine();
                    ReconcileNow(selected, "bonus report: restore selected mode", logResult: false);
                    float2[] restoredModifiers = LogSnapshot(selected, "RESTORED", report);
                    if (selectedModifiers != null)
                    {
                        report.AppendLine($"  Restoration check: " +
                            (Different(selectedModifiers, restoredModifiers)
                                ? "CHECK - city modifiers differ from selected mode."
                                : "PASS - selected mode and city modifiers restored."));
                    }
                    m_RequestedMode = selected;
                    m_ReconcileRequested = false;
                    Enabled = false;
                }
                catch (Exception ex)
                {
                    LogUtils.Warn($"{Mod.ModTag} Bonus report restore failed: {ex.Message}", ex);
                    ScheduleReconcile(selected, "Restore after report failure");
                }
                report.AppendLine("===== END CITY-WIDE COMPARISON =====");
                LogUtils.Info($"{Mod.ModTag} {report.ToString().TrimEnd()}");
            }
        }

        private float2[] TestMode(SignatureBonusMode mode, StringBuilder report)
        {
            report.AppendLine();
            ReconcileNow(mode, "bonus report test", logResult: false);
            return LogSnapshot(mode, "TEST", report);
        }

        private float2[] LogSnapshot(SignatureBonusMode mode, string phase, StringBuilder report)
        {
            using NativeArray<Entity> signatures =
                m_SignatureQuery.ToEntityArray(Allocator.Temp);
            Dictionary<Entity, int[]> byPrefab = new();
            int providers = 0;
            int active = 0;
            int local = 0;
            int attractiveness = 0;
            int tagged = 0;

            foreach (Entity entity in signatures)
            {
                Entity prefab = EntityManager.GetComponentData<PrefabRef>(entity).m_Prefab;
                if (!byPrefab.TryGetValue(prefab, out int[]? counts))
                    byPrefab.Add(prefab, counts = new int[3]);
                counts[0]++;
                bool suppressed = EntityManager.HasComponent<SignatureBonusSuppressed>(entity);
                if (suppressed) tagged++;
                if (EntityManager.HasComponent<LocalEffectProvider>(entity)) local++;
                if (EntityManager.HasComponent<AttractivenessProvider>(entity)) attractiveness++;
                if (!EntityManager.HasComponent<CityEffectProvider>(entity)) continue;
                providers++;
                counts[1]++;
                if (!suppressed) { active++; counts[2]++; }
            }

            int extraCopies = signatures.Length - byPrefab.Count;
            bool oneCityProviderPerType = true;
            foreach (int[] counts in byPrefab.Values)
            {
                if (counts[2] > 1)
                    oneCityProviderPerType = false;
            }

            bool correct = mode switch
            {
                SignatureBonusMode.VanillaStacking =>
                    tagged == 0 && active == providers,
                SignatureBonusMode.FirstCopyOnly =>
                    tagged == extraCopies && oneCityProviderPerType,
                SignatureBonusMode.NoBonuses =>
                    tagged == signatures.Length && active == 0,
                _ => false,
            };

            report.AppendLine($"  {phase}: {ModeLabel(mode)}");
            report.AppendLine($"    Buildings: {signatures.Length} placed | " +
                $"{byPrefab.Count} types | {extraCopies} extra copies");
            report.AppendLine($"    City-wide providers: {active} active / {providers} total | " +
                $"{providers - active} blocked");
            report.AppendLine($"    Rule check: {(correct ? "PASS" : "CHECK")} " +
                $"({tagged} buildings tagged for bonus suppression)");
            if (phase == "CURRENT")
                report.AppendLine($"    Nearby providers: {local} | " +
                    $"Attractiveness providers (untouched): {attractiveness}");

            // Show the duplicate list once, not again for every test mode.
            if (phase == "CURRENT")
            {
                PrefabSystem? prefabs = World.GetExistingSystemManaged<PrefabSystem>();
                foreach (KeyValuePair<Entity, int[]> pair in byPrefab)
                {
                    int[] counts = pair.Value;
                    if (counts[0] < 2)
                        continue;

                    string name = $"Prefab {pair.Key.Index}:{pair.Key.Version}";
                    if (prefabs != null &&
                        prefabs.TryGetPrefab<PrefabBase>(pair.Key, out PrefabBase prefab))
                    {
                        name = prefab.name;
                    }

                    report.AppendLine($"    Duplicate {name}: " +
                        $"{counts[0]} placed | {counts[2]}/{counts[1]} city-wide providers active");
                }
            }

            EntityQuery cityQuery = GetEntityQuery(ComponentType.ReadOnly<City>());
            using NativeArray<Entity> cities = cityQuery.ToEntityArray(Allocator.Temp);
            if (cities.Length != 1 || !EntityManager.HasBuffer<CityModifier>(cities[0]))
            {
                LogUtils.Warn($"{Mod.ModTag} [{phase} {mode}] No city modifier buffer available.");
                return Array.Empty<float2>();
            }

            DynamicBuffer<CityModifier> buffer =
                EntityManager.GetBuffer<CityModifier>(cities[0], isReadOnly: true);
            float2[] result = new float2[buffer.Length];
            for (int i = 0; i < buffer.Length; i++)
                result[i] = buffer[i].m_Delta;

            return result;
        }

        private static string ModeLabel(SignatureBonusMode mode)
        {
            return mode switch
            {
                SignatureBonusMode.VanillaStacking => "Vanilla stacking",
                SignatureBonusMode.FirstCopyOnly => "First copy only",
                SignatureBonusMode.NoBonuses => "No city-wide bonuses",
                _ => mode.ToString(),
            };
        }

        private static void LogDifference(string label, float2[] before, float2[] after, StringBuilder report)
        {
            int changed = 0;
            StringBuilder names = new();
            int size = Math.Max(before.Length, after.Length);
            for (int i = 0; i < size; i++)
            {
                float2 a = i < before.Length ? before[i] : default;
                float2 b = i < after.Length ? after[i] : default;
                if (Math.Abs(a.x - b.x) <= 0.0000001f &&
                    Math.Abs(a.y - b.y) <= 0.0000001f)
                    continue;

                if (changed < 8)
                {
                    if (names.Length > 0)
                        names.Append(", ");
                    names.Append((CityModifierType)i);
                }

                changed++;
            }

            string suffix = changed > 8 ? ", ..." : string.Empty;
            report.AppendLine($"  {label}: {changed} changed city modifier types" +
                (names.Length == 0 ? "." : $" ({names}{suffix})."));
        }

        private static bool Different(float2[] a, float2[] b)
        {
            int length = Math.Max(a.Length, b.Length);
            for (int i = 0; i < length; i++)
            {
                float2 x = i < a.Length ? a[i] : default;
                float2 y = i < b.Length ? b[i] : default;
                if (Math.Abs(x.x - y.x) > 0.0000001f ||
                    Math.Abs(x.y - y.y) > 0.0000001f) return true;
            }
            return false;
        }
    }
}
