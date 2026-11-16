// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleIT.cs
// All 62 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleIT : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Icone)", // 0
            "Azioni", // 1
            "Informazioni", // 2
            "Bonus degli edifici distintivi", // 3
            "Sblocco degli edifici distintivi", // 4
            "Posizionamento", // 5
            "Stato", // 6
            "Info", // 7
            "Debug / Registro", // 8
            "Bonus cittadini degli edifici distintivi", // 9
            "<Solo la prima copia> = ogni tipo di edificio distintivo fornisce una sola volta il bonus per tutta la città.\n<Nessun bonus cittadino> = disattiva i bonus per tutta la città.\n<Accumulo normale> = ogni copia fornisce il suo bonus cittadino.\nGli effetti nelle vicinanze hanno un'impostazione separata. L'attrattiva degli edifici non cambia.\nLe righe verdi dei bonus restano visibili anche se l'effetto è limitato o disattivato. Consulta Azioni > Stato o il rapporto nel registro.", // 10
            "Solo la prima copia", // 11
            "Nessun bonus cittadino", // 12
            "Accumulo normale", // 13
            "Attrattiva cittadina", // 14
            "<Segui impostazione cittadina> = usa la regola sopra.\n<Solo prima copia> = una copia per tipo contribuisce.\n<Accumulo standard> = ogni copia contribuisce.\n<Nessun bonus attrattiva> = nessun bonus cittadino dagli edifici distintivi.\nAttrattiva del singolo edificio e descrizione invariate.\nL'attrattiva della città aiuta ad attirare turisti. Predefinito: solo prima copia.\nLe righe verdi dei bonus restano visibili anche se l'effetto è limitato o disattivato. Consulta Azioni > Stato o il rapporto nel registro.", // 15
            "Segui impostazione cittadina", // 16
            "Solo prima copia", // 17
            "Accumulo standard", // 18
            "Nessun bonus attrattiva", // 19
            "Effetti nelle vicinanze degli edifici distintivi", // 20
            "<Effetti vicini normali> = ogni copia fornisce i suoi effetti nelle vicinanze.\n<Solo la prima copia> = una sola copia per tipo fornisce effetti nelle vicinanze.\n<Nessun effetto vicino> = disattiva i normali effetti locali degli edifici distintivi.\nGli effetti degli edifici abbandonati e l'attrattiva restano invariati.", // 21
            "Effetti vicini normali", // 22
            "Solo la prima copia", // 23
            "Nessun effetto vicino", // 24
            "Sblocca tutti gli edifici distintivi", // 25
            "**ATTIVO** = rende disponibili tutti gli edifici distintivi senza requisiti di popolazione, zone o progressione.\n**DISATTIVO** = progressione normale del gioco.\nPredefinito: disattivo. Solo edifici distintivi, non tutti quelli unici.", // 26
            "Nascondi notifiche di sblocco in massa degli edifici distintivi", // 27
            "**ATTIVO** (consigliato, predefinito) = nasconde le notifiche dello sblocco in massa effettuato da questo mod.\n**DISATTIVO** = mostra una notifica per ogni edificio distintivo appena sbloccato dal mod; possono essercene decine o centinaia.\nRestano visibili le normali notifiche del gioco, comprese quelle per nuovi edifici da aggiornamenti, DLC, pacchetti regionali e progressione della città.", // 28
            "Consenti più copie", // 29
            "**ATTIVO** = consente di costruire più copie degli oggetti unici, inclusi gli edifici distintivi.\n**DISATTIVO** = una copia per città, salvo che un altro mod lo consenta.", // 30
            "Impedisci le viste informative automatiche per gli edifici unici", // 31
            "Impedisce agli edifici unici, compresi quelli distintivi, di aprire automaticamente il pannello informativo e la mappa colorata durante il posizionamento. Le viste informative possono essere aperte manualmente. Gli altri strumenti restano invariati. Toggleable Overlays ha la precedenza se attivo. Predefinito: ATTIVO.", // 32
            "Regole per gli edifici unici", // 33
            "Mostra se gli oggetti unici possono essere collocati più volte.", // 34
            "Edifici distintivi", // 35
            "Mostra gli edifici distintivi costruiti, i tipi diversi e le copie extra.", // 36
            "Altri bonus cittadini", // 37
            "Conta gli edifici distintivi con bonus per tutta la città.\nGli effetti locali non sono inclusi.\nL'attrattiva cittadina ha una regola separata.", // 38
            "Mod ridondanti rilevati", // 39
            "Anarchy è supportato e non compare qui.\nRimuovi gli altri mod per edifici unici illimitati: questa funzione è già inclusa.", // 40
            "Nessuna città caricata", // 41
            "Caricamento…", // 42
            "Carica una città per vedere lo stato", // 43
            "Copie multiple consentite", // 44
            "Copie multiple consentite da Anarchy", // 45
            "Un altro mod consente più edifici unici", // 46
            "Uno per tipo", // 47
            "Regole miste", // 48
            "{0} posizionati | {1} tipi | {2} copie extra", // 49
            "{0}/{1} attivi | {2} bloccati", // 50
            "Nessuno", // 51
            "Mod", // 52
            "Nome visualizzato del mod.", // 53
            "Versione", // 54
            "Versione installata e tipo di compilazione.", // 55
            "Rapporto di stato nel registro", // 56
            "Scrive nel registro il numero attuale di edifici distintivi, i bonus cittadini e gli effetti nelle vicinanze. Non modifica impostazioni o effetti. Prima carica una città.", // 57
            "Confronta le modalità bonus nel registro", // 58
            "Prova temporaneamente tutte le modalità dei bonus cittadini e degli effetti vicini mentre il gioco è in pausa nelle Opzioni. Poi riapplica le modalità selezionate. Risultati nel registro del mod. Prima carica una città.", // 59
            "Apri registro", // 60
            "Apre il file di registro del mod oppure la cartella dei registri.", // 61
        };

        public LocaleIT(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
