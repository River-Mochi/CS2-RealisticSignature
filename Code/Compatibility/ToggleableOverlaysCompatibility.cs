// <copyright file="ToggleableOverlaysCompatibility.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

namespace UniqueBuildings
{
    using Game.Modding;
    using Game.SceneFlow;

    internal static class ToggleableOverlaysCompatibility
    {
        // The loaded mod type in ToggleableOverlays, not its display name.
        private const string ModTypeName = "ToggleableOverlays.Mod";

        public static bool IsActive()
        {
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
                        return true;
                }
            }

            return false;
        }
    }
}
