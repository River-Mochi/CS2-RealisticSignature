// <copyright file="SignatureScanSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignatureScanSystem.cs
// One-shot Status scan. Runs only opening the mod Options or the player manually rescans.

namespace SignatureBuildingControl
{
    using System.Collections.Generic;
    using Colossal.Serialization.Entities;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Buildings;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Unity.Collections;
    using Unity.Entities;

    public sealed partial class SignatureScanSystem : GameSystemBase
    {
        private EntityQuery m_SignatureQuery;
        private EntityQuery m_BonusProviderQuery;

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
                        ComponentType.ReadOnly<Game.Common.Deleted>(),
                        ComponentType.ReadOnly<Game.Common.Destroyed>(),
                        ComponentType.ReadOnly<Game.Tools.Temp>(),
                    },
                });

            Enabled = false;
        }

        protected override void OnGameLoaded(Context serializationContext)
        {
            SignatureScanState.Clear();
        }

        protected override void OnUpdate()
        {
            if (!SignatureScanState.ConsumeRequest())
            {
                Enabled = false;
                return;
            }

            GameManager? gameManager = GameManager.instance;

            if (gameManager == null || !gameManager.gameMode.IsGame())
            {
                SignatureScanState.Clear();

                LogUtils.Info(
                    $"{Mod.ModTag} Signature scan skipped: no city is loaded.");

                Enabled = false;
                return;
            }

            try
            {
                using NativeArray<PrefabRef> signaturePrefabs =
                    m_SignatureQuery.ToComponentDataArray<PrefabRef>(
                        Allocator.Temp);

                using NativeArray<PrefabRef> bonusPrefabs =
                    m_BonusProviderQuery.ToComponentDataArray<PrefabRef>(
                        Allocator.Temp);

                HashSet<Entity> signatureTypes = new();
                HashSet<Entity> bonusTypes = new();

                for (int i = 0; i < signaturePrefabs.Length; i++)
                {
                    signatureTypes.Add(
                        signaturePrefabs[i].m_Prefab);
                }

                for (int i = 0; i < bonusPrefabs.Length; i++)
                {
                    bonusTypes.Add(
                        bonusPrefabs[i].m_Prefab);
                }

                int duplicateBonusProviders =
                    bonusPrefabs.Length - bonusTypes.Count;

                if (duplicateBonusProviders < 0)
                {
                    duplicateBonusProviders = 0;
                }

                SignatureScanState.SetSnapshot(
                    signaturePrefabs.Length,
                    signatureTypes.Count,
                    bonusPrefabs.Length,
                    duplicateBonusProviders);

                LogUtils.Info(
                    $"{Mod.ModTag} Signature scan: " +
                    $"buildings={signaturePrefabs.Length}, " +
                    $"types={signatureTypes.Count}, " +
                    $"bonusProviders={bonusPrefabs.Length}, " +
                    $"duplicateBonusProviders={duplicateBonusProviders}.");
            }
            catch (System.Exception ex)
            {
                SignatureScanState.Clear();

                LogUtils.Warn(
                    $"{Mod.ModTag} Signature scan failed: " +
                    $"{ex.GetType().Name}: {ex.Message}",
                    ex);
            }

            Enabled = false;
        }
    }
}
