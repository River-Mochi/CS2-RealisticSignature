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
        private const string kMultipleUniquePropertyName = "AllowPlacingMultipleUniqueBuildings";

        public static AnarchyMultipleUniqueState GetMultipleUniqueState()
        {
            try
            {
                Type? modType = FindAnarchyModType();
                if (modType == null)
                    return AnarchyMultipleUniqueState.NotInstalled;

                PropertyInfo? instanceProperty = modType.GetProperty(
                    "Instance",
                    BindingFlags.Public | BindingFlags.Static);

                object? instance = instanceProperty?.GetValue(null);
                if (instance == null)
                    return AnarchyMultipleUniqueState.Unknown;

                PropertyInfo? settingsProperty = modType.GetProperty(
                    kSettingsPropertyName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                object? settings = settingsProperty?.GetValue(instance);
                if (settings == null)
                    return AnarchyMultipleUniqueState.Unknown;

                PropertyInfo? multipleUniqueProperty = settings.GetType().GetProperty(
                    kMultipleUniquePropertyName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                if (multipleUniqueProperty?.GetValue(settings) is not bool enabled)
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
                AnarchyMultipleUniqueState.NotInstalled => "not installed",
                AnarchyMultipleUniqueState.Off => "installed, Multiple Unique OFF",
                AnarchyMultipleUniqueState.On => "installed, Multiple Unique ON",
                _ => "installed, state unknown",
            };
        }

        private static Type? FindAnarchyModType()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type? type = assembly.GetType(
                    kAnarchyModTypeName,
                    throwOnError: false,
                    ignoreCase: false);

                if (type != null)
                    return type;
            }

            return null;
        }
    }
}
