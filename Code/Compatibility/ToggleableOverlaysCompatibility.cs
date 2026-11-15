// <copyright file="ToggleableOverlaysCompatibility.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

namespace UniqueBuildings
{
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.SceneFlow;

    internal static class ToggleableOverlaysCompatibility
    {
        // The loaded mod type in ToggleableOverlays, not its display name.
        private const string ModTypeName = "ToggleableOverlays.Mod";
        private static ParadoxModsDataSource? s_DataSource;
        private static bool s_CacheValid;
        private static bool s_Active;

        public static void Initialize()
        {
            ParadoxModsDataSource? dataSource =
                AssetDatabase<ParadoxMods>.instance?.dataSource as ParadoxModsDataSource;
            if (object.ReferenceEquals(dataSource, s_DataSource))
                return;

            if (s_DataSource != null)
            {
                s_DataSource.onAfterActivePlaysetOrModStatusChanged -=
                    Invalidate;
            }

            s_DataSource = dataSource;
            if (s_DataSource != null)
            {
                s_DataSource.onAfterActivePlaysetOrModStatusChanged +=
                    Invalidate;
            }

            Invalidate();
        }

        public static void Dispose()
        {
            if (s_DataSource != null)
            {
                s_DataSource.onAfterActivePlaysetOrModStatusChanged -=
                    Invalidate;
                s_DataSource = null;
            }

            Invalidate();
        }

        public static void Invalidate()
        {
            s_CacheValid = false;
            s_Active = false;
        }

        public static bool IsActive()
        {
            if (s_CacheValid)
                return s_Active;

            ModManager? modManager = GameManager.instance?.modManager;
            if (modManager == null)
                return false;

            foreach (ModManager.ModInfo modInfo in modManager)
            {
                if (modInfo.state != ModManager.ModInfo.State.Loaded)
                    continue;

                foreach (IMod instance in modInfo.instances)
                {
                    if (instance.GetType().FullName == ModTypeName)
                    {
                        s_Active = true;
                        s_CacheValid = true;
                        return true;
                    }
                }
            }

            s_Active = false;
            s_CacheValid = true;
            return false;
        }
    }
}
