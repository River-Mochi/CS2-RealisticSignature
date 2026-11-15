// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePT_BR.cs
// All 45 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

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
            "Posicionamento", // 5
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
            "Mods redundantes detectados", // 29
            "Anarchy é compatível e não aparece aqui.\nRemova outros mods de edifícios únicos ilimitados: esta função já está incluída.", // 30
            "Mod", // 31
            "Nome exibido deste mod.", // 32
            "Versão", // 33
            "Versão instalada e tipo de compilação.", // 34
            "Abrir registro", // 35
            "Abre o registro do mod ou, se não estiver disponível, a pasta de registros.", // 36
            "Ocultar avisos de desbloqueio em massa", // 37
            "**LIGADO** (recomendado, padrão) = oculta os avisos do desbloqueio em massa feito por este mod.\n**DESLIGADO** = mostra um aviso para cada edifício emblemático recém-desbloqueado por este mod; podem ser dezenas ou centenas.\nOs avisos normais do jogo continuam aparecendo, inclusive novos edifícios de atualizações, DLC, pacotes regionais e progresso da cidade.", // 38
            "Impedir vistas de informação automáticas para edifícios únicos", // 39
            "Impede que edifícios únicos, incluindo os emblemáticos, abram automaticamente o painel de informações e o mapa colorido ao serem posicionados. As vistas ainda podem ser abertas manualmente. As outras ferramentas não mudam. Toggleable Overlays tem prioridade quando ativo. Padrão: DESLIGADO.", // 40
            "Relatório de status no log", // 41
            "Registra no log a quantidade atual de edifícios emblemáticos, os bônus da cidade e os efeitos próximos. Não altera configurações nem efeitos. Carregue uma cidade primeiro.", // 42
            "Comparar modos de bônus no log", // 43
            "Testa temporariamente todos os modos de bônus da cidade e efeitos próximos enquanto o jogo está pausado nas Opções. Depois reaplica os modos escolhidos. Os resultados ficam no log do mod. Carregue uma cidade primeiro.", // 44
        };

        public LocalePT_BR(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
