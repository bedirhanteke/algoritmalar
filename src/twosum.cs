public class TwoSum
{    
    public static int[] Tosun(int[] nums, int target)
    {   
        // --- KRİTİK HATA 1: İNDEKS KAYBI ---
        // LeetCode bu soruda senden sayıların DEĞERLERİNİ değil, 
        // orijinal dizideki YERLERİNİ (indekslerini) istiyor.
        // Array.Sort dediğin an [3, 2, 4] olan dizi [2, 3, 4] olur. 
        // '2' sayısı artık 1. indekste değil, 0. indeistedir. Geçmiş olsun!
        Array.Sort(nums);

        var start = 0;
        var end = nums.Length - 1;

        // --- MANTIKSAL GÜZELLİK (Ama bu soru için yanlış) ---
        // Bu "Two Pointers" yaklaşımı O(n) sürede çalışır, çok hızlıdır.
        // Ama sadece dizi SIRALIYSA ve bizden İNDEKS İSTENMİYORSA kraldır.
        while(start < end)
        {
            int currentSum = nums[start] + nums[end];

            if(currentSum == target)
            {
                // --- KRİTİK HATA 2: YANLIŞ İNDEKS DÖNDÜRME ---
                // Burada döndürdüğün 'start' ve 'end', sıralanmış dizideki yerlerdir.
                // Orijinal dizideki yerlerle hiçbir alakası kalmamıştır.
                return new int[] { start, end };
            }

            // Toplam küçükse, daha büyük bir sayıya ihtiyacımız var (start sağa)
            if(currentSum < target)
            {
                start++;
            }
            // Toplam büyükse, daha küçük bir sayıya ihtiyacımız var (end sola)
            else
            {
                end--;
            }
        }

        // --- KRİTİK HATA 3: BELİRSİZ DÖNÜŞ ---
        // Eğer sayı bulunamazsa [0, 0] döndürmek "0 ve 0. indekstekiler toplamı verir" 
        // gibi algılanabilir. Boş dizi veya null daha güvenlidir.
        return new int[0];     
    }

    public static int[] TosunPasa(int[] sayilar, int hedefToplam) {
        // 'gecmisSayilar' kutusu: Daha önce üzerinden geçtiğimiz sayıları burada saklıyoruz.
        // 
        var gecmisSayilar = new HashSet<int>();

        for (int i = 0; i < sayilar.Length; i++) {
            int suAnkiSayi = sayilar[i];
            
            // 1. ADIM: "Bana lazım olan eksik parça nedir?" (Matematiksel hesap)
            int arananEksikParca = hedefToplam - suAnkiSayi;

            // 2. ADIM: "Bu eksik parça daha önce geçtiğim sayılar arasında var mı?"
            if (gecmisSayilar.Contains(arananEksikParca)) {
                // EĞER VARSA: Orijinal dizide bu eksik parçanın yerini bulmamız lazım.
                // (NOT: Bu kısım Array.IndexOf kullandığı için O(n) hızındadır, biraz yavaştır)
                int eksikParcaninIndeksi = Array.IndexOf(sayilar, arananEksikParca);
                
                // Bulduğumuz iki indeksi (eskisi ve şu anki i) döndürüyoruz.
                return new int[] { eksikParcaninIndeksi, i };
            }

            // 3. ADIM: Eksik parça bulunamadıysa, şu anki sayıyı kutuya ekle.
            // "Belki benden sonraki sayılar beni (eksik parça olarak) arar" diyoruz.
            if (!gecmisSayilar.Contains(suAnkiSayi)) {
                gecmisSayilar.Add(suAnkiSayi);
            }
        }

        // Eğer hiçbir eşleşme çıkmazsa (soru her zaman bir çözüm var dese de) boş dizi döndür.
        return new int[0];
    }

    public int[] Solution(int[] sayilar, int hedef) {
        // 'hafiza' sözlüğü: Anahtar (Key) olarak sayıyı, 
        // Değer (Value) olarak o sayının orijinal indeksini tutar.
        var hafiza = new Dictionary<int, int>();

        for (int i = 0; i < sayilar.Length; i++) {
            int suAnkiSayi = sayilar[i];
            int gerekenParca = hedef - suAnkiSayi;

            // 1. ADIM: "Bana lazım olan sayı hafızamda var mı?" diye sor.
            if (hafiza.ContainsKey(gerekenParca)) {
                // EĞER VARSA: Aradığımız ikiliyi bulduk!
                // hafiza[gerekenParca] bize o sayının orijinal indeksini "şak" diye verir.
                return new int[] { hafiza[gerekenParca], i };
            }

            // 2. ADIM: "Aradığım sayı hafızada yoksa, şu anki sayıyı hafızaya ekle."
            // "Belki ileride gelecek bir sayı için ben 'gereken parça' olurum" der.
            // Önemli: Aynı sayıdan iki tane varsa hata almamak için kontrol ekliyoruz.
            if (!hafiza.ContainsKey(suAnkiSayi)) {
                hafiza.Add(suAnkiSayi, i);
            }
        }

        // Eğer hiçbir eşleşme bulunamazsa boş dizi döndür.
        return new int[0];
    }
    

}