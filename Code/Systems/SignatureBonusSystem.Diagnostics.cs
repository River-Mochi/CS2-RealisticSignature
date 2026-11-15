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
            LogUtils.Info($"{Mod.ModTag} ===== CITY-WIDE BONUS STATUS START =====");
            LogUtils.Info($"{Mod.ModTag} Current selected mode: {selected}.");
            LogSnapshot(selected, "STATUS");
            LogUtils.Info($"{Mod.ModTag} ===== CITY-WIDE BONUS STATUS END =====");
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
            LogUtils.Info($"{Mod.ModTag} ===== CITY-WIDE BONUS REPORT START =====");
            LogUtils.Info($"{Mod.ModTag} Selected setting: {selected}. Testing three modes, then restoring it.");
            try
            {
                float2[] vanilla = TestMode(SignatureBonusMode.VanillaStacking);
                float2[] first = TestMode(SignatureBonusMode.FirstCopyOnly);
                float2[] none = TestMode(SignatureBonusMode.NoBonuses);
                LogUtils.Info($"{Mod.ModTag} Actual city modifier comparison: " +
                    $"Vanilla vs First={(Different(vanilla, first) ? "DIFFERENT" : "SAME")}, " +
                    $"First vs None={(Different(first, none) ? "DIFFERENT" : "SAME")}, " +
                    $"Vanilla vs None={(Different(vanilla, none) ? "DIFFERENT" : "SAME")}.");
            }
            catch (Exception ex)
            {
                LogUtils.Warn($"{Mod.ModTag} Bonus report failed: {ex.Message}", ex);
            }
            finally
            {
                try
                {
                    ReconcileNow(selected, "bonus report: restore selected mode");
                    LogSnapshot(selected, "RESTORED");
                    m_RequestedMode = selected;
                    m_ReconcileRequested = false;
                    Enabled = false;
                }
                catch (Exception ex)
                {
                    LogUtils.Warn($"{Mod.ModTag} Bonus report restore failed: {ex.Message}", ex);
                    ScheduleReconcile(selected, "Restore after report failure");
                }
                LogUtils.Info($"{Mod.ModTag} ===== CITY-WIDE BONUS REPORT END =====");
            }
        }

        private float2[] TestMode(SignatureBonusMode mode)
        {
            ReconcileNow(mode, "bonus report test");
            return LogSnapshot(mode, "TEST");
        }

        private float2[] LogSnapshot(SignatureBonusMode mode, string phase)
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

            LogUtils.Info($"{Mod.ModTag} [{phase} {mode}] " +
                $"Signatures={signatures.Length}, Types={byPrefab.Count}, " +
                $"ExtraCopies={signatures.Length - byPrefab.Count}, TaggedCopies={tagged}, " +
                $"CityProviders={providers}, ActiveCityProviders={active}, " +
                $"NearbyProviders={local}, AttractivenessProviders={attractiveness}.");

            PrefabSystem? prefabs = World.GetExistingSystemManaged<PrefabSystem>();
            foreach (KeyValuePair<Entity, int[]> pair in byPrefab)
            {
                int[] counts = pair.Value;
                if (counts[0] < 2) continue;
                string name = $"Prefab {pair.Key.Index}:{pair.Key.Version}";
                if (prefabs != null && prefabs.TryGetPrefab<PrefabBase>(pair.Key, out PrefabBase prefab))
                    name = prefab.name;
                LogUtils.Info($"{Mod.ModTag} [{phase} {mode}] DUPLICATE {name}: " +
                    $"Placed={counts[0]}, CityProviders={counts[1]}, " +
                    $"ActiveCityProviders={counts[2]}.");
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
            StringBuilder values = new();
            for (int i = 0; i < buffer.Length; i++)
            {
                result[i] = buffer[i].m_Delta;
                float2 delta = result[i];
                if (Math.Abs(delta.x) < 0.0000001f && Math.Abs(delta.y) < 0.0000001f)
                    continue;
                if (values.Length > 0) values.Append("; ");
                values.Append($"{(CityModifierType)i}=({delta.x:0.######},{delta.y:0.######})");
            }
            LogUtils.Info($"{Mod.ModTag} [{phase} {mode}] ACTUAL CITY MODIFIERS: " +
                (values.Length == 0 ? "none" : values.ToString()));
            return result;
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
