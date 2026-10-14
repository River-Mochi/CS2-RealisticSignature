// <copyright file="LocaleEN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleEN.cs
// English source of truth.

namespace UniqueBuildings
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly UniqueBldgSettings m_Setting;

        public LocaleEN(UniqueBldgSettings setting)
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
                { m_Setting.GetSettingsLocaleID(), Mod.ModName },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(UniqueBldgSettings.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(UniqueBldgSettings.AboutTab), "About" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(UniqueBldgSettings.BonusGroup), "Signature Bonuses" },
                { m_Setting.GetOptionGroupLocaleID(UniqueBldgSettings.UnlockGroup), "Signature Unlocks" },
                { m_Setting.GetOptionGroupLocaleID(UniqueBldgSettings.PlacementGroup), "Multiple Unique Buildings" },
                { m_Setting.GetOptionGroupLocaleID(UniqueBldgSettings.SignatureStatusGroup), "Status" },
                { m_Setting.GetOptionGroupLocaleID(UniqueBldgSettings.AboutInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(UniqueBldgSettings.DebugGroup), "Debug / Logging" },

                // Signature Bonuses
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.SignatureBonuses)), "Signature Bonuses" },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.SignatureBonuses)),
                    "<First copy only> = each Signature building type provides its bonus once.\n" +
                    "<No Bonuses> = Signature bonuses are disabled.\n" +
                    "<Normal game stacked bonuses> = every copy provides its normal game bonus."
                },

                { m_Setting.GetEnumValueLocaleID(SignatureBonusMode.FirstCopyOnly), "First copy only" },
                { m_Setting.GetEnumValueLocaleID(SignatureBonusMode.NoBonuses), "No Bonuses" },
                { m_Setting.GetEnumValueLocaleID(SignatureBonusMode.VanillaStacking), "Normal game stacked bonuses" },

                // Signature Unlocks
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.UnlockSignatureRequirements)), "Unlock Signature requirements" },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.UnlockSignatureRequirements)),
                    "**ON** = make all Signature buildings available without meeting population, zoning, or other progression requirements.\n" +
                    "**OFF** = normal game progression rules."
                },

                // Multiple Unique
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.AllowMultipleUniqueBuildings)), "Allow multiple copies" },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.AllowMultipleUniqueBuildings)),
                    "**ON** = place multiple copies of anything the game marks Unique, including Signature buildings.\n" +
                    "**OFF** = normal one-per-city rules unless another mod allows multiple Unique items."
                },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.StatusPlacementRule)), "Unique placement rule" },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.StatusPlacementRule)),
                    "Shows whether Unique items can currently be placed more than once."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.StatusSignatureSummary)), "Signature buildings" },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.StatusSignatureSummary)),
                    "Shows total placed Signature buildings, different Signature types, and extra duplicate copies."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.StatusCityWideEffects)), "City-wide bonus effects" },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.StatusCityWideEffects)),
                    "Counts Signature buildings with city-wide bonus effects.\n" +
                    "Nearby/local bonus effects are separate and are not included here."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.StatusRedundantMods)), "Redundant mods detected" },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.StatusRedundantMods)),
                    "Anarchy is supported and is not listed here.\n" +
                    "Remove other Unlimited/Multiple Unique mods because this mod already provides that feature."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.ModNameDisplay)), "Display name of this mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.ModVersionDisplay)),
                    "Installed mod version and build type."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.OpenLogButton)), "Open Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.OpenLogButton)),
                    "Opens this mod's log file. If unavailable, opens the Logs folder."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
