// <copyright file="SignatureBonusSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignatureBonusSystem.cs
// Controls city-wide Signature bonuses while leaving nearby/local effects,
// attractiveness, and normal building behavior untouched.

namespace UniqueBuildings
{
    using System.Collections.Generic;
    using Colossal.Serialization.Entities;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Game.Tools;
    using Unity.Collections;
    using Unity.Entities;

    /// <summary>
    /// Runtime-only BUB marker for Signature buildings whose city-wide
    /// bonus must be ignored.
    ///
    /// Deliberately not serializable. Vanilla CityEffectProvider remains
    /// untouched so removing BUB restores normal game behavior.
    /// </summary>
    internal struct SignatureBonusSuppressed :
        IComponentData,
        IQueryTypeParameter
    {
    }

    public sealed partial class SignatureBonusSystem : GameSystemBase
    {
        private readonly Dictionary<Entity, Entity> m_FirstCopyByPrefab =
            new();

        private EntityQuery m_SignatureQuery;
        private EntityQuery m_SuppressedQuery;

        private bool m_ReconcileRequested;
        private SignatureBonusMode m_RequestedMode;
        private string m_RequestReason = string.Empty;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_SignatureQuery = GetEntityQuery(
                new EntityQueryDesc
                {
                    All = new ComponentType[]
                    {
                        ComponentType.ReadOnly<Signature>(),
                        ComponentType.ReadOnly<PrefabRef>(),
                    },
                    None = new ComponentType[]
                    {
                        ComponentType.ReadOnly<Deleted>(),
                        ComponentType.ReadOnly<Destroyed>(),
                        ComponentType.ReadOnly<Temp>(),
                    },
                });

            m_SuppressedQuery = GetEntityQuery(
                ComponentType.ReadOnly<SignatureBonusSuppressed>());

            Enabled = false;
        }

        protected override void OnGameLoaded(
            Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);

            m_FirstCopyByPrefab.Clear();

            ScheduleReconcile(
                Mod.Setting?.SignatureBonuses ??
                    SignatureBonusMode.FirstCopyOnly,
                "city load");
        }

        protected override void OnDestroy()
        {
            try
            {
                RestoreOwnedChangesForDispose(
                    logResult: false);
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

            if (gameManager == null ||
                !gameManager.gameMode.IsGame())
            {
                Enabled = false;
                return;
            }

            try
            {
                ReconcileNow(
                    NormalizeMode(m_RequestedMode),
                    m_RequestReason);
            }
            catch (System.Exception ex)
            {
                LogUtils.Warn(
                    $"{Mod.ModTag} Signature bonus reconcile failed: " +
                    $"{ex.GetType().Name}: {ex.Message}",
                    ex);
            }

            Enabled = false;
        }

        public void ScheduleReconcile(
            SignatureBonusMode mode,
            string reason)
        {
            m_RequestedMode = NormalizeMode(mode);
            m_RequestReason = reason ?? string.Empty;

            m_ReconcileRequested = true;
            Enabled = true;
        }

        public void RestoreOwnedChangesForDispose()
        {
            RestoreOwnedChangesForDispose(
                logResult: true);
        }

        private void ReconcileNow(
            SignatureBonusMode mode,
            string reason)
        {
            CompleteDependency();

            using NativeArray<Entity> signatures =
                m_SignatureQuery.ToEntityArray(
                    Allocator.Temp);

            Dictionary<Entity, List<Entity>> copiesByPrefab =
                BuildCopiesByPrefab(signatures);

            PruneFirstCopyMap(copiesByPrefab);

            if (mode == SignatureBonusMode.FirstCopyOnly)
                SelectFirstCopies(copiesByPrefab);

            int changed;

            if (mode == SignatureBonusMode.VanillaStacking)
            {
                changed =
                    RemoveAllSuppressionTags();
            }
            else
            {
                changed =
                    ApplySuppressionMode(
                        mode,
                        copiesByPrefab);
            }

            int suppressed =
                CountSuppressed(signatures);

            RefreshCityWideEffects();

            SignatureScanState.Clear();

            LogUtils.Info(
                $"{Mod.ModTag} City-wide Signature bonus reconcile " +
                $"({reason}): " +
                $"Mode={mode} | " +
                $"Signatures={signatures.Length} | " +
                $"Types={copiesByPrefab.Count} | " +
                $"Suppressed={suppressed} | " +
                $"Changed={changed}.");
        }

        private Dictionary<Entity, List<Entity>>
            BuildCopiesByPrefab(
                NativeArray<Entity> signatures)
        {
            Dictionary<Entity, List<Entity>> result =
                new();

            for (int i = 0; i < signatures.Length; i++)
            {
                Entity entity = signatures[i];

                if (!EntityManager.Exists(entity) ||
                    !EntityManager.HasComponent<PrefabRef>(
                        entity))
                {
                    continue;
                }

                Entity prefab =
                    EntityManager
                        .GetComponentData<PrefabRef>(
                            entity)
                        .m_Prefab;

                if (!result.TryGetValue(
                        prefab,
                        out List<Entity>? copies))
                {
                    copies = new List<Entity>();

                    result.Add(
                        prefab,
                        copies);
                }

                copies.Add(entity);
            }

            return result;
        }

        private void PruneFirstCopyMap(
            Dictionary<Entity, List<Entity>>
                copiesByPrefab)
        {
            if (m_FirstCopyByPrefab.Count == 0)
                return;

            List<Entity> stalePrefabs = new();

            foreach (
                KeyValuePair<Entity, Entity> pair
                in m_FirstCopyByPrefab)
            {
                if (!copiesByPrefab.TryGetValue(
                        pair.Key,
                        out List<Entity>? copies) ||
                    !copies.Contains(pair.Value))
                {
                    stalePrefabs.Add(pair.Key);
                }
            }

            for (int i = 0;
                 i < stalePrefabs.Count;
                 i++)
            {
                m_FirstCopyByPrefab.Remove(
                    stalePrefabs[i]);
            }
        }

        private void SelectFirstCopies(
            Dictionary<Entity, List<Entity>>
                copiesByPrefab)
        {
            foreach (
                KeyValuePair<Entity, List<Entity>> pair
                in copiesByPrefab)
            {
                if (m_FirstCopyByPrefab.TryGetValue(
                        pair.Key,
                        out Entity existingWinner) &&
                    pair.Value.Contains(existingWinner))
                {
                    continue;
                }

                if (pair.Value.Count == 0)
                    continue;

                Entity winner = pair.Value[0];

                for (int i = 1;
                     i < pair.Value.Count;
                     i++)
                {
                    Entity candidate = pair.Value[i];

                    if (ComesBefore(
                            candidate,
                            winner))
                    {
                        winner = candidate;
                    }
                }

                m_FirstCopyByPrefab[pair.Key] =
                    winner;
            }
        }

        private int ApplySuppressionMode(
            SignatureBonusMode mode,
            Dictionary<Entity, List<Entity>>
                copiesByPrefab)
        {
            int changed = 0;

            foreach (
                KeyValuePair<Entity, List<Entity>> pair
                in copiesByPrefab)
            {
                Entity winner = Entity.Null;

                if (mode ==
                    SignatureBonusMode.FirstCopyOnly)
                {
                    m_FirstCopyByPrefab.TryGetValue(
                        pair.Key,
                        out winner);
                }

                for (int i = 0;
                     i < pair.Value.Count;
                     i++)
                {
                    Entity entity = pair.Value[i];

                    bool shouldSuppress =
                        mode ==
                            SignatureBonusMode.NoBonuses ||
                        (mode ==
                            SignatureBonusMode.FirstCopyOnly &&
                         entity != winner);

                    bool isSuppressed =
                        EntityManager.HasComponent<
                            SignatureBonusSuppressed>(
                                entity);

                    if (shouldSuppress ==
                        isSuppressed)
                    {
                        continue;
                    }

                    if (shouldSuppress)
                    {
                        EntityManager.AddComponent<
                            SignatureBonusSuppressed>(
                                entity);
                    }
                    else
                    {
                        EntityManager.RemoveComponent<
                            SignatureBonusSuppressed>(
                                entity);
                    }

                    changed++;
                }
            }

            return changed;
        }

        private int RemoveAllSuppressionTags()
        {
            using NativeArray<Entity> suppressed =
                m_SuppressedQuery.ToEntityArray(
                    Allocator.Temp);

            int changed = 0;

            for (int i = 0;
                 i < suppressed.Length;
                 i++)
            {
                Entity entity = suppressed[i];

                if (!EntityManager.Exists(entity) ||
                    !EntityManager.HasComponent<
                        SignatureBonusSuppressed>(
                            entity))
                {
                    continue;
                }

                EntityManager.RemoveComponent<
                    SignatureBonusSuppressed>(
                        entity);

                changed++;
            }

            return changed;
        }

        private int CountSuppressed(
            NativeArray<Entity> signatures)
        {
            int count = 0;

            for (int i = 0;
                 i < signatures.Length;
                 i++)
            {
                Entity entity = signatures[i];

                if (EntityManager.Exists(entity) &&
                    EntityManager.HasComponent<
                        SignatureBonusSuppressed>(
                            entity))
                {
                    count++;
                }
            }

            return count;
        }

        private void RefreshCityWideEffects()
        {
            SignatureCityModifierFilterSystem?
                filterSystem =
                    World.GetExistingSystemManaged<
                        SignatureCityModifierFilterSystem>();

            filterSystem?.RefreshNow();
        }

        private void RestoreOwnedChangesForDispose(
            bool logResult)
        {
            CompleteDependency();

            int changed =
                RemoveAllSuppressionTags();

            RefreshCityWideEffects();

            m_FirstCopyByPrefab.Clear();

            SignatureScanState.Clear();

            if (logResult)
            {
                LogUtils.Info(
                    $"{Mod.ModTag} Restored vanilla city-wide " +
                    $"Signature bonuses: " +
                    $"RemovedSuppressionTags={changed}.");
            }
        }

        private static bool ComesBefore(
            Entity candidate,
            Entity current)
        {
            if (candidate.Index != current.Index)
            {
                return candidate.Index <
                       current.Index;
            }

            return candidate.Version <
                   current.Version;
        }

        private static SignatureBonusMode NormalizeMode(
            SignatureBonusMode mode)
        {
            switch (mode)
            {
                case SignatureBonusMode.FirstCopyOnly:
                case SignatureBonusMode.NoBonuses:
                case SignatureBonusMode.VanillaStacking:
                    return mode;

                default:
                    return SignatureBonusMode.FirstCopyOnly;
            }
        }
    }
}
