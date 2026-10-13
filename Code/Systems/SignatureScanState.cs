// <copyright file="SignatureScanState.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignatureScanState.cs
// Cached Signature Status snapshot for the Options UI.

namespace SignatureBuildingControl
{
    internal static class SignatureScanState
    {
        private static int s_UiVersion;

        public static bool HasSnapshot { get; private set; }

        public static uint LastSnapshotSimulationFrame { get; private set; } =
            uint.MaxValue;

        public static int SignatureBuildings { get; private set; }

        public static int SignatureTypes { get; private set; }

        public static int ActiveBonusProviders { get; private set; }

        public static int DuplicateBonusProviders { get; private set; }

        public static int GetUiVersion()
        {
            return s_UiVersion;
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
            int activeBonusProviders,
            int duplicateBonusProviders)
        {
            LastSnapshotSimulationFrame = simulationFrame;

            SignatureBuildings = signatureBuildings;
            SignatureTypes = signatureTypes;
            ActiveBonusProviders = activeBonusProviders;
            DuplicateBonusProviders = duplicateBonusProviders;

            HasSnapshot = true;
            s_UiVersion++;
        }

        public static void Clear()
        {
            HasSnapshot = false;
            LastSnapshotSimulationFrame = uint.MaxValue;

            SignatureBuildings = 0;
            SignatureTypes = 0;
            ActiveBonusProviders = 0;
            DuplicateBonusProviders = 0;

            s_UiVersion++;
        }
    }
}
