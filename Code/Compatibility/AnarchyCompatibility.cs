// <copyright file="AnarchyCompatibility.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Compatibility/AnarchyCompatibility.cs
// Optional runtime check for Anarchy's actual Multiple Unique Buildings setting.
// No hard dependency on Anarchy.dll.

namespace SignatureBuildingControl
{
    using System;
    using System.Reflection;

    internal enum AnarchyMultipleUniqueState
    {
        NotInstalled,
        Off,
        On,
        Unknown,
    }

    internal static class AnarchyCompatibility
    {
        private const string kAnarchyModTypeName = "Anarchy.AnarchyMod";
        private const string kSettingsPropertyName = "Settings";
        private const string kMultipleUniquePropertyName =
            "AllowPlacingMultipleUniqueBuildings";

        private static Type? s_AnarchyModType;
        private static PropertyInfo? s_InstanceProperty;
        private static PropertyInfo? s_SettingsProperty;
        private static PropertyInfo? s_MultipleUniqueProperty;

        private static int s_LastAssemblyCount = -1;

        public static AnarchyMultipleUniqueState GetMultipleUniqueState()
        {
            try
            {
                Type? modType = FindAnarchyModType();
                if (modType == null)
                    return AnarchyMultipleUniqueState.NotInstalled;

                s_InstanceProperty ??= modType.GetProperty(
                    "Instance",
                    BindingFlags.Public | BindingFlags.Static);

                object? instance = s_InstanceProperty?.GetValue(null);
                if (instance == null)
                    return AnarchyMultipleUniqueState.Unknown;

                s_SettingsProperty ??= modType.GetProperty(
                    kSettingsPropertyName,
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.NonPublic);

                object? settings = s_SettingsProperty?.GetValue(instance);
                if (settings == null)
                    return AnarchyMultipleUniqueState.Unknown;

                Type settingsType = settings.GetType();

                if (s_MultipleUniqueProperty == null ||
                    s_MultipleUniqueProperty.DeclaringType != settingsType)
                {
                    s_MultipleUniqueProperty = settingsType.GetProperty(
                        kMultipleUniquePropertyName,
                        BindingFlags.Instance |
                        BindingFlags.Public |
                        BindingFlags.NonPublic);
                }

                if (s_MultipleUniqueProperty?.GetValue(settings) is not bool enabled)
                    return AnarchyMultipleUniqueState.Unknown;

                return enabled
                    ? AnarchyMultipleUniqueState.On
                    : AnarchyMultipleUniqueState.Off;
            }
            catch
            {
                return AnarchyMultipleUniqueState.Unknown;
            }
        }

        public static string GetLogText(AnarchyMultipleUniqueState state)
        {
            return state switch
            {
                AnarchyMultipleUniqueState.NotInstalled =>
                    "not installed",

                AnarchyMultipleUniqueState.Off =>
                    "installed, Multiple Unique OFF",

                AnarchyMultipleUniqueState.On =>
                    "installed, Multiple Unique ON",

                _ =>
                    "installed, state unknown",
            };
        }

        private static Type? FindAnarchyModType()
        {
            if (s_AnarchyModType != null)
                return s_AnarchyModType;

            Assembly[] assemblies =
                AppDomain.CurrentDomain.GetAssemblies();

            // Avoid rescanning every UI refresh when nothing new has loaded.
            if (assemblies.Length == s_LastAssemblyCount)
                return null;

            s_LastAssemblyCount = assemblies.Length;

            foreach (Assembly assembly in assemblies)
            {
                Type? type = assembly.GetType(
                    kAnarchyModTypeName,
                    throwOnError: false,
                    ignoreCase: false);

                if (type == null)
                    continue;

                s_AnarchyModType = type;
                return type;
            }

            return null;
        }
    }
}
