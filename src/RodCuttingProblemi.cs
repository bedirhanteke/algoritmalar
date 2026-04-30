using System;

class Program
{
    static void Main()
    {
        // fiyatlar dizisi:
        // index = parça uzunluğu
        // değer = o uzunluktaki parçanın fiyatı
        // 0. index kullanılmadığı için başa 0 koyduk
        int[] fiyatlar = { 0, 2, 5, 7, 8 };

        // Kesmek istediğimiz çubuğun toplam uzunluğu
        int cubukUzunlugu = 4;

        // Maksimum kazancı hesapla
        int maksimumKazanc = RodKesme(fiyatlar, cubukUzunlugu);

        Console.WriteLine("Maksimum kazanç: " + maksimumKazanc);
    }

    static int RodKesme(int[] fiyatlar, int cubukUzunlugu)
    {
        // enIyi[i]:
        // i uzunluğundaki bir çubuktan elde edilebilecek maksimum kazancı tutar
        int[] enIyi = new int[cubukUzunlugu + 1];

        // 0 uzunlukta çubuk varsa kazanç da 0 olur
        enIyi[0] = 0;

        // 1'den başlayarak her uzunluk için tek tek hesaplama yapıyoruz
        for (int uzunluk = 1; uzunluk <= cubukUzunlugu; uzunluk++)
        {
            // O anki uzunluk için bulduğumuz en büyük kazancı tutacak değişken
            // Başlangıçta çok küçük bir değer veriyoruz ki karşılaştırma yapabilelim
            int enBuyukKazanc = int.MinValue;

            // Çubuğu ilk olarak nereden keseceğimizi deniyoruz
            // (ilk parça 1, 2, 3 ... uzunluk olabilir)
            for (int ilkParca = 1; ilkParca <= uzunluk; ilkParca++)
            {
                // Mantık:
                // İlk parçayı kes (ilkParca kadar) → onun fiyatını al
                // Geriye kalan kısmın en iyi sonucu zaten daha önce hesaplandı (enIyi dizisinde var)
                int adayKazanc = fiyatlar[ilkParca] + enIyi[uzunluk - ilkParca];

                // Eğer bu seçenek daha iyiyse, maksimumu güncelle
                if (adayKazanc > enBuyukKazanc)
                {
                    enBuyukKazanc = adayKazanc;
                }
            }

            // Bu uzunluk için en iyi sonucu tabloya kaydet
            enIyi[uzunluk] = enBuyukKazanc;
        }

        // İstenen çubuk uzunluğu için maksimum kazancı döndür
        return enIyi[cubukUzunlugu];
    }
}