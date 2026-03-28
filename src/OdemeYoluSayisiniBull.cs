using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace algoritmalar.src
{
    class OdemeYoluSayisiniBull{
    static int OdemeYoluSayisiniBul(int[] paralar, int kacCesitParaVar, int kalanBorc)
    {
        // --- DURDURMA KOŞULLARI (Base Cases) ---

        // 1. Başarı: Borç tam sıfırlandıysa 1 yol bulduk demektir.
        if (kalanBorc == 0) 
            return 1;

        // 2. Hata: Borç eksiye düştüyse bu yol yanlış, 0 dön.
        if (kalanBorc < 0) 
            return 0;

        // 3. Hata: Elimizde kullanacak para çeşidi kalmadıysa 0 dön.
        if (kacCesitParaVar <= 0 && kalanBorc >= 1) 
            return 0;

        // --- KARAR ANI (Özyineleme - Recursion) ---

        // Seçenek A: Sonuncu parayı LİSTEDEN ÇIKAR, borç aynı kalsın (Pas Geç)
        int pasGec = OdemeYoluSayisiniBul(paralar, kacCesitParaVar - 1, kalanBorc);

        // Seçenek B: Sonuncu parayı KULLAN, borçtan düş (Dahil Et)
        // Not: paralar[kacCesitParaVar - 1] bize listenin sonundaki parayı verir.
        int kullan = OdemeYoluSayisiniBul(paralar, kacCesitParaVar, kalanBorc - paralar[kacCesitParaVar - 1]);

        // Toplam ihtimali döndür
        return pasGec + kullan;
    }
    }
}