// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleIT.cs
// All 43 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

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
            "Più edifici unici", // 5
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
            "Consenti più copie", // 21
            "**ATTIVO** = consente di costruire più copie degli oggetti unici, inclusi gli edifici distintivi.\n**DISATTIVO** = una copia per città, salvo che un altro mod lo consenta.", // 22
            "Regole per gli edifici unici", // 23
            "Mostra se gli oggetti unici possono essere collocati più volte.", // 24
            "Edifici distintivi", // 25
            "Mostra gli edifici distintivi costruiti, i tipi diversi e le copie extra.", // 26
            "Effetti bonus per tutta la città", // 27
            "Conta gli edifici distintivi con bonus per tutta la città.\nGli effetti locali non sono inclusi.", // 28
            "Rapporto bonus nel registro", // 29
            "Prova i tre modi dei bonus cittadini, scrive i valori effettivi nel registro e ripristina il modo scelto. Non serve confrontare manualmente.", // 30
            "Rapporto effetti vicini nel registro", // 31
            "Controlla i tre modi degli effetti locali nel registro e ripristina il modo scelto.", // 32
            "Mod ridondanti rilevati", // 33
            "Anarchy è supportato e non compare qui.\nRimuovi gli altri mod per edifici unici illimitati: questa funzione è già inclusa.", // 34
            "Mod", // 35
            "Nome visualizzato del mod.", // 36
            "Versione", // 37
            "Versione installata e tipo di compilazione.", // 38
            "Apri registro", // 39
            "Apre il file di registro del mod oppure la cartella dei registri.", // 40
            "Nascondi notifiche di sblocco in massa degli edifici distintivi", // 41
            "**ATTIVO** (consigliato, predefinito) = nasconde le notifiche fastidiose quando sblocchi tutti gli edifici distintivi.\n**DISATTIVO** = mostra una notifica per ogni nuovo edificio sbloccato. Caricando una città possono comparirne decine o centinaia.\nNon influisce sulle normali notifiche del gioco.", // 42
        };

        public LocaleIT(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
