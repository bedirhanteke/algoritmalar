using System;
using algoritmalar.src;

namespace MerhabaCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Merhaba Bedirhan, C# dünyasına hoş geldin!");
            
            // Console.Write("Bir sayı gir: ");
            // string girdi = Console.ReadLine();
            // Console.WriteLine("Girdiğin sayı: " + girdi);

            // Console.WriteLine("--------------------------------");

            // // Class'tan nesne oluşturma (Instantiation)
            // Ogrenci ogr = new Ogrenci();

            // // Özelliklere değer atama
            // ogr.Ad = "Bedirhan";
            // ogr.Bolum = "Bilgisayar Mühendisliği";

            // Metodu çağırma
            Ogrenci.SelamVer();

            // Elimizdeki bozuk paralar (Örn: 1 TL, 2 TL, 5 TL)
            int[] bozukParaListesi = { 1, 2, 5 };
            int paraCesidiSayisi = bozukParaListesi.Length;
            int hedefBorc = 4; // Örnek olarak 4 TL'yi hesaplayalım

            int sonuc = OdemeYoluSayisiniBull.OdemeYoluSayisiniBul(bozukParaListesi, paraCesidiSayisi, hedefBorc);

            Console.WriteLine($"{hedefBorc} TL ödemek için toplam {sonuc} farklı yol var.");
        }
    }
    
}