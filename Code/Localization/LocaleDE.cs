// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleDE.cs
// All 45 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleDE : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Realistische Signaturgebäude)", // 0
            "Aktionen", // 1
            "Über", // 2
            "Signaturgebäude-Boni", // 3
            "Signaturgebäude freischalten", // 4
            "Platzierung", // 5
            "Status", // 6
            "Info", // 7
            "Debug / Protokoll", // 8
            "Stadtweite Signaturgebäude-Boni", // 9
            "<Nur erstes Exemplar> = jeder Signaturgebäudetyp gewährt seinen stadtweiten Bonus nur einmal.\n<Keine stadtweiten Boni> = deaktiviert stadtweite Signaturgebäude-Boni.\n<Vanilla-Stapelung> = jedes Exemplar gewährt den stadtweiten Bonus.\nNahbereichseffekte haben eine eigene Einstellung. Die Gebäudeattraktivität bleibt unverändert.", // 10
            "Nur erstes Exemplar", // 11
            "Keine stadtweiten Boni", // 12
            "Vanilla-Stapelung", // 13
            "Nahbereichseffekte von Signaturgebäuden", // 14
            "<Vanilla-Nahbereichseffekte> = jedes Exemplar erzeugt seine normalen Effekte in der Umgebung.\n<Nur erstes Exemplar> = nur ein Exemplar je Gebäudetyp erzeugt Nahbereichseffekte.\n<Keine Nahbereichseffekte> = deaktiviert die normalen Nahbereichseffekte von Signaturgebäuden.\nEffekte verlassener Gebäude und die Gebäudeattraktivität bleiben erhalten.", // 15
            "Vanilla-Nahbereichseffekte", // 16
            "Nur erstes Exemplar", // 17
            "Keine Nahbereichseffekte", // 18
            "Freischaltbedingungen für Signaturgebäude aufheben", // 19
            "**EIN** = alle Signaturgebäude ohne Einwohner-, Zonen- oder Fortschrittsanforderungen verfügbar machen.\n**AUS** = normaler Spielfortschritt.", // 20
            "Pop-ups beim Massenfreischalten von Signaturgebäuden ausblenden", // 21
            "**EIN** (empfohlen, Standard) = Pop-ups beim massenhaften Freischalten durch diesen Mod ausblenden.\n**AUS** = für jedes durch diesen Mod neu freigeschaltete Signaturgebäude ein Pop-up zeigen. Es können Dutzende oder Hunderte erscheinen.\nNormale Spielmeldungen bleiben sichtbar, auch für neue Gebäude aus Spielupdates, DLC, Region-Paketen oder dem Stadtfortschritt.", // 22
            "Mehrere Exemplare erlauben", // 23
            "**EIN** = mehrere Exemplare aller als einzigartig markierten Objekte platzieren, einschließlich Signaturgebäuden.\n**AUS** = normalerweise nur ein Exemplar pro Stadt, sofern kein anderer Mod mehrere erlaubt.", // 24
            "Automatische Infoviews für einzigartige Gebäude verhindern", // 25
            "Verhindert beim Platzieren einzigartiger Gebäude einschließlich Signaturgebäuden das automatische Öffnen des Infoview-Fensters und der farbigen Karte. Infoviews lassen sich weiterhin manuell öffnen. Andere Bauwerkzeuge bleiben unverändert. Ist Toggleable Overlays aktiv, hat es Vorrang. Standard: AUS.", // 26
            "Platzierungsregel für einzigartige Objekte", // 27
            "Zeigt an, ob einzigartige Objekte derzeit mehrfach platziert werden dürfen.", // 28
            "Signaturgebäude", // 29
            "Zeigt platzierte Signaturgebäude, verschiedene Typen und zusätzliche Kopien.", // 30
            "Stadtweite Bonuseffekte", // 31
            "Zählt Signaturgebäude mit stadtweiten Bonuseffekten.\nLokale und Nahbereichseffekte sind nicht enthalten.", // 32
            "Überflüssige Mods erkannt", // 33
            "Anarchy wird unterstützt und hier nicht aufgeführt.\nEntferne andere Mods für unbegrenzt einzigartige Gebäude; diese Funktion ist bereits enthalten.", // 34
            "Mod", // 35
            "Anzeigename dieses Mods.", // 36
            "Version", // 37
            "Installierte Modversion und Build-Typ.", // 38
            "Statusbericht ins Log", // 39
            "Schreibt den aktuellen Stand der Signaturgebäude, stadtweiten Boni und Nahbereichseffekte ins Log. Ändert keine Einstellungen oder Effekte. Zuerst eine Stadt laden.", // 40
            "Bonusmodi im Log vergleichen", // 41
            "Testet vorübergehend alle stadtweiten und Nahbereichsmodi, während das Spiel im Optionsmenü pausiert ist. Danach werden deine gewählten Modi erneut angewendet. Ergebnisse stehen im Mod-Log. Zuerst eine Stadt laden.", // 42
            "Protokoll öffnen", // 43
            "Öffnet die Protokolldatei des Mods oder andernfalls den Protokollordner.", // 44
            "Noch keine Stadt geladen", // 45
            "Wird geladen…", // 46
            "Lade zuerst eine Stadt, um den Status zu sehen", // 47
            "Mehrere Exemplare erlaubt", // 48
            "Mehrere Exemplare durch Anarchy erlaubt", // 49
            "Mehrere einzigartige Gebäude durch anderen Mod erlaubt", // 50
            "Nur eines pro Typ", // 51
            "Gemischte Regeln", // 52
            "{0} platziert | {1} Typen | {2} zusätzliche Exemplare", // 53
            "{0} aktive Bonusgeber | {1} doppelte Bonusgeber", // 54
            "Keine", // 55
        };

        public LocaleDE(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
