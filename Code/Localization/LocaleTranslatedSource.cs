// <copyright file="LocaleTranslatedSource.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleTranslatedSource.cs
// Entries follow the Options section order in LocaleEN.cs.
// LocaleEN.cs remains the source of truth.

namespace UniqueBuildings
{
    using System;
    using System.Collections.Generic;
    using Colossal;

    public abstract class LocaleTranslatedSource : IDictionarySource
    {
        private readonly UniqueBldgSettings m_Setting;

        protected LocaleTranslatedSource(UniqueBldgSettings setting)
        {
            m_Setting = setting;
        }

        protected abstract string[] Text { get; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string[] t = Text;
            if (t.Length != 56)
                throw new InvalidOperationException("Signature locale must have all 56 entries.");

            return new Dictionary<string, string>
                { { m_Setting.GetSettingsLocaleID(), t[0] },
                { m_Setting.GetOptionTabLocaleID(UniqueBldgSettings.ActionsTab), t[1] },
                { m_Setting.GetOptionTabLocaleID(UniqueBldgSettings.AboutTab), t[2] },
                { m_Setting.GetOptionGroupLocaleID(UniqueBldgSettings.BonusGroup), t[3] },
                { m_Setting.GetOptionGroupLocaleID(UniqueBldgSettings.UnlockGroup), t[4] },
                { m_Setting.GetOptionGroupLocaleID(UniqueBldgSettings.PlacementGroup), t[5] },
                { m_Setting.GetOptionGroupLocaleID(UniqueBldgSettings.SignatureStatusGroup), t[6] },
                { m_Setting.GetOptionGroupLocaleID(UniqueBldgSettings.AboutInfoGroup), t[7] },
                { m_Setting.GetOptionGroupLocaleID(UniqueBldgSettings.DebugGroup), t[8] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.SignatureBonuses)), t[9] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.SignatureBonuses)), t[10] },
                { m_Setting.GetEnumValueLocaleID(SignatureBonusMode.FirstCopyOnly), t[11] },
                { m_Setting.GetEnumValueLocaleID(SignatureBonusMode.NoBonuses), t[12] },
                { m_Setting.GetEnumValueLocaleID(SignatureBonusMode.VanillaStacking), t[13] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.NearbySignatureEffects)), t[14] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.NearbySignatureEffects)), t[15] },
                { m_Setting.GetEnumValueLocaleID(NearbySignatureMode.Vanilla), t[16] },
                { m_Setting.GetEnumValueLocaleID(NearbySignatureMode.FirstCopyOnly), t[17] },
                { m_Setting.GetEnumValueLocaleID(NearbySignatureMode.NoEffects), t[18] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.UnlockSignatureRequirements)), t[19] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.UnlockSignatureRequirements)), t[20] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.HideBulkUnlockNotifications)), t[21] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.HideBulkUnlockNotifications)), t[22] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.AllowMultipleUniqueBuildings)), t[23] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.AllowMultipleUniqueBuildings)), t[24] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.PreventAutomaticSignatureInfoviews)), t[25] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.PreventAutomaticSignatureInfoviews)), t[26] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.StatusPlacementRule)), t[27] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.StatusPlacementRule)), t[28] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.StatusSignatureSummary)), t[29] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.StatusSignatureSummary)), t[30] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.StatusCityWideEffects)), t[31] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.StatusCityWideEffects)), t[32] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.StatusRedundantMods)), t[33] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.StatusRedundantMods)), t[34] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.ModNameDisplay)), t[35] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.ModNameDisplay)), t[36] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.ModVersionDisplay)), t[37] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.ModVersionDisplay)), t[38] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.RunStatusReportButton)), t[39] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.RunStatusReportButton)), t[40] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.RunCompareBonusModesButton)), t[41] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.RunCompareBonusModesButton)), t[42] },
                { m_Setting.GetOptionLabelLocaleID(nameof(UniqueBldgSettings.OpenLogButton)), t[43] },
                { m_Setting.GetOptionDescLocaleID(nameof(UniqueBldgSettings.OpenLogButton)), t[44] },
                { LocaleEN.KeyStatusNoCity, t[45] },
                { LocaleEN.KeyStatusLoading, t[46] },
                { LocaleEN.KeyStatusLoadCity, t[47] },
                { LocaleEN.KeyStatusMultipleAllowed, t[48] },
                { LocaleEN.KeyStatusAllowedByAnarchy, t[49] },
                { LocaleEN.KeyStatusAllowedByAnotherMod, t[50] },
                { LocaleEN.KeyStatusOneOfEach, t[51] },
                { LocaleEN.KeyStatusMixedRules, t[52] },
                { LocaleEN.KeyStatusSignatureSummaryLine, t[53] },
                { LocaleEN.KeyStatusCityProvidersLine, t[54] },
                { LocaleEN.KeyStatusNone, t[55] },
            };
        }

        public void Unload()
        {
        }
    }
}
