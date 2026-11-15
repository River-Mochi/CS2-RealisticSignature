// <copyright file="UniquePlacementState.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/UniquePlacementState.cs
// Cached player-facing Unique placement status.

namespace UniqueBuildings
{
    internal static class UniquePlacementState
    {
        private static int s_UiVersion;
        private static int s_TotalKnownUnique;
        private static int s_RestrictedUnique;

        private static int s_LastUniqueModsVersion;

        private static AnarchyMultipleUniqueState s_LastAnarchyState =
            AnarchyMultipleUniqueState.NotInstalled;

        public static bool HasSnapshot { get; private set; }

        public static string StatusText
        {
            get
            {
                if (!HasSnapshot || s_TotalKnownUnique <= 0)
                    return "—";

                bool ourSetting =
                    Mod.Setting?.AllowMultipleUniqueBuildings ?? true;

                AnarchyMultipleUniqueState anarchyState =
                    GetCurrentAnarchyState();

                if (ourSetting && s_RestrictedUnique == 0)
                    return "Multiple allowed";

                if (!ourSetting &&
                    anarchyState == AnarchyMultipleUniqueState.On)
                {
                    return "Multiple allowed by Anarchy";
                }

                if (!ourSetting &&
                    UniqueModsCompatibility.HasRedundantMods)
                {
                    return "Multiple unique enabled by another mod";
                }

                if (s_RestrictedUnique == 0)
                {
                    return ourSetting
                        ? "Multiple copies allowed"
                        : "Multiple unique enabled by another mod";
                }

                if (s_RestrictedUnique == s_TotalKnownUnique)
                    return "One of each";

                return "Mixed rules";
            }
        }

        public static int GetUiVersion()
        {
            bool changed = false;

            AnarchyMultipleUniqueState currentAnarchy =
                AnarchyCompatibility.GetMultipleUniqueState();

            if (currentAnarchy != AnarchyMultipleUniqueState.Unknown &&
                currentAnarchy != s_LastAnarchyState)
            {
                s_LastAnarchyState = currentAnarchy;
                changed = true;
            }

            int uniqueModsVersion =
                UniqueModsCompatibility.GetUiVersion();

            if (uniqueModsVersion != s_LastUniqueModsVersion)
            {
                s_LastUniqueModsVersion = uniqueModsVersion;
                changed = true;
            }

            if (changed)
                s_UiVersion++;

            return s_UiVersion;
        }

        public static void SetSnapshot(
            int totalKnownUnique,
            int restrictedUnique,
            AnarchyMultipleUniqueState anarchyState,
            int uniqueModsVersion)
        {
            s_TotalKnownUnique = totalKnownUnique;
            s_RestrictedUnique = restrictedUnique;

            if (anarchyState != AnarchyMultipleUniqueState.Unknown)
                s_LastAnarchyState = anarchyState;

            s_LastUniqueModsVersion = uniqueModsVersion;

            HasSnapshot = true;
            s_UiVersion++;
        }

        public static void Clear()
        {
            HasSnapshot = false;

            s_TotalKnownUnique = 0;
            s_RestrictedUnique = 0;

            s_LastAnarchyState =
                AnarchyMultipleUniqueState.NotInstalled;

            s_LastUniqueModsVersion =
                UniqueModsCompatibility.GetUiVersion();

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
