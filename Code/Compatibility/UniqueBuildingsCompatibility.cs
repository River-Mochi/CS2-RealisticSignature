// <copyright file="UnlimitedUniqueBuildingsCompatibility.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Compatibility/UnlimitedUniqueBuildingsCompatibility.cs
// Optional detection of the Unlimited Unique Buildings mod.

namespace SignatureBuildingControl
{
    using System;
    using System.Reflection;

    internal static class UnlimitedUniqueBuildingsCompatibility
    {
        private const string kModTypeName = "UnlimitedUniqueBuildings.Mod";

        private static bool s_IsInstalled;
        private static int s_LastAssemblyCount = -1;

        public static bool IsInstalled()
        {
            if (s_IsInstalled)
                return true;

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            if (assemblies.Length == s_LastAssemblyCount)
                return false;

            s_LastAssemblyCount = assemblies.Length;

            foreach (Assembly assembly in assemblies)
            {
                if (assembly.GetType(
                    kModTypeName,
                    throwOnError: false,
                    ignoreCase: false) == null)
                {
                    continue;
                }

                s_IsInstalled = true;
                return true;
            }

            return false;
        }
    }
}
