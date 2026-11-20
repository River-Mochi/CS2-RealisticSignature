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
            // Mod title
            "Realistic Signature Buildings (Ícones)", // 0

            // Tabs
            "Ações", // 1
            "Sobre", // 2

            // Groups
            "Bónus de edifícios emblemáticos", // 3
            "Desbloqueio de edifícios emblemáticos", // 4
            "Colocação", // 5
            "Estado", // 6
            "Informações", // 7
            "Depuração / Registo", // 8

            // Signature Bonuses
            "Bónus urbanos de edifícios únicos", // 9
            "<Só a primeira cópia> **(predefinição)** = um bónus urbano por tipo de edifício único.\n<Sem bónus globais> = desativa os bónus gerais; atratividade separada.\n<Acumulação normal> = todas as cópias contam.\n**O texto verde** mantém os bónus originais, mesmo quando bloqueados.\nConsulta **Ações > Estado** ou o relatório no registo.", // 10
            "Só a primeira cópia", // 11
            "Sem bónus globais", // 12
            "Acumulação normal", // 13

            // Independent city-wide Attractiveness
            "Atratividade da cidade", // 14
            "<Só a primeira cópia> **(predefinição)** = um bónus urbano de atratividade por tipo de edifício único elegível.\n<Acumulação normal> = todas as cópias contam.\n<Sem bónus de atratividade> = desativa esses bónus urbanos.\n<Seguir definição geral> = aplica a regra acima.\n**A atratividade atrai turistas.** O valor próprio do edifício mantém-se.\n**O texto verde** é uma descrição fixa.", // 15
            "Seguir definição geral", // 16
            "Só a primeira cópia", // 17
            "Acumulação normal", // 18
            "Sem bónus de atratividade", // 19

            // Nearby Signature effects
            "Efeitos locais de edifícios únicos", // 20
            "<Efeitos normais nas proximidades> **(predefinição)** = cada cópia de edifício único mantém os efeitos próximos.\n<Só a primeira cópia> = uma por tipo.\n<Sem efeitos nas proximidades> = desativa os efeitos normais; as penalizações por abandono mantêm-se.\n**A atratividade do edifício** não muda.", // 21
            "Efeitos normais nas proximidades", // 22
            "Só a primeira cópia", // 23
            "Sem efeitos nas proximidades", // 24

            // Signature Unlocks
            "Desbloquear todos os edifícios emblemáticos", // 25
            "**LIGADO** = desbloqueia edifícios emblemáticos sem requisitos de progresso.\n**DESLIGADO (predefinição)** = desbloqueio normal.\n**Outros edifícios únicos**, como o Quartel-General da Polícia, continuam a exigir <pontos de desenvolvimento> em **Progressão > Desenvolvimento**.", // 26
            "Ocultar avisos de desbloqueio em massa", // 27
            "**LIGADO** (recomendado, predefinição) = oculta os avisos do desbloqueio em massa feito por este mod.\n**DESLIGADO** = mostra um aviso por cada edifício emblemático desbloqueado pelo mod; podem ser dezenas ou centenas.\nOs avisos normais do jogo continuam a aparecer, incluindo edifícios novos de atualizações, DLC, pacotes regionais e progresso da cidade.", // 28

            // Multiple Unique
            "Permitir várias cópias", // 29
            "**LIGADO** = permite colocar várias cópias de objetos únicos, incluindo edifícios emblemáticos.\n**DESLIGADO** = uma cópia por cidade, a menos que outro mod permita mais.", // 30
            "Mostrar os edifícios claramente ao colocar", // 31
            "**LIGADO (predefinição)** = <vista desimpedida>: evita escurecimento automático, mapa colorido e painel informativo durante a colocação de edifícios únicos.\n**DESLIGADO** = comportamento automático normal.\nPodes continuar a abrir o painel de informações manualmente. <Toggle Overlays> tem prioridade.", // 32

            // Status
            "Regra de colocação de objetos únicos", // 33
            "**Várias cópias permitidas** = limite de uma por cidade desligado.\n**Uma de cada tipo** = limite normal.\n<Anarchy> também pode permitir cópias.\nNão indica a acumulação de bónus.", // 34
            "Edifícios emblemáticos", // 35
            "**Colocados** = todos os edifícios emblemáticos.\n**Tipos** = modelos diferentes.\n<Cópias extra> = além do primeiro de cada tipo.\nInclui edifícios sem bónus global.", // 36
            "Bónus urbanos de edifícios Signature", // 37
            "**Ativos / Total** = fornecedores aceites pela regra geral / todos os presentes.\n<Bloqueados> = excluídos pela regra, não todas as cópias extra.\n**Atratividade independente:** um fornecedor bloqueado pode ainda contribuir.\nEfeitos próximos são separados.", // 38

            // Other Unique city-wide bonuses
            "Bónus urbanos de outros edifícios únicos", // 39
            "Bónus de edifícios únicos que não são Signature, como a Câmara Municipal.\nAtivos / Total = fontes aplicadas / existentes. Bloqueados = fontes excluídas pela regra. Os serviços comuns não são contabilizados.", // 40

            // Redundant mods
            "Mods redundantes detetados", // 41
            "**Nenhum** = não foi detetado outro mod conhecido de colocação múltipla de edifícios únicos.\n<Anarchy> é compatível e não aparece aqui.\nEvita outros mods com a mesma função.", // 42

            // Localized Status values (not translated in log reports)
            "Nenhuma cidade carregada", // 43
            "A carregar…", // 44
            "Carrega uma cidade para veres o estado", // 45
            "Várias cópias permitidas", // 46
            "Anarchy permite várias cópias", // 47
            "Cópias ilimitadas ainda permitidas", // 48
            "Um de cada tipo", // 49
            "Regras de colocação mistas", // 50
            "{0} construídos | {1} tipos | {2} cópias extra", // 51
            "{0}/{1} ativos | {2} bloqueados", // 52
            "Nenhum", // 53

            // About
            "Mod", // 54
            "Nome apresentado deste mod.", // 55
            "Versão", // 56
            "Versão instalada e tipo de compilação.", // 57
            "Relatório de estado no registo", // 58
            "Regista no log a quantidade atual de edifícios emblemáticos, os bónus da cidade e os efeitos próximos. Não altera definições nem efeitos. Carrega primeiro uma cidade.", // 59
            "Comparar modos de bónus no log", // 60
            "Testa temporariamente todos os modos de bónus da cidade e efeitos próximos enquanto o jogo está em pausa nas Opções. Depois volta a aplicar os modos escolhidos. Os resultados ficam no log do mod. Carrega primeiro uma cidade.", // 61
            "Abrir registo", // 62
            "Abre o registo do mod ou, se indisponível, a pasta dos registos.", // 63
        };

        public LocalePT_PT(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
