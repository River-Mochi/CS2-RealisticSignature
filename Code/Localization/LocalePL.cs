// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePL.cs
// All 45 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

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
            "Ukryj powiadomienia o zbiorczym odblokowaniu", // 21
            "**WŁ.** (zalecane, domyślnie) = ukrywa powiadomienia o zbiorczym odblokowaniu przez ten mod.\n**WYŁ.** = pokazuje powiadomienie o każdym budynku charakterystycznym nowo odblokowanym przez mod; może ich być kilkadziesiąt lub kilkaset.\nZwykłe powiadomienia gry nadal się pojawiają, także o budynkach z aktualizacji, DLC, pakietów regionalnych i postępów miasta.", // 22
            "Zezwalaj na wiele egzemplarzy", // 23
            "**WŁ.** = pozwala stawiać wiele egzemplarzy obiektów unikatowych, w tym budynków charakterystycznych.\n**WYŁ.** = jeden egzemplarz na miasto, chyba że inny mod pozwala na więcej.", // 24
            "Zablokuj automatyczne widoki informacji dla budynków unikatowych", // 25
            "Podczas stawiania budynków unikatowych, w tym charakterystycznych, panel informacji i kolorowa mapa nie otworzą się automatycznie. Widoki można nadal otwierać ręcznie. Inne narzędzia pozostają bez zmian. Aktywny mod Toggleable Overlays ma pierwszeństwo. Domyślnie: WYŁ.", // 26
            "Zasady stawiania obiektów unikatowych", // 27
            "Pokazuje, czy można obecnie stawiać wiele egzemplarzy obiektów unikatowych.", // 28
            "Budynki charakterystyczne", // 29
            "Pokazuje liczbę postawionych budynków charakterystycznych, różnych typów i dodatkowych kopii.", // 30
            "Ogólnomiejskie efekty premii", // 31
            "Zlicza budynki charakterystyczne z premiami ogólnomiejskimi.\nEfekty lokalne i w pobliżu nie są tutaj uwzględnione.", // 32
            "Wykryte zbędne mody", // 33
            "Anarchy jest obsługiwany i nie pojawia się tutaj.\nUsuń inne mody zezwalające na nieograniczone budynki unikatowe — ta funkcja jest już dostępna.", // 34
            "Mod", // 35
            "Wyświetlana nazwa moda.", // 36
            "Wersja", // 37
            "Zainstalowana wersja moda i typ kompilacji.", // 38
            "Raport stanu do dziennika", // 39
            "Zapisuje w dzienniku aktualną liczbę budynków charakterystycznych, premie ogólnomiejskie i efekty pobliskie. Nie zmienia ustawień ani efektów. Najpierw wczytaj miasto.", // 40
            "Porównaj tryby premii w dzienniku", // 41
            "Tymczasowo testuje wszystkie tryby premii ogólnomiejskich i efektów pobliskich, gdy gra jest wstrzymana w Opcjach. Następnie ponownie stosuje wybrane tryby. Wyniki trafiają do dziennika moda. Najpierw wczytaj miasto.", // 42
            "Otwórz dziennik", // 43
            "Otwiera dziennik moda, a jeśli jest niedostępny — folder dzienników.", // 44
            "Nie wczytano miasta", // 45
            "Wczytywanie…", // 46
            "Najpierw wczytaj miasto, aby zobaczyć stan", // 47
            "Można stawiać wiele kopii", // 48
            "Anarchy pozwala na wiele kopii", // 49
            "Inny mod pozwala na wiele unikalnych budynków", // 50
            "Po jednym z każdego typu", // 51
            "Mieszane zasady", // 52
            "Postawiono {0} | typy: {1} | dodatkowe kopie: {2}", // 53
            "Aktywne źródła premii: {0} | powielone: {1}", // 54
            "Brak", // 55
        };

        public LocalePL(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
