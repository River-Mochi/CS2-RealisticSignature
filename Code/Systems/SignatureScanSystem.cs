// <copyright file="SignatureScanSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignatureScanSystem.cs
// Cached Status scan refreshed automatically when Options reads it.

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
    using Game.Simulation;
    using Game.Tools;
    using Unity.Collections;
    using Unity.Entities;

    public sealed partial class SignatureScanSystem : GameSystemBase
    {
        private EntityQuery m_SignatureQuery;
        private EntityQuery m_BonusProviderQuery;
        private EntityQuery m_AllBonusProviderQuery;

        private SimulationSystem? m_SimulationSystem;

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
                        ComponentType.ReadOnly<Game.Common.Deleted>(),
                        ComponentType.ReadOnly<Game.Common.Destroyed>(),
                        ComponentType.ReadOnly<Game.Tools.Temp>(),
                    },
                });

            m_BonusProviderQuery = GetEntityQuery(
                new EntityQueryDesc
                {
                    All = new ComponentType[]
                    {
                        ComponentType.ReadOnly<Signature>(),
                        ComponentType.ReadOnly<CityEffectProvider>(),
                        ComponentType.ReadOnly<PrefabRef>(),
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

            m_AllBonusProviderQuery = GetEntityQuery(
                new EntityQueryDesc
                {
                    All = new ComponentType[]
                    {
                        ComponentType.ReadOnly<Signature>(),
                        ComponentType.ReadOnly<CityEffectProvider>(),
                        ComponentType.ReadOnly<PrefabRef>(),
                    },
                    None = new ComponentType[]
                    {
                        ComponentType.ReadOnly<Deleted>(),
                        ComponentType.ReadOnly<Destroyed>(),
                        ComponentType.ReadOnly<Temp>(),
                    },
                });

            m_SimulationSystem =
                World.GetOrCreateSystemManaged<SimulationSystem>();

            Enabled = false;
        }

        protected override void OnGameLoaded(Context serializationContext)
        {
            SignatureScanState.Clear();
        }

        protected override void OnUpdate()
        {
            Enabled = false;
        }

        public void RefreshSnapshotIfNeeded()
        {
            GameManager? gameManager = GameManager.instance;

            if (gameManager == null || !gameManager.gameMode.IsGame())
            {
                if (SignatureScanState.HasSnapshot)
                    SignatureScanState.Clear();

                return;
            }

            uint simulationFrame =
                m_SimulationSystem?.frameIndex ?? uint.MaxValue;

            if (simulationFrame == uint.MaxValue)
                return;

            if (!SignatureScanState.NeedsRefresh(simulationFrame))
                return;

            try
            {
                BuildSnapshot(simulationFrame);
            }
            catch (System.Exception ex)
            {
                LogUtils.Warn(
                    $"{Mod.ModTag} Signature Status refresh failed: " +
                    $"{ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        private void BuildSnapshot(uint simulationFrame)
        {
            CompleteDependency();

            using NativeArray<PrefabRef> signaturePrefabs =
                m_SignatureQuery.ToComponentDataArray<PrefabRef>(
                    Allocator.Temp);

            using NativeArray<PrefabRef> bonusPrefabs =
                m_BonusProviderQuery.ToComponentDataArray<PrefabRef>(
                    Allocator.Temp);

            HashSet<Entity> signatureTypes = new();
            HashSet<Entity> bonusTypes = new();

            for (int i = 0; i < signaturePrefabs.Length; i++)
                signatureTypes.Add(signaturePrefabs[i].m_Prefab);

            for (int i = 0; i < bonusPrefabs.Length; i++)
                bonusTypes.Add(bonusPrefabs[i].m_Prefab);

            int duplicateBonusProviders =
                bonusPrefabs.Length - bonusTypes.Count;

            if (duplicateBonusProviders < 0)
                duplicateBonusProviders = 0;

            SignatureScanState.SetSnapshot(
                simulationFrame,
                signaturePrefabs.Length,
                signatureTypes.Count,
                bonusPrefabs.Length,
                duplicateBonusProviders,
                m_AllBonusProviderQuery.CalculateEntityCount());

#if DEBUG
            LogUtils.Info(
                $"{Mod.ModTag} Signature Status: " +
                $"buildings={signaturePrefabs.Length}, " +
                $"types={signatureTypes.Count}, " +
                $"cityWideProviders={bonusPrefabs.Length}, " +
                $"duplicateCityWideProviders={duplicateBonusProviders} | " +
                $"totalCityProviders={SignatureScanState.TotalCityWideProviders} | " +
                $"blockedCityProviders={SignatureScanState.BlockedCityWideProviders}.");
#endif
        }
    }
}
