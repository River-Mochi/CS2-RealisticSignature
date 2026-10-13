// <copyright file="SignaturePlacementState.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/SignaturePlacementState.cs
// Cached player-facing placement status.

namespace SignatureBuildingControl
{
    internal static class SignaturePlacementState
    {
        private static int s_UiVersion;
        private static int s_TotalSignaturePrefabs;
        private static int s_UniqueRestrictedPrefabs;

        private static AnarchyMultipleUniqueState s_LastAnarchyState =
            AnarchyMultipleUniqueState.NotInstalled;

        public static bool HasSnapshot { get; private set; }

        public static string StatusText
        {
            get
            {
                if (!HasSnapshot || s_TotalSignaturePrefabs <= 0)
                    return "—";

                bool sbcEnabled =
                    Mod.Setting?.AllowMultipleSignatureBuildings ?? false;

                AnarchyMultipleUniqueState anarchyState =
                    GetCurrentAnarchyState();

                if (sbcEnabled && s_UniqueRestrictedPrefabs == 0)
                    return "Multiple allowed";

                if (!sbcEnabled &&
                    anarchyState == AnarchyMultipleUniqueState.On)
                {
                    return "Multiple allowed by Anarchy";
                }

                if (s_UniqueRestrictedPrefabs == 0)
                {
                    return sbcEnabled
                        ? "Multiple allowed"
                        : "Multiple allowed by another mod";
                }

                if (s_UniqueRestrictedPrefabs == s_TotalSignaturePrefabs)
                    return "One of each";

                return "Mixed rules";
            }
        }

        public static int GetUiVersion()
        {
            AnarchyMultipleUniqueState current =
                AnarchyCompatibility.GetMultipleUniqueState();

            if (current != AnarchyMultipleUniqueState.Unknown &&
                current != s_LastAnarchyState)
            {
                s_LastAnarchyState = current;
                s_UiVersion++;
            }

            return s_UiVersion;
        }

        public static void SetSnapshot(
            int totalSignaturePrefabs,
            int uniqueRestrictedPrefabs,
            AnarchyMultipleUniqueState anarchyState)
        {
            s_TotalSignaturePrefabs = totalSignaturePrefabs;
            s_UniqueRestrictedPrefabs = uniqueRestrictedPrefabs;

            if (anarchyState != AnarchyMultipleUniqueState.Unknown)
                s_LastAnarchyState = anarchyState;

            HasSnapshot = true;
            s_UiVersion++;
        }

        public static void Clear()
        {
            HasSnapshot = false;

            s_TotalSignaturePrefabs = 0;
            s_UniqueRestrictedPrefabs = 0;

            s_LastAnarchyState =
                AnarchyMultipleUniqueState.NotInstalled;

            s_UiVersion++;
        }

        private static AnarchyMultipleUniqueState GetCurrentAnarchyState()
        {
            AnarchyMultipleUniqueState current =
                AnarchyCompatibility.GetMultipleUniqueState();

            if (current != AnarchyMultipleUniqueState.Unknown)
            {
                s_LastAnarchyState = current;
                return current;
            }

            return s_LastAnarchyState;
        }
    }
}
