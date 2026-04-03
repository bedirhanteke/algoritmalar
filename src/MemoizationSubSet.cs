using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace algoritmalar.src
{
    public class MemoizationSubSet
    {
        public bool SubSet(int[] dizi, int hedef)
        {   
            // Ufak bir ön kontrol: Hedef negatifse pozitif sayılarla ulaşmak imkansızdır.
            if (hedef < 0) return false;

            // ADIM 1: Değişkenleri (Durumu) Belirle
            // memoization tablosu oluşturulur 
            // satır: eleman sayısı , sütun hedef değer 
            int[,] memo = new int [dizi.Length+1, hedef+1 ];
            
            // tablo başlangıçta -1 ile dolu hiç bi değer bilinmiyor 
            for(int i=0; i<= dizi.Length; i++)
            {
                for(int j=0; j<=hedef; j++)
                {
                    memo[i, j] = -1; // İskeletteki eksik atamayı tamamladık
                }
            }

            // Başlangıç noktamızı vererek asıl işi yapacak fonksiyonu çağırıyoruz.
            // 0. indisten ve tam hedef değerinden başlıyoruz.
            return Hesapla(dizi, 0, hedef, memo);
        }

        // Ana işlemleri (dallanmaları) yapacak olan gizli (private) yardımcı fonksiyonumuz
        private bool Hesapla(int[] dizi, int indis, int hedef, int[,] memo)
        {
            // ADIM 2: Çıkış Şartlarını (Base Cases) Yaz
            // 1. Başarı Çıkışı: Hedef tam olarak sıfırlandıysa, doğru alt kümeyi bulduk demektir.
            if (hedef == 0) 
            {
                return true;
            }
            
            // 2. Hata Çıkışı: Dizinin sonuna geldiysek veya hedef negatif olduysa, bu yol çıkmaz sokaktır.
            if (indis >= dizi.Length || hedef < 0) 
            {
                return false;
            }

            // ADIM 3: Not Defterine Bak (Memoization Kontrolü)
            // Eğer bu durum tablomuzda -1 değilse, yani daha önce hesaplandıysa:
            if (memo[indis, hedef] != -1)
            {
                // Tablodaki değer 1 ise true, 0 ise false döndür (hesaplama yapmadan kurtul)
                return memo[indis, hedef] == 1;
            }

            // ADIM 4: Seçenekleri (Kararları) Kodla
            // KARAR 1: Dizideki bu sayıyı kullan (hedef sayının değeri kadar küçülür)
            bool al = Hesapla(dizi, indis + 1, hedef - dizi[indis], memo);
            
            // KARAR 2: Dizideki bu sayıyı pas geç (hedef aynı kalır)
            bool alma = Hesapla(dizi, indis + 1, hedef, memo);

            // İki yoldan herhangi biri başarıya (true) ulaştırdıysa sonuç başarılıdır.
            bool nihai_sonuc = al || alma;

            // ADIM 5: Sonucu Kaydet ve Çık
            // Dönmeden önce, bulduğumuz bu sonucu gelecekte kullanmak üzere tabloya yazıyoruz.
            // (True ise 1, False ise 0 olarak kaydediyoruz)
            if (nihai_sonuc)
            {
                memo[indis, hedef] = 1;
            }
            else
            {
                memo[indis, hedef] = 0;
            }

            return nihai_sonuc;
        }
    }
}