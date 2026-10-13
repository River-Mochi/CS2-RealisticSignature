// <copyright file="SBCSettings.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Settings/SBCSettings.cs
// Options UI and saved settings.

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
        VanillaStacking = 0,
        FirstCopyOnly = 1,
        NoBonuses = 2,
    }

    [FileLocation("ModsSettings/SignatureBuildingControl/SignatureBuildingControl")]
    [SettingsUITabOrder(ActionsTab, AboutTab)]
    [SettingsUIGroupOrder(
        BonusGroup, PlacementGroup, SignatureStatusGroup,
        AboutInfoGroup, DebugGroup)]
    [SettingsUIShowGroupName(
        BonusGroup, PlacementGroup, SignatureStatusGroup,
        DebugGroup)]
    public sealed class SBCSettings : ModSetting
    {
        public const string ActionsTab = "Actions";
        public const string AboutTab = "About";

        public const string BonusGroup = "Bonuses";
        public const string PlacementGroup = "Placement";
        public const string SignatureStatusGroup = "SignatureStatus";
        public const string AboutInfoGroup = "AboutInfo";
        public const string DebugGroup = "Debug";

        public SBCSettings(IMod mod)
            : base(mod)
        {
            SetDefaults();
        }

        // --------------------
        // Signature Bonuses
        // --------------------

        [SettingsUIDropdown(typeof(SBCSettings), nameof(GetSignatureBonusDropdownItems))]
        [SettingsUISection(ActionsTab, BonusGroup)]
        public SignatureBonusMode SignatureBonuses { get; set; }

        // --------------------
        // Multiple Unique
        // --------------------

        [SettingsUISection(ActionsTab, PlacementGroup)]
        [SettingsUISetter(typeof(SBCSettings), nameof(SetAllowMultipleUniqueBuildings))]
        public bool AllowMultipleUniqueBuildings { get; set; }

        // --------------------
        // Status
        // --------------------

        [Exclude]
        [SettingsUIValueVersion(typeof(UniquePlacementState), nameof(UniquePlacementState.GetUiVersion))]
        [SettingsUISection(ActionsTab, SignatureStatusGroup)]
        public string StatusPlacementRule
        {
            get
            {
                if (!IsCityLoaded())
                    return "No city loaded yet";

                RefreshStatusIfNeeded();

                return UniquePlacementState.HasSnapshot
                    ? UniquePlacementState.StatusText
                    : "Loading…";
            }
        }

        [Exclude]
        [SettingsUIValueVersion(typeof(SignatureScanState), nameof(SignatureScanState.GetUiVersion))]
        [SettingsUISection(ActionsTab, SignatureStatusGroup)]
        public string StatusSignatureSummary
        {
            get
            {
                if (!IsCityLoaded())
                    return "Load a city first to see status";

                RefreshStatusIfNeeded();

                if (!SignatureScanState.HasSnapshot)
                    return "Loading…";

                return
                    $"{SignatureScanState.SignatureBuildings} placed | " +
                    $"{SignatureScanState.SignatureTypes} types | " +
                    $"{SignatureScanState.DuplicateSignatureBuildings} duplicates";
            }
        }

        [Exclude]
        [SettingsUIValueVersion(typeof(SignatureScanState), nameof(SignatureScanState.GetUiVersion))]
        [SettingsUISection(ActionsTab, SignatureStatusGroup)]
        public string StatusCityWideEffects
        {
            get
            {
                if (!IsCityLoaded())
                    return "—";

                RefreshStatusIfNeeded();

                if (!SignatureScanState.HasSnapshot)
                    return "Loading…";

                return
                    $"{SignatureScanState.CityWideEffectProviders} providers | " +
                    $"{SignatureScanState.DuplicateCityWideProviders} duplicate providers";
            }
        }

        [Exclude]
        [SettingsUIValueVersion(typeof(UniqueModsCompatibility), nameof(UniqueModsCompatibility.GetUiVersion))]
        [SettingsUISection(ActionsTab, SignatureStatusGroup)]
        public string StatusRedundantMods =>
            UniqueModsCompatibility.StatusText;

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
                    ShellOpen.OpenModLogOrLogsFolder();
            }
        }

        public override void SetDefaults()
        {
            SignatureBonuses = SignatureBonusMode.VanillaStacking;
            AllowMultipleUniqueBuildings = true;
        }

        private void SetAllowMultipleUniqueBuildings(bool value)
        {
            if (AllowMultipleUniqueBuildings == value)
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
            if (!IsCityLoaded())
                return;

            if (!UniquePlacementState.HasSnapshot)
            {
                GetPlacementSystem()?.ScheduleReconcile(
                    Mod.Setting?.AllowMultipleUniqueBuildings ?? true,
                    "Status opened");
            }

            GetScanSystem()?.RefreshSnapshotIfNeeded();
        }

        private static UniquePlacementSystem? GetPlacementSystem()
        {
            World? world = World.DefaultGameObjectInjectionWorld;

            if (world == null || !world.IsCreated)
                return null;

            return world.GetOrCreateSystemManaged<UniquePlacementSystem>();
        }

        private static SignatureScanSystem? GetScanSystem()
        {
            World? world = World.DefaultGameObjectInjectionWorld;

            if (world == null || !world.IsCreated)
                return null;

            return world.GetOrCreateSystemManaged<SignatureScanSystem>();
        }

        private static bool IsCityLoaded()
        {
            GameManager? gameManager = GameManager.instance;

            return gameManager != null &&
                   gameManager.gameMode.IsGame();
        }
    }
}
