// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleFR.cs
// All 62 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleFR : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Emblèmes)", // 0
            "Actions", // 1
            "À propos", // 2
            "Bonus des bâtiments emblématiques", // 3
            "Déblocage des bâtiments emblématiques", // 4
            "Placement", // 5
            "Statut", // 6
            "Infos", // 7
            "Débogage / Journal", // 8
            "Bonus des bâtiments emblématiques à l'échelle de la ville", // 9
            "<Première copie uniquement> = chaque type de bâtiment emblématique accorde son bonus global une seule fois.\n<Aucun bonus global> = désactive les bonus globaux des bâtiments emblématiques.\n<Cumul normal du jeu> = chaque copie accorde son bonus global.\nLes effets de proximité ont un réglage distinct. L'attrait du bâtiment reste inchangé.", // 10
            "Première copie uniquement", // 11
            "Aucun bonus global", // 12
            "Cumul normal du jeu", // 13
            "Attrait dans toute la ville", // 14
            "<Suivre le réglage global> = applique la règle ci-dessus.\n<Première copie uniquement> = une seule copie par type apporte de l'attrait global.\n<Cumul normal du jeu> = toutes les copies comptent.\n<Aucun bonus d'attrait> = aucun bonus global des bâtiments emblématiques.\nL'attrait propre et le descriptif restent inchangés.\nL'attrait de la ville aide à attirer des touristes. Par défaut : cumul normal du jeu.", // 15
            "Suivre le réglage global", // 16
            "Première copie uniquement", // 17
            "Cumul normal du jeu", // 18
            "Aucun bonus d'attrait", // 19
            "Effets de proximité des bâtiments emblématiques", // 20
            "<Effets de proximité normaux> = chaque copie produit ses effets à proximité.\n<Première copie uniquement> = une seule copie par type produit ses effets à proximité.\n<Aucun effet de proximité> = désactive les effets de proximité normaux des bâtiments emblématiques.\nLes effets des bâtiments abandonnés et l'attrait des bâtiments sont conservés.", // 21
            "Effets de proximité normaux", // 22
            "Première copie uniquement", // 23
            "Aucun effet de proximité", // 24
            "Débloquer les conditions des bâtiments emblématiques", // 25
            "**ACTIVÉ** = rend tous les bâtiments emblématiques disponibles sans conditions de population, de zonage ou de progression.\n**DÉSACTIVÉ** = progression normale du jeu.", // 26
            "Masquer les notifications de déblocage groupé des bâtiments emblématiques", // 27
            "**ACTIVÉ** (recommandé, par défaut) = masque les notifications du déblocage groupé effectué par ce mod.\n**DÉSACTIVÉ** = affiche une notification par bâtiment emblématique nouvellement débloqué par ce mod ; des dizaines ou centaines peuvent apparaître.\nLes notifications normales du jeu restent visibles, notamment celles des mises à jour, DLC, packs régionaux et de la progression de la ville.", // 28
            "Autoriser plusieurs copies", // 29
            "**ACTIVÉ** = permet de placer plusieurs exemplaires des éléments uniques, y compris les bâtiments emblématiques.\n**DÉSACTIVÉ** = règle normale d'un exemplaire par ville, sauf si un autre mod l'autorise.", // 30
            "Empêcher l'ouverture automatique des infovues pour les bâtiments uniques", // 31
            "Empêche les bâtiments uniques, y compris les bâtiments emblématiques, d'ouvrir automatiquement l'infovue et la carte colorée lors du placement. Les infovues peuvent toujours être ouvertes manuellement. Les autres outils restent inchangés. Toggleable Overlays est prioritaire s'il est actif. Par défaut : ACTIVÉ.", // 32
            "Règle de placement des éléments uniques", // 33
            "Indique si les éléments uniques peuvent actuellement être placés plusieurs fois.", // 34
            "Bâtiments emblématiques", // 35
            "Affiche le nombre de bâtiments emblématiques placés, de types différents et de copies supplémentaires.", // 36
            "Effets des bonus globaux", // 37
            "Compte les bâtiments emblématiques fournissant un bonus global.\nLes bonus locaux et de proximité ne sont pas inclus.", // 38
            "Mods redondants détectés", // 39
            "Anarchy est compatible et n'apparaît pas ici.\nRetirez les autres mods de bâtiments uniques illimités : cette fonction est déjà incluse.", // 40
            "Aucune ville chargée", // 41
            "Chargement…", // 42
            "Chargez d'abord une ville pour voir l'état", // 43
            "Copies multiples autorisées", // 44
            "Copies multiples autorisées par Anarchy", // 45
            "Un autre mod autorise plusieurs bâtiments uniques", // 46
            "Un seul de chaque", // 47
            "Règles mixtes", // 48
            "{0} placés | {1} types | {2} copies supplémentaires", // 49
            "{0} fournisseurs actifs | {1} fournisseurs en double", // 50
            "Aucun", // 51
            "Mod", // 52
            "Nom affiché de ce mod.", // 53
            "Version", // 54
            "Version installée et type de compilation.", // 55
            "Rapport d'état dans le journal", // 56
            "Inscrit dans le journal le nombre actuel de bâtiments emblématiques, les bonus globaux et les effets de proximité. Ne change aucun réglage ni effet. Chargez d'abord une ville.", // 57
            "Comparer les modes de bonus dans le journal", // 58
            "Teste temporairement tous les modes de bonus globaux et d'effets de proximité pendant que le jeu est en pause dans les Options. Réapplique ensuite vos modes choisis. Résultats dans le journal du mod. Chargez d'abord une ville.", // 59
            "Ouvrir le journal", // 60
            "Ouvre le journal du mod ou, à défaut, le dossier des journaux.", // 61
        };

        public LocaleFR(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
