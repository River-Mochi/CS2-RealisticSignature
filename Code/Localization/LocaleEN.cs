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
            return new Dictionary<string, string>
            {
                // Mod title
                {
                    m_Setting.GetSettingsLocaleID(),
                    Mod.ShortName
                },

                // Tabs
                {
                    m_Setting.GetOptionTabLocaleID(
                        SBCSettings.ActionsTab),
                    "Actions"
                },
                {
                    m_Setting.GetOptionTabLocaleID(
                        SBCSettings.StatusTab),
                    "Status"
                },
                {
                    m_Setting.GetOptionTabLocaleID(
                        SBCSettings.AboutTab),
                    "About"
                },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(SBCSettings.PlacementGroup), "Multiple Signature Buildings" },
                { m_Setting.GetOptionLabelLocaleID(nameof(SBCSettings.AllowMultipleSignatureBuildings)), "Allow multiple copies" },
                { m_Setting.GetOptionDescLocaleID(nameof(SBCSettings.AllowMultipleSignatureBuildings)),
                    "**ON** = place more than one copy of the same Signature building.\n" +
                    "**OFF** = game default: only one of each unique building."
                },


                {
                    m_Setting.GetOptionGroupLocaleID(SBCSettings.BonusGroup),"Signature Bonuses"
                },
                {
                    m_Setting.GetOptionGroupLocaleID(
                        SBCSettings.SignatureStatusGroup),
                    "Signature Status"
                },
                {
                    m_Setting.GetOptionGroupLocaleID(
                        SBCSettings.StatusActionsGroup),
                    "Status Actions"
                },
                {
                    m_Setting.GetOptionGroupLocaleID(
                        SBCSettings.AboutInfoGroup),
                    "Info"
                },
                {
                    m_Setting.GetOptionGroupLocaleID(
                        SBCSettings.DebugGroup),
                    "Debug / Logging"
                },

                // Placement
                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(
                            SBCSettings.AllowMultipleSignatureBuildings)),
                    "Allow multiple unique buildings"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(
                            SBCSettings.AllowMultipleSignatureBuildings)),
                    "**ON** = place more than one copy of the same " +
                    "Signature building.\n" +
                    "**OFF** = game default: one of each."
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
                    "<First copy only> = each Signature building type " +
                    "provides its bonus once.\n" +
                    "<No Bonuses> = Signature city bonuses are disabled.\n" +
                    "<Vanilla stacked bonuses> = every copy provides " +
                    "its normal bonus."
                },

                {
                    m_Setting.GetEnumValueLocaleID(
                        SignatureBonusMode.FirstCopyOnly),
                    "First copy only"
                },
                {
                    m_Setting.GetEnumValueLocaleID(
                        SignatureBonusMode.NoBonuses),
                    "No Bonuses"
                },
                {
                    m_Setting.GetEnumValueLocaleID(
                        SignatureBonusMode.VanillaStacking),
                    "Vanilla stacked bonuses"
                },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(SBCSettings.StatusPlacementRule)), "Placement rule" },
                { m_Setting.GetOptionDescLocaleID(nameof(SBCSettings.StatusPlacementRule)),
                    "Current placement rule for Signature buildings."
                },


                {
                    m_Setting.GetOptionLabelLocaleID(nameof(SBCSettings.StatusSignatureBuildings)), "Signature buildings placed"},
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(
                            SBCSettings.StatusSignatureBuildings)),
                    "Signature buildings currently placed in the city."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(
                            SBCSettings.StatusSignatureTypes)),
                    "Unique Signature types"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(
                            SBCSettings.StatusSignatureTypes)),
                    "Different Signature building types currently placed."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(
                            SBCSettings.StatusActiveBonusProviders)),
                    "Active bonus providers"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(
                            SBCSettings.StatusActiveBonusProviders)),
                    "Placed Signature buildings that currently have a " +
                    "city-wide bonus."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(
                            SBCSettings.StatusDuplicateBonusProviders)),
                    "Duplicate bonus providers"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(
                            SBCSettings.StatusDuplicateBonusProviders)),
                    "Extra copies of the same Signature type that also " +
                    "have a city-wide bonus."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(
                        nameof(
                            SBCSettings.ScanSignatureBonuses)),
                    "Scan Signature Bonuses"
                },
                {
                    m_Setting.GetOptionDescLocaleID(
                        nameof(
                            SBCSettings.ScanSignatureBonuses)),
                    "Scans the current city once and refreshes Signature Status.\n" +
                    "Note: city is paused while in Options menu, so these numbers will not change until you run the city and make changes."
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

                { m_Setting.GetOptionLabelLocaleID(nameof(SBCSettings.OpenLogButton)),"Open Log"},
                { m_Setting.GetOptionDescLocaleID(nameof(SBCSettings.OpenLogButton)),
                    "Opens this mod's log file. If unavailable, " +
                    "opens the Logs folder."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
