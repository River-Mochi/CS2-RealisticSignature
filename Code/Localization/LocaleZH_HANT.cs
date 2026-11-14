// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_HANT.cs
// All 45 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleZH_HANT : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings（更真實的地標建築）", // 0
            "操作", // 1
            "關於", // 2
            "地標建築加成", // 3
            "解鎖地標建築", // 4
            "放置", // 5
            "狀態", // 6
            "資訊", // 7
            "偵錯 / 紀錄", // 8
            "地標建築的全市加成", // 9
            "<僅第一棟生效> = 每種地標建築的全市加成只套用一次。\n<無全市加成> = 關閉地標建築的全市加成。\n<原版累加> = 每一棟都提供全市加成。\n附近效果可另外設定，建築吸引力維持不變。", // 10
            "僅第一棟生效", // 11
            "無全市加成", // 12
            "原版累加", // 13
            "地標建築的附近效果", // 14
            "<原版附近效果> = 每一棟都提供正常的附近效果。\n<僅第一棟生效> = 每種建築只有一棟提供附近效果。\n<無附近效果> = 關閉地標建築的正常局部效果。\n廢棄建築的效果與建築吸引力會保留。", // 15
            "原版附近效果", // 16
            "僅第一棟生效", // 17
            "無附近效果", // 18
            "解除地標建築的解鎖條件", // 19
            "**開啟** = 不必達成人口、分區或發展進度條件，即可使用所有地標建築。\n**關閉** = 依照遊戲原版進度解鎖。", // 20
            "允許放置多個複本", // 21
            "**開啟** = 可重複放置標記為獨特的物件，包括地標建築。\n**關閉** = 每座城市只能放一個，除非其他模組允許重複放置。", // 22
            "獨特物件放置規則", // 23
            "顯示目前能否重複放置獨特物件。", // 24
            "地標建築", // 25
            "顯示已放置的地標建築數量、不同類型與額外複本數量。", // 26
            "全市加成效果", // 27
            "統計具有全市加成的地標建築。\n不包含局部與附近效果。", // 28
            "將加成報告寫入紀錄", // 29
            "依序測試三種全市加成模式，將實際城市數值寫入紀錄，再恢復所選模式。無須手動比較。", // 30
            "將附近效果報告寫入紀錄", // 31
            "在紀錄中檢查三種附近效果模式，再恢復所選模式。", // 32
            "偵測到功能重複的模組", // 33
            "支援 Anarchy，因此不會列在這裡。\n請移除其他允許無限放置獨特建築的模組，因為本模組已有此功能。", // 34
            "模組", // 35
            "此模組的顯示名稱。", // 36
            "版本", // 37
            "已安裝的模組版本和建置類型。", // 38
            "開啟紀錄", // 39
            "開啟模組紀錄檔案；若沒有檔案，則開啟紀錄資料夾。", // 40
            "隱藏大量解鎖地標建築時的通知", // 41
            "**開啟**（建議、預設）= 隱藏本模組批量解鎖地標建築所產生的通知。\n**關閉** = 本模組每解鎖一棟新建築就顯示通知，可能出現數十甚至數百則。\n遊戲的正常解鎖通知仍會顯示，包括遊戲更新、DLC、地區建築包新增的建築及城市發展進度帶來的通知。", // 42
            "放置地標建築時不自動開啟資訊檢視", // 43
            "選擇地標建築進行放置時，不自動開啟資訊檢視面板和彩色地圖圖層。仍可手動開啟資訊檢視。其他建築工具不受影響。若 Toggleable Overlays 已啟用，則由該模組優先控制。預設：關閉。", // 44
        };

        public LocaleZH_HANT(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
