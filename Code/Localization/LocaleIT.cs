// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleIT.cs
// All 45 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleIT : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Edifici distintivi realistici)", // 0
            "Azioni", // 1
            "Informazioni", // 2
            "Bonus degli edifici distintivi", // 3
            "Sblocco degli edifici distintivi", // 4
            "Posizionamento", // 5
            "Stato", // 6
            "Info", // 7
            "Debug / Registro", // 8
            "Bonus cittadini degli edifici distintivi", // 9
            "<Solo la prima copia> = ogni tipo di edificio distintivo fornisce una sola volta il bonus per tutta la città.\n<Nessun bonus cittadino> = disattiva i bonus per tutta la città.\n<Accumulo normale> = ogni copia fornisce il suo bonus cittadino.\nGli effetti nelle vicinanze hanno un'impostazione separata. L'attrattiva degli edifici non cambia.", // 10
            "Solo la prima copia", // 11
            "Nessun bonus cittadino", // 12
            "Accumulo normale", // 13
            "Effetti nelle vicinanze degli edifici distintivi", // 14
            "<Effetti vicini normali> = ogni copia fornisce i suoi effetti nelle vicinanze.\n<Solo la prima copia> = una sola copia per tipo fornisce effetti nelle vicinanze.\n<Nessun effetto vicino> = disattiva i normali effetti locali degli edifici distintivi.\nGli effetti degli edifici abbandonati e l'attrattiva restano invariati.", // 15
            "Effetti vicini normali", // 16
            "Solo la prima copia", // 17
            "Nessun effetto vicino", // 18
            "Sblocca i requisiti degli edifici distintivi", // 19
            "**ATTIVO** = rende disponibili tutti gli edifici distintivi senza requisiti di popolazione, zone o progressione.\n**DISATTIVO** = progressione normale del gioco.", // 20
            "Nascondi notifiche di sblocco in massa degli edifici distintivi", // 21
            "**ATTIVO** (consigliato, predefinito) = nasconde le notifiche dello sblocco in massa effettuato da questo mod.\n**DISATTIVO** = mostra una notifica per ogni edificio distintivo appena sbloccato dal mod; possono essercene decine o centinaia.\nRestano visibili le normali notifiche del gioco, comprese quelle per nuovi edifici da aggiornamenti, DLC, pacchetti regionali e progressione della città.", // 22
            "Consenti più copie", // 23
            "**ATTIVO** = consente di costruire più copie degli oggetti unici, inclusi gli edifici distintivi.\n**DISATTIVO** = una copia per città, salvo che un altro mod lo consenta.", // 24
            "Impedisci le viste informative automatiche per gli edifici unici", // 25
            "Impedisce agli edifici unici, compresi quelli distintivi, di aprire automaticamente il pannello informativo e la mappa colorata durante il posizionamento. Le viste informative possono essere aperte manualmente. Gli altri strumenti restano invariati. Toggleable Overlays ha la precedenza se attivo. Predefinito: ATTIVO.", // 26
            "Regole per gli edifici unici", // 27
            "Mostra se gli oggetti unici possono essere collocati più volte.", // 28
            "Edifici distintivi", // 29
            "Mostra gli edifici distintivi costruiti, i tipi diversi e le copie extra.", // 30
            "Effetti bonus per tutta la città", // 31
            "Conta gli edifici distintivi con bonus per tutta la città.\nGli effetti locali non sono inclusi.", // 32
            "Mod ridondanti rilevati", // 33
            "Anarchy è supportato e non compare qui.\nRimuovi gli altri mod per edifici unici illimitati: questa funzione è già inclusa.", // 34
            "Nessuna città caricata", // 35
            "Caricamento…", // 36
            "Carica una città per vedere lo stato", // 37
            "Copie multiple consentite", // 38
            "Copie multiple consentite da Anarchy", // 39
            "Un altro mod consente più edifici unici", // 40
            "Uno per tipo", // 41
            "Regole miste", // 42
            "{0} posizionati | {1} tipi | {2} copie extra", // 43
            "{0} fornitori attivi | {1} fornitori duplicati", // 44
            "Nessuno", // 45
            "Mod", // 46
            "Nome visualizzato del mod.", // 47
            "Versione", // 48
            "Versione installata e tipo di compilazione.", // 49
            "Rapporto di stato nel registro", // 50
            "Scrive nel registro il numero attuale di edifici distintivi, i bonus cittadini e gli effetti nelle vicinanze. Non modifica impostazioni o effetti. Prima carica una città.", // 51
            "Confronta le modalità bonus nel registro", // 52
            "Prova temporaneamente tutte le modalità dei bonus cittadini e degli effetti vicini mentre il gioco è in pausa nelle Opzioni. Poi riapplica le modalità selezionate. Risultati nel registro del mod. Prima carica una città.", // 53
            "Apri registro", // 54
            "Apre il file di registro del mod oppure la cartella dei registri.", // 55
        };

        public LocaleIT(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
