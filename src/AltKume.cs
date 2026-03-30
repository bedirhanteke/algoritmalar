using System;

class AltKumeToplami
{
    static void AltKume()
    {
        // Örnek dizi (10 elemanlı)
        int[] dizi = { 1, 2, 1, 0, 3, 1, 2, 0, 1, 2 }; 
        
        // Toplamı 3 olan alt kümelerin sayısını tutacak
        int count = 0;

        // 10 eleman olduğu için 2^10 = 1024 farklı alt küme vardır
        // Her sayı (i), bir alt kümeyi temsil eder
        for (int i = 1; i < 1024; i++)
        {
            int t = 0;      // O anki alt kümenin toplamı
            int tmp = i;    // i'nin kopyası (bit işlemleri için)

            // Her bit, dizideki bir elemanı temsil eder
            // j = 0 → dizi[0]
            // j = 1 → dizi[1]
            // ...
            for (int j = 0; j < 10; j++)
            {
                // (tmp & 1) → sayının en sağdaki bitini kontrol eder
                // Eğer 1 ise → bu eleman alt kümeye dahil
                // Eğer 0 ise → dahil değil
                if ((tmp & 1) == 1)
                {
                    // Elemanı toplama ekle
                    t = t + dizi[j];
                }

                // tmp'yi sağa kaydır → bir sonraki bite geç
                // Örn: 101 → 010
                // Bu işlem aslında tmp = tmp / 2 (tam sayı bölme)
                tmp = tmp >> 1;
            }

            // Eğer alt kümenin toplamı 3 ise sayacı artır
            if (t == 3) count++;
        }

        // Sonucu yazdır
        Console.WriteLine("Toplamı 3 olan alt küme sayısı: " + count);

        Console.ReadLine();
    }
}