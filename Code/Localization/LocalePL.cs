// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePL.cs
// All 64 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

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
            "Bonusy ogólnomiejskie unikatowych budynków", // 9
            "<Tylko pierwszy egzemplarz> **(domyślnie)** = jeden bonus miejski na typ unikatowego budynku.\n<Bez premii ogólnomiejskich> = wyłącza bonusy ogólne, atrakcyjność jest osobno.\n<Zwykłe sumowanie> = każda kopia się liczy.\n**Zielony tekst premii** pozostaje na panelu nawet po zablokowaniu efektu.\nSprawdź **Akcje > Status** lub raport w dzienniku.", // 10
            "Tylko pierwszy egzemplarz", // 11
            "Bez premii ogólnomiejskich", // 12
            "Zwykłe sumowanie", // 13
            "Atrakcyjność całego miasta", // 14
            "<Tylko pierwszy egzemplarz> **(domyślnie)** = jedna premia do atrakcyjności miasta na typ objętego regułą budynku unikatowego.\n<Normalne sumowanie> = wszystkie kopie.\n<Bez premii atrakcyjności> = wyłącza te bonusy miejskie.\n<Zgodnie z ustawieniem miasta> = stosuje powyższą regułę.\n**Atrakcyjność przyciąga turystów.** Wartość samego budynku nie zmienia się.\n**Zielone opisy** są stałe.", // 15
            "Zgodnie z ustawieniem miasta", // 16
            "Tylko pierwszy egzemplarz", // 17
            "Normalne sumowanie", // 18
            "Bez premii atrakcyjności", // 19
            "Efekty lokalne unikatowych budynków", // 20
            "<Zwykłe efekty w pobliżu> **(domyślnie)** = każda kopia unikatowego budynku ma efekty w okolicy.\n<Tylko pierwszy egzemplarz> = jedna na typ.\n<Bez efektów w pobliżu> = wyłącza zwykłe efekty, ale nie kary opuszczonych budynków.\n**Atrakcyjność budynku** nie zmienia się.", // 21
            "Zwykłe efekty w pobliżu", // 22
            "Tylko pierwszy egzemplarz", // 23
            "Bez efektów w pobliżu", // 24
            "Odblokuj wszystkie budynki charakterystyczne", // 25
            "**WŁ.** = odblokowuje budynki charakterystyczne bez wymagań rozwoju.\n**WYŁ. (domyślnie)** = normalne odblokowywanie.\n**Inne unikatowe budynki**, np. komenda policji, nadal wymagają <punktów rozwoju> w **Postępy > Rozwój**.", // 26
            "Ukryj powiadomienia o zbiorczym odblokowaniu", // 27
            "**WŁ.** (zalecane, domyślnie) = ukrywa powiadomienia o zbiorczym odblokowaniu przez ten mod.\n**WYŁ.** = pokazuje powiadomienie o każdym budynku charakterystycznym nowo odblokowanym przez mod; może ich być kilkadziesiąt lub kilkaset.\nZwykłe powiadomienia gry nadal się pojawiają, także o budynkach z aktualizacji, DLC, pakietów regionalnych i postępów miasta.", // 28
            "Zezwalaj na wiele egzemplarzy", // 29
            "**WŁ.** = pozwala stawiać wiele egzemplarzy obiektów unikatowych, w tym budynków charakterystycznych.\n**WYŁ.** = jeden egzemplarz na miasto, chyba że inny mod pozwala na więcej.", // 30
            "Wyraźny widok budynków podczas stawiania", // 31
            "**WŁ. (domyślnie)** = <czytelny widok>: bez automatycznego przyciemniania, kolorowej mapy i widoku informacji podczas stawiania unikatowych budynków.\n**WYŁ.** = normalne automatyczne widoki.\nPanel informacji nadal można otworzyć ręcznie. <Toggle Overlays> ma pierwszeństwo.", // 32
            "Zasady stawiania obiektów unikatowych", // 33
            "**Wiele kopii dozwolonych** = limit jednego na miasto wyłączony.\n**Jeden z każdego typu** = normalny limit.\n<Anarchy> też może dopuścić kopie.\nNie określa sumowania premii.", // 34
            "Budynki charakterystyczne", // 35
            "**Ustawione** = wszystkie budynki charakterystyczne.\n**Typy** = różne rodzaje.\n<Dodatkowe kopie> = kolejne po pierwszej danego typu.\nWlicza budynki bez premii miejskich.", // 36
            "Bonusy ogólnomiejskie budynków Signature", // 37
            "**Aktywne / Wszystkie** = dostawcy premii według zasady ogólnej / wszyscy w mieście.\n<Zablokowane> = wykluczeni przez tę zasadę, nie wszystkie dodatkowe kopie.\n**Atrakcyjność osobno:** zablokowany dostawca może nadal ją zwiększać.\nEfekty lokalne są osobne.", // 38
            "Wykryte zbędne mody", // 39
            "**Brak** = nie wykryto znanych modów z tą samą funkcją wielokrotnego stawiania.\n<Anarchy> jest zgodny i nie pojawia się tutaj.\nUnikaj innych modów o tej samej funkcji.", // 40
            "Nie wczytano miasta", // 41
            "Wczytywanie…", // 42
            "Najpierw wczytaj miasto, aby zobaczyć stan", // 43
            "Można stawiać wiele kopii", // 44
            "Anarchy pozwala na wiele kopii", // 45
            "Nadal można stawiać wiele egzemplarzy", // 46
            "Po jednym z każdego typu", // 47
            "Mieszane zasady stawiania", // 48
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
            "Bonusy ogólnomiejskie innych unikatowych budynków", // 62
            "Bonusy unikatowych budynków innych niż Signature, np. ratusza.\nAktywne / Razem = uwzględniane / wszystkie źródła. Zablokowane = wyłączone przez regułę. Zwykłe budynki usługowe nie są liczone.", // 63
        };

        public LocalePL(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
