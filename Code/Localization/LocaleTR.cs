// <copyright file="LocaleTR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleTR.cs
// All 41 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleTR : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            "Better Unique Buildings (Geliştirilmiş Benzersiz Binalar)", // 0
            "İşlemler", // 1
            "Hakkında", // 2
            "İmza bina bonusları", // 3
            "İmza binaların kilidini aç", // 4
            "Birden fazla benzersiz bina", // 5
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
            "Bonus raporunu günlüğe yaz", // 29
            "Üç şehir geneli bonus modunu dener, gerçek şehir değerlerini günlüğe yazar ve seçilen modu geri yükler. Elle karşılaştırma gerekmez.", // 30
            "Yakın çevre raporunu günlüğe yaz", // 31
            "Üç yakın çevre modunu günlükte kontrol eder ve seçilen modu geri yükler.", // 32
            "Gereksiz modlar algılandı", // 33
            "Anarchy desteklenir ve burada listelenmez.\nDiğer sınırsız benzersiz bina modlarını kaldırın; bu özellik zaten mevcut.", // 34
            "Mod", // 35
            "Bu modun görünen adı.", // 36
            "Sürüm", // 37
            "Yüklü mod sürümü ve derleme türü.", // 38
            "Günlüğü aç", // 39
            "Mod günlüğünü veya yoksa günlükler klasörünü açar.", // 40
        };

        public LocaleTR(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
