// <copyright file="SignatureScanState.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignatureScanState.cs
// Small runtime-only state shared by the manual Signature scan and Options UI.

namespace SignatureBuildingControl
{
    internal static class SignatureScanState
    {
        private static bool s_ScanRequested;

        public static bool HasSnapshot
        {
            get;
            private set;
        }

        public static int SignatureBuildings
        {
            get;
            private set;
        }

        public static int SignatureTypes
        {
            get;
            private set;
        }

        public static int ActiveBonusProviders
        {
            get;
            private set;
        }

        public static int DuplicateBonusProviders
        {
            get;
            private set;
        }

        public static void RequestScan()
        {
            s_ScanRequested = true;
        }

        public static bool ConsumeRequest()
        {
            if (!s_ScanRequested)
            {
                return false;
            }

            s_ScanRequested = false;
            return true;
        }

        public static void SetSnapshot(
            int signatureBuildings,
            int signatureTypes,
            int activeBonusProviders,
            int duplicateBonusProviders)
        {
            SignatureBuildings = signatureBuildings;
            SignatureTypes = signatureTypes;
            ActiveBonusProviders = activeBonusProviders;
            DuplicateBonusProviders = duplicateBonusProviders;

            HasSnapshot = true;
        }

        public static void Clear()
        {
            s_ScanRequested = false;

            HasSnapshot = false;

            SignatureBuildings = 0;
            SignatureTypes = 0;
            ActiveBonusProviders = 0;
            DuplicateBonusProviders = 0;
        }
    }
}
