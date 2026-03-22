class Armstrong
{   
    // Armstrong sayısını kontrol eden metot
    public static bool armodilla(int a)
    {
        // 'a' değişkeni döngü sonunda 0 olacağı için orijinal sayıyı 'sayı' değişkeninde saklıyoruz.
        int sayı = a; 
        int basamak = 0;
        int temp = a; // Basamak sayısını bulmak için geçici bir kopya oluşturuyoruz.
        int toplam = 0;

        // 0 sayısı özel bir durumdur, eğer sayı 0 ise basamak sayısı 1 kabul edilir.
        if(a == 0) basamak = 1;

        // 1. ADIM: Sayının kaç basamaklı olduğunu buluyoruz.
        // Sayıyı sürekli 10'a bölerek (integer division) basamak sayısını sayıyoruz.
        while (temp > 0)
        {
            temp /= 10; // Sayının son basamağını siler (Örn: 153 -> 15 -> 1 -> 0)
            basamak++;  // Her silmede basamak sayacını artırır.
        }

        // 2. ADIM: Her basamağın, toplam basamak sayısı kadar kuvvetini alıp topluyoruz.
        while(a > 0)
        {   
            int sonuc = 1; // Her basamağın üssü hesaplanırken kullanılacak çarpım sonucu.
            int gelen = a % 10; // Sayının o anki son basamağını (mod 10 ile) alıyoruz.
            
            a /= 10; // İşlem yapılan basamağı orijinal sayıdan atıyoruz.

            // Math.Pow kullanmak yerine, basamak sayısı kadar for döngüsü döndürerek
            // basamağın kuvvetini manuel hesaplıyoruz (Performans ve algoritma mantığı için).
            for(int i = 0; i < basamak; i++)
            {
                sonuc = gelen * sonuc; // Basamağı kendisiyle 'basamak' kez çarpıyoruz.
            }
        
            // Elde edilen üstlü sonucu genel toplama ekliyoruz.
            toplam = toplam + sonuc;
        }

        // 3. ADIM: Hesaplanan toplam, en başta sakladığımız orijinal sayıya eşit mi?
        if(toplam == sayı)
        {
            return true; // Eğer eşitse bu bir Armstrong sayısıdır.
        }
        
        return false; // Eşit değilse değildir.
    }
}