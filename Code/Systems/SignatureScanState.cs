// <copyright file="SignatureScanState.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignatureScanState.cs
// Cached Signature Status snapshot for the Options UI.

namespace UniqueBuildings
{
    using CS2Shared.RiverMochi;

    internal static class SignatureScanState
    {
        private static int s_UiVersion;

        public static bool HasSnapshot { get; private set; }

        public static uint LastSnapshotSimulationFrame { get; private set; } =
            uint.MaxValue;

        public static int SignatureBuildings { get; private set; }

        public static int SignatureTypes { get; private set; }

        public static int CityWideEffectProviders { get; private set; }

        public static int DuplicateCityWideProviders { get; private set; }

        public static int TotalCityWideProviders { get; private set; }

        public static int BlockedCityWideProviders =>
            System.Math.Max(0, TotalCityWideProviders - CityWideEffectProviders);

        public static int DuplicateSignatureBuildings
        {
            get
            {
                int duplicates =
                    SignatureBuildings - SignatureTypes;

                return duplicates > 0 ? duplicates : 0;
            }
        }

        public static int GetUiVersion()
        {
            return unchecked((s_UiVersion * 397) + LocaleUtils.GetLocaleVersion());
        }

        public static bool NeedsRefresh(uint simulationFrame)
        {
            return !HasSnapshot ||
                   LastSnapshotSimulationFrame != simulationFrame;
        }

        public static void SetSnapshot(
            uint simulationFrame,
            int signatureBuildings,
            int signatureTypes,
            int cityWideEffectProviders,
            int duplicateCityWideProviders,
            int totalCityWideProviders)
        {
            LastSnapshotSimulationFrame = simulationFrame;

            SignatureBuildings = signatureBuildings;
            SignatureTypes = signatureTypes;
            CityWideEffectProviders = cityWideEffectProviders;
            DuplicateCityWideProviders = duplicateCityWideProviders;
            TotalCityWideProviders = totalCityWideProviders;

            HasSnapshot = true;
            s_UiVersion++;
        }

        public static void Clear()
        {
            HasSnapshot = false;
            LastSnapshotSimulationFrame = uint.MaxValue;

            SignatureBuildings = 0;
            SignatureTypes = 0;
            CityWideEffectProviders = 0;
            DuplicateCityWideProviders = 0;
            TotalCityWideProviders = 0;

            s_UiVersion++;
        }
    }
}
