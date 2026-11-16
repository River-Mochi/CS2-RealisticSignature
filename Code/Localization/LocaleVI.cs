// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleVI.cs
// All 62 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

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
            "<Chỉ bản đầu tiên> = mỗi loại công trình đặc trưng chỉ cộng thưởng toàn thành phố một lần.\n<Không có thưởng toàn thành phố> = tắt các khoản thưởng này.\n<Cộng dồn mặc định> = mỗi bản sao đều cộng thưởng.\nHiệu ứng xung quanh có thiết lập riêng. Độ hấp dẫn của công trình không đổi.", // 10
            "Chỉ bản đầu tiên", // 11
            "Không có thưởng toàn thành phố", // 12
            "Cộng dồn mặc định", // 13
            "Sức hút toàn thành phố", // 14
            "<Theo cài đặt toàn thành phố> = dùng quy tắc trên.\n<Chỉ bản đầu tiên> = một bản mỗi loại được tính.\n<Cộng dồn mặc định> = mọi bản đều được tính.\n<Không có thưởng sức hút> = tắt thưởng toàn thành phố của công trình đặc trưng.\nSức hút riêng và mô tả công trình không đổi.\nSức hút của thành phố giúp thu hút khách du lịch. Mặc định: chỉ bản đầu tiên.", // 15
            "Theo cài đặt toàn thành phố", // 16
            "Chỉ bản đầu tiên", // 17
            "Cộng dồn mặc định", // 18
            "Không có thưởng sức hút", // 19
            "Hiệu ứng xung quanh từ công trình đặc trưng", // 20
            "<Hiệu ứng mặc định> = mọi bản sao đều tạo hiệu ứng xung quanh như bình thường.\n<Chỉ bản đầu tiên> = mỗi loại chỉ có một bản sao tạo hiệu ứng.\n<Không có hiệu ứng xung quanh> = tắt hiệu ứng cục bộ thông thường của công trình đặc trưng.\nVẫn giữ hiệu ứng từ công trình bị bỏ hoang và độ hấp dẫn.", // 21
            "Hiệu ứng mặc định", // 22
            "Chỉ bản đầu tiên", // 23
            "Không có hiệu ứng xung quanh", // 24
            "Bỏ yêu cầu mở khóa công trình đặc trưng", // 25
            "**BẬT** = mở tất cả công trình đặc trưng mà không cần đáp ứng dân số, phân vùng hay tiến trình.\n**TẮT** = mở khóa theo quy tắc gốc.", // 26
            "Ẩn thông báo khi mở khóa hàng loạt công trình đặc trưng", // 27
            "**BẬT** (khuyến nghị, mặc định) = ẩn thông báo do mod này mở khóa hàng loạt công trình đặc trưng.\n**TẮT** = hiện thông báo cho từng công trình vừa được mod mở khóa; có thể có hàng chục hoặc hàng trăm thông báo.\nThông báo mở khóa thông thường của trò chơi vẫn hiện, kể cả công trình mới từ bản cập nhật, DLC, gói khu vực và tiến trình thành phố.", // 28
            "Cho phép nhiều bản sao", // 29
            "**BẬT** = đặt nhiều bản sao của các đối tượng độc đáo, kể cả công trình đặc trưng.\n**TẮT** = mỗi loại một bản trong thành phố, trừ khi mod khác cho phép.", // 30
            "Ngăn chế độ xem thông tin tự mở cho công trình độc đáo", // 31
            "Khi đặt công trình độc đáo, kể cả công trình đặc trưng, bảng thông tin và bản đồ màu sẽ không tự mở. Vẫn có thể mở thủ công. Các công cụ xây dựng khác không thay đổi. Toggleable Overlays được ưu tiên nếu đang hoạt động. Mặc định: BẬT.", // 32
            "Quy tắc đặt đối tượng độc đáo", // 33
            "Cho biết hiện có được đặt nhiều bản sao của đối tượng độc đáo hay không.", // 34
            "Công trình đặc trưng", // 35
            "Hiển thị tổng công trình đặc trưng, số loại khác nhau và số bản sao thêm.", // 36
            "Hiệu ứng thưởng toàn thành phố", // 37
            "Đếm công trình đặc trưng có thưởng toàn thành phố.\nKhông tính hiệu ứng cục bộ hoặc lân cận.", // 38
            "Phát hiện mod trùng chức năng", // 39
            "Hỗ trợ Anarchy nên không liệt kê tại đây.\nHãy gỡ các mod cho phép vô hạn công trình độc đáo khác vì tính năng này đã có sẵn.", // 40
            "Chưa tải thành phố", // 41
            "Đang tải…", // 42
            "Hãy tải thành phố để xem trạng thái", // 43
            "Cho phép nhiều bản sao", // 44
            "Anarchy cho phép nhiều bản sao", // 45
            "Mod khác cho phép xây nhiều công trình độc nhất", // 46
            "Mỗi loại một công trình", // 47
            "Quy tắc kết hợp", // 48
            "Đã xây {0} | {1} loại | {2} bản sao thêm", // 49
            "{0} nguồn thưởng đang hoạt động | {1} nguồn thưởng trùng", // 50
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
        };

        public LocaleVI(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
