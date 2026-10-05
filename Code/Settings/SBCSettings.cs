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
    using Colossal.Json;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;
    using Game.Settings;
    using Game.UI.Localization;
    using Game.UI.Widgets;
    using Unity.Entities;

    public enum SignatureBonusMode
    {
        // Do not change these numbers after release.
        VanillaStacking = 0,
        FirstCopyOnly = 1,
        NoBonuses = 2,
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

        [SettingsUIDropdown(
            typeof(SBCSettings),
            nameof(GetSignatureBonusDropdownItems))]
        [SettingsUISection(ActionsTab, BonusGroup)]
        public SignatureBonusMode SignatureBonuses
        {
            get;
            set;
        }

        // --------------------
        // Status
        // --------------------

        [Exclude]
        [SettingsUIValueVersion(
            typeof(SignatureScanState),
            nameof(SignatureScanState.GetUiVersion))]
        [SettingsUISection(StatusTab, SignatureStatusGroup)]
        public string StatusSignatureBuildings
        {
            get
            {
                EnsureAutomaticStatusScan();

                return SignatureScanState.HasSnapshot
                    ? SignatureScanState.SignatureBuildings.ToString()
                    : "—";
            }
        }

        [Exclude]
        [SettingsUIValueVersion(
            typeof(SignatureScanState),
            nameof(SignatureScanState.GetUiVersion))]
        [SettingsUISection(StatusTab, SignatureStatusGroup)]
        public string StatusSignatureTypes
        {
            get
            {
                EnsureAutomaticStatusScan();

                return SignatureScanState.HasSnapshot
                    ? SignatureScanState.SignatureTypes.ToString()
                    : "—";
            }
        }

        [Exclude]
        [SettingsUIValueVersion(
            typeof(SignatureScanState),
            nameof(SignatureScanState.GetUiVersion))]
        [SettingsUISection(StatusTab, SignatureStatusGroup)]
        public string StatusActiveBonusProviders
        {
            get
            {
                EnsureAutomaticStatusScan();

                return SignatureScanState.HasSnapshot
                    ? SignatureScanState.ActiveBonusProviders.ToString()
                    : "—";
            }
        }

        [Exclude]
        [SettingsUIValueVersion(
            typeof(SignatureScanState),
            nameof(SignatureScanState.GetUiVersion))]
        [SettingsUISection(StatusTab, SignatureStatusGroup)]
        public string StatusDuplicateBonusProviders
        {
            get
            {
                EnsureAutomaticStatusScan();

                return SignatureScanState.HasSnapshot
                    ? SignatureScanState.DuplicateBonusProviders.ToString()
                    : "—";
            }
        }

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

                RequestStatusScan(force: true, logFailure: true);
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

        private DropdownItem<int>[] GetSignatureBonusDropdownItems()
        {
            return new DropdownItem<int>[]
            {
                new()
                {
                    value = (int)SignatureBonusMode.FirstCopyOnly,
                    displayName = LocalizedString.Id(
                        GetEnumValueLocaleID(
                            SignatureBonusMode.FirstCopyOnly)),
                },
                new()
                {
                    value = (int)SignatureBonusMode.NoBonuses,
                    displayName = LocalizedString.Id(
                        GetEnumValueLocaleID(
                            SignatureBonusMode.NoBonuses)),
                },
                new()
                {
                    value = (int)SignatureBonusMode.VanillaStacking,
                    displayName = LocalizedString.Id(
                        GetEnumValueLocaleID(
                            SignatureBonusMode.VanillaStacking)),
                },
            };
        }

        private static void EnsureAutomaticStatusScan()
        {
            RequestStatusScan(
                force: false,
                logFailure: false);
        }

        private static void RequestStatusScan(
            bool force,
            bool logFailure)
        {
            GameManager? gameManager = GameManager.instance;

            if (gameManager == null ||
                !gameManager.gameMode.IsGame())
            {
                return;
            }

            World? world = World.DefaultGameObjectInjectionWorld;

            if (world == null ||
                !world.IsCreated)
            {
                if (logFailure)
                {
                    LogUtils.Warn(
                        $"{Mod.ModTag} Signature scan requested, " +
                        "but no ECS World is available.");
                }

                return;
            }

            if (!SignatureScanState.TryRequestScan(force))
            {
                return;
            }

            try
            {
                SignatureScanSystem system =
                    world.GetOrCreateSystemManaged<SignatureScanSystem>();

                system.Enabled = true;
            }
            catch (System.Exception ex)
            {
                SignatureScanState.CancelRequest();

                if (logFailure)
                {
                    LogUtils.Warn(
                        $"{Mod.ModTag} Could not start Signature scan: " +
                        $"{ex.GetType().Name}: {ex.Message}",
                        ex);
                }
            }
        }
    }
}
