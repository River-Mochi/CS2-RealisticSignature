// <copyright file="UniqueInfoviewPatch.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

namespace UniqueBuildings
{
    using System.Reflection;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Game.Tools;
    using HarmonyLib;
    using Unity.Entities;

    [HarmonyPatch(typeof(ToolBaseSystem), "UpdateInfoview")]
    internal static class UniqueInfoviewPatch
    {
        private static readonly MethodInfo? s_SetToolInfoview =
            typeof(ToolBaseSystem)
                .GetProperty(nameof(ToolBaseSystem.infoview))
                ?.GetSetMethod(nonPublic: true);

        private static bool s_MissingSetterLogged;
        private static bool s_SuppressionLogged;
        private static bool s_CompatibilityLogged;
        private static bool s_SetterFailureLogged;

        [HarmonyPrefix]
        private static bool Prefix(ToolBaseSystem __instance, Entity prefab)
        {
            if (Mod.Setting?.PreventAutomaticSignatureInfoviews != true ||
                __instance is not ObjectToolSystem ||
                GameManager.instance?.gameMode.IsGame() != true)
            {
                return true;
            }

            World? world = World.DefaultGameObjectInjectionWorld;
            UniquePlacementSystem? placement =
                world?.GetExistingSystemManaged<UniquePlacementSystem>();
            if (placement?.IsKnownUniqueBuilding(prefab) != true)
                return true;

            if (ToggleableOverlaysCompatibility.IsActive())
            {
                if (!s_CompatibilityLogged)
                {
                    s_CompatibilityLogged = true;
                    LogUtils.Info(
                        $"{Mod.ModTag} ToggleableOverlays is active; " +
                        "its infoview behavior takes priority.");
                }

                return true;
            }

            if (s_SetToolInfoview == null)
            {
                if (!s_MissingSetterLogged)
                {
                    s_MissingSetterLogged = true;
                    LogUtils.Warn(
                        $"{Mod.ModTag} Cannot suppress automatic infoview: " +
                        "ToolBaseSystem.infoview setter was not found.");
                }

                return true;
            }

            // Clear the tool's request before ToolSystem reads it. Its public
            // infoview remains available for deliberate player selection.
            try
            {
                if (__instance.infoview != null)
                    s_SetToolInfoview.Invoke(__instance, new object?[] { null });

                __instance.infomodes.Clear();
            }
            catch (System.Exception ex)
            {
                if (!s_SetterFailureLogged)
                {
                    s_SetterFailureLogged = true;
                    LogUtils.Warn(
                        $"{Mod.ModTag} Could not clear the tool's " +
                        "automatic infoview request.", ex);
                }

                return true;
            }

            if (!s_SuppressionLogged)
            {
                s_SuppressionLogged = true;
                LogUtils.Info(
                    $"{Mod.ModTag} Suppressed an automatic Unique-building infoview.");
            }

            return false;
        }
    }
}
