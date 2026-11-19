// <copyright file="LocalePT_PT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePT_PT.cs
// All 64 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocalePT_PT : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Ícones)", // 0
            "Ações", // 1
            "Sobre", // 2
            "Bónus de edifícios emblemáticos", // 3
            "Desbloqueio de edifícios emblemáticos", // 4
            "Colocação", // 5
            "Estado", // 6
            "Informações", // 7
            "Depuração / Registo", // 8
            "Bónus dos edifícios emblemáticos em toda a cidade", // 9
            "<Só a primeira cópia> **(predefinição)** = um bónus por tipo.\n<Sem bónus globais> = desliga os bónus gerais; atratividade tem regra própria.\n<Acumulação normal> = todas as cópias contam.\n**O texto verde** permanece mesmo que o bónus esteja bloqueado.\nVer **Ações > Estado** ou **Sobre > Relatório no registo**.", // 10
            "Só a primeira cópia", // 11
            "Sem bónus globais", // 12
            "Acumulação normal", // 13
            "Atratividade da cidade", // 14
            "<Só a primeira cópia> **(predefinição)** = um bónus de atratividade por tipo.\n<Acumulação normal> = todas as cópias.\n<Sem bónus de atratividade> = bónus global desligado.\n<Seguir definição geral> = regra geral.\n**A atratividade ajuda a atrair turistas.** O valor próprio do edifício mantém-se.\n**O texto verde** não muda.", // 15
            "Seguir definição geral", // 16
            "Só a primeira cópia", // 17
            "Acumulação normal", // 18
            "Sem bónus de atratividade", // 19
            "Efeitos dos edifícios emblemáticos nas proximidades", // 20
            "<Efeitos normais nas proximidades> = cada cópia produz os seus efeitos locais habituais.\n<Só a primeira cópia> = apenas uma cópia de cada tipo produz efeitos próximos.\n<Sem efeitos nas proximidades> = desativa os efeitos locais habituais desses edifícios.\nOs efeitos dos edifícios abandonados e a atratividade mantêm-se.", // 21
            "Efeitos normais nas proximidades", // 22
            "Só a primeira cópia", // 23
            "Sem efeitos nas proximidades", // 24
            "Desbloquear todos os edifícios emblemáticos", // 25
            "**LIGADO** = disponibiliza todos os edifícios emblemáticos sem requisitos de população, zonamento ou progresso.\n**DESLIGADO** = progressão normal do jogo.\nPredefinição: desligado. Apenas edifícios emblemáticos, não todos os únicos.", // 26
            "Ocultar avisos de desbloqueio em massa", // 27
            "**LIGADO** (recomendado, predefinição) = oculta os avisos do desbloqueio em massa feito por este mod.\n**DESLIGADO** = mostra um aviso por cada edifício emblemático desbloqueado pelo mod; podem ser dezenas ou centenas.\nOs avisos normais do jogo continuam a aparecer, incluindo edifícios novos de atualizações, DLC, pacotes regionais e progresso da cidade.", // 28
            "Permitir várias cópias", // 29
            "**LIGADO** = permite colocar várias cópias de objetos únicos, incluindo edifícios emblemáticos.\n**DESLIGADO** = uma cópia por cidade, a menos que outro mod permita mais.", // 30
            "Impedir vistas de informação automáticas para edifícios únicos", // 31
            "Impede que edifícios únicos, incluindo os emblemáticos, abram automaticamente o painel de informação e o mapa colorido durante a colocação. As vistas podem continuar a ser abertas manualmente. As outras ferramentas não mudam. Toggleable Overlays tem prioridade quando ativo. Predefinição: LIGADO.", // 32
            "Regra de colocação de objetos únicos", // 33
            "**Várias cópias permitidas** = limite de uma por cidade desligado.\n**Uma de cada tipo** = limite normal.\n<Anarchy> também pode permitir cópias.\nNão indica a acumulação de bónus.", // 34
            "Edifícios emblemáticos", // 35
            "**Colocados** = todos os edifícios emblemáticos.\n**Tipos** = modelos diferentes.\n<Cópias extra> = além do primeiro de cada tipo.\nInclui edifícios sem bónus global.", // 36
            "Bónus urbanos de edifícios Signature", // 37
            "**Ativos / Total** = fornecedores aceites pela regra geral / todos os presentes.\n<Bloqueados> = excluídos pela regra, não todas as cópias extra.\n**Atratividade independente:** um fornecedor bloqueado pode ainda contribuir.\nEfeitos próximos são separados.", // 38
            "Mods redundantes detetados", // 39
            "<Só a primeira cópia> = um bónus por tipo.\n<Acumulação normal> = todas as cópias.\n<Sem bónus> = desligado.\n<Seguir definição geral> = regra geral.\n**Mostra a regra escolhida, não o valor do bónus.**\nValores reais: **Sobre > Relatório no registo**. Texto verde inalterado.", // 40
            "Nenhuma cidade carregada", // 41
            "A carregar…", // 42
            "Carrega uma cidade para veres o estado", // 43
            "Várias cópias permitidas", // 44
            "Anarchy permite várias cópias", // 45
            "Outro mod permite vários edifícios únicos", // 46
            "Um de cada tipo", // 47
            "Regras mistas", // 48
            "{0} construídos | {1} tipos | {2} cópias extra", // 49
            "{0}/{1} ativos | {2} bloqueados", // 50
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
            "Bónus urbanos de outros edifícios únicos", // 62
            "Bónus de edifícios únicos que não são Signature, como a Câmara Municipal.\\nAtivos / Total = fontes aplicadas / existentes. Bloqueados = fontes excluídas pela regra. Os serviços comuns não são contabilizados.", // 63
        };

        public LocalePT_PT(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
