using System;

namespace algoritmalar.src
{
    public class CoinRow
    {
        // Madeni para sırası problemini çözen ana metodumuz
        public static int MaxCoinValue(int[] coins)
        {
            // --- 1. GÜVENLİK KONTROLÜ ---
            // Eğer dizi boşsa veya tanımlanmamışsa toplam 0'dır.
            if (coins == null || coins.Length == 0)
            {
                return 0;
            }

            int n = coins.Length;

            // --- 2. TEMEL DURUMLAR ---
            // Sadece 1 tane para varsa, en büyük değer o paranın kendisidir.
            if (n == 1)
            {
                return coins[0];
            }

            // --- 3. DP (DİNAMİK PROGRAMLAMA) TABLOSU ---
            // Her adımda o ana kadar topladığımız maksimum parayı bu dizide saklayacağız.
            int[] dp = new int[n];

            // İlk sıradaki para için maksimum kazanç sadece o paradır.
            dp[0] = coins[0];

            // İkinci sıradaki para için karar veriyoruz: 
            // Yan yana alamayacağımız için 1. mi daha büyük yoksa 2. mi?
            if (coins[0] > coins[1])
            {
                dp[1] = coins[0];
            }
            else
            {
                dp[1] = coins[1];
            }

            // --- 4. ASIL HESAPLAMA DÖNGÜSÜ ---
            // 3. paradan (indeks 2) başlayarak sırayla her para için en iyi kararı veriyoruz.
            for (int i = 2; i < n; i++)
            {
                // SEÇENEK 1: Mevcut parayı alıyorum.
                // Eğer i. parayı alırsam, i-1. parayı alamam. 
                // Dolayısıyla i-2. adımdaki en iyi toplamıma şu anki parayı eklerim.
                int secenek_Al = dp[i - 2] + coins[i];

                // SEÇENEK 2: Mevcut parayı pas geçiyorum.
                // Eğer bu parayı almazsam, i-1. adımdaki toplamım aynen korunur.
                int secenek_PasGec = dp[i - 1];

                // Karar anı: Hangi seçenek bize daha çok para kazandırıyor?
                if (secenek_Al > secenek_PasGec)
                {
                    dp[i] = secenek_Al; // Almak daha kârlı
                }
                else
                {
                    dp[i] = secenek_PasGec; // Pas geçmek (önceki birikimi korumak) daha kârlı
                }
            }

            // --- 5. SONUÇ ---
            // Tablonun en sonundaki değer, tüm sıradan toplanabilecek maksimum paradır.
            return dp[n - 1];
        }

        // Kodu denemek için kullanabileceğin bir örnek:
        /*
        static void Main()
        {
            int[] paralar = { 5, 1, 2, 10, 6, 2 };
            Console.WriteLine("Maksimum Toplam: " + MaxCoinValue(paralar));
        }
        */
    }
}