// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleVI.cs
// All 45 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleVI : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Công trình đặc trưng chân thực)", // 0
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
            "Hiệu ứng xung quanh từ công trình đặc trưng", // 14
            "<Hiệu ứng mặc định> = mọi bản sao đều tạo hiệu ứng xung quanh như bình thường.\n<Chỉ bản đầu tiên> = mỗi loại chỉ có một bản sao tạo hiệu ứng.\n<Không có hiệu ứng xung quanh> = tắt hiệu ứng cục bộ thông thường của công trình đặc trưng.\nVẫn giữ hiệu ứng từ công trình bị bỏ hoang và độ hấp dẫn.", // 15
            "Hiệu ứng mặc định", // 16
            "Chỉ bản đầu tiên", // 17
            "Không có hiệu ứng xung quanh", // 18
            "Bỏ yêu cầu mở khóa công trình đặc trưng", // 19
            "**BẬT** = mở tất cả công trình đặc trưng mà không cần đáp ứng dân số, phân vùng hay tiến trình.\n**TẮT** = mở khóa theo quy tắc gốc.", // 20
            "Ẩn thông báo khi mở khóa hàng loạt công trình đặc trưng", // 21
            "**BẬT** (khuyến nghị, mặc định) = ẩn thông báo do mod này mở khóa hàng loạt công trình đặc trưng.\n**TẮT** = hiện thông báo cho từng công trình vừa được mod mở khóa; có thể có hàng chục hoặc hàng trăm thông báo.\nThông báo mở khóa thông thường của trò chơi vẫn hiện, kể cả công trình mới từ bản cập nhật, DLC, gói khu vực và tiến trình thành phố.", // 22
            "Cho phép nhiều bản sao", // 23
            "**BẬT** = đặt nhiều bản sao của các đối tượng độc đáo, kể cả công trình đặc trưng.\n**TẮT** = mỗi loại một bản trong thành phố, trừ khi mod khác cho phép.", // 24
            "Ngăn chế độ xem thông tin tự mở cho công trình độc đáo", // 25
            "Khi đặt công trình độc đáo, kể cả công trình đặc trưng, bảng thông tin và bản đồ màu sẽ không tự mở. Vẫn có thể mở thủ công. Các công cụ xây dựng khác không thay đổi. Toggleable Overlays được ưu tiên nếu đang hoạt động. Mặc định: BẬT.", // 26
            "Quy tắc đặt đối tượng độc đáo", // 27
            "Cho biết hiện có được đặt nhiều bản sao của đối tượng độc đáo hay không.", // 28
            "Công trình đặc trưng", // 29
            "Hiển thị tổng công trình đặc trưng, số loại khác nhau và số bản sao thêm.", // 30
            "Hiệu ứng thưởng toàn thành phố", // 31
            "Đếm công trình đặc trưng có thưởng toàn thành phố.\nKhông tính hiệu ứng cục bộ hoặc lân cận.", // 32
            "Phát hiện mod trùng chức năng", // 33
            "Hỗ trợ Anarchy nên không liệt kê tại đây.\nHãy gỡ các mod cho phép vô hạn công trình độc đáo khác vì tính năng này đã có sẵn.", // 34
            "Mod", // 35
            "Tên hiển thị của mod này.", // 36
            "Phiên bản", // 37
            "Phiên bản mod đã cài và loại bản dựng.", // 38
            "Ghi báo cáo trạng thái vào nhật ký", // 39
            "Ghi số lượng công trình đặc trưng hiện tại, phần thưởng toàn thành phố và hiệu ứng lân cận vào nhật ký. Không thay đổi cài đặt hoặc hiệu ứng. Hãy tải thành phố trước.", // 40
            "So sánh các chế độ phần thưởng vào nhật ký", // 41
            "Tạm thời thử tất cả chế độ phần thưởng toàn thành phố và hiệu ứng lân cận khi trò chơi đang tạm dừng trong Tùy chọn. Sau đó áp dụng lại các chế độ bạn đã chọn. Kết quả được ghi vào nhật ký mod. Hãy tải thành phố trước.", // 42
            "Mở nhật ký", // 43
            "Mở tệp nhật ký của mod hoặc thư mục nhật ký nếu tệp không có.", // 44
            "Chưa tải thành phố", // 45
            "Đang tải…", // 46
            "Hãy tải thành phố để xem trạng thái", // 47
            "Cho phép nhiều bản sao", // 48
            "Anarchy cho phép nhiều bản sao", // 49
            "Mod khác cho phép xây nhiều công trình độc nhất", // 50
            "Mỗi loại một công trình", // 51
            "Quy tắc kết hợp", // 52
            "Đã xây {0} | {1} loại | {2} bản sao thêm", // 53
            "{0} nguồn thưởng đang hoạt động | {1} nguồn thưởng trùng", // 54
            "Không có", // 55
        };

        public LocaleVI(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
