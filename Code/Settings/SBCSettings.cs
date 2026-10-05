// <copyright file="SBCSettings.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Settings/SBCSettings.cs
// Options UI and saved settings for Signature Building Control.

namespace SignatureBuildingControl
{
    using Colossal.IO.AssetDatabase;
    using CS2Shared.RiverMochi;
    using Game.Modding;
    using Game.Settings;
    using Unity.Entities;

    public enum SignatureBonusMode
    {
        VanillaStacking,
        FirstCopyOnly,
        NoBonuses,
    }

    [FileLocation("ModsSettings/SignatureBuildingControl/SignatureBuildingControl")]
    [SettingsUITabOrder(
        ActionsTab,
        StatusTab,
        AboutTab)]
    [SettingsUIGroupOrder(
        PlacementGroup,
        BonusGroup,
        SignatureStatusGroup,
        StatusActionsGroup,
        AboutInfoGroup,
        DebugGroup)]
    [SettingsUIShowGroupName(
        PlacementGroup,
        BonusGroup,
        SignatureStatusGroup,
        StatusActionsGroup,
        AboutInfoGroup,
        DebugGroup)]
    public sealed class SBCSettings : ModSetting
    {
        public const string ActionsTab = "Actions";
        public const string StatusTab = "Status";
        public const string AboutTab = "About";

        public const string PlacementGroup = "Placement";
        public const string BonusGroup = "Bonuses";

        public const string SignatureStatusGroup = "SignatureStatus";
        public const string StatusActionsGroup = "StatusActions";

        public const string AboutInfoGroup = "AboutInfo";
        public const string DebugGroup = "Debug";

        public SBCSettings(IMod mod)
            : base(mod)
        {
            SetDefaults();
        }

        // --------------------
        // Actions
        // --------------------

        [SettingsUISection(ActionsTab, PlacementGroup)]
        public bool AllowMultipleSignatureBuildings
        {
            get;
            set;
        }

        [SettingsUISection(ActionsTab, BonusGroup)]
        public SignatureBonusMode SignatureBonuses
        {
            get;
            set;
        }

        // --------------------
        // Status
        // --------------------

        [SettingsUISection(StatusTab, SignatureStatusGroup)]
        public string StatusSignatureBuildings =>
            SignatureScanState.HasSnapshot
                ? SignatureScanState.SignatureBuildings.ToString()
                : "—";

        [SettingsUISection(StatusTab, SignatureStatusGroup)]
        public string StatusSignatureTypes =>
            SignatureScanState.HasSnapshot
                ? SignatureScanState.SignatureTypes.ToString()
                : "—";

        [SettingsUISection(StatusTab, SignatureStatusGroup)]
        public string StatusActiveBonusProviders =>
            SignatureScanState.HasSnapshot
                ? SignatureScanState.ActiveBonusProviders.ToString()
                : "—";

        [SettingsUISection(StatusTab, SignatureStatusGroup)]
        public string StatusDuplicateBonusProviders =>
            SignatureScanState.HasSnapshot
                ? SignatureScanState.DuplicateBonusProviders.ToString()
                : "—";

        [SettingsUIButtonGroup(StatusActionsGroup)]
        [SettingsUIButton]
        [SettingsUISection(StatusTab, StatusActionsGroup)]
        public bool ScanSignatureBonuses
        {
            set
            {
                if (!value)
                {
                    return;
                }

                SignatureScanState.RequestScan();

                try
                {
                    World? world = World.DefaultGameObjectInjectionWorld;
                    if (world == null)
                    {
                        LogUtils.Warn(
                            $"{Mod.ModTag} Signature scan requested, but no ECS World is available.");

                        return;
                    }

                    SignatureScanSystem system =
                        world.GetOrCreateSystemManaged<SignatureScanSystem>();

                    system.Enabled = true;
                }
                catch (System.Exception ex)
                {
                    LogUtils.Warn(
                        $"{Mod.ModTag} Could not start Signature scan: " +
                        $"{ex.GetType().Name}: {ex.Message}",
                        ex);
                }
            }
        }

        // --------------------
        // About
        // --------------------

        [SettingsUISection(AboutTab, AboutInfoGroup)]
        public string ModNameDisplay => Mod.ModName;

        [SettingsUISection(AboutTab, AboutInfoGroup)]
        public string ModVersionDisplay =>
            $"{Mod.ModVersion} {Mod.BuildDisplayName}";

        [SettingsUIButtonGroup(DebugGroup)]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, DebugGroup)]
        public bool OpenLogButton
        {
            set
            {
                if (value)
                {
                    ShellOpen.OpenModLogOrLogsFolder();
                }
            }
        }

        public override void SetDefaults()
        {
            AllowMultipleSignatureBuildings = false;
            SignatureBonuses = SignatureBonusMode.VanillaStacking;
        }
    }
}
