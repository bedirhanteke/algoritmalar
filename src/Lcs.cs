using System;
using System.Text; // StringBuilder kullanabilmek için bu kütüphane şart

namespace algoritmalar.src
{
    public class Lcs
    {
        public static void Lcss() 
        { 
            string s1 = "bedirhantekesinemtekin";
            string s2 = "sinemtekinbedirhanteke";
            int n = s1.Length; // n: Birinci kelimenin uzunluğu (Satır sayımız olacak)
            int m = s2.Length; // m: İkinci kelimenin uzunluğu (Sütun sayımız olacak)

            // 1. ADIM: TABLOYU OLUŞTURMA VE DOLDURMA
            // Matrisin boyutunu [n+1, m+1] yapıyoruz.
            // Neden +1? Çünkü 0. satır ve 0. sütun "boş string" (hiç harf yok) durumunu temsil eder.
            // Boş bir string ile başka bir string'in ortak harfi olamayacağı için ilk satır ve sütun hep 0 kalır.
            // C#'ta int dizileri zaten default olarak 0 ile dolduğu için ekstra 0 atamamıza gerek yok.
            int[,] matris = new int[n + 1, m + 1];

            // Aramaya 1. indekslerden (yani matrisin 1'e 1 noktasından) başlıyoruz
            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= m; j++)
                {
                    // DİKKAT: İndekslerde i-1 ve j-1 kullanıyoruz çünkü matriste 1. satırdayken, 
                    // aslında kelimenin 0. indeksindeki harfe bakıyoruz (C#'ta stringler 0'dan başlar).
                    
                    // DURUM 1: HARFLER EŞLEŞTİ Mİ?
                    if(s1[i - 1] == s2[j - 1])
                    {
                        // Harfler aynıysa: "Buldum!" deyip çapraz sol üstteki değere 1 ekliyoruz.
                        // Çapraz sol üst demek: "Bu harfleri bulmadan önceki maksimum ortak uzunluk neydi? Ona 1 ekle" demek.
                        matris[i, j] = matris[i - 1, j - 1] + 1;
                    }
                    
                    // DURUM 2: HARFLER FARKLI MI?
                    else
                    {
                        // Harfler farklıysa bir seçim yapmalıyız. 
                        // Acaba s1'den mi bir harf atlasam daha kârlı çıkarım, yoksa s2'den mi?
                        // Bunun için matriste "bir üstteki" değere ve "bir soldaki" değere bakıyoruz.
                        if(matris[i - 1, j] > matris[i, j - 1])
                        {
                            // Üstteki (s1'den harf atladığımız durum) daha büyükse, o değeri aşağı çek
                            matris[i, j] = matris[i - 1, j];
                        }
                        else
                        {
                            // Soldaki (s2'den harf atladığımız durum) daha büyükse, o değeri sağa çek
                            matris[i, j] = matris[i, j - 1];
                        }
                    }
                }
            }
            
            // Tablonun en sağ alt köşesi (n. satır, m. sütun) bize ulaştığımız en büyük sayıyı, 
            // yani bulabileceğimiz maksimum ortak harf sayısını verir.
            int lcsUzunlugu = matris[n, m];
            Console.WriteLine($"Ortak Kelimenin Uzunluğu: {lcsUzunlugu}");


            // 2. ADIM: KELİMEYİ BULMA (BACKTRACKING - İZ SÜRME)
            // Sadece uzunluğu bulmak yetmez, kelimenin kendisini de istiyoruz.
            // Bunun için tablonun en alt sağ köşesinden başlayıp geriye doğru yolumuzu bulacağız.
            StringBuilder lcsKelimesi = new StringBuilder();
            
            // r (row/satır) için s1'in uzunluğu (n), c (column/sütun) için s2'nin uzunluğu (m) kullanılır.
            int r = n; 
            int c = m;

            // Matrisin 0'a 0 (başlangıç) noktasına çarpana kadar geriye doğru yürümeye devam et
            while (r > 0 && c > 0) 
            {
                // İz sürerken bulunduğumuz yerdeki harfler aynı mı diye kontrol ediyoruz
                if (s1[r - 1] == s2[c - 1]) 
                {
                    // Harfler aynıysa, bu harf bizim aradığımız LCS kelimesinin bir parçasıdır!
                    // Tersten okuduğumuz için bulduğumuz her harfi StringBuilder'ın en BAŞINA (0. indekse) ekliyoruz.
                    lcsKelimesi.Insert(0, s1[r - 1]); 
                    
                    // Harfi aldığımız için artık "çapraz sol yukarıya" gitmeliyiz (geldiğimiz yola dönüyoruz)
                    r--;
                    c--;
                }
                // Harfler farklıysa: O sayıya üstten mi gelmişiz, soldan mı gelmişiz onu bulmalıyız.
                // Üstteki değer daha büyükse (veya eşitse), demek ki üstten gelmişiz. Rotayı yukarı çevir.
                else if (matris[r - 1, c] > matris[r, c - 1]) 
                {
                    r--; // Bir üst satıra çık
                }
                // Soldaki değer daha büyükse, demek ki soldan gelmişiz. Rotayı sola çevir.
                else 
                {
                    c--; // Bir sol sütuna geç
                }
            }

            // Döngü bittiğinde lcsKelimesi değişkeninin içinde ortak kelimemiz hazır olacak.
            Console.WriteLine($"Ortak Kelime (String): {lcsKelimesi.ToString()}");
        }
    }
}