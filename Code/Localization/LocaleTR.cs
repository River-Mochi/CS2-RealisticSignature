// <copyright file="LocaleTR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleTR.cs
// All 64 translation entries follow LocaleEN.cs order via LocaleTranslatedSource.

namespace UniqueBuildings
{
    public sealed class LocaleTR : LocaleTranslatedSource
    {
        private static readonly string[] s_Text =
        {
            // Mod title
            "Realistic Signature Buildings (Simgeler)", // 0

            // Tabs
            "İşlemler", // 1
            "Hakkında", // 2

            // Groups
            "İmza bina bonusları", // 3
            "İmza binaların kilidini aç", // 4
            "Yerleştirme", // 5
            "Durum", // 6
            "Bilgi", // 7
            "Hata ayıklama / Günlük", // 8

            // Signature Bonuses
            "Benzersiz binaların şehir geneli bonusları", // 9
            "<Yalnızca ilk kopya> **(varsayılan)** = benzersiz bina türü başına bir şehir geneli bonus.\n<Şehir geneli bonusları yok> = genel bonuslar kapalı; çekicilik ayrı ayarlanır.\n<Vanilla birikimi> = tüm kopyalar katkıda bulunur.\n**Yeşil bonus yazıları** bonus engellense bile orijinal açıklamayı gösterir.\n**İşlemler > Durum** veya günlük raporuna bakın.", // 10
            "Yalnızca ilk kopya", // 11
            "Şehir geneli bonusları yok", // 12
            "Vanilla birikimi", // 13

            // Independent city-wide Attractiveness
            "Şehir geneli çekicilik", // 14
            "<Yalnızca ilk kopya> **(varsayılan)** = uygun benzersiz bina türü başına bir şehir geneli çekicilik bonusu.\n<Vanilla birikimi> = tüm kopyalar sayılır.\n<Çekicilik bonusu yok> = bu şehir bonuslarını kapatır.\n<Şehir geneli ayarını izle> = yukarıdaki kuralı kullanır.\n**Çekicilik turist çeker.** Binanın kendi çekiciliği değişmez.\n**Yeşil yazılar** sabit açıklamalardır.", // 15
            "Şehir geneli ayarını izle", // 16
            "Yalnızca ilk kopya", // 17
            "Vanilla birikimi", // 18
            "Çekicilik bonusu yok", // 19

            // Nearby Signature effects
            "Benzersiz binaların yakın çevre etkileri", // 20
            "<Vanilla yakın çevre etkileri> **(varsayılan)** = her benzersiz bina kopyası yerel etkilerini korur.\n<Yalnızca ilk kopya> = tür başına bir kopya.\n<Yakın çevre etkileri yok> = normal etkileri kapatır; terk edilmiş binaların cezaları korunur.\n**Bina çekiciliği** değişmez.", // 21
            "Vanilla yakın çevre etkileri", // 22
            "Yalnızca ilk kopya", // 23
            "Yakın çevre etkileri yok", // 24

            // Signature Unlocks
            "Tüm imza binalarını aç", // 25
            "**AÇIK** = imza binalarını ilerleme şartı olmadan açar.\n**KAPALI (varsayılan)** = normal kilit açma.\n**Diğer benzersiz binalar**, ör. Polis Merkezi, **İlerleme > Gelişim** bölümünde <gelişim puanları> gerektirir.", // 26
            "Toplu İmza bina açma bildirimlerini gizle", // 27
            "**AÇIK** (önerilen, varsayılan) = bu modun toplu İmza bina açma bildirimlerini gizler.\n**KAPALI** = modun yeni açtığı her bina için bildirim gösterir; onlarca veya yüzlerce bildirim olabilir.\nOyun güncellemeleri, DLC, bölge paketleri ve şehrin ilerlemesiyle gelen binalar dahil normal oyun bildirimleri görünmeye devam eder.", // 28

            // Multiple Unique
            "Birden fazla kopyaya izin ver", // 29
            "**AÇIK** = imza binalar dâhil benzersiz olarak işaretlenen nesnelerin birden fazla kopyasını yerleştirir.\n**KAPALI** = başka bir mod izin vermedikçe şehirde her nesneden bir tane.", // 30
            "Yerleştirirken binaları net göster", // 31
            "**AÇIK (varsayılan)** = <net bina görünümü>: benzersiz bina yerleştirirken otomatik karartmayı, renkli haritayı ve bilgi görünümünü engeller.\n**KAPALI** = normal otomatik gösterim.\nBilgi panelini istediğiniz zaman elle açabilirsiniz. <Toggle Overlays> önceliklidir.", // 32

            // Status
            "Benzersiz nesne yerleştirme kuralı", // 33
            "**Çoklu kopya serbest** = şehir başına tek bina sınırı kapalı.\n**Her türden bir tane** = normal sınır.\n<Anarchy> de kopyalara izin verebilir.\nBonus birikimini göstermez.", // 34
            "İmza binalar", // 35
            "**Yerleştirilen** = tüm imza binaları.\n**Türler** = farklı bina türleri.\n<Ek kopyalar> = her türün ilki dışındakiler.\nŞehir bonusu olmayan binalar da dahil.", // 36
            "Signature binalarının şehir geneli bonusları", // 37
            "**Etkin / Toplam** = genel kuralla sayılan bonus kaynakları / tüm kaynaklar.\n<Engelli> = bu kuralla dışlananlar, bütün ek binalar değil.\n**Çekicilik bağımsızdır:** engellenen kaynak yine çekicilik verebilir.\nYakın çevre etkileri ayrıdır.", // 38

            // Other Unique city-wide bonuses
            "Diğer benzersiz binaların şehir geneli bonusları", // 39
            "Belediye Binası gibi Signature olmayan benzersiz binaların bonusları.\nAktif / Toplam = uygulanan / mevcut bonus kaynakları. Engellenen = ayar gereği sayılmayanlar. Normal hizmet binaları dahil değildir.", // 40

            // Redundant mods
            "Gereksiz modlar algılandı", // 41
            "**Yok** = aynı çoklu yerleştirme işlevine sahip bilinen bir mod algılanmadı.\n<Anarchy> uyumludur ve burada listelenmez.\nAynı işlevi yapan diğer modları birlikte kullanmayın.", // 42

            // Localized Status values (not translated in log reports)
            "Şehir yüklenmedi", // 43
            "Yükleniyor…", // 44
            "Durumu görmek için önce bir şehir yükleyin", // 45
            "Birden fazla kopyaya izin veriliyor", // 46
            "Anarchy birden fazla kopyaya izin veriyor", // 47
            "Sınırsız kopyaya hâlâ izin veriliyor", // 48
            "Her türden bir tane", // 49
            "Karışık yerleştirme kuralları", // 50
            "{0} yerleştirildi | {1} tür | {2} ek kopya", // 51
            "{0}/{1} etkin | {2} engelli", // 52
            "Yok", // 53

            // About
            "Mod", // 54
            "Bu modun görünen adı.", // 55
            "Sürüm", // 56
            "Yüklü mod sürümü ve derleme türü.", // 57
            "Durum raporunu günlüğe yaz", // 58
            "Mevcut İmza bina sayılarını, şehir genelindeki bonusları ve yakın çevre etkilerini günlüğe yazar. Ayarları veya etkileri değiştirmez. Önce bir şehir yükleyin.", // 59
            "Bonus modlarını günlüğe karşılaştır", // 60
            "Oyun Seçenekler menüsünde duraklatılmışken tüm şehir geneli bonus ve yakın çevre etkisi modlarını geçici olarak dener. Ardından seçtiğiniz modları yeniden uygular. Sonuçlar mod günlüğüne yazılır. Önce bir şehir yükleyin.", // 61
            "Günlüğü aç", // 62
            "Mod günlüğünü veya yoksa günlükler klasörünü açar.", // 63
        };

        public LocaleTR(UniqueBldgSettings setting)
            : base(setting)
        {
        }

        protected override string[] Text => s_Text;
    }
}
