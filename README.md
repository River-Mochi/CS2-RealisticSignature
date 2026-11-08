# Realistic Signature Buildings

**Build the city you want, without making its economy unrealistically easy.**

A [Cities: Skylines II](https://www.paradoxinteractive.com/games/cities-skylines-ii/about) code mod by RiverMochi. Place multiple Unique and Signature buildings for their appearance, without necessarily multiplying the same bonuses. Choose a more balanced simulation **or** keep the game's original stacked effects.

## Features and defaults

| Setting | Default | What it does |
| --- | --- | --- |
| **City-wide Signature bonuses** | **First copy only** | Apply each Signature type's city-wide bonuses once, instead of stacking bonuses from duplicate copies. |
| **Nearby Signature effects** | **Vanilla nearby effects** | Keep each copy's normal local effects; this is independent of the city-wide setting. |
| **Unlock Signature requirements** | **OFF** | Optionally unlock condition-gated Signature buildings without progression requirements. |
| **Allow multiple copies** | **ON** | Place extra copies of objects marked Unique, including Signature buildings. |

### City-wide Signature bonuses

- **First copy only** (default): only one copy of each Signature building type contributes its city-wide bonus.
- **No city-wide bonuses**: disable those city-wide Signature bonuses.
- **Vanilla Stacked Bonuses**: let every eligible Signature copy contribute its city-wide bonus, just as in the base game.

### Nearby Signature effects

- **Vanilla nearby effects** (default): normal local effects from every eligible copy.
- **First copy only**: one copy of each Signature type provides nearby effects.
- **No nearby effects**: disable normal nearby Signature effects.

**The two controls are independent.** You can prevent duplicate city-wide economic bonuses while keeping local happiness or other nearby effects from each copy. Building attractiveness and abandoned-building effects are preserved.

### Signature unlocking and unique placement

- Enable **Unlock Signature requirements** to make eligible Signature prefabs available without meeting population, zoning, building-count, or other progression requirements. It works on existing cities.
- The bulk unlock bypasses the usual unlock-event flood, so it does **not** create dozens of “New Signature Building” popups. When the setting is OFF, the base game's progression remains in effect.
- **Allow multiple copies** lets you place additional Unique buildings. Disabling it later does **not** bulldoze copies already built.
- Custom Signature assets that use the game's `SignatureBuildingData` component are included when the city loads; their actual available effects depend on the asset.

## Status and diagnostics

The Options page shows Signature building counts, different types, duplicate copies, and active city-wide bonus providers.

**Bonus Report to log** and **Nearby Report to log** check the three modes and restore the player's selected settings. Find the logs using **Options → About → Debug / Logging → Open Log**.

## Compatibility

- Supports Anarchy's Multiple Unique setting. Separate mods devoted solely to unlimited Unique building placement can overlap with this feature.
- No Harmony patching and no required third-party mods.
- Keep a backup save before changing mods or testing combinations. Some custom buildings may have different effects or no applicable bonuses.

## Localization

Options labels and tooltips are available in English, French, German, Spanish, Italian, Polish, Brazilian and European Portuguese, Turkish, Thai, Vietnamese, Japanese, Korean, Simplified Chinese, and Traditional Chinese. Some live Status text is still displayed in English.

English source of truth: [`Code/Localization/LocaleEN.cs`](Code/Localization/LocaleEN.cs). Contributions to improve translations are welcome.

## Feedback and development

Report bugs and suggestions through [GitHub Issues](https://github.com/River-Mochi/CS2-RealisticSignature/issues), or join the [Discord](https://discord.gg/gwXgvtyhjc). Include the game version, mod version, exact settings, and relevant log excerpts.

To build from source on the configured Cities: Skylines II modding environment:

```bash
dotnet build Code/UniqueBuildings.csproj -c Release
```

## Credits and license

Created by **RiverMochi**. Licensed under GPL-3.0-or-later with the Cities: Skylines II Linking Exception; see [GPL-LICENSE](GPL-LICENSE) and [LICENSE-EXCEPTION](LICENSE-EXCEPTION).

**Paradox Mods release:** v0.5.0 (first public release planned).
