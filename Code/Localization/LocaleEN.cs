// <copyright file="LocaleEN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleEN.cs
// English source of truth for Signature Building Control.

namespace SignatureBuildingControl
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly SBCSettings m_Setting;

        public LocaleEN(SBCSettings setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ShortName;

            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title += $" ({Mod.ModVersion})";
            }

            return new Dictionary<string, string>
            {
                // Mod title
                { m_Setting.GetSettingsLocaleID(), title },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(SBCSettings.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(SBCSettings.StatusTab), "Status" },
                { m_Setting.GetOptionTabLocaleID(SBCSettings.AboutTab), "About" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(SBCSettings.PlacementGroup), "Signature Placement" },
                { m_Setting.GetOptionGroupLocaleID(SBCSettings.BonusGroup), "Signature Bonuses" },

                { m_Setting.GetOptionGroupLocaleID(SBCSettings.SignatureStatusGroup), "SIGNATURE STATUS" },
                { m_Setting.GetOptionGroupLocaleID(SBCSettings.StatusActionsGroup), "STATUS ACTIONS" },

                { m_Setting.GetOptionGroupLocaleID(SBCSettings.AboutInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(SBCSettings.DebugGroup), "Debug / Logging" },

                // Placement
                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(SBCSettings.AllowMultipleSignatureBuildings)),
                    "Allow Multiple Signature Buildings"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(SBCSettings.AllowMultipleSignatureBuildings)),
                    "**ON** = allows more than one copy of a Signature building.\n" +
                    "**OFF** = normal game placement rules.\n" +
                    "Compatibility checks will avoid unnecessary changes when another mod already allows multiple unique buildings."
                },

                // Bonus behavior
                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(SBCSettings.SignatureBonuses)),
                    "Signature Bonuses"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(SBCSettings.SignatureBonuses)),
                    "<Vanilla stacking> = every placed copy contributes its normal bonus.\n" +
                    "<First copy only> = each Signature building type contributes its bonus once.\n" +
                    "<No bonuses> = Signature city bonuses are disabled."
                },

                {
                    m_Setting.GetEnumValueLocaleID(
                        SignatureBonusMode.VanillaStacking),
                    "Vanilla stacking"
                },
                {
                    m_Setting.GetEnumValueLocaleID(
                        SignatureBonusMode.FirstCopyOnly),
                    "First copy only"
                },
                {
                    m_Setting.GetEnumValueLocaleID(
                        SignatureBonusMode.NoBonuses),
                    "No bonuses"
                },

                // Status
                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(SBCSettings.StatusSignatureBuildings)),
                    "Signature buildings placed"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(SBCSettings.StatusSignatureBuildings)),
                    "Number of currently placed Signature buildings found by the last scan."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(SBCSettings.StatusSignatureTypes)),
                    "Unique Signature types"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(SBCSettings.StatusSignatureTypes)),
                    "Number of different Signature building prefabs currently placed."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(SBCSettings.StatusActiveBonusProviders)),
                    "Active bonus providers"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(SBCSettings.StatusActiveBonusProviders)),
                    "Placed Signature buildings currently carrying the game's city bonus provider."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(SBCSettings.StatusDuplicateBonusProviders)),
                    "Duplicate bonus providers"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(SBCSettings.StatusDuplicateBonusProviders)),
                    "Extra copies of the same Signature type that currently provide city bonuses."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(SBCSettings.ScanSignatureBonuses)),
                    "Scan Signature Bonuses"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(SBCSettings.ScanSignatureBonuses)),
                    "Scans the current city once and updates the Signature Status above."
                },

                // About
                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(SBCSettings.ModNameDisplay)),
                    "Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(SBCSettings.ModNameDisplay)),
                    "Display name of this mod."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(SBCSettings.ModVersionDisplay)),
                    "Version"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(SBCSettings.ModVersionDisplay)),
                    "Installed mod version and build type."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(SBCSettings.OpenLogButton)),
                    "Open Log"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(SBCSettings.OpenLogButton)),
                    "Opens this mod's log file. If unavailable, opens the Logs folder."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
