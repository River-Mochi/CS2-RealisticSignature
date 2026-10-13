// <copyright file="UniquePlacementState.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/UniquePlacementState.cs
// Cached player-facing Unique building placement status.

namespace SignatureBuildingControl
{
    internal static class UniquePlacementState
    {
        private static int s_UiVersion;
        private static int s_TotalUniqueBuildings;
        private static int s_UniqueRestrictedBuildings;

        private static AnarchyMultipleUniqueState s_LastAnarchyState =
            AnarchyMultipleUniqueState.NotInstalled;

        private static bool s_LastUnlimitedUniqueBuildingsInstalled;

        public static bool HasSnapshot { get; private set; }

        public static string StatusText
        {
            get
            {
                if (!HasSnapshot || s_TotalUniqueBuildings <= 0)
                    return "—";

                bool ourSetting =
                    Mod.Setting?.AllowMultipleUniqueBuildings ?? true;

                AnarchyMultipleUniqueState anarchyState =
                    GetCurrentAnarchyState();

                bool unlimitedUniqueBuildingsInstalled =
                    UniqueModsCompatibility.IsInstalled();

                if (ourSetting && s_UniqueRestrictedBuildings == 0)
                    return "Multiple allowed";

                if (anarchyState == AnarchyMultipleUniqueState.On)
                {
                    return ourSetting
                        ? "Multiple allowed"
                        : "Multiple allowed by Anarchy";
                }

                if (unlimitedUniqueBuildingsInstalled)
                {
                    return ourSetting
                        ? "Multiple allowed"
                        : "Multiple allowed by Unlimited Unique Buildings";
                }

                if (s_UniqueRestrictedBuildings == 0)
                {
                    return ourSetting
                        ? "Multiple allowed"
                        : "Multiple allowed by another mod";
                }

                if (s_UniqueRestrictedBuildings == s_TotalUniqueBuildings)
                    return "One of each";

                return "Mixed rules";
            }
        }

        public static int GetUiVersion()
        {
            AnarchyMultipleUniqueState currentAnarchy =
                AnarchyCompatibility.GetMultipleUniqueState();

            bool currentUnlimitedUniqueBuildings =
                UniqueModsCompatibility.IsInstalled();

            bool changed = false;

            if (currentAnarchy != AnarchyMultipleUniqueState.Unknown &&
                currentAnarchy != s_LastAnarchyState)
            {
                s_LastAnarchyState = currentAnarchy;
                changed = true;
            }

            if (currentUnlimitedUniqueBuildings !=
                s_LastUnlimitedUniqueBuildingsInstalled)
            {
                s_LastUnlimitedUniqueBuildingsInstalled =
                    currentUnlimitedUniqueBuildings;

                changed = true;
            }

            if (changed)
                s_UiVersion++;

            return s_UiVersion;
        }

        public static void SetSnapshot(
            int totalUniqueBuildings,
            int uniqueRestrictedBuildings,
            AnarchyMultipleUniqueState anarchyState,
            bool unlimitedUniqueBuildingsInstalled)
        {
            s_TotalUniqueBuildings = totalUniqueBuildings;
            s_UniqueRestrictedBuildings = uniqueRestrictedBuildings;

            if (anarchyState != AnarchyMultipleUniqueState.Unknown)
                s_LastAnarchyState = anarchyState;

            s_LastUnlimitedUniqueBuildingsInstalled =
                unlimitedUniqueBuildingsInstalled;

            HasSnapshot = true;
            s_UiVersion++;
        }

        public static void Clear()
        {
            HasSnapshot = false;

            s_TotalUniqueBuildings = 0;
            s_UniqueRestrictedBuildings = 0;

            s_LastAnarchyState =
                AnarchyMultipleUniqueState.NotInstalled;

            s_LastUnlimitedUniqueBuildingsInstalled = false;

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
