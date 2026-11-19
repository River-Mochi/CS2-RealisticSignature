// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleDE.cs
// All 64 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleDE : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Signatur)", // 0
            "Aktionen", // 1
            "Über", // 2
            "Signaturgebäude-Boni", // 3
            "Signaturgebäude freischalten", // 4
            "Platzierung", // 5
            "Status", // 6
            "Info", // 7
            "Debug / Protokoll", // 8
            "Stadtweite Boni einzigartiger Gebäude", // 9
            "<Nur erstes Exemplar> **(Standard)** = ein Stadtbonus pro einzigartigem Gebäudetyp.\n<Keine stadtweiten Boni> = allgemeine Boni einzigartiger Gebäude aus; Attraktivität separat.\n<Vanilla-Stapelung> = jede Kopie zählt.\n**Grüne Bonuszeilen** bleiben im Gebäude-Infobereich sichtbar, auch wenn der Bonus blockiert ist.\nWerte: **Aktionen > Status** oder **Über > Statusbericht ins Protokoll**.", // 10
            "Nur erstes Exemplar", // 11
            "Keine stadtweiten Boni", // 12
            "Vanilla-Stapelung", // 13
            "Stadtweite Attraktivität", // 14
            "<Nur erstes Exemplar> **(Standard)** = Stadtattraktivität einmal pro geeignetem einzigartigem Gebäudetyp.\n<Vanilla-Stapelung> = jede Kopie zählt.\n<Kein Attraktivitätsbonus> = diese Stadtboni aus.\n<Stadtweite Einstellung übernehmen> = allgemeine Regel nutzen.\n**Attraktivität lockt Touristen an.** Der eigene Gebäudewert bleibt.\n**Grüne Bonuszeilen** sind feste Beschreibungen.", // 15
            "Stadtweite Einstellung übernehmen", // 16
            "Nur erste Kopie", // 17
            "Vanilla-Stapelung", // 18
            "Kein Attraktivitätsbonus", // 19
            "Nahbereichseffekte einzigartiger Gebäude", // 20
            "<Vanilla-Nahbereichseffekte> **(Standard)** = jede einzigartige Gebäudekopie behält ihre Effekte.\n<Nur erstes Exemplar> = eine Kopie je Gebäudetyp.\n<Keine Nahbereichseffekte> = normale Effekte aus, Strafen verlassener Gebäude bleiben.\n**Gebäudeattraktivität** bleibt unverändert.", // 21
            "Vanilla-Nahbereichseffekte", // 22
            "Nur erstes Exemplar", // 23
            "Keine Nahbereichseffekte", // 24
            "Alle Signaturgebäude freischalten", // 25
            "**EIN** = alle Signaturgebäude ohne Einwohner-, Zonen- oder Fortschrittsanforderungen verfügbar machen.\n**AUS** = normaler Spielfortschritt.\nStandard: AUS. Gilt nur für Signaturgebäude, nicht für andere einzigartige Gebäude.", // 26
            "Pop-ups beim Massenfreischalten von Signaturgebäuden ausblenden", // 27
            "**EIN** (empfohlen, Standard) = Pop-ups beim massenhaften Freischalten durch diesen Mod ausblenden.\n**AUS** = für jedes durch diesen Mod neu freigeschaltete Signaturgebäude ein Pop-up zeigen. Es können Dutzende oder Hunderte erscheinen.\nNormale Spielmeldungen bleiben sichtbar, auch für neue Gebäude aus Spielupdates, DLC, Region-Paketen oder dem Stadtfortschritt.", // 28
            "Mehrere Exemplare erlauben", // 29
            "**EIN** = mehrere Exemplare aller als einzigartig markierten Objekte platzieren, einschließlich Signaturgebäuden.\n**AUS** = normalerweise nur ein Exemplar pro Stadt, sofern kein anderer Mod mehrere erlaubt.", // 30
            "Gebäude beim Platzieren klar anzeigen", // 31
            "**EIN (Standard)** = <freie Sicht auf Gebäude>: keine automatische Abdunklung, farbige Kartenansicht oder Infoview beim Platzieren einzigartiger Gebäude.\n**AUS** = normale automatische Infoviews.\nManuell bleiben Infoviews verfügbar. <Toggle Overlays> hat Vorrang.", // 32
            "Platzierungsregel für einzigartige Objekte", // 33
            "**Mehrere Kopien erlaubt** = Einmal-pro-Stadt-Sperre ist aus.\n**Nur eines je Typ** = normale Sperre aktiv.\n<Anarchy> kann Kopien ebenfalls erlauben.\nDies betrifft Platzierung, nicht Bonus-Stapelung.", // 34
            "Signaturgebäude", // 35
            "**Gebäude** = alle platzierten Signaturgebäude.\n**Typen** = unterschiedliche Signaturtypen.\n<Extra-Kopien> = weitere Exemplare über das erste hinaus.\nAuch Gebäude ohne Stadtbonus zählen.", // 36
            "Stadtweite Boni von Signaturgebäuden", // 37
            "**Aktiv / Gesamt** = Stadtbonus-Quellen gemäß allgemeiner Regel / alle vorhandenen.\n<Blockiert> = durch diese Regel ausgeschlossen, nicht alle Extra-Gebäude.\n**Attraktivität ist unabhängig:** blockierte Quellen können trotzdem Attraktivität geben.\nNahbereich und Gebäudewert sind getrennt.", // 38
            "Überflüssige Mods erkannt", // 39
            "**Erste Kopie** = ein Attraktivitätsbonus je Typ.\n<Vanilla-Stapelung> = alle Kopien.\n<Kein Bonus> = Signatur-Stadtbonus aus.\n<Einstellung übernehmen> = allgemeine Regel.\n**Zeigt die gewählte Regel, keinen Bonuswert.**\nTatsächliche Stadtwerte: **Über > Statusbericht ins Protokoll**. Grüner Infotext bleibt.", // 40
            "Noch keine Stadt geladen", // 41
            "Wird geladen…", // 42
            "Lade zuerst eine Stadt, um den Status zu sehen", // 43
            "Mehrere Exemplare erlaubt", // 44
            "Mehrere Exemplare durch Anarchy erlaubt", // 45
            "Mehrere einzigartige Gebäude durch anderen Mod erlaubt", // 46
            "Nur eines pro Typ", // 47
            "Unbegrenzte Exemplare weiterhin möglich", // 48
            "{0} platziert | {1} Typen | {2} zusätzliche Exemplare", // 49
            "{0}/{1} aktiv | {2} gesperrt", // 50
            "Keine", // 51
            "Mod", // 52
            "Anzeigename dieses Mods.", // 53
            "Version", // 54
            "Installierte Modversion und Build-Typ.", // 55
            "Statusbericht ins Log", // 56
            "Schreibt den aktuellen Stand der Signaturgebäude, stadtweiten Boni und Nahbereichseffekte ins Log. Ändert keine Einstellungen oder Effekte. Zuerst eine Stadt laden.", // 57
            "Bonusmodi im Log vergleichen", // 58
            "Testet vorübergehend alle stadtweiten und Nahbereichsmodi, während das Spiel im Optionsmenü pausiert ist. Danach werden deine gewählten Modi erneut angewendet. Ergebnisse stehen im Mod-Log. Zuerst eine Stadt laden.", // 59
            "Protokoll öffnen", // 60
            "Öffnet die Protokolldatei des Mods oder andernfalls den Protokollordner.", // 61
            "Stadtweite Boni der anderen einzigartigen Gebäude", // 62
            "Stadtweite Boni einzigartiger Gebäude außerhalb der Signatur-Kategorie, z. B. Rathaus.\nAktiv / Gesamt = berücksichtigte / vorhandene Bonusquellen. Blockiert = durch die Regel ausgeschlossen. Normale Gebäude zählen nicht.", // 63
        };

        public LocaleDE(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
