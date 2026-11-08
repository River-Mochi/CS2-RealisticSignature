// <copyright file="LocaleKO.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleKO.cs
// All 43 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleKO : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (현실적인 시그니처 건물)", // 0
            "작업", // 1
            "정보", // 2
            "시그니처 건물 보너스", // 3
            "시그니처 건물 잠금 해제", // 4
            "고유 건물 중복 배치", // 5
            "상태", // 6
            "안내", // 7
            "디버그 / 로그", // 8
            "시그니처 건물의 도시 전체 보너스", // 9
            "<첫 건물만 적용> = 같은 종류의 시그니처 건물은 도시 전체 보너스를 한 번만 제공합니다.\n<도시 전체 보너스 없음> = 도시 전체 보너스를 끕니다.\n<기본 중첩> = 모든 복제 건물이 보너스를 제공합니다.\n주변 효과는 별도로 설정합니다. 건물 매력도는 그대로 유지됩니다.", // 10
            "첫 건물만 적용", // 11
            "도시 전체 보너스 없음", // 12
            "기본 중첩", // 13
            "시그니처 건물의 주변 효과", // 14
            "<기본 주변 효과> = 모든 복제 건물이 정상적인 주변 효과를 제공합니다.\n<첫 건물만 적용> = 각 종류에서 한 건물만 주변 효과를 제공합니다.\n<주변 효과 없음> = 시그니처 건물의 일반 주변 효과를 끕니다.\n버려진 건물의 효과와 건물 매력도는 유지됩니다.", // 15
            "기본 주변 효과", // 16
            "첫 건물만 적용", // 17
            "주변 효과 없음", // 18
            "시그니처 건물 해금 조건 제거", // 19
            "**켜짐** = 인구, 구역 또는 진행 조건을 충족하지 않아도 모든 시그니처 건물을 사용할 수 있습니다.\n**꺼짐** = 게임 기본 진행 규칙을 따릅니다.", // 20
            "여러 개 배치 허용", // 21
            "**켜짐** = 시그니처 건물을 포함한 고유 대상의 여러 복제본을 배치할 수 있습니다.\n**꺼짐** = 다른 모드가 허용하지 않으면 도시당 하나만 배치할 수 있습니다.", // 22
            "고유 건물 배치 규칙", // 23
            "현재 고유 대상을 여러 개 배치할 수 있는지 보여 줍니다.", // 24
            "시그니처 건물", // 25
            "배치된 시그니처 건물 수, 종류 수, 추가 복제본 수를 보여 줍니다.", // 26
            "도시 전체 보너스 효과", // 27
            "도시 전체 보너스가 있는 시그니처 건물을 셉니다.\n주변 및 지역 효과는 포함하지 않습니다.", // 28
            "보너스 보고서를 로그에 기록", // 29
            "도시 전체 보너스의 세 가지 모드를 시험하고 실제 도시 값을 로그에 기록한 뒤 선택한 모드로 복원합니다. 직접 비교할 필요가 없습니다.", // 30
            "주변 효과 보고서를 로그에 기록", // 31
            "주변 효과의 세 가지 모드를 로그에서 확인하고 선택한 모드로 복원합니다.", // 32
            "중복 모드 감지됨", // 33
            "Anarchy는 지원되므로 여기에 표시되지 않습니다.\n고유 건물 무제한 배치 기능이 겹치는 다른 모드는 제거하세요.", // 34
            "모드", // 35
            "이 모드의 표시 이름입니다.", // 36
            "버전", // 37
            "설치된 모드 버전과 빌드 종류입니다.", // 38
            "로그 열기", // 39
            "이 모드의 로그 파일을 엽니다. 없으면 로그 폴더를 엽니다.", // 40
            "일괄 잠금 해제 알림 표시", // 41
            "**꺼짐** (기본값) = 수많은 알림 없이 시그니처 건물을 잠금 해제합니다.\n**켜짐** = 일괄 해제 시 새롭게 잠금 해제된 건물마다 알림을 표시합니다.\n지난 해제 알림을 다시 표시하지 않으며 일반 게임 알림에는 영향을 주지 않습니다.", // 42
        };

        public LocaleKO(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
