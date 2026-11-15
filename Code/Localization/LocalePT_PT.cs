// <copyright file="LocalePT_PT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePT_PT.cs
// All 62 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocalePT_PT : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Edifícios emblemáticos realistas)", // 0
            "Ações", // 1
            "Sobre", // 2
            "Bónus de edifícios emblemáticos", // 3
            "Desbloqueio de edifícios emblemáticos", // 4
            "Colocação", // 5
            "Estado", // 6
            "Informações", // 7
            "Depuração / Registo", // 8
            "Bónus dos edifícios emblemáticos em toda a cidade", // 9
            "<Só a primeira cópia> = cada tipo de edifício emblemático concede o seu bónus à cidade apenas uma vez.\n<Sem bónus globais> = desativa esses bónus.\n<Acumulação normal> = cada cópia concede o seu bónus.\nOs efeitos nas proximidades têm uma definição própria. A atratividade dos edifícios mantém-se.", // 10
            "Só a primeira cópia", // 11
            "Sem bónus globais", // 12
            "Acumulação normal", // 13
            "Atratividade da cidade", // 14
            "<Seguir definição geral> = usa a regra acima.\n<Só a primeira cópia> = apenas uma por tipo contribui.\n<Acumulação normal> = todas as cópias contribuem.\n<Sem bónus de atratividade> = nenhum bónus global dos edifícios emblemáticos.\nA atratividade própria e a descrição mantêm-se.", // 15
            "Seguir definição geral", // 16
            "Só a primeira cópia", // 17
            "Acumulação normal", // 18
            "Sem bónus de atratividade", // 19
            "Efeitos dos edifícios emblemáticos nas proximidades", // 20
            "<Efeitos normais nas proximidades> = cada cópia produz os seus efeitos locais habituais.\n<Só a primeira cópia> = apenas uma cópia de cada tipo produz efeitos próximos.\n<Sem efeitos nas proximidades> = desativa os efeitos locais habituais desses edifícios.\nOs efeitos dos edifícios abandonados e a atratividade mantêm-se.", // 21
            "Efeitos normais nas proximidades", // 22
            "Só a primeira cópia", // 23
            "Sem efeitos nas proximidades", // 24
            "Desbloquear requisitos dos edifícios emblemáticos", // 25
            "**LIGADO** = disponibiliza todos os edifícios emblemáticos sem requisitos de população, zonamento ou progresso.\n**DESLIGADO** = progressão normal do jogo.", // 26
            "Ocultar avisos de desbloqueio em massa", // 27
            "**LIGADO** (recomendado, predefinição) = oculta os avisos do desbloqueio em massa feito por este mod.\n**DESLIGADO** = mostra um aviso por cada edifício emblemático desbloqueado pelo mod; podem ser dezenas ou centenas.\nOs avisos normais do jogo continuam a aparecer, incluindo edifícios novos de atualizações, DLC, pacotes regionais e progresso da cidade.", // 28
            "Permitir várias cópias", // 29
            "**LIGADO** = permite colocar várias cópias de objetos únicos, incluindo edifícios emblemáticos.\n**DESLIGADO** = uma cópia por cidade, a menos que outro mod permita mais.", // 30
            "Impedir vistas de informação automáticas para edifícios únicos", // 31
            "Impede que edifícios únicos, incluindo os emblemáticos, abram automaticamente o painel de informação e o mapa colorido durante a colocação. As vistas podem continuar a ser abertas manualmente. As outras ferramentas não mudam. Toggleable Overlays tem prioridade quando ativo. Predefinição: LIGADO.", // 32
            "Regra de colocação de objetos únicos", // 33
            "Indica se é possível colocar várias cópias de objetos únicos.", // 34
            "Edifícios emblemáticos", // 35
            "Mostra os edifícios emblemáticos construídos, os tipos diferentes e as cópias adicionais.", // 36
            "Efeitos dos bónus globais", // 37
            "Conta edifícios emblemáticos com bónus em toda a cidade.\nOs efeitos locais ou próximos não estão incluídos.", // 38
            "Mods redundantes detetados", // 39
            "Anarchy é compatível e não aparece aqui.\nRemove outros mods de edifícios únicos ilimitados: esta função já está incluída.", // 40
            "Nenhuma cidade carregada", // 41
            "A carregar…", // 42
            "Carrega uma cidade para veres o estado", // 43
            "Várias cópias permitidas", // 44
            "Anarchy permite várias cópias", // 45
            "Outro mod permite vários edifícios únicos", // 46
            "Um de cada tipo", // 47
            "Regras mistas", // 48
            "{0} construídos | {1} tipos | {2} cópias extra", // 49
            "{0} fornecedores ativos | {1} fornecedores duplicados", // 50
            "Nenhum", // 51
            "Mod", // 52
            "Nome apresentado deste mod.", // 53
            "Versão", // 54
            "Versão instalada e tipo de compilação.", // 55
            "Relatório de estado no registo", // 56
            "Regista no log a quantidade atual de edifícios emblemáticos, os bónus da cidade e os efeitos próximos. Não altera definições nem efeitos. Carrega primeiro uma cidade.", // 57
            "Comparar modos de bónus no log", // 58
            "Testa temporariamente todos os modos de bónus da cidade e efeitos próximos enquanto o jogo está em pausa nas Opções. Depois volta a aplicar os modos escolhidos. Os resultados ficam no log do mod. Carrega primeiro uma cidade.", // 59
            "Abrir registo", // 60
            "Abre o registo do mod ou, se indisponível, a pasta dos registos.", // 61
        };

        public LocalePT_PT(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
