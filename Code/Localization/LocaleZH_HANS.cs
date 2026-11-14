// <copyright file="LocaleZH_HANS.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_HANS.cs
// All 43 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleZH_HANS : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings（更真实的标志性建筑）", // 0
            "操作", // 1
            "关于", // 2
            "标志性建筑加成", // 3
            "解锁标志性建筑", // 4
            "放置", // 5
            "状态", // 6
            "信息", // 7
            "调试 / 日志", // 8
            "标志性建筑的全城加成", // 9
            "<仅首栋生效> = 每种标志性建筑的全城加成只生效一次。\n<无全城加成> = 关闭标志性建筑的全城加成。\n<原版叠加> = 每一栋都提供全城加成。\n附近效果单独设置，建筑吸引力保持不变。", // 10
            "仅首栋生效", // 11
            "无全城加成", // 12
            "原版叠加", // 13
            "标志性建筑的附近效果", // 14
            "<原版附近效果> = 每一栋都提供正常的附近效果。\n<仅首栋生效> = 每种建筑只有一栋提供附近效果。\n<无附近效果> = 关闭标志性建筑的正常局部效果。\n废弃建筑的效果和建筑吸引力仍会保留。", // 15
            "原版附近效果", // 16
            "仅首栋生效", // 17
            "无附近效果", // 18
            "解除标志性建筑的解锁条件", // 19
            "**开启** = 无需满足人口、分区或发展进度条件，即可使用所有标志性建筑。\n**关闭** = 按游戏原版进度解锁。", // 20
            "允许放置多个副本", // 21
            "**开启** = 可以重复放置所有标记为独特的对象，包括标志性建筑。\n**关闭** = 每城只能放一个，除非其他模组允许重复放置。", // 22
            "独特对象的放置规则", // 23
            "显示当前是否允许重复放置独特对象。", // 24
            "标志性建筑", // 25
            "显示已放置的标志性建筑数量、不同种类及额外副本数量。", // 26
            "全城加成效果", // 27
            "统计具有全城加成的标志性建筑。\n不包括局部及附近效果。", // 28
            "检测到功能重复的模组", // 29
            "支持 Anarchy，因此不会在此列出。\n请移除其他允许无限放置独特建筑的模组，因为本模组已提供此功能。", // 30
            "模组", // 31
            "此模组的显示名称。", // 32
            "版本", // 33
            "已安装的模组版本和构建类型。", // 34
            "打开日志", // 35
            "打开模组日志文件；若不存在，则打开日志文件夹。", // 36
            "隐藏批量解锁标志性建筑的弹窗", // 37
            "**开启**（推荐、默认）= 隐藏本模组批量解锁标志性建筑所产生的弹窗。\n**关闭** = 本模组每解锁一栋新建筑就显示弹窗，可能出现数十甚至数百条。\n游戏的正常解锁通知仍会显示，包括游戏更新、DLC、地区建筑包新增的建筑及城市发展进度带来的通知。", // 38
            "阻止独特建筑自动打开信息视图", // 39
            "放置独特建筑（包括标志性建筑）时，不自动打开信息视图面板和彩色地图。仍可手动打开信息视图。其他建筑工具不受影响。若 Toggleable Overlays 已启用，则由该模组优先控制。默认：关闭。", // 40
            "将状态报告写入日志", // 41
            "运行全城加成和周边效果报告，然后恢复所选模式。结果写入本模组日志。请先加载城市。", // 42
        };

        public LocaleZH_HANS(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
