// <copyright file="LocaleTR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleTR.cs
// All 43 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleTR : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Gerçekçi İmza Binaları)", // 0
            "İşlemler", // 1
            "Hakkında", // 2
            "İmza bina bonusları", // 3
            "İmza binaların kilidini aç", // 4
            "Yerleştirme", // 5
            "Durum", // 6
            "Bilgi", // 7
            "Hata ayıklama / Günlük", // 8
            "Şehir genelinde imza bina bonusları", // 9
            "<Yalnızca ilk kopya> = her imza bina türü şehir genelindeki bonusunu yalnızca bir kez verir.\n<Şehir geneli bonusları yok> = bu bonusları kapatır.\n<Vanilla birikimi> = her kopya şehir geneli bonusunu verir.\nYakın çevre etkileri ayrı ayarlanır. Bina çekiciliği değişmez.", // 10
            "Yalnızca ilk kopya", // 11
            "Şehir geneli bonusları yok", // 12
            "Vanilla birikimi", // 13
            "İmza binaların yakın çevre etkileri", // 14
            "<Vanilla yakın çevre etkileri> = her kopya normal yakın çevre etkilerini sağlar.\n<Yalnızca ilk kopya> = her bina türünden yalnızca bir kopya etki sağlar.\n<Yakın çevre etkileri yok> = imza binaların normal yerel etkilerini kapatır.\nTerk edilmiş bina etkileri ve bina çekiciliği korunur.", // 15
            "Vanilla yakın çevre etkileri", // 16
            "Yalnızca ilk kopya", // 17
            "Yakın çevre etkileri yok", // 18
            "İmza bina açma koşullarını kaldır", // 19
            "**AÇIK** = nüfus, imar veya ilerleme şartı olmadan tüm imza binaları açar.\n**KAPALI** = normal oyun ilerlemesi.", // 20
            "Birden fazla kopyaya izin ver", // 21
            "**AÇIK** = imza binalar dâhil benzersiz olarak işaretlenen nesnelerin birden fazla kopyasını yerleştirir.\n**KAPALI** = başka bir mod izin vermedikçe şehirde her nesneden bir tane.", // 22
            "Benzersiz nesne yerleştirme kuralı", // 23
            "Benzersiz nesnelerden birden fazla yerleştirilip yerleştirilemeyeceğini gösterir.", // 24
            "İmza binalar", // 25
            "Yerleştirilen imza bina sayısını, farklı türleri ve ek kopyaları gösterir.", // 26
            "Şehir geneli bonus etkileri", // 27
            "Şehir genelinde bonus sağlayan imza binaları sayar.\nYakın çevre ve yerel bonuslar buna dâhil değildir.", // 28
            "Gereksiz modlar algılandı", // 29
            "Anarchy desteklenir ve burada listelenmez.\nDiğer sınırsız benzersiz bina modlarını kaldırın; bu özellik zaten mevcut.", // 30
            "Mod", // 31
            "Bu modun görünen adı.", // 32
            "Sürüm", // 33
            "Yüklü mod sürümü ve derleme türü.", // 34
            "Günlüğü aç", // 35
            "Mod günlüğünü veya yoksa günlükler klasörünü açar.", // 36
            "Toplu İmza bina açma bildirimlerini gizle", // 37
            "**AÇIK** (önerilen, varsayılan) = bu modun toplu İmza bina açma bildirimlerini gizler.\n**KAPALI** = modun yeni açtığı her bina için bildirim gösterir; onlarca veya yüzlerce bildirim olabilir.\nOyun güncellemeleri, DLC, bölge paketleri ve şehrin ilerlemesiyle gelen binalar dahil normal oyun bildirimleri görünmeye devam eder.", // 38
            "Benzersiz binalar için otomatik bilgi görünümlerini engelle", // 39
            "İmza binalar dâhil benzersiz binalar yerleştirilirken bilgi panelinin ve renkli haritanın otomatik açılmasını önler. Bilgi görünümleri elle açılabilir. Diğer inşa araçları değişmez. Toggleable Overlays etkinse öncelik ondadır. Varsayılan: KAPALI.", // 40
            "Durum raporunu günlüğe yaz", // 41
            "Şehir genelindeki bonus ve yakın çevre etkisi raporlarını çalıştırır, ardından seçilen modları geri yükler. Sonuçlar mod günlüğüne yazılır. Önce bir şehir yükleyin.", // 42
        };

        public LocaleTR(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
