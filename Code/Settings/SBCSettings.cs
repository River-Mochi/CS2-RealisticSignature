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
    using Game.Modding;
    using Game.Settings;
    using Game.UI.Localization;
    using Game.UI.Widgets;
    using Unity.Entities;

    public enum SignatureBonusMode
    {
        VanillaStacking = 0,
        FirstCopyOnly = 1,
        NoBonuses = 2,
    }

    [FileLocation("ModsSettings/SignatureBuildingControl/SignatureBuildingControl")]
    [SettingsUITabOrder(ActionsTab, AboutTab)]
    [SettingsUIGroupOrder(
        PlacementGroup, BonusGroup, SignatureStatusGroup,
        AboutInfoGroup, DebugGroup)]
    [SettingsUIShowGroupName(
        PlacementGroup, BonusGroup, SignatureStatusGroup,
        DebugGroup)]
    public sealed class SBCSettings : ModSetting
    {
        public const string ActionsTab = "Actions";
        public const string AboutTab = "About";

        public const string PlacementGroup = "Placement";
        public const string BonusGroup = "Bonuses";
        public const string SignatureStatusGroup = "SignatureStatus";
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
        [SettingsUISetter(typeof(SBCSettings), nameof(SetAllowMultipleSignatureBuildings))]
        public bool AllowMultipleSignatureBuildings { get; set; }

        [SettingsUIDropdown(typeof(SBCSettings), nameof(GetSignatureBonusDropdownItems))]
        [SettingsUISection(ActionsTab, BonusGroup)]
        public SignatureBonusMode SignatureBonuses { get; set; }

        // --------------------
        // Status
        // --------------------

        [Exclude]
        [SettingsUIValueVersion(typeof(SignaturePlacementState), nameof(SignaturePlacementState.GetUiVersion))]
        [SettingsUISection(ActionsTab, SignatureStatusGroup)]
        public string StatusPlacementRule
        {
            get
            {
                RefreshStatusIfNeeded();
                return SignaturePlacementState.StatusText;
            }
        }

        [Exclude]
        [SettingsUIValueVersion(typeof(SignatureScanState), nameof(SignatureScanState.GetUiVersion))]
        [SettingsUISection(ActionsTab, SignatureStatusGroup)]
        public string StatusSignatureBuildings
        {
            get
            {
                RefreshStatusIfNeeded();

                return SignatureScanState.HasSnapshot
                    ? SignatureScanState.SignatureBuildings.ToString()
                    : "—";
            }
        }

        [Exclude]
        [SettingsUIValueVersion(typeof(SignatureScanState), nameof(SignatureScanState.GetUiVersion))]
        [SettingsUISection(ActionsTab, SignatureStatusGroup)]
        public string StatusSignatureTypes
        {
            get
            {
                RefreshStatusIfNeeded();

                return SignatureScanState.HasSnapshot
                    ? SignatureScanState.SignatureTypes.ToString()
                    : "—";
            }
        }

        [Exclude]
        [SettingsUIValueVersion(typeof(SignatureScanState), nameof(SignatureScanState.GetUiVersion))]
        [SettingsUISection(ActionsTab, SignatureStatusGroup)]
        public string StatusActiveBonusProviders
        {
            get
            {
                RefreshStatusIfNeeded();

                return SignatureScanState.HasSnapshot
                    ? SignatureScanState.ActiveBonusProviders.ToString()
                    : "—";
            }
        }

        [Exclude]
        [SettingsUIValueVersion(typeof(SignatureScanState), nameof(SignatureScanState.GetUiVersion))]
        [SettingsUISection(ActionsTab, SignatureStatusGroup)]
        public string StatusDuplicateBonusProviders
        {
            get
            {
                RefreshStatusIfNeeded();

                return SignatureScanState.HasSnapshot
                    ? SignatureScanState.DuplicateBonusProviders.ToString()
                    : "—";
            }
        }

        // --------------------
        // About
        // --------------------

        [SettingsUISection(AboutTab, AboutInfoGroup)]
        public string ModNameDisplay => Mod.ModName;

        [SettingsUISection(AboutTab, AboutInfoGroup)]
        public string ModVersionDisplay => $"{Mod.ModVersion} {Mod.BuildDisplayName}";

        [SettingsUIButtonGroup(DebugGroup)]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, DebugGroup)]
        public bool OpenLogButton
        {
            set
            {
                if (value)
                    ShellOpen.OpenModLogOrLogsFolder();
            }
        }

        public override void SetDefaults()
        {
            AllowMultipleSignatureBuildings = false;
            SignatureBonuses = SignatureBonusMode.VanillaStacking;
        }

        private void SetAllowMultipleSignatureBuildings(bool value)
        {
            if (AllowMultipleSignatureBuildings == value)
                return;

            GetPlacementSystem()?.ScheduleReconcile(
                value,
                "Options setting changed");
        }

        private DropdownItem<int>[] GetSignatureBonusDropdownItems()
        {
            return new DropdownItem<int>[]
            {
                new()
                {
                    value = (int)SignatureBonusMode.FirstCopyOnly,
                    displayName = LocalizedString.Id(
                        GetEnumValueLocaleID(SignatureBonusMode.FirstCopyOnly)),
                },
                new()
                {
                    value = (int)SignatureBonusMode.NoBonuses,
                    displayName = LocalizedString.Id(
                        GetEnumValueLocaleID(SignatureBonusMode.NoBonuses)),
                },
                new()
                {
                    value = (int)SignatureBonusMode.VanillaStacking,
                    displayName = LocalizedString.Id(
                        GetEnumValueLocaleID(SignatureBonusMode.VanillaStacking)),
                },
            };
        }

        private static void RefreshStatusIfNeeded()
        {
            if (!SignaturePlacementState.HasSnapshot)
            {
                GetPlacementSystem()?.ScheduleReconcile(
                    Mod.Setting?.AllowMultipleSignatureBuildings ?? false,
                    "Status opened");
            }

            GetScanSystem()?.RefreshSnapshotIfNeeded();
        }

        private static SignaturePlacementSystem? GetPlacementSystem()
        {
            World? world = World.DefaultGameObjectInjectionWorld;

            if (world == null || !world.IsCreated)
                return null;

            return world.GetOrCreateSystemManaged<SignaturePlacementSystem>();
        }

        private static SignatureScanSystem? GetScanSystem()
        {
            World? world = World.DefaultGameObjectInjectionWorld;

            if (world == null || !world.IsCreated)
                return null;

            return world.GetOrCreateSystemManaged<SignatureScanSystem>();
        }
    }
}
