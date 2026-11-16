// <copyright file="UniqueInfoviewSuppressionSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// Experimental non-Harmony alternative. Do not merge until tested against
// the working Harmony branch for behavior, performance, and compatibility.
namespace UniqueBuildings
{
    using System.Reflection;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Game.Tools;
    using Unity.Entities;

    public sealed partial class UniqueInfoviewSuppressionSystem : GameSystemBase
    {
        private static readonly MethodInfo? s_SetToolInfoview =
            typeof(ToolBaseSystem)
                .GetProperty(nameof(ToolBaseSystem.infoview))
                ?.GetSetMethod(nonPublic: true);

        private ToolSystem m_ToolSystem = null!;
        private ObjectToolSystem m_ObjectToolSystem = null!;
        private PrefabSystem m_PrefabSystem = null!;
        private UniquePlacementSystem m_PlacementSystem = null!;

        private bool m_MissingSetterLogged;
        private bool m_FailureLogged;
        private bool m_SuppressionLogged;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_ToolSystem = World.GetOrCreateSystemManaged<ToolSystem>();
            m_ObjectToolSystem = World.GetOrCreateSystemManaged<ObjectToolSystem>();
            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            m_PlacementSystem = World.GetOrCreateSystemManaged<UniquePlacementSystem>();

            // Avoid running this extra tool system when its option is OFF.
            Enabled = Mod.Setting?.PreventAutomaticSignatureInfoviews == true;
        }

        protected override void OnUpdate()
        {
            if (Mod.Setting?.PreventAutomaticSignatureInfoviews != true ||
                GameManager.instance?.gameMode.IsGame() != true ||
                m_ToolSystem.activeTool != m_ObjectToolSystem ||
                ToggleableOverlaysCompatibility.IsActive())
            {
                return;
            }

            PrefabBase? prefab = m_ToolSystem.activePrefab;
            if (prefab == null ||
                !m_PlacementSystem.IsKnownUniqueBuilding(m_PrefabSystem.GetEntity(prefab)))
                return;

            if (s_SetToolInfoview == null)
            {
                if (!m_MissingSetterLogged)
                {
                    m_MissingSetterLogged = true;
                    LogUtils.Warn(
                        $"{Mod.ModTag} Cannot suppress automatic infoview: " +
                        "ToolBaseSystem.infoview setter was not found.");
                }

                return;
            }

            try
            {
                if (m_ObjectToolSystem.infoview != null)
                    s_SetToolInfoview.Invoke(m_ObjectToolSystem, new object?[] { null });

                m_ObjectToolSystem.infomodes.Clear();
                if (!m_SuppressionLogged)
                {
                    m_SuppressionLogged = true;
#if DEBUG
                    LogUtils.Info($"{Mod.ModTag} Suppressed automatic Unique infoview (non-Harmony test).");
#endif
                }
            }
            catch (System.Exception ex)
            {
                if (!m_FailureLogged)
                {
                    m_FailureLogged = true;
                    LogUtils.Warn($"{Mod.ModTag} Non-Harmony infoview suppression failed.", ex);
                }
            }
        }
    }
}
