// <copyright file="UniqueModsCompatibility.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Compatibility/UniqueModsCompatibility.cs
// Detects redundant mods whose main purpose overlaps our Multiple Unique feature.

namespace SignatureBuildingControl
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using CS2Shared.RiverMochi;

    internal static class UniqueModsCompatibility
    {
        private sealed class KnownMod
        {
            public KnownMod(string displayName, string typeName)
            {
                DisplayName = displayName;
                TypeName = typeName;
            }

            public string DisplayName { get; }

            public string TypeName { get; }
        }

        private static readonly KnownMod[] s_KnownMods =
        {
            new(
                "Unlimited Unique Buildings",
                "UnlimitedUniqueBuildings.Mod"),
        };

        private static readonly List<string> s_DetectedMods = new();
        private static readonly HashSet<string> s_LoggedMods = new();

        private static int s_LastAssemblyCount = -1;
        private static int s_UiVersion;
        private static string s_StatusText = "None";

        public static bool HasRedundantMods
        {
            get
            {
                ScanIfNeeded();
                return s_DetectedMods.Count > 0;
            }
        }

        public static string StatusText
        {
            get
            {
                ScanIfNeeded();
                return s_StatusText;
            }
        }

        public static int GetUiVersion()
        {
            ScanIfNeeded();
            return s_UiVersion;
        }

        public static void LogDetectedMods()
        {
            ScanIfNeeded();

            for (int i = 0; i < s_DetectedMods.Count; i++)
            {
                string modName = s_DetectedMods[i];

                if (!s_LoggedMods.Add(modName))
                    continue;

                LogUtils.Warn(
                    $"{Mod.ModTag} {modName} detected. " +
                    "Mod is redundant with our Multiple Unique Buildings feature; " +
                    "remove redundant mods if you want to avoid confusing overlapping controls.");
            }
        }

        private static void ScanIfNeeded()
        {
            Assembly[] assemblies =
                AppDomain.CurrentDomain.GetAssemblies();

            if (assemblies.Length == s_LastAssemblyCount)
                return;

            s_LastAssemblyCount = assemblies.Length;

            List<string> detected = new();

            for (int i = 0; i < s_KnownMods.Length; i++)
            {
                KnownMod knownMod = s_KnownMods[i];

                for (int j = 0; j < assemblies.Length; j++)
                {
                    if (assemblies[j].GetType(
                        knownMod.TypeName,
                        throwOnError: false,
                        ignoreCase: false) == null)
                    {
                        continue;
                    }

                    detected.Add(knownMod.DisplayName);
                    break;
                }
            }

            string newStatus =
                detected.Count == 0
                    ? "None"
                    : string.Join(", ", detected);

            s_DetectedMods.Clear();
            s_DetectedMods.AddRange(detected);

            if (newStatus == s_StatusText)
                return;

            s_StatusText = newStatus;
            s_UiVersion++;
        }
    }
}
