// <copyright file="SignatureBonusWatchSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignatureBonusWatchSystem.cs
// Lightweight change watcher for placed Signature buildings.

namespace UniqueBuildings
{
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Tools;
    using Unity.Entities;

    public sealed partial class SignatureBonusWatchSystem :
        GameSystemBase
    {
        private EntityQuery m_ChangedSignatureQuery;
        private EntityQuery m_DestroyedSignatureQuery;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_ChangedSignatureQuery = GetEntityQuery(
                new EntityQueryDesc
                {
                    All = new ComponentType[]
                    {
                        ComponentType.ReadOnly<Signature>(),
                    },
                    Any = new ComponentType[]
                    {
                        ComponentType.ReadOnly<Created>(),
                        ComponentType.ReadOnly<Updated>(),
                        ComponentType.ReadOnly<Deleted>(),
                    },
                    None = new ComponentType[]
                    {
                        ComponentType.ReadOnly<Temp>(),
                    },
                });

            // Destroyed can persist longer than Created/Updated,
            // so use a change filter rather than treating every
            // destroyed Signature as a permanent trigger.
            m_DestroyedSignatureQuery = GetEntityQuery(
                new EntityQueryDesc
                {
                    All = new ComponentType[]
                    {
                        ComponentType.ReadOnly<Signature>(),
                        ComponentType.ReadOnly<Destroyed>(),
                    },
                    None = new ComponentType[]
                    {
                        ComponentType.ReadOnly<Temp>(),
                    },
                });

            m_DestroyedSignatureQuery.SetChangedVersionFilter(
                ComponentType.ReadOnly<Destroyed>());
        }

        protected override void OnUpdate()
        {
            SignatureBonusMode mode =
                Mod.Setting?.SignatureBonuses ??
                SignatureBonusMode.VanillaStacking;

            if (mode == SignatureBonusMode.VanillaStacking &&
                SignatureBonusSystem.GetEffectiveAttractivenessMode(mode) ==
                    SignatureBonusMode.VanillaStacking)
                return;

            bool changed =
                !m_ChangedSignatureQuery.IsEmptyIgnoreFilter ||
                m_DestroyedSignatureQuery.CalculateEntityCount() > 0;

            if (!changed)
                return;

            SignatureBonusSystem? bonusSystem =
                World.GetExistingSystemManaged<
                    SignatureBonusSystem>();

            bonusSystem?.ScheduleReconcile(
                mode,
                "Signature building changed");
        }
    }
}
