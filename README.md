# Realistic Signature Buildings

**Build the city you want without multiplying Signature bonuses unrealistically.**

A [Cities: Skylines II](https://www.paradoxinteractive.com/games/cities-skylines-ii/about) code mod by RiverMochi.

Place multiple Unique and Signature buildings for their appearance while choosing how their bonuses affect the city. Keep the game's stacked bonuses if you prefer, or prevent extra copies from stacking the same city-wide benefits.

## Features and defaults

| Setting | Default | What it does |
| --- | --- | --- |
| **City-wide bonuses** | **First copy only** | Count general city-wide Signature bonuses once per building type. |
| **City-wide Attractiveness** | **First copy only** | Count city-wide Signature Attractiveness once per building type, independently of other city-wide bonuses. |
| **Nearby neighborhood effects** | **Vanilla nearby effects** | Preserve each eligible copy's normal nearby/local effects. |
| **Unlock all Signature buildings** | **OFF** | Optionally bypass Signature progression requirements; does not unlock unrelated Unique buildings or missing DLC. |
| **Hide unlock pop-up spam** | **ON** | Suppress mass notifications caused by this mod's Signature unlock option; shown only when that option is enabled. |
| **Allow multiple copies** | **ON** | Allow extra copies of buildings marked Unique, including Signature buildings. |
| **Prevent automatic infoviews for Unique buildings** | **ON** | Prevent automatic infoview overlays during placement; manual infoviews remain available. |

Saved settings from an earlier version may keep the player's previous choices instead of using these new-install defaults.

## Signature bonus controls

### 1. General city-wide bonuses

- **First copy only (default):** count each Signature building type's general city-wide bonuses once, even with multiple copies.
- **No city-wide bonuses:** disable general Signature city-wide bonuses.
- **Vanilla Stacked Bonuses:** count eligible bonuses from every copy.

### 2. City-wide Attractiveness

City-wide Signature Attractiveness is controlled separately. City attractiveness can help attract tourists.

- **First copy only (default):** count the city-wide Attractiveness bonus once per Signature type.
- **Vanilla stacking:** count the city-wide Attractiveness bonus from every copy.
- **No attractiveness bonus:** ignore Signature city-wide Attractiveness bonuses.
- **Follow city-wide setting:** use the general city-wide bonus rule above.

These choices do **not** remove a building's own attractiveness.

### 3. Nearby neighborhood effects

- **Vanilla nearby effects (default):** keep nearby/local effects from every eligible Signature copy.
- **First copy only:** allow nearby effects from one copy of each Signature type.
- **No nearby effects:** disable normal Signature nearby effects.

Nearby effects are independent of the city-wide bonus settings. Abandoned-building local effects are unchanged.

## Unique placement and Signature unlocking

- **Allow multiple copies** works for buildings the game marks Unique, including Signature and non-Signature buildings. Turning the option OFF later does not bulldoze copies you have already built.
- **Unlock all Signature buildings** optionally makes loaded Signature buildings available without their usual population, zoning, or other progression requirements. It does not grant missing DLC or unlock unrelated Unique buildings.
- **Hide unlock pop-up spam** prevents mass notifications triggered by this mod's Signature unlocking. Normal game unlock notifications are not suppressed by this option.
- **Prevent automatic infoviews for Unique buildings** stops the automatic map overlay when placing Unique buildings. You can still open infoviews manually.
- Custom Signature assets are supported when they use the game's corresponding Signature components; available effects depend on the asset.

## Options Status and diagnostics

Go to **Options → Actions → Status** to see:

- **Signature buildings:** the number placed, the number of distinct types, and extra copies beyond the first of each type.
- **General city-wide bonuses:** active/total Signature bonus providers and how many are blocked by the general city-wide rule. Blocked providers are **not** the same as extra building copies.
- **City-wide Attractiveness:** the selected rule, **not** a numeric attractiveness total. This rule is independent of the general provider count.
- **Unique placement rule** and any detected redundant placement mods.

**Important:** Green bonus descriptions in the game's building information panel remain visible even when this mod limits or disables the corresponding bonus. They describe the original building, **not necessarily the bonus currently applied**.

Under **Options → About → Debug / Logging**:

- **Status report to log:** read-only report of current Signature counts, applied bonus rules, nearby effects, and actual whole-city modifier values. The numeric city Attractiveness modifier includes contributions beyond Signature buildings.
- **Compare bonus modes to log:** temporarily compares the available city-wide, Attractiveness, and nearby modes, then restores your selected rules.
- **Open Log:** opens the mod log (or Logs folder if the log is unavailable).

You do not need to run comparison reports during normal play.

## Compatibility and safe removal

- Compatible with **Anarchy**, including its Multiple Unique option. Other unlimited-Unique placement mods may be redundant.
- No Harmony patches and no required third-party mods.
- Removing the mod does not bulldoze placed duplicate buildings. Vanilla placement rules and bonuses return when the mod is no longer active and the city is reloaded.
- Back up your save before changing your mod setup. Different game updates, DLC, and custom assets may provide different bonuses.

## Localization

English, French, German, Spanish, Italian, Polish, Brazilian and European Portuguese, Turkish, Thai, Vietnamese, Japanese, Korean, Simplified Chinese, and Traditional Chinese. Diagnostic log reports are in English.

Contributions to improve translations are welcome.

## Feedback and development

Report issues through [GitHub Issues](https://github.com/River-Mochi/CS2-RealisticSignature/issues) or [Discord](https://discord.gg/gwXgvtyhjc). Include the mod version, selected settings, the mod log, and Player.log when relevant.

## Credits and license

Created by **RiverMochi**. Licensed under GPL-3.0-or-later with the Cities: Skylines II Linking Exception; see [GPL-LICENSE](GPL-LICENSE) and [LICENSE-EXCEPTION](LICENSE-EXCEPTION).
