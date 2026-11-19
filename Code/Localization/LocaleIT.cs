// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleIT.cs
// All 64 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

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
            "Bonus cittadini degli edifici unici", // 9
            "<Solo prima copia> **(predefinito)** = un bonus cittadino per tipo di edificio unico.\n<Nessun bonus cittadino> = disattiva i bonus generali; attrattività separata.\n<Accumulo originale> = ogni copia contribuisce.\n**Le righe verdi** restano visibili anche se il bonus è bloccato.\nControlla **Azioni > Stato** o il rapporto nel registro.", // 10
            "Solo la prima copia", // 11
            "Nessun bonus cittadino", // 12
            "Accumulo normale", // 13
            "Attrattiva cittadina", // 14
            "<Solo prima copia> **(predefinito)** = un bonus cittadino di attrattività per tipo unico idoneo.\n<Accumulo originale> = tutte le copie contribuiscono.\n<Nessun bonus di attrattività> = questi bonus sono disattivati.\n<Segui impostazione generale> = applica la regola precedente.\n**L'attrattività richiama turisti.** Quella del singolo edificio resta invariata.\n**Le righe verdi** sono descrizioni statiche.", // 15
            "Segui impostazione cittadina", // 16
            "Solo prima copia", // 17
            "Accumulo standard", // 18
            "Nessun bonus attrattiva", // 19
            "Effetti nelle vicinanze degli edifici unici", // 20
            "<Effetti originali> **(predefinito)** = ogni copia unica conserva gli effetti locali.\n<Solo prima copia> = una copia per tipo.\n<Nessun effetto nelle vicinanze> = disattiva gli effetti normali, non le penalità da abbandono.\n**L'attrattività dell'edificio** non cambia.", // 21
            "Effetti vicini normali", // 22
            "Solo la prima copia", // 23
            "Nessun effetto vicino", // 24
            "Sblocca tutti gli edifici distintivi", // 25
            "**ATTIVO** = rende disponibili tutti gli edifici distintivi senza requisiti di popolazione, zone o progressione.\n**DISATTIVO** = progressione normale del gioco.\nPredefinito: disattivo. Solo edifici distintivi, non tutti quelli unici.", // 26
            "Nascondi notifiche di sblocco in massa degli edifici distintivi", // 27
            "**ATTIVO** (consigliato, predefinito) = nasconde le notifiche dello sblocco in massa effettuato da questo mod.\n**DISATTIVO** = mostra una notifica per ogni edificio distintivo appena sbloccato dal mod; possono essercene decine o centinaia.\nRestano visibili le normali notifiche del gioco, comprese quelle per nuovi edifici da aggiornamenti, DLC, pacchetti regionali e progressione della città.", // 28
            "Consenti più copie", // 29
            "**ATTIVO** = consente di costruire più copie degli oggetti unici, inclusi gli edifici distintivi.\n**DISATTIVO** = una copia per città, salvo che un altro mod lo consenta.", // 30
            "Mostra chiaramente gli edifici durante il posizionamento", // 31
            "**ATTIVO (predefinito)** = <visuale libera>: niente oscuramento automatico, sovrapposizioni colorate o pannelli informativi automatici quando posizioni edifici unici.\n**DISATTIVO** = comportamento automatico normale.\nPuoi aprire le visualizzazioni manualmente. <Toggle Overlays> ha priorità.", // 32
            "Regole per gli edifici unici", // 33
            "**Copie multiple consentite** = limite di uno per città disattivato.\n**Uno per tipo** = limite normale.\n<Anarchy> può consentire copie.\nNon indica se i bonus si sommano.", // 34
            "Edifici distintivi", // 35
            "**Collocati** = tutti gli edifici distintivi.\n**Tipi** = modelli diversi.\n<Copie extra> = oltre il primo per tipo.\nConta anche edifici senza bonus cittadino.", // 36
            "Bonus cittadini degli edifici Signature", // 37
            "**Attivi / Totale** = fornitori ammessi dalla regola generale / tutti quelli presenti.\n<Bloccati> = esclusi da quella regola, non tutte le copie extra.\n**Attrattiva indipendente:** i fornitori bloccati possono comunque dare attrattiva.\nEffetti locali separati.", // 38
            "Mod ridondanti rilevati", // 39
            "<Solo prima copia> = un bonus attrattiva per tipo.\n<Accumulo standard> = ogni copia.\n<Nessun bonus> = disattivato.\n<Segui impostazione cittadina> = regola generale.\n**Mostra la regola scelta, non il valore del bonus.**\nValori reali: **Informazioni > Rapporto nel registro**. Il testo verde resta invariato.", // 40
            "Nessuna città caricata", // 41
            "Caricamento…", // 42
            "Carica una città per vedere lo stato", // 43
            "Copie multiple consentite", // 44
            "Copie multiple consentite da Anarchy", // 45
            "Un altro mod consente più edifici unici", // 46
            "Uno per tipo", // 47
            "Copie illimitate ancora consentite", // 48
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
            "Bonus cittadini degli altri edifici unici", // 62
            "Bonus degli edifici unici non Signature, come il Municipio.\nAttivi / Totale = fonti conteggiate / presenti. Bloccati = fonti escluse dalla regola. I servizi normali non sono inclusi.", // 63
        };

        public LocaleIT(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
