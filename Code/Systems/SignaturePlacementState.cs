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

        public static bool HasSnapshot { get; private set; }

        public static string StatusText { get; private set; } = "—";

        public static int GetUiVersion()
        {
            return s_UiVersion;
        }

        public static void SetSnapshot(
            int totalSignaturePrefabs,
            int uniqueRestrictedPrefabs,
            AnarchyMultipleUniqueState anarchyState)
        {
            HasSnapshot = true;

            if (totalSignaturePrefabs <= 0)
            {
                StatusText = "—";
            }
            else if (anarchyState == AnarchyMultipleUniqueState.On ||
                     uniqueRestrictedPrefabs == 0)
            {
                StatusText = "Multiple allowed";
            }
            else if (uniqueRestrictedPrefabs == totalSignaturePrefabs)
            {
                StatusText = "One of each";
            }
            else
            {
                StatusText = "Mixed rules";
            }

            s_UiVersion++;
        }

        public static void Clear()
        {
            HasSnapshot = false;
            StatusText = "—";
            s_UiVersion++;
        }
    }
}
