// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePT_BR.cs
// All 64 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocalePT_BR : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            // Mod title
            "Realistic Signature Buildings (Ícones)", // 0

            // Tabs
            "Ações", // 1
            "Sobre", // 2

            // Groups
            "Bônus de edifícios emblemáticos", // 3
            "Desbloqueio de edifícios emblemáticos", // 4
            "Posicionamento", // 5
            "Status", // 6
            "Informações", // 7
            "Depuração / Registro", // 8

            // Signature Bonuses
            "Bônus urbanos de edifícios únicos", // 9
            "<Só a primeira cópia> **(padrão)** = um bônus urbano por tipo de edifício único.\n<Sem bônus para a cidade> = desativa os bônus gerais; atratividade separada.\n<Acúmulo padrão> = todas as cópias contam.\n**O texto verde** continua mostrando os bônus originais, mesmo quando bloqueados.\nConfira **Ações > Status** ou o relatório no log.", // 10
            "Só a primeira cópia", // 11
            "Sem bônus para a cidade", // 12
            "Acúmulo padrão", // 13

            // Independent city-wide Attractiveness
            "Atratividade da cidade", // 14
            "<Só a primeira cópia> **(padrão)** = um bônus urbano de atratividade por tipo de edifício único elegível.\n<Acúmulo padrão> = todas as cópias contam.\n<Sem bônus de atratividade> = desativa esses bônus urbanos.\n<Seguir configuração geral> = usa a regra acima.\n**Atratividade atrai turistas.** A atratividade própria do edifício não muda.\n**O texto verde** é uma descrição fixa.", // 15
            "Seguir configuração geral", // 16
            "Só a primeira cópia", // 17
            "Acúmulo padrão", // 18
            "Sem bônus de atratividade", // 19

            // Nearby Signature effects
            "Efeitos locais de edifícios únicos", // 20
            "<Efeitos próximos padrão> **(padrão)** = toda cópia de edifício único mantém os efeitos próximos.\n<Só a primeira cópia> = uma por tipo.\n<Sem efeitos próximos> = desativa os efeitos normais; penalidades de edifícios abandonados continuam.\n**A atratividade do edifício** não muda.", // 21
            "Efeitos próximos padrão", // 22
            "Só a primeira cópia", // 23
            "Sem efeitos próximos", // 24

            // Signature Unlocks
            "Desbloquear todos os edifícios emblemáticos", // 25
            "**LIGADO** = libera edifícios emblemáticos sem requisitos de progresso.\n**DESLIGADO (padrão)** = desbloqueio normal.\n**Outros edifícios únicos**, como a Sede da Polícia, ainda exigem <pontos de desenvolvimento> em **Progressão > Desenvolvimento**.", // 26
            "Ocultar avisos de desbloqueio em massa", // 27
            "**LIGADO** (recomendado, padrão) = oculta os avisos do desbloqueio em massa feito por este mod.\n**DESLIGADO** = mostra um aviso para cada edifício emblemático recém-desbloqueado por este mod; podem ser dezenas ou centenas.\nOs avisos normais do jogo continuam aparecendo, inclusive novos edifícios de atualizações, DLC, pacotes regionais e progresso da cidade.", // 28

            // Multiple Unique
            "Permitir várias cópias", // 29
            "**LIGADO** = permite construir várias cópias de objetos únicos, incluindo edifícios emblemáticos.\n**DESLIGADO** = apenas uma cópia por cidade, exceto se outro mod permitir mais.", // 30
            "Mostrar edifícios claramente ao posicionar", // 31
            "**LIGADO (padrão)** = <visual livre>: evita escurecimento automático, mapa colorido e painel de informações ao posicionar edifícios únicos.\n**DESLIGADO** = comportamento automático original.\nVocê ainda pode abrir o painel de informações manualmente. <Toggle Overlays> tem prioridade.", // 32

            // Status
            "Regra de construção de objetos únicos", // 33
            "**Múltiplas cópias permitidas** = limite de uma por cidade desligado.\n**Uma de cada tipo** = limite normal.\n<Anarchy> também pode liberar cópias.\nIsso não mostra o acúmulo dos bônus.", // 34
            "Edifícios emblemáticos", // 35
            "**Colocados** = todos os edifícios emblemáticos.\n**Tipos** = modelos diferentes.\n<Cópias extras> = além do primeiro de cada tipo.\nConta edifícios sem bônus global.", // 36
            "Bônus urbanos de edifícios Signature", // 37
            "**Ativos / Total** = fornecedores incluídos pela regra geral / todos os encontrados.\n<Bloqueados> = excluídos pela regra, não todas as cópias extras.\n**Atratividade independente:** um fornecedor bloqueado ainda pode contribuir.\nEfeitos próximos são separados.", // 38

            // Other Unique city-wide bonuses
            "Bônus urbanos de outros edifícios únicos", // 39
            "Bônus de edifícios únicos que não são Signature, como a Prefeitura.\nAtivos / Total = fontes aplicadas / existentes. Bloqueados = fontes excluídas pela regra. Serviços comuns não entram na contagem.", // 40

            // Redundant mods
            "Mods redundantes detectados", // 41
            "**Nenhum** = nenhum outro mod conhecido de construção ilimitada de edifícios únicos foi detectado.\n<Anarchy> é compatível e não aparece aqui.\nEvite outros mods com a mesma função.", // 42

            // Localized Status values (not translated in log reports)
            "Nenhuma cidade carregada", // 43
            "Carregando…", // 44
            "Carregue uma cidade para ver o status", // 45
            "Várias cópias permitidas", // 46
            "Anarchy permite várias cópias", // 47
            "Cópias ilimitadas ainda permitidas", // 48
            "Um de cada tipo", // 49
            "Regras de construção mistas", // 50
            "{0} construídos | {1} tipos | {2} cópias extras", // 51
            "{0}/{1} ativos | {2} bloqueados", // 52
            "Nenhum", // 53

            // About
            "Mod", // 54
            "Nome exibido deste mod.", // 55
            "Versão", // 56
            "Versão instalada e tipo de compilação.", // 57
            "Relatório de status no log", // 58
            "Registra no log a quantidade atual de edifícios emblemáticos, os bônus da cidade e os efeitos próximos. Não altera configurações nem efeitos. Carregue uma cidade primeiro.", // 59
            "Comparar modos de bônus no log", // 60
            "Testa temporariamente todos os modos de bônus da cidade e efeitos próximos enquanto o jogo está pausado nas Opções. Depois reaplica os modos escolhidos. Os resultados ficam no log do mod. Carregue uma cidade primeiro.", // 61
            "Abrir registro", // 62
            "Abre o registro do mod ou, se não estiver disponível, a pasta de registros.", // 63
        };

        public LocalePT_BR(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
