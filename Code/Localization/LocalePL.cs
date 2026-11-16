// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePL.cs
// All 62 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocalePL : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Ikony)", // 0
            "Działania", // 1
            "O modzie", // 2
            "Premie budynków charakterystycznych", // 3
            "Odblokowywanie budynków charakterystycznych", // 4
            "Umieszczanie", // 5
            "Stan", // 6
            "Informacje", // 7
            "Debugowanie / Dziennik", // 8
            "Ogólnomiejskie premie budynków charakterystycznych", // 9
            "<Tylko pierwszy egzemplarz> **(domyślnie)** = jedna premia na typ.\n<Bez premii miejskich> = ogólne premie wyłączone; atrakcyjność jest osobno.\n<Normalne sumowanie> = każda kopia się liczy.\n**Zielony opis** pozostaje widoczny także po blokadzie premii.\nSprawdź **Akcje > Status** lub **Informacje > Raport w dzienniku**.", // 10
            "Tylko pierwszy egzemplarz", // 11
            "Bez premii ogólnomiejskich", // 12
            "Zwykłe sumowanie", // 13
            "Atrakcyjność całego miasta", // 14
            "<Tylko pierwszy egzemplarz> **(domyślnie)** = jedna premia atrakcyjności na typ.\n<Normalne sumowanie> = wszystkie kopie.\n<Bez premii atrakcyjności> = premia miejska wyłączona.\n<Zgodnie z ustawieniem miasta> = zasada ogólna.\n**Atrakcyjność pomaga przyciągać turystów.** Wartość budynku pozostaje.\n**Zielony opis** się nie zmienia.", // 15
            "Zgodnie z ustawieniem miasta", // 16
            "Tylko pierwszy egzemplarz", // 17
            "Normalne sumowanie", // 18
            "Bez premii atrakcyjności", // 19
            "Efekty budynków charakterystycznych w pobliżu", // 20
            "<Zwykłe efekty w pobliżu> = każda kopia zapewnia normalne efekty w okolicy.\n<Tylko pierwszy egzemplarz> = efekty zapewnia jeden egzemplarz każdego typu.\n<Bez efektów w pobliżu> = wyłącza zwykłe efekty lokalne budynków charakterystycznych.\nEfekty opuszczonych budynków i atrakcyjność pozostają bez zmian.", // 21
            "Zwykłe efekty w pobliżu", // 22
            "Tylko pierwszy egzemplarz", // 23
            "Bez efektów w pobliżu", // 24
            "Odblokuj wszystkie budynki charakterystyczne", // 25
            "**WŁ.** = udostępnia wszystkie budynki charakterystyczne bez wymagań dotyczących ludności, stref i postępów.\n**WYŁ.** = normalne zasady rozwoju miasta.\nDomyślnie: WYŁ. Dotyczy tylko budynków charakterystycznych, nie wszystkich unikalnych.", // 26
            "Ukryj powiadomienia o zbiorczym odblokowaniu", // 27
            "**WŁ.** (zalecane, domyślnie) = ukrywa powiadomienia o zbiorczym odblokowaniu przez ten mod.\n**WYŁ.** = pokazuje powiadomienie o każdym budynku charakterystycznym nowo odblokowanym przez mod; może ich być kilkadziesiąt lub kilkaset.\nZwykłe powiadomienia gry nadal się pojawiają, także o budynkach z aktualizacji, DLC, pakietów regionalnych i postępów miasta.", // 28
            "Zezwalaj na wiele egzemplarzy", // 29
            "**WŁ.** = pozwala stawiać wiele egzemplarzy obiektów unikatowych, w tym budynków charakterystycznych.\n**WYŁ.** = jeden egzemplarz na miasto, chyba że inny mod pozwala na więcej.", // 30
            "Zablokuj automatyczne widoki informacji dla budynków unikatowych", // 31
            "Podczas stawiania budynków unikatowych, w tym charakterystycznych, panel informacji i kolorowa mapa nie otworzą się automatycznie. Widoki można nadal otwierać ręcznie. Inne narzędzia pozostają bez zmian. Aktywny mod Toggleable Overlays ma pierwszeństwo. Domyślnie: WŁ.", // 32
            "Zasady stawiania obiektów unikatowych", // 33
            "**Wiele kopii dozwolonych** = limit jednego na miasto wyłączony.\n**Jeden z każdego typu** = normalny limit.\n<Anarchy> też może dopuścić kopie.\nNie określa sumowania premii.", // 34
            "Budynki charakterystyczne", // 35
            "**Ustawione** = wszystkie budynki charakterystyczne.\n**Typy** = różne rodzaje.\n<Dodatkowe kopie> = kolejne po pierwszej danego typu.\nWlicza budynki bez premii miejskich.", // 36
            "Ogólne premie miejskie", // 37
            "**Aktywne / Wszystkie** = dostawcy premii według zasady ogólnej / wszyscy w mieście.\n<Zablokowane> = wykluczeni przez tę zasadę, nie wszystkie dodatkowe kopie.\n**Atrakcyjność osobno:** zablokowany dostawca może nadal ją zwiększać.\nEfekty lokalne są osobne.", // 38
            "Wykryte zbędne mody", // 39
            "<Tylko pierwszy egzemplarz> = jedna premia atrakcyjności na typ.\n<Normalne sumowanie> = wszystkie kopie.\n<Bez premii> = wyłączona.\n<Zgodnie z ustawieniem miasta> = zasada ogólna.\n**To wybrana zasada, nie wynik liczbowy.** Inne budynki też zwiększają atrakcyjność.\nZielony tekst pozostaje. Wyniki: **Informacje > Raport w dzienniku**.", // 40
            "Nie wczytano miasta", // 41
            "Wczytywanie…", // 42
            "Najpierw wczytaj miasto, aby zobaczyć stan", // 43
            "Można stawiać wiele kopii", // 44
            "Anarchy pozwala na wiele kopii", // 45
            "Inny mod pozwala na wiele unikalnych budynków", // 46
            "Po jednym z każdego typu", // 47
            "Mieszane zasady", // 48
            "Postawiono {0} | typy: {1} | dodatkowe kopie: {2}", // 49
            "Aktywne {0}/{1} | zablokowane {2}", // 50
            "Brak", // 51
            "Mod", // 52
            "Wyświetlana nazwa moda.", // 53
            "Wersja", // 54
            "Zainstalowana wersja moda i typ kompilacji.", // 55
            "Raport stanu do dziennika", // 56
            "Zapisuje w dzienniku aktualną liczbę budynków charakterystycznych, premie ogólnomiejskie i efekty pobliskie. Nie zmienia ustawień ani efektów. Najpierw wczytaj miasto.", // 57
            "Porównaj tryby premii w dzienniku", // 58
            "Tymczasowo testuje wszystkie tryby premii ogólnomiejskich i efektów pobliskich, gdy gra jest wstrzymana w Opcjach. Następnie ponownie stosuje wybrane tryby. Wyniki trafiają do dziennika moda. Najpierw wczytaj miasto.", // 59
            "Otwórz dziennik", // 60
            "Otwiera dziennik moda, a jeśli jest niedostępny — folder dzienników.", // 61
        };

        public LocalePL(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
