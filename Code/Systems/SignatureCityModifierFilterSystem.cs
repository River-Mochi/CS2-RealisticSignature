// <copyright file="SignatureCityModifierFilterSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignatureCityModifierFilterSystem.cs
// Rebuilds derived city modifiers while excluding suppressed Signature
// providers, with optional independent city-wide Attractiveness filtering.

namespace UniqueBuildings
{
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Buildings;
    using Game.City;
    using Game.Common;
    using Game.Policies;
    using Game.Prefabs;
    using Game.Simulation;
    using Game.Tools;
    using Unity.Collections;
    using Unity.Entities;
    using Unity.Jobs;

    public sealed partial class SignatureCityModifierFilterSystem :
        GameSystemBase
    {
        private EntityQuery m_EffectProviderQuery;
        private EntityQuery m_SuppressedCityProviderQuery;
        private EntityQuery m_AttractivenessProviderQuery;
        private EntityQuery m_AttractivenessSuppressedProviderQuery;
        private EntityQuery m_CityQuery;
        private EntityQuery m_UpdatedCityQuery;

        private UpdateSystem m_UpdateSystem = null!;

        private CityModifierUpdateSystem.CityModifierRefreshData
            m_RefreshData;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_UpdateSystem =
                World.GetOrCreateSystemManaged<UpdateSystem>();

            m_EffectProviderQuery = GetEntityQuery(
                new EntityQueryDesc
                {
                    All = new ComponentType[]
                    {
                        ComponentType.ReadOnly<
                            CityEffectProvider>(),
                    },
                    None = new ComponentType[]
                    {
                        ComponentType.ReadOnly<Deleted>(),
                        ComponentType.ReadOnly<Destroyed>(),
                        ComponentType.ReadOnly<Temp>(),
                        ComponentType.ReadOnly<
                            SignatureBonusSuppressed>(),
                    },
                });

            // No suppressed city provider means the vanilla modifier result
            // is already correct. Skip redundant city-wide rebuild.
            m_SuppressedCityProviderQuery = GetEntityQuery(
                new EntityQueryDesc
                {
                    All = new ComponentType[]
                    {
                        ComponentType.ReadOnly<CityEffectProvider>(),
                        ComponentType.ReadOnly<SignatureBonusSuppressed>(),
                    },
                    None = new ComponentType[]
                    {
                        ComponentType.ReadOnly<Deleted>(),
                        ComponentType.ReadOnly<Destroyed>(),
                        ComponentType.ReadOnly<Temp>(),
                    },
                });

            m_AttractivenessProviderQuery = GetEntityQuery(
                new EntityQueryDesc
                {
                    All = new ComponentType[] { ComponentType.ReadOnly<CityEffectProvider>() },
                    None = new ComponentType[]
                    {
                        ComponentType.ReadOnly<Deleted>(),
                        ComponentType.ReadOnly<Destroyed>(),
                        ComponentType.ReadOnly<Temp>(),
                        ComponentType.ReadOnly<SignatureAttractivenessSuppressed>(),
                    },
                });
            m_AttractivenessSuppressedProviderQuery = GetEntityQuery(
                new EntityQueryDesc
                {
                    All = new ComponentType[]
                    {
                        ComponentType.ReadOnly<CityEffectProvider>(),
                        ComponentType.ReadOnly<SignatureAttractivenessSuppressed>(),
                    },
                    None = new ComponentType[]
                    {
                        ComponentType.ReadOnly<Deleted>(),
                        ComponentType.ReadOnly<Destroyed>(),
                        ComponentType.ReadOnly<Temp>(),
                    },
                });

            m_CityQuery = GetEntityQuery(
                ComponentType.ReadOnly<Game.City.City>());

            // Used only after ModificationBarrier4 so city policy changes are handled immediately
            // w/out watching our own CityModifier writes.
            m_UpdatedCityQuery = GetEntityQuery(
                ComponentType.ReadOnly<Game.City.City>(),
                ComponentType.ReadOnly<Updated>());

            m_RefreshData =
                new CityModifierUpdateSystem
                    .CityModifierRefreshData(this);
        }

        public override int GetUpdateInterval(
            SystemUpdatePhase phase)
        {
            // Match vanilla CityModifierUpdateSystem exactly.
            if (phase == SystemUpdatePhase.GameSimulation)
                return 256;

            return 1;
        }

        protected override void OnUpdate()
        {
            if (m_SuppressedCityProviderQuery.IsEmptyIgnoreFilter &&
                m_AttractivenessSuppressedProviderQuery.IsEmptyIgnoreFilter)
                return;

            // In Modification4 we only need to correct a city-wide
            // modifier rebuild when the city was actually updated.
            //
            // In GameSimulation this system has the same 256-tick
            // interval as vanilla CityModifierUpdateSystem and runs
            // immediately after it, so always correct that rebuild.
            if (m_UpdateSystem.currentPhase ==
                    SystemUpdatePhase.Modification4 &&
                m_UpdatedCityQuery.IsEmptyIgnoreFilter)
            {
                return;
            }

            try
            {
                RefreshNow();
            }
            catch (System.Exception ex)
            {
                LogUtils.Warn(
                    $"{Mod.ModTag} City-wide Signature bonus " +
                    $"filter failed: " +
                    $"{ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        public void RefreshNow(
            SignatureBonusMode? cityModeOverride = null,
            SignatureBonusMode? attractivenessModeOverride = null)
        {
            if (m_CityQuery.CalculateEntityCount() != 1)
                return;

            CompleteDependency();

            Entity cityEntity =
                m_CityQuery.GetSingletonEntity();

            if (!EntityManager.HasBuffer<CityModifier>(
                    cityEntity) ||
                !EntityManager.HasBuffer<Policy>(
                    cityEntity))
            {
                return;
            }

            SignatureBonusMode cityMode = cityModeOverride ??
                Mod.Setting?.SignatureBonuses ?? SignatureBonusMode.FirstCopyOnly;
            SignatureBonusMode attractivenessMode = attractivenessModeOverride ??
                SignatureBonusSystem.GetEffectiveAttractivenessMode(cityMode);

            m_RefreshData.Update(this);

            NativeList<ArchetypeChunk>
                effectProviderChunks =
                    m_EffectProviderQuery
                        .ToArchetypeChunkListAsync(
                            Allocator.TempJob,
                            out JobHandle chunkJob);

            chunkJob.Complete();

            try
            {
                DynamicBuffer<CityModifier> modifiers =
                    EntityManager.GetBuffer<CityModifier>(
                        cityEntity);

                DynamicBuffer<Policy> policies =
                    EntityManager.GetBuffer<Policy>(
                        cityEntity,
                        isReadOnly: true);

                using NativeList<CityModifierData>
                    tempModifierList =
                        new(10, Allocator.Temp);

                // Use the game's own modifier aggregation math.
                // This mod only changes which providers are included.
                m_RefreshData.RefreshCityModifiers(
                    modifiers,
                    policies,
                    effectProviderChunks,
                    tempModifierList);

                if (attractivenessMode != cityMode)
                    ReplaceAttractivenessModifier(modifiers, policies);
            }
            finally
            {
                effectProviderChunks.Dispose();
            }
        }

        private void ReplaceAttractivenessModifier(
            DynamicBuffer<CityModifier> modifiers,
            DynamicBuffer<Policy> policies)
        {
            using NativeArray<CityModifier> original =
                new(modifiers.Length, Allocator.Temp);
            for (int i = 0; i < original.Length; i++)
                original[i] = modifiers[i];

            NativeList<ArchetypeChunk> chunks =
                m_AttractivenessProviderQuery.ToArchetypeChunkListAsync(
                    Allocator.TempJob, out JobHandle job);
            job.Complete();

            CityModifier attractiveness = default;
            int index = (int)CityModifierType.Attractiveness;
            bool found = false;
            try
            {
                using NativeList<CityModifierData> temp = new(10, Allocator.Temp);
                m_RefreshData.RefreshCityModifiers(modifiers, policies, chunks, temp);
                found = index < modifiers.Length;
                if (found)
                    attractiveness = modifiers[index];
            }
            finally
            {
                // Restore every unrelated city modifier, including after an exception.
                modifiers.ResizeUninitialized(original.Length);
                for (int i = 0; i < original.Length; i++)
                    modifiers[i] = original[i];
                chunks.Dispose();
            }

            if (found && index >= modifiers.Length)
            {
                int oldLength = modifiers.Length;
                modifiers.ResizeUninitialized(index + 1);
                for (int i = oldLength; i < modifiers.Length; i++)
                    modifiers[i] = default;
            }
            if (index < modifiers.Length)
                modifiers[index] = attractiveness;
        }
    }
}
