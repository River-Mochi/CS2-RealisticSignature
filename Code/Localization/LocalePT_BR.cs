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
            "Realistic Signature Buildings (Ícones)", // 0
            "Ações", // 1
            "Sobre", // 2
            "Bônus de edifícios emblemáticos", // 3
            "Desbloqueio de edifícios emblemáticos", // 4
            "Posicionamento", // 5
            "Status", // 6
            "Informações", // 7
            "Depuração / Registro", // 8
            "Bônus de edifícios emblemáticos em toda a cidade", // 9
            "<Só a primeira cópia> **(padrão)** = um bônus por tipo.\n<Sem bônus globais> = desativa os bônus gerais; atratividade tem regra separada.\n<Acúmulo padrão> = todas as cópias contribuem.\n**O texto verde** do painel continua visível mesmo com o bônus bloqueado.\nVeja **Ações > Status** ou **Sobre > Relatório no log**.", // 10
            "Só a primeira cópia", // 11
            "Sem bônus para a cidade", // 12
            "Acúmulo padrão", // 13
            "Atratividade da cidade", // 14
            "<Só a primeira cópia> **(padrão)** = um bônus de atratividade por tipo.\n<Acúmulo padrão> = todas as cópias contribuem.\n<Sem bônus de atratividade> = bônus da cidade desligado.\n<Seguir configuração geral> = usar a regra geral.\n**Atratividade ajuda a atrair turistas.** A atratividade própria do prédio não muda.\n**O texto verde** continua visível.", // 15
            "Seguir configuração geral", // 16
            "Só a primeira cópia", // 17
            "Acúmulo padrão", // 18
            "Sem bônus de atratividade", // 19
            "Efeitos próximos de edifícios emblemáticos", // 20
            "<Efeitos próximos padrão> = cada cópia fornece seus efeitos locais normais.\n<Só a primeira cópia> = apenas uma cópia de cada tipo fornece efeitos próximos.\n<Sem efeitos próximos> = desativa os efeitos locais normais desses edifícios.\nEfeitos de edifícios abandonados e atratividade são preservados.", // 21
            "Efeitos próximos padrão", // 22
            "Só a primeira cópia", // 23
            "Sem efeitos próximos", // 24
            "Desbloquear todos os edifícios emblemáticos", // 25
            "**LIGADO** = disponibiliza todos os edifícios emblemáticos sem requisitos de população, zoneamento ou progresso.\n**DESLIGADO** = progressão normal do jogo.\nPadrão: desligado. Só para edifícios emblemáticos, não para todos os únicos.", // 26
            "Ocultar avisos de desbloqueio em massa", // 27
            "**LIGADO** (recomendado, padrão) = oculta os avisos do desbloqueio em massa feito por este mod.\n**DESLIGADO** = mostra um aviso para cada edifício emblemático recém-desbloqueado por este mod; podem ser dezenas ou centenas.\nOs avisos normais do jogo continuam aparecendo, inclusive novos edifícios de atualizações, DLC, pacotes regionais e progresso da cidade.", // 28
            "Permitir várias cópias", // 29
            "**LIGADO** = permite construir várias cópias de objetos únicos, incluindo edifícios emblemáticos.\n**DESLIGADO** = apenas uma cópia por cidade, exceto se outro mod permitir mais.", // 30
            "Impedir vistas de informação automáticas para edifícios únicos", // 31
            "Impede que edifícios únicos, incluindo os emblemáticos, abram automaticamente o painel de informações e o mapa colorido ao serem posicionados. As vistas ainda podem ser abertas manualmente. As outras ferramentas não mudam. Toggleable Overlays tem prioridade quando ativo. Padrão: LIGADO.", // 32
            "Regra de construção de objetos únicos", // 33
            "**Múltiplas cópias permitidas** = limite de uma por cidade desligado.\n**Uma de cada tipo** = limite normal.\n<Anarchy> também pode liberar cópias.\nIsso não mostra o acúmulo dos bônus.", // 34
            "Edifícios emblemáticos", // 35
            "**Colocados** = todos os edifícios emblemáticos.\n**Tipos** = modelos diferentes.\n<Cópias extras> = além do primeiro de cada tipo.\nConta edifícios sem bônus global.", // 36
            "Bônus urbanos de edifícios Signature", // 37
            "**Ativos / Total** = fornecedores incluídos pela regra geral / todos os encontrados.\n<Bloqueados> = excluídos pela regra, não todas as cópias extras.\n**Atratividade independente:** um fornecedor bloqueado ainda pode contribuir.\nEfeitos próximos são separados.", // 38
            "Mods redundantes detectados", // 39
            "<Só a primeira cópia> = um bônus por tipo.\n<Acúmulo padrão> = todas as cópias.\n<Sem bônus> = desligado.\n<Seguir configuração geral> = regra geral.\n**Mostra a regra escolhida, não o valor do bônus.**\nValores reais: **Sobre > Relatório no log**. Texto verde inalterado.", // 40
            "Nenhuma cidade carregada", // 41
            "Carregando…", // 42
            "Carregue uma cidade para ver o status", // 43
            "Várias cópias permitidas", // 44
            "Anarchy permite várias cópias", // 45
            "Outro mod permite vários edifícios únicos", // 46
            "Um de cada tipo", // 47
            "Regras mistas", // 48
            "{0} construídos | {1} tipos | {2} cópias extras", // 49
            "{0}/{1} ativos | {2} bloqueados", // 50
            "Nenhum", // 51
            "Mod", // 52
            "Nome exibido deste mod.", // 53
            "Versão", // 54
            "Versão instalada e tipo de compilação.", // 55
            "Relatório de status no log", // 56
            "Registra no log a quantidade atual de edifícios emblemáticos, os bônus da cidade e os efeitos próximos. Não altera configurações nem efeitos. Carregue uma cidade primeiro.", // 57
            "Comparar modos de bônus no log", // 58
            "Testa temporariamente todos os modos de bônus da cidade e efeitos próximos enquanto o jogo está pausado nas Opções. Depois reaplica os modos escolhidos. Os resultados ficam no log do mod. Carregue uma cidade primeiro.", // 59
            "Abrir registro", // 60
            "Abre o registro do mod ou, se não estiver disponível, a pasta de registros.", // 61
            "Bônus urbanos de outros edifícios únicos", // 62
            "Bônus de edifícios únicos que não são Signature, como a Prefeitura.\\nAtivos / Total = fontes aplicadas / existentes. Bloqueados = fontes excluídas pela regra. Serviços comuns não entram na contagem.", // 63
        };

        public LocalePT_BR(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
