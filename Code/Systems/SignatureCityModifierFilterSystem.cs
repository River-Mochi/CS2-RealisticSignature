// <copyright file="SignatureCityModifierFilterSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignatureCityModifierFilterSystem.cs
// Rebuilds derived city modifiers while excluding BUB-suppressed
// Signature providers.

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

            m_CityQuery = GetEntityQuery(
                ComponentType.ReadOnly<Game.City.City>());

            // Used only after ModificationBarrier4 so city policy
            // changes are handled immediately without watching our
            // own CityModifier writes.
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
            SignatureBonusMode mode =
                Mod.Setting?.SignatureBonuses ??
                SignatureBonusMode.FirstCopyOnly;

            if (mode ==
                SignatureBonusMode.VanillaStacking)
            {
                return;
            }

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

        public void RefreshNow()
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
                // BUB only changes which providers are included.
                m_RefreshData.RefreshCityModifiers(
                    modifiers,
                    policies,
                    effectProviderChunks,
                    tempModifierList);
            }
            finally
            {
                effectProviderChunks.Dispose();
            }
        }
    }
}
