// <copyright file="Mod.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Mod.cs
// Entry point for Better Unique Buildings mod.

namespace UniqueBuildings
{
    using System;
    using System.Reflection;
    using Colossal.IO.AssetDatabase;
    using Colossal.Localization;
    using Colossal.Logging;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Modding;
    using Game.SceneFlow;
    using Game.Simulation;
    using Unity.Entities;

    public sealed class Mod : IMod
    {
        public const string ModName = "Better Unique Buildings";
        public const string ShortName = "Unique Buildings";
        public const string ModId = "BetterUniqueBuildings";
        public const string ModTag = "[BUB]";

#if DEBUG
        private const string kBuildType = "DEBUG";
#else
        private const string kBuildType = "RELEASE";
#endif

        private static bool s_BannerLogged;

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "0.1.0";

        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        public static UniqueBldgSettings? Setting { get; private set; }

        public static string BuildDisplayName =>
            kBuildType == "RELEASE" ? "Release" : "Debug";

        public void OnLoad(UpdateSystem updateSystem)
        {
            ShellOpen.Configure(s_Log, ModId, ModTag);

            if (!s_BannerLogged)
            {
                s_BannerLogged = true;

                LogUtils.Info(
                    $"{ModName} {ModTag} v{ModVersion} [{kBuildType}] OnLoad");
            }

            GameManager? gameManager = GameManager.instance;

            if (gameManager == null)
            {
                LogUtils.Warn(
                    $"{ModTag} GameManager.instance is null; " +
                    $"{ModName} cannot initialize.");

                return;
            }

            UniqueBldgSettings setting = new(this);
            Setting = setting;

            try
            {
                LocalizationManager? localizationManager =
                    gameManager.localizationManager;

                if (localizationManager == null)
                {
                    LogUtils.Warn(
                        $"{ModTag} LocalizationManager is null; " +
                        "locale sources were not registered.");
                }
                else
                {
                    localizationManager.AddSource(
                        "en-US",
                        new LocaleEN(setting));
                }
            }
            catch (Exception ex)
            {
                LogUtils.Warn(
                    $"{ModTag} Localization registration failed: " +
                    $"{ex.GetType().Name}: {ex.Message}",
                    ex);
            }

            try
            {
                UniqueBldgSettings defaults = new(this);

                AssetDatabase.global.LoadSettings(
                    ModId,
                    setting,
                    defaults,
                    userSetting: true);
            }
            catch (Exception ex)
            {
                LogUtils.Warn(
                    $"{ModTag} LoadSettings failed; using defaults.",
                    ex);
            }

            try
            {
                setting.RegisterInOptionsUI();
            }
            catch (Exception ex)
            {
                LogUtils.Warn(
                    $"{ModTag} RegisterInOptionsUI failed; " +
                    "mod options may be missing.",
                    ex);
            }

                    updateSystem.UpdateAt<SignatureUnlockSystem>(
                        SystemUpdatePhase.PrefabUpdate);

                    updateSystem.UpdateAt<UniquePlacementSystem>(
                        SystemUpdatePhase.PrefabUpdate);

                    updateSystem.UpdateAt<SignatureBonusSystem>(
                        SystemUpdatePhase.PrefabUpdate);

                    updateSystem.UpdateAt<SignatureBonusWatchSystem>(
                        SystemUpdatePhase.ModificationEnd);

                    updateSystem.UpdateAfter<
                        SignatureBonusSystem,
                        SignatureBonusWatchSystem>(
                            SystemUpdatePhase.ModificationEnd);

                    updateSystem.UpdateAfter<
                        SignatureCityModifierFilterSystem,
                        ModificationBarrier4>(
                            SystemUpdatePhase.Modification4);

                    updateSystem.UpdateAfter<
                        SignatureCityModifierFilterSystem,
                        CityModifierUpdateSystem>(
                            SystemUpdatePhase.GameSimulation);

                    updateSystem.UpdateAfter<
                        SignatureNearbyEffectSystem,
                        LocalEffectSystem>(
                            SystemUpdatePhase.Modification5);

                    updateSystem.UpdateAt<SignatureScanSystem>(
                        SystemUpdatePhase.PrefabUpdate);

        }

        public void OnDispose()
        {
            try
            {
                World? world =
                    World.DefaultGameObjectInjectionWorld;

                world?.GetExistingSystemManaged<SignatureUnlockSystem>()
                    ?.RestoreOwnedChangesForDispose();

                world?.GetExistingSystemManaged<UniquePlacementSystem>()
                    ?.RestoreOwnedChangesForDispose();

                world?.GetExistingSystemManaged<SignatureBonusSystem>()
                    ?.RestoreOwnedChangesForDispose();

                world?.GetExistingSystemManaged<SignatureNearbyEffectSystem>()
                    ?.RestoreForDispose();
            }
            catch
            {
            }

            Setting?.UnregisterInOptionsUI();
            Setting = null;

            UniquePlacementState.Clear();
            SignatureScanState.Clear();
        }
    }
}
