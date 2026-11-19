// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleVI.cs
// All 64 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleVI : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Biểu tượng)", // 0
            "Thao tác", // 1
            "Giới thiệu", // 2
            "Thưởng từ công trình đặc trưng", // 3
            "Mở khóa công trình đặc trưng", // 4
            "Đặt công trình", // 5
            "Trạng thái", // 6
            "Thông tin", // 7
            "Gỡ lỗi / Nhật ký", // 8
            "Thưởng toàn thành phố từ công trình đặc trưng", // 9
            "<Chỉ bản đầu tiên> **(mặc định)** = một phần thưởng cho mỗi loại.\n<Không có thưởng toàn thành phố> = tắt thưởng chung; sức hút có quy tắc riêng.\n<Cộng dồn mặc định> = mọi bản đều tính.\n**Dòng thưởng màu xanh** vẫn hiện khi hiệu ứng bị chặn.\nXem **Hành động > Trạng thái** hoặc **Giới thiệu > Báo cáo nhật ký**.", // 10
            "Chỉ bản đầu tiên", // 11
            "Không có thưởng toàn thành phố", // 12
            "Cộng dồn mặc định", // 13
            "Sức hút toàn thành phố", // 14
            "<Chỉ bản đầu tiên> **(mặc định)** = một thưởng sức hút cho mỗi loại.\n<Cộng dồn mặc định> = mọi bản đều tính.\n<Không có thưởng sức hút> = tắt thưởng toàn thành phố.\n<Theo cài đặt toàn thành phố> = dùng quy tắc chung.\n**Sức hút giúp thu hút khách du lịch.** Giá trị riêng của công trình không đổi.\n**Dòng màu xanh** vẫn hiện.", // 15
            "Theo cài đặt toàn thành phố", // 16
            "Chỉ bản đầu tiên", // 17
            "Cộng dồn mặc định", // 18
            "Không có thưởng sức hút", // 19
            "Hiệu ứng xung quanh từ công trình đặc trưng", // 20
            "<Hiệu ứng mặc định> = mọi bản sao đều tạo hiệu ứng xung quanh như bình thường.\n<Chỉ bản đầu tiên> = mỗi loại chỉ có một bản sao tạo hiệu ứng.\n<Không có hiệu ứng xung quanh> = tắt hiệu ứng cục bộ thông thường của công trình đặc trưng.\nVẫn giữ hiệu ứng từ công trình bị bỏ hoang và độ hấp dẫn.", // 21
            "Hiệu ứng mặc định", // 22
            "Chỉ bản đầu tiên", // 23
            "Không có hiệu ứng xung quanh", // 24
            "Mở khóa mọi công trình đặc trưng", // 25
            "**BẬT** = mở tất cả công trình đặc trưng mà không cần đáp ứng dân số, phân vùng hay tiến trình.\n**TẮT** = mở khóa theo quy tắc gốc.\nMặc định: TẮT. Chỉ áp dụng cho công trình đặc trưng, không phải mọi công trình độc nhất.", // 26
            "Ẩn thông báo khi mở khóa hàng loạt công trình đặc trưng", // 27
            "**BẬT** (khuyến nghị, mặc định) = ẩn thông báo do mod này mở khóa hàng loạt công trình đặc trưng.\n**TẮT** = hiện thông báo cho từng công trình vừa được mod mở khóa; có thể có hàng chục hoặc hàng trăm thông báo.\nThông báo mở khóa thông thường của trò chơi vẫn hiện, kể cả công trình mới từ bản cập nhật, DLC, gói khu vực và tiến trình thành phố.", // 28
            "Cho phép nhiều bản sao", // 29
            "**BẬT** = đặt nhiều bản sao của các đối tượng độc đáo, kể cả công trình đặc trưng.\n**TẮT** = mỗi loại một bản trong thành phố, trừ khi mod khác cho phép.", // 30
            "Ngăn chế độ xem thông tin tự mở cho công trình độc đáo", // 31
            "Khi đặt công trình độc đáo, kể cả công trình đặc trưng, bảng thông tin và bản đồ màu sẽ không tự mở. Vẫn có thể mở thủ công. Các công cụ xây dựng khác không thay đổi. Toggleable Overlays được ưu tiên nếu đang hoạt động. Mặc định: BẬT.", // 32
            "Quy tắc đặt đối tượng độc đáo", // 33
            "**Cho phép nhiều bản** = bỏ giới hạn một công trình mỗi thành phố.\n**Mỗi loại một bản** = giới hạn bình thường.\n<Anarchy> cũng có thể cho phép bản sao.\nKhông phản ánh cộng dồn thưởng.", // 34
            "Công trình đặc trưng", // 35
            "**Đã xây** = tổng công trình đặc trưng.\n**Loại** = số kiểu công trình khác nhau.\n<Bản thêm> = bản sau công trình đầu mỗi loại.\nGồm cả công trình không có thưởng toàn thành phố.", // 36
            "Thưởng toàn thành phố từ công trình Signature", // 37
            "**Đang hoạt động / Tổng** = nguồn thưởng theo quy tắc chung / tất cả nguồn.\n<Bị chặn> = bị quy tắc chung loại bỏ, không phải mọi công trình thêm.\n**Sức hút độc lập:** nguồn bị chặn vẫn có thể góp sức hút.\nHiệu ứng xung quanh tính riêng.", // 38
            "Phát hiện mod trùng chức năng", // 39
            "<Chỉ bản đầu tiên> = một thưởng sức hút mỗi loại.\n<Cộng dồn mặc định> = mọi bản.\n<Không có thưởng> = tắt.\n<Theo cài đặt toàn thành phố> = quy tắc chung.\n**Hiện quy tắc đã chọn, không phải giá trị thưởng.**\nGiá trị thực: **Giới thiệu > Báo cáo nhật ký**. Dòng xanh không đổi.", // 40
            "Chưa tải thành phố", // 41
            "Đang tải…", // 42
            "Hãy tải thành phố để xem trạng thái", // 43
            "Cho phép nhiều bản sao", // 44
            "Anarchy cho phép nhiều bản sao", // 45
            "Mod khác cho phép xây nhiều công trình độc nhất", // 46
            "Mỗi loại một công trình", // 47
            "Quy tắc kết hợp", // 48
            "Đã xây {0} | {1} loại | {2} bản sao thêm", // 49
            "Hoạt động {0}/{1} | chặn {2}", // 50
            "Không có", // 51
            "Mod", // 52
            "Tên hiển thị của mod này.", // 53
            "Phiên bản", // 54
            "Phiên bản mod đã cài và loại bản dựng.", // 55
            "Ghi báo cáo trạng thái vào nhật ký", // 56
            "Ghi số lượng công trình đặc trưng hiện tại, phần thưởng toàn thành phố và hiệu ứng lân cận vào nhật ký. Không thay đổi cài đặt hoặc hiệu ứng. Hãy tải thành phố trước.", // 57
            "So sánh các chế độ phần thưởng vào nhật ký", // 58
            "Tạm thời thử tất cả chế độ phần thưởng toàn thành phố và hiệu ứng lân cận khi trò chơi đang tạm dừng trong Tùy chọn. Sau đó áp dụng lại các chế độ bạn đã chọn. Kết quả được ghi vào nhật ký mod. Hãy tải thành phố trước.", // 59
            "Mở nhật ký", // 60
            "Mở tệp nhật ký của mod hoặc thư mục nhật ký nếu tệp không có.", // 61
            "Thưởng toàn thành phố từ công trình độc đáo khác", // 62
            "Thưởng từ công trình độc đáo không thuộc nhóm Signature, như Tòa thị chính.\\nĐang áp dụng / Tổng = số nguồn thưởng có hiệu lực / hiện có. Bị chặn = số nguồn bị loại theo thiết lập. Không tính công trình dịch vụ thông thường.", // 63
        };

        public LocaleVI(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
