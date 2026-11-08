// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePT_BR.cs
// All 43 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocalePT_BR : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Edifícios emblemáticos realistas)", // 0
            "Ações", // 1
            "Sobre", // 2
            "Bônus de edifícios emblemáticos", // 3
            "Desbloqueio de edifícios emblemáticos", // 4
            "Vários edifícios únicos", // 5
            "Status", // 6
            "Informações", // 7
            "Depuração / Registro", // 8
            "Bônus de edifícios emblemáticos em toda a cidade", // 9
            "<Só a primeira cópia> = cada tipo de edifício emblemático concede seu bônus para a cidade apenas uma vez.\n<Sem bônus para a cidade> = desativa esses bônus.\n<Acúmulo padrão> = cada cópia concede seu bônus.\nOs efeitos próximos têm configuração própria. A atratividade dos edifícios não muda.", // 10
            "Só a primeira cópia", // 11
            "Sem bônus para a cidade", // 12
            "Acúmulo padrão", // 13
            "Efeitos próximos de edifícios emblemáticos", // 14
            "<Efeitos próximos padrão> = cada cópia fornece seus efeitos locais normais.\n<Só a primeira cópia> = apenas uma cópia de cada tipo fornece efeitos próximos.\n<Sem efeitos próximos> = desativa os efeitos locais normais desses edifícios.\nEfeitos de edifícios abandonados e atratividade são preservados.", // 15
            "Efeitos próximos padrão", // 16
            "Só a primeira cópia", // 17
            "Sem efeitos próximos", // 18
            "Desbloquear requisitos de edifícios emblemáticos", // 19
            "**LIGADO** = disponibiliza todos os edifícios emblemáticos sem requisitos de população, zoneamento ou progresso.\n**DESLIGADO** = progressão normal do jogo.", // 20
            "Permitir várias cópias", // 21
            "**LIGADO** = permite construir várias cópias de objetos únicos, incluindo edifícios emblemáticos.\n**DESLIGADO** = apenas uma cópia por cidade, exceto se outro mod permitir mais.", // 22
            "Regra de construção de objetos únicos", // 23
            "Mostra se é possível construir várias cópias de objetos únicos.", // 24
            "Edifícios emblemáticos", // 25
            "Mostra quantos edifícios emblemáticos foram construídos, tipos diferentes e cópias extras.", // 26
            "Efeitos dos bônus da cidade", // 27
            "Conta edifícios emblemáticos com bônus para toda a cidade.\nEfeitos locais e próximos não estão incluídos.", // 28
            "Relatório de bônus no registro", // 29
            "Testa os três modos de bônus para a cidade, registra os valores reais e restaura o modo escolhido. Não é necessário comparar manualmente.", // 30
            "Relatório de efeitos próximos no registro", // 31
            "Verifica os três modos de efeitos próximos no registro e restaura o modo escolhido.", // 32
            "Mods redundantes detectados", // 33
            "Anarchy é compatível e não aparece aqui.\nRemova outros mods de edifícios únicos ilimitados: esta função já está incluída.", // 34
            "Mod", // 35
            "Nome exibido deste mod.", // 36
            "Versão", // 37
            "Versão instalada e tipo de compilação.", // 38
            "Abrir registro", // 39
            "Abre o registro do mod ou, se não estiver disponível, a pasta de registros.", // 40
            "Ocultar avisos de desbloqueio em massa", // 41
            "**LIGADO** (recomendado, padrão) = oculta os avisos do desbloqueio em massa feito por este mod.\n**DESLIGADO** = mostra um aviso para cada edifício emblemático recém-desbloqueado por este mod; podem ser dezenas ou centenas.\nOs avisos normais do jogo continuam aparecendo, inclusive novos edifícios de atualizações, DLC, pacotes regionais e progresso da cidade.", // 42
        };

        public LocalePT_BR(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
