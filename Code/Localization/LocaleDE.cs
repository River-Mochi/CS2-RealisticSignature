// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleDE.cs
// All 43 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

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
            "Mehrere einzigartige Gebäude", // 5
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
            "Mehrere Exemplare erlauben", // 21
            "**EIN** = mehrere Exemplare aller als einzigartig markierten Objekte platzieren, einschließlich Signaturgebäuden.\n**AUS** = normalerweise nur ein Exemplar pro Stadt, sofern kein anderer Mod mehrere erlaubt.", // 22
            "Platzierungsregel für einzigartige Objekte", // 23
            "Zeigt an, ob einzigartige Objekte derzeit mehrfach platziert werden dürfen.", // 24
            "Signaturgebäude", // 25
            "Zeigt platzierte Signaturgebäude, verschiedene Typen und zusätzliche Kopien.", // 26
            "Stadtweite Bonuseffekte", // 27
            "Zählt Signaturgebäude mit stadtweiten Bonuseffekten.\nLokale und Nahbereichseffekte sind nicht enthalten.", // 28
            "Bonusbericht ins Protokoll", // 29
            "Testet alle drei stadtweiten Bonusmodi, schreibt tatsächliche Stadtwerte ins Protokoll und stellt die Auswahl wieder her. Kein manueller Vergleich nötig.", // 30
            "Nahbereichsbericht ins Protokoll", // 31
            "Prüft alle drei Nahbereichsmodi im Protokoll und stellt die Auswahl wieder her.", // 32
            "Überflüssige Mods erkannt", // 33
            "Anarchy wird unterstützt und hier nicht aufgeführt.\nEntferne andere Mods für unbegrenzt einzigartige Gebäude; diese Funktion ist bereits enthalten.", // 34
            "Mod", // 35
            "Anzeigename dieses Mods.", // 36
            "Version", // 37
            "Installierte Modversion und Build-Typ.", // 38
            "Protokoll öffnen", // 39
            "Öffnet die Protokolldatei des Mods oder andernfalls den Protokollordner.", // 40
            "Pop-ups beim Massenfreischalten von Signaturgebäuden ausblenden", // 41
            "**EIN** (empfohlen, Standard) = störende Pop-ups beim Freischalten aller Signaturgebäude ausblenden.\n**AUS** = für jedes neu freigeschaltete Signaturgebäude ein Pop-up anzeigen. Beim Laden einer Stadt können Dutzende oder Hunderte erscheinen.\nNormale Freischaltmeldungen des Spiels bleiben unverändert.", // 42
        };

        public LocaleDE(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
