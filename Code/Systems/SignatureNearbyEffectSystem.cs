// <copyright file="SignatureNearbyEffectSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignatureNearbyEffectSystem.cs
// Filters Signature and other Unique building local effects in vanilla's spatial tree.
// Never edits prefab data, LocalEffectProvider, or abandoned-building effects.

namespace UniqueBuildings
{
    using System;
    using System.Collections.Generic;
    using CS2Shared.RiverMochi;
    using Colossal.Collections;
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Objects;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Game.Simulation;
    using Game.Tools;
    using Unity.Collections;
    using Unity.Entities;
    using Unity.Jobs;

    public sealed partial class SignatureNearbyEffectSystem : GameSystemBase
    {
        private EntityQuery m_EligibleQuery;
        private EntityQuery m_ChangedQuery;
        private EntityQuery m_ChangedOtherUniqueQuery;
        private LocalEffectSystem m_LocalEffects = null!;
        private UpdateSystem m_UpdateSystem = null!;
        private NearbySignatureMode m_AppliedMode = NearbySignatureMode.Vanilla;
        private bool m_NeedsReconcile = true;

        protected override void OnCreate()
        {
            base.OnCreate();
            m_LocalEffects = World.GetOrCreateSystemManaged<LocalEffectSystem>();
            m_UpdateSystem = World.GetOrCreateSystemManaged<UpdateSystem>();

            // Never touch abandoned entities: vanilla has additional penalty effects.
            m_EligibleQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new ComponentType[]
                {
                    ComponentType.ReadOnly<LocalEffectProvider>(),
                    ComponentType.ReadOnly<PrefabRef>(),
                    ComponentType.ReadOnly<Transform>(),
                },
                None = new ComponentType[]
                {
                    ComponentType.ReadOnly<Abandoned>(),
                    ComponentType.ReadOnly<Deleted>(),
                    ComponentType.ReadOnly<Destroyed>(),
                    ComponentType.ReadOnly<Temp>(),
                },
            });

            m_ChangedQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new ComponentType[] { ComponentType.ReadOnly<Signature>() },
                Any = new ComponentType[]
                {
                    ComponentType.ReadOnly<Created>(),
                    ComponentType.ReadOnly<Updated>(),
                    ComponentType.ReadOnly<Deleted>(),
                },
                None = new ComponentType[] { ComponentType.ReadOnly<Temp>() },
            });

            m_ChangedOtherUniqueQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new ComponentType[]
                {
                    ComponentType.ReadOnly<Building>(),
                    ComponentType.ReadOnly<LocalEffectProvider>(),
                    ComponentType.ReadOnly<PrefabRef>(),
                },
                Any = new ComponentType[]
                {
                    ComponentType.ReadOnly<Created>(),
                    ComponentType.ReadOnly<Updated>(),
                    ComponentType.ReadOnly<Deleted>(),
                },
                None = new ComponentType[]
                {
                    ComponentType.ReadOnly<Signature>(),
                    ComponentType.ReadOnly<Temp>(),
                },
            });
        }

        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
            // Vanilla LocalEffectUpdateSystem rebuilds non-Signature
            // nearby effects every 256 simulation ticks.
            return phase == SystemUpdatePhase.GameSimulation ? 256 : 1;
        }

        protected override void OnGameLoaded(Colossal.Serialization.Entities.Context context)
        {
            base.OnGameLoaded(context);
            // Vanilla rebuilds the tree on each city load.
            m_AppliedMode = NearbySignatureMode.Vanilla;
            m_NeedsReconcile = true;
        }

        protected override void OnUpdate()
        {
            if (GameManager.instance?.gameMode.IsGame() != true)
                return;

            NearbySignatureMode mode = Normalize(
                Mod.Setting?.NearbySignatureEffects ?? NearbySignatureMode.Vanilla);

            if (mode == NearbySignatureMode.Vanilla &&
                m_AppliedMode == NearbySignatureMode.Vanilla)
            {
                // Default ON: do not touch vanilla spatial data at all.
                m_NeedsReconcile = false;
                return;
            }

            bool afterVanillaSimulation =
                m_UpdateSystem.currentPhase == SystemUpdatePhase.GameSimulation;

            // Non-Signature local effects can reappear when vanilla updates
            // building efficiency every 256 ticks, without an Updated tag.
            // Always reapply a non-Vanilla rule after that refresh.
            if (!afterVanillaSimulation &&
                !m_NeedsReconcile && mode == m_AppliedMode &&
                m_ChangedQuery.IsEmptyIgnoreFilter &&
                !HasChangedOtherUniqueProviders())
                return;

            m_NeedsReconcile = false;
            try
            {
                ReconcileNow(
                    mode,
                    afterVanillaSimulation ? "vanilla periodic effects" : "city update");
            }
            catch (Exception ex)
            {
                m_NeedsReconcile = true;
                LogUtils.Warn($"{Mod.ModTag} Nearby effects update failed: {ex.Message}", ex);
            }
        }

        public void ApplyFromOptions(NearbySignatureMode requested)
        {
            NearbySignatureMode mode = Normalize(requested);
            if (GameManager.instance?.gameMode.IsGame() != true)
            {
                m_NeedsReconcile = true;
                return;
            }
            try
            {
                ReconcileNow(mode, "Options setting changed");
                m_NeedsReconcile = false;
            }
            catch (Exception ex)
            {
                m_NeedsReconcile = true;
                LogUtils.Warn($"{Mod.ModTag} Nearby Options update failed: {ex.Message}", ex);
            }
        }

        public void RestoreForDispose()
        {
            if (m_AppliedMode != NearbySignatureMode.Vanilla &&
                GameManager.instance?.gameMode.IsGame() == true)
                ReconcileNow(NearbySignatureMode.Vanilla, "mod unload");
        }

        private static NearbySignatureMode Normalize(NearbySignatureMode mode)
        {
            return mode == NearbySignatureMode.FirstCopyOnly ||
                   mode == NearbySignatureMode.NoEffects
                ? mode : NearbySignatureMode.Vanilla;
        }

        private bool HasChangedOtherUniqueProviders()
        {
            if (m_ChangedOtherUniqueQuery.IsEmptyIgnoreFilter)
                return false;

            UniquePlacementSystem? placement =
                World.GetExistingSystemManaged<UniquePlacementSystem>();
            if (placement == null)
                return false;

            using NativeArray<Entity> candidates =
                m_ChangedOtherUniqueQuery.ToEntityArray(Allocator.Temp);

            foreach (Entity entity in candidates)
            {
                Entity prefab = EntityManager.GetComponentData<PrefabRef>(entity).m_Prefab;
                if (placement.IsKnownUniqueBuilding(prefab))
                    return true;
            }

            return false;
        }

        private List<Entity> GetEligibleUniqueBuildings()
        {
            using NativeArray<Entity> candidates =
                m_EligibleQuery.ToEntityArray(Allocator.Temp);

            List<Entity> result = new();
            UniquePlacementSystem? placement =
                World.GetExistingSystemManaged<UniquePlacementSystem>();

            foreach (Entity entity in candidates)
            {
                if (EntityManager.HasComponent<Signature>(entity))
                {
                    result.Add(entity);
                    continue;
                }

                Entity prefab = EntityManager.GetComponentData<PrefabRef>(entity).m_Prefab;
                if (placement != null && placement.IsKnownUniqueBuilding(prefab))
                    result.Add(entity);
            }

            return result;
        }

        private void ReconcileNow(
            NearbySignatureMode mode, string reason, bool logResult = true)
        {
            CompleteDependency();
            List<Entity> buildings = GetEligibleUniqueBuildings();

            // Deterministic winner per eligible Unique prefab; no serialized state.
            Dictionary<Entity, Entity> firstByPrefab = new();
            foreach (Entity building in buildings)
            {
                Entity prefab = EntityManager.GetComponentData<PrefabRef>(building).m_Prefab;
                if (!firstByPrefab.TryGetValue(prefab, out Entity first) ||
                    building.Index < first.Index ||
                    (building.Index == first.Index && building.Version < first.Version))
                    firstByPrefab[prefab] = building;
            }

            NativeQuadTree<LocalEffectSystem.EffectItem, LocalEffectSystem.EffectBounds> tree =
                m_LocalEffects.GetSearchTree(readOnly: false, out JobHandle dependencies);
            dependencies.Complete();

            int enabled = 0;
            int removed = 0;
            using NativeList<LocalModifierData> modifiers = new(10, Allocator.Temp);
            foreach (Entity building in buildings)
            {
                Entity prefab = EntityManager.GetComponentData<PrefabRef>(building).m_Prefab;
                bool keep = mode == NearbySignatureMode.Vanilla ||
                    (mode == NearbySignatureMode.FirstCopyOnly &&
                     firstByPrefab[prefab] == building);
                FillModifiers(building, prefab, modifiers);
                Transform transform = EntityManager.GetComponentData<Transform>(building);

                for (int i = 0; i < modifiers.Length; i++)
                {
                    LocalModifierData modifier = modifiers[i];
                    LocalEffectSystem.EffectItem item =
                        new(building, modifier.m_Type);

                    if (keep && LocalEffectSystem.GetEffectBounds(
                        transform, modifier, out LocalEffectSystem.EffectBounds bounds))
                    {
                        tree.AddOrUpdate(item, bounds);
                        enabled++;
                    }
                    else
                    {
                        if (tree.TryGet(item, out _))
                        {
                            tree.TryRemove(item);
                            removed++;
                        }
                    }
                }
            }

            m_AppliedMode = mode;
#if DEBUG
            if (logResult)
            {
                LogUtils.Info($"{Mod.ModTag} Nearby Signature reconcile ({reason}): " +
                    $"Mode={mode} | Eligible={buildings.Count} | " +
                    $"Types={firstByPrefab.Count} | ActiveEffects={enabled} | Removed={removed}.");
            }
#endif
        }

        private void FillModifiers(Entity building, Entity prefab,
            NativeList<LocalModifierData> modifiers)
        {
            if (EntityManager.HasBuffer<LocalModifierData>(prefab))
                LocalEffectSystem.InitializeTempList(modifiers,
                    EntityManager.GetBuffer<LocalModifierData>(prefab, true));
            else
                modifiers.Clear();

            if (!EntityManager.HasBuffer<InstalledUpgrade>(building))
                return;

            DynamicBuffer<InstalledUpgrade> upgrades =
                EntityManager.GetBuffer<InstalledUpgrade>(building, true);
            for (int i = 0; i < upgrades.Length; i++)
            {
                InstalledUpgrade upgrade = upgrades[i];
                Entity upgradeEntity = upgrade.m_Upgrade;
                if (!EntityManager.Exists(upgradeEntity) ||
                    !EntityManager.HasComponent<PrefabRef>(upgradeEntity))
                    continue;

                Entity upgradePrefab =
                    EntityManager.GetComponentData<PrefabRef>(upgradeEntity).m_Prefab;
                if (EntityManager.HasBuffer<LocalModifierData>(upgradePrefab))
                    LocalEffectSystem.AddToTempList(modifiers,
                        EntityManager.GetBuffer<LocalModifierData>(upgradePrefab, true),
                        BuildingUtils.CheckOption(upgrade, BuildingOption.Inactive));
            }
        }
    }
}
