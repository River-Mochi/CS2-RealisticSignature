// <copyright file="SignatureInfoviewSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// Suppress only the infoview automatically selected by Signature placement.
namespace UniqueBuildings
{
    using Colossal.Serialization.Entities;
    using Game;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Game.Tools;
    using Unity.Entities;

    public sealed partial class SignatureInfoviewSystem : GameSystemBase
    {
        private ToolSystem? m_ToolSystem;
        private PrefabSystem? m_PrefabSystem;
        private bool m_PendingSignatureSelection;
        private bool m_SuppressedCurrentSignature;
        private bool m_Subscribed;

        protected override void OnCreate()
        {
            base.OnCreate();
            m_ToolSystem = World.GetOrCreateSystemManaged<ToolSystem>();
            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            m_ToolSystem.EventPrefabChanged += OnPrefabChanged;
            m_ToolSystem.EventInfoviewChanged += OnInfoviewChanged;
            m_Subscribed = true;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);
            m_PendingSignatureSelection = false;
            m_SuppressedCurrentSignature = false;
        }

        protected override void OnUpdate()
        {
            // PostTool follows the game's automatic infoview selection. A later
            // manual click must never be treated as part of this selection.
            m_PendingSignatureSelection = false;
        }

        protected override void OnDestroy()
        {
            Detach();
            base.OnDestroy();
        }

        public void OnSettingChanged(bool preventAutomaticInfoviews)
        {
            m_PendingSignatureSelection = false;
            if (!IsCurrentSignaturePlacement() ||
                ToggleableOverlaysCompatibility.IsActive())
            {
                return;
            }

            if (preventAutomaticInfoviews)
            {
                // Apply the option now unless the player chose a different
                // infoview manually while this Signature was selected.
                if (m_ToolSystem!.activeTool is ObjectToolSystem objectTool &&
                    m_ToolSystem.infoview == objectTool.infoview)
                {
                    m_SuppressedCurrentSignature = true;
                    m_ToolSystem.infoview = null;
                }
            }
            else
            {
                if (m_SuppressedCurrentSignature)
                    RestoreAutomaticInfoview();

                m_SuppressedCurrentSignature = false;
            }
        }

        public void ReleaseForDispose()
        {
            m_PendingSignatureSelection = false;
            if (m_SuppressedCurrentSignature &&
                IsCurrentSignaturePlacement() &&
                !ToggleableOverlaysCompatibility.IsActive())
            {
                RestoreAutomaticInfoview();
            }

            Detach();
            m_SuppressedCurrentSignature = false;
        }

        private void OnPrefabChanged(PrefabBase prefab)
        {
            m_PendingSignatureSelection =
                Mod.Setting?.PreventAutomaticSignatureInfoviews == true &&
                m_ToolSystem != null && m_ToolSystem.actionMode.IsGame() &&
                !ToggleableOverlaysCompatibility.IsActive() &&
                IsSignaturePrefab(prefab);

            m_SuppressedCurrentSignature = m_PendingSignatureSelection;

            if (m_PendingSignatureSelection)
            {
                // Clear a previous asset's view, including when both assets
                // use the same infoview and vanilla would not emit a change.
                m_ToolSystem!.infoview = null;
            }
        }

        private void OnInfoviewChanged(
            InfoviewPrefab newInfoview,
            InfoviewPrefab oldInfoview)
        {
            if (!m_PendingSignatureSelection || newInfoview == null ||
                m_ToolSystem?.activeTool is not ObjectToolSystem ||
                ToggleableOverlaysCompatibility.IsActive())
            {
                if (!m_PendingSignatureSelection && newInfoview != null)
                    m_SuppressedCurrentSignature = false;

                return;
            }

            // This fires inside ToolSystem.ToolUpdate, before it uploads the
            // infoview shader colors. The null event from this write is ignored.
            m_PendingSignatureSelection = false;
            m_ToolSystem.infoview = null;
        }

        private bool IsCurrentSignaturePlacement()
        {
            return m_ToolSystem != null && m_ToolSystem.actionMode.IsGame() &&
                   m_ToolSystem.activeTool is ObjectToolSystem &&
                   IsSignaturePrefab(m_ToolSystem.activePrefab);
        }

        private bool IsSignaturePrefab(PrefabBase? prefab)
        {
            if (prefab == null || m_PrefabSystem == null ||
                !m_PrefabSystem.TryGetEntity(prefab, out Entity entity))
            {
                return false;
            }

            return EntityManager.HasComponent<SignatureBuildingData>(entity);
        }

        private void RestoreAutomaticInfoview()
        {
            if (m_ToolSystem?.activeTool is ObjectToolSystem objectTool &&
                m_ToolSystem.infoview == null)
            {
                m_ToolSystem.infoview = objectTool.infoview;
            }
        }

        private void Detach()
        {
            if (!m_Subscribed || m_ToolSystem == null)
                return;

            m_ToolSystem.EventPrefabChanged -= OnPrefabChanged;
            m_ToolSystem.EventInfoviewChanged -= OnInfoviewChanged;
            m_Subscribed = false;
        }
    }
}
