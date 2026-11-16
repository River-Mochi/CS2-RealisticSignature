// <copyright file="LocaleTR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleTR.cs
// All 62 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleTR : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Realistic Signature Buildings (Simgeler)", // 0
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
            "Şehir geneli çekicilik", // 14
            "<Şehir geneli ayarını izle> = yukarıdaki kuralı kullanır.\n<Yalnızca ilk kopya> = her türden yalnızca biri katkı sağlar.\n<Vanilla birikimi> = tüm kopyalar katkı sağlar.\n<Çekicilik bonusu yok> = imza binalarının şehir bonusu kapatılır.\nBinanın çekiciliği ve bilgi paneli metni değişmez.\nŞehir çekiciliği turist çekmeye yardımcı olur. Varsayılan: yalnızca ilk kopya.", // 15
            "Şehir geneli ayarını izle", // 16
            "Yalnızca ilk kopya", // 17
            "Vanilla birikimi", // 18
            "Çekicilik bonusu yok", // 19
            "İmza binaların yakın çevre etkileri", // 20
            "<Vanilla yakın çevre etkileri> = her kopya normal yakın çevre etkilerini sağlar.\n<Yalnızca ilk kopya> = her bina türünden yalnızca bir kopya etki sağlar.\n<Yakın çevre etkileri yok> = imza binaların normal yerel etkilerini kapatır.\nTerk edilmiş bina etkileri ve bina çekiciliği korunur.", // 21
            "Vanilla yakın çevre etkileri", // 22
            "Yalnızca ilk kopya", // 23
            "Yakın çevre etkileri yok", // 24
            "İmza bina açma koşullarını kaldır", // 25
            "**AÇIK** = nüfus, imar veya ilerleme şartı olmadan tüm imza binaları açar.\n**KAPALI** = normal oyun ilerlemesi.", // 26
            "Toplu İmza bina açma bildirimlerini gizle", // 27
            "**AÇIK** (önerilen, varsayılan) = bu modun toplu İmza bina açma bildirimlerini gizler.\n**KAPALI** = modun yeni açtığı her bina için bildirim gösterir; onlarca veya yüzlerce bildirim olabilir.\nOyun güncellemeleri, DLC, bölge paketleri ve şehrin ilerlemesiyle gelen binalar dahil normal oyun bildirimleri görünmeye devam eder.", // 28
            "Birden fazla kopyaya izin ver", // 29
            "**AÇIK** = imza binalar dâhil benzersiz olarak işaretlenen nesnelerin birden fazla kopyasını yerleştirir.\n**KAPALI** = başka bir mod izin vermedikçe şehirde her nesneden bir tane.", // 30
            "Benzersiz binalar için otomatik bilgi görünümlerini engelle", // 31
            "İmza binalar dâhil benzersiz binalar yerleştirilirken bilgi panelinin ve renkli haritanın otomatik açılmasını önler. Bilgi görünümleri elle açılabilir. Diğer inşa araçları değişmez. Toggleable Overlays etkinse öncelik ondadır. Varsayılan: AÇIK.", // 32
            "Benzersiz nesne yerleştirme kuralı", // 33
            "Benzersiz nesnelerden birden fazla yerleştirilip yerleştirilemeyeceğini gösterir.", // 34
            "İmza binalar", // 35
            "Yerleştirilen imza bina sayısını, farklı türleri ve ek kopyaları gösterir.", // 36
            "Şehir geneli bonus etkileri", // 37
            "Şehir genelinde bonus sağlayan imza binaları sayar.\nYakın çevre ve yerel bonuslar buna dâhil değildir.", // 38
            "Gereksiz modlar algılandı", // 39
            "Anarchy desteklenir ve burada listelenmez.\nDiğer sınırsız benzersiz bina modlarını kaldırın; bu özellik zaten mevcut.", // 40
            "Şehir yüklenmedi", // 41
            "Yükleniyor…", // 42
            "Durumu görmek için önce bir şehir yükleyin", // 43
            "Birden fazla kopyaya izin veriliyor", // 44
            "Anarchy birden fazla kopyaya izin veriyor", // 45
            "Başka bir mod birden fazla benzersiz binaya izin veriyor", // 46
            "Her türden bir tane", // 47
            "Karma kurallar", // 48
            "{0} yerleştirildi | {1} tür | {2} ek kopya", // 49
            "{0} etkin bonus kaynağı | {1} yinelenen kaynak", // 50
            "Yok", // 51
            "Mod", // 52
            "Bu modun görünen adı.", // 53
            "Sürüm", // 54
            "Yüklü mod sürümü ve derleme türü.", // 55
            "Durum raporunu günlüğe yaz", // 56
            "Mevcut İmza bina sayılarını, şehir genelindeki bonusları ve yakın çevre etkilerini günlüğe yazar. Ayarları veya etkileri değiştirmez. Önce bir şehir yükleyin.", // 57
            "Bonus modlarını günlüğe karşılaştır", // 58
            "Oyun Seçenekler menüsünde duraklatılmışken tüm şehir geneli bonus ve yakın çevre etkisi modlarını geçici olarak dener. Ardından seçtiğiniz modları yeniden uygular. Sonuçlar mod günlüğüne yazılır. Önce bir şehir yükleyin.", // 59
            "Günlüğü aç", // 60
            "Mod günlüğünü veya yoksa günlükler klasörünü açar.", // 61
        };

        public LocaleTR(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
