// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleFR.cs
// All 41 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleFR : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Bâtiments emblématiques réalistes)", // 0
            "Actions", // 1
            "À propos", // 2
            "Bonus des bâtiments emblématiques", // 3
            "Déblocage des bâtiments emblématiques", // 4
            "Plusieurs bâtiments uniques", // 5
            "Statut", // 6
            "Infos", // 7
            "Débogage / Journal", // 8
            "Bonus des bâtiments emblématiques à l'échelle de la ville", // 9
            "<Première copie uniquement> = chaque type de bâtiment emblématique accorde son bonus global une seule fois.\n<Aucun bonus global> = désactive les bonus globaux des bâtiments emblématiques.\n<Cumul normal du jeu> = chaque copie accorde son bonus global.\nLes effets de proximité ont un réglage distinct. L'attrait du bâtiment reste inchangé.", // 10
            "Première copie uniquement", // 11
            "Aucun bonus global", // 12
            "Cumul normal du jeu", // 13
            "Effets de proximité des bâtiments emblématiques", // 14
            "<Effets de proximité normaux> = chaque copie produit ses effets à proximité.\n<Première copie uniquement> = une seule copie par type produit ses effets à proximité.\n<Aucun effet de proximité> = désactive les effets de proximité normaux des bâtiments emblématiques.\nLes effets des bâtiments abandonnés et l'attrait des bâtiments sont conservés.", // 15
            "Effets de proximité normaux", // 16
            "Première copie uniquement", // 17
            "Aucun effet de proximité", // 18
            "Débloquer les conditions des bâtiments emblématiques", // 19
            "**ACTIVÉ** = rend tous les bâtiments emblématiques disponibles sans conditions de population, de zonage ou de progression.\n**DÉSACTIVÉ** = progression normale du jeu.", // 20
            "Autoriser plusieurs copies", // 21
            "**ACTIVÉ** = permet de placer plusieurs exemplaires des éléments uniques, y compris les bâtiments emblématiques.\n**DÉSACTIVÉ** = règle normale d'un exemplaire par ville, sauf si un autre mod l'autorise.", // 22
            "Règle de placement des éléments uniques", // 23
            "Indique si les éléments uniques peuvent actuellement être placés plusieurs fois.", // 24
            "Bâtiments emblématiques", // 25
            "Affiche le nombre de bâtiments emblématiques placés, de types différents et de copies supplémentaires.", // 26
            "Effets des bonus globaux", // 27
            "Compte les bâtiments emblématiques fournissant un bonus global.\nLes bonus locaux et de proximité ne sont pas inclus.", // 28
            "Rapport des bonus dans le journal", // 29
            "Teste les trois modes de bonus globaux, inscrit les valeurs réelles de la ville dans le journal, puis restaure le mode choisi. Aucune comparaison manuelle nécessaire.", // 30
            "Rapport de proximité dans le journal", // 31
            "Vérifie les trois modes d'effets de proximité dans le journal, puis restaure le mode choisi.", // 32
            "Mods redondants détectés", // 33
            "Anarchy est compatible et n'apparaît pas ici.\nRetirez les autres mods de bâtiments uniques illimités : cette fonction est déjà incluse.", // 34
            "Mod", // 35
            "Nom affiché de ce mod.", // 36
            "Version", // 37
            "Version installée et type de compilation.", // 38
            "Ouvrir le journal", // 39
            "Ouvre le journal du mod ou, à défaut, le dossier des journaux.", // 40
        };

        public LocaleFR(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
