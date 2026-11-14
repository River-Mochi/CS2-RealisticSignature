// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePL.cs
// All 43 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocalePL : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Realistyczne budynki charakterystyczne)", // 0
            "Działania", // 1
            "O modzie", // 2
            "Premie budynków charakterystycznych", // 3
            "Odblokowywanie budynków charakterystycznych", // 4
            "Umieszczanie", // 5
            "Stan", // 6
            "Informacje", // 7
            "Debugowanie / Dziennik", // 8
            "Ogólnomiejskie premie budynków charakterystycznych", // 9
            "<Tylko pierwszy egzemplarz> = każdy typ budynku charakterystycznego przyznaje premię ogólnomiejską tylko raz.\n<Bez premii ogólnomiejskich> = wyłącza te premie.\n<Zwykłe sumowanie> = każdy egzemplarz przyznaje swoją premię.\nEfekty w pobliżu mają osobne ustawienie. Atrakcyjność budynku pozostaje bez zmian.", // 10
            "Tylko pierwszy egzemplarz", // 11
            "Bez premii ogólnomiejskich", // 12
            "Zwykłe sumowanie", // 13
            "Efekty budynków charakterystycznych w pobliżu", // 14
            "<Zwykłe efekty w pobliżu> = każda kopia zapewnia normalne efekty w okolicy.\n<Tylko pierwszy egzemplarz> = efekty zapewnia jeden egzemplarz każdego typu.\n<Bez efektów w pobliżu> = wyłącza zwykłe efekty lokalne budynków charakterystycznych.\nEfekty opuszczonych budynków i atrakcyjność pozostają bez zmian.", // 15
            "Zwykłe efekty w pobliżu", // 16
            "Tylko pierwszy egzemplarz", // 17
            "Bez efektów w pobliżu", // 18
            "Pomiń wymagania odblokowania budynków charakterystycznych", // 19
            "**WŁ.** = udostępnia wszystkie budynki charakterystyczne bez wymagań dotyczących ludności, stref i postępów.\n**WYŁ.** = normalne zasady rozwoju miasta.", // 20
            "Zezwalaj na wiele egzemplarzy", // 21
            "**WŁ.** = pozwala stawiać wiele egzemplarzy obiektów unikatowych, w tym budynków charakterystycznych.\n**WYŁ.** = jeden egzemplarz na miasto, chyba że inny mod pozwala na więcej.", // 22
            "Zasady stawiania obiektów unikatowych", // 23
            "Pokazuje, czy można obecnie stawiać wiele egzemplarzy obiektów unikatowych.", // 24
            "Budynki charakterystyczne", // 25
            "Pokazuje liczbę postawionych budynków charakterystycznych, różnych typów i dodatkowych kopii.", // 26
            "Ogólnomiejskie efekty premii", // 27
            "Zlicza budynki charakterystyczne z premiami ogólnomiejskimi.\nEfekty lokalne i w pobliżu nie są tutaj uwzględnione.", // 28
            "Wykryte zbędne mody", // 29
            "Anarchy jest obsługiwany i nie pojawia się tutaj.\nUsuń inne mody zezwalające na nieograniczone budynki unikatowe — ta funkcja jest już dostępna.", // 30
            "Mod", // 31
            "Wyświetlana nazwa moda.", // 32
            "Wersja", // 33
            "Zainstalowana wersja moda i typ kompilacji.", // 34
            "Otwórz dziennik", // 35
            "Otwiera dziennik moda, a jeśli jest niedostępny — folder dzienników.", // 36
            "Ukryj powiadomienia o zbiorczym odblokowaniu", // 37
            "**WŁ.** (zalecane, domyślnie) = ukrywa powiadomienia o zbiorczym odblokowaniu przez ten mod.\n**WYŁ.** = pokazuje powiadomienie o każdym budynku charakterystycznym nowo odblokowanym przez mod; może ich być kilkadziesiąt lub kilkaset.\nZwykłe powiadomienia gry nadal się pojawiają, także o budynkach z aktualizacji, DLC, pakietów regionalnych i postępów miasta.", // 38
            "Zablokuj automatyczne widoki informacji dla budynków unikatowych", // 39
            "Podczas stawiania budynków unikatowych, w tym charakterystycznych, panel informacji i kolorowa mapa nie otworzą się automatycznie. Widoki można nadal otwierać ręcznie. Inne narzędzia pozostają bez zmian. Aktywny mod Toggleable Overlays ma pierwszeństwo. Domyślnie: WYŁ.", // 40
            "Raport stanu do dziennika", // 41
            "Uruchamia raporty bonusów miejskich i efektów pobliskich, po czym przywraca wybrane tryby. Wyniki trafiają do dziennika moda. Najpierw wczytaj miasto.", // 42
        };

        public LocalePL(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
