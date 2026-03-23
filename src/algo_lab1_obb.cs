using System;

namespace Algo_lab1_OOP
{
    // --- 1. MATEMATİKSEL SERİLER SINIFI ---
    public class MatematikselSeriler
    {
        public double FaktoryelSerisiHesapla(int terimSayisi)
        {
            double toplam = 0;
            int isaret = 1;
            double us = 1;

            for (int i = 1; i <= terimSayisi; i++)
            {
                toplam += isaret * (Faktoryel(i) / (us *= 2));
                isaret *= -1;
            }
            return toplam;
        }

        public double LeibnizPiHesapla(int iterasyon)
        {
            double toplam = 0;
            int isaret = 1;
            for (int i = 0; i < iterasyon; i++)
            {
                toplam += isaret * (1.0 / (2 * i + 1));
                isaret *= -1;
            }
            return 4 * toplam;
        }

        private double Faktoryel(int n)
        {
            double sonuc = 1;
            for (int i = 1; i <= n; i++) sonuc *= i;
            return sonuc;
        }
    }

    // --- 2. DÖNÜŞTÜRÜCÜ SINIFI ---
    public static class Donusturucu
    {
        public static int StringiSayıyaCevir(string st)
        {
            int sonuc = 0;
            foreach (char karakter in st)
            {
                if (karakter >= '0' && karakter <= '9')
                    sonuc = sonuc * 10 + (karakter - '0');
            }
            return sonuc;
        }
    }

    // --- 3. KOMBİNASYON HESAPLAYICI SINIFI ---
    public class KombinasyonHesaplayici
    {
        public void KombinasyonlariYazdir(int[] dizi, int secimSayisi)
        {
            int[] secilenler = new int[secimSayisi];
            Bul(dizi, secilenler, 0, 0, secimSayisi);
        }

        private void Bul(int[] dizi, int[] secilenler, int index, int baslangic, int secimSayisi)
        {
            if (index == secimSayisi)
            {
                Console.WriteLine(string.Join(" ", secilenler));
                return;
            }

            // Not: Orijinal kodundaki döngü mantığını kombinasyon kuralına göre güncelledim
            for (int i = baslangic; i <= dizi.Length - (secimSayisi - index); i++)
            {
                secilenler[index] = dizi[i];
                Bul(dizi, secilenler, index + 1, i + 1, secimSayisi);
            }
        }
    }

    // --- ANA PROGRAM ---
    internal class Program
    {
        static void Main(string[] args)
        {
            // Nesnelerin oluşturulması
            MatematikselSeriler seriAraci = new MatematikselSeriler();
            KombinasyonHesaplayici kombiAraci = new KombinasyonHesaplayici();

            // 1. Seri Hesaplama
            Console.WriteLine($"Faktöriyel Serisi (50 terim): {seriAraci.FaktoryelSerisiHesapla(50)}");

            // 2. Leibniz Serisi
            Console.WriteLine($"Leibniz Pi Sonucu: {seriAraci.LeibnizPiHesapla(1000000)}");

            // 3. String Dönüşümü
            Console.Write("\nBir sayı giriniz: ");
            string? girdi = Console.ReadLine();
            if (girdi != null)
            {
                Console.WriteLine($"Sayıya çevrildi: {Donusturucu.StringiSayıyaCevir(girdi)}");
            }

            // 4. Kombinasyonlar
            Console.WriteLine("\nKombinasyonlar (4'ün 2'lisi):");
            int[] dizi = { 1, 2, 3, 4 };
            kombiAraci.KombinasyonlariYazdir(dizi, 2);

            Console.WriteLine("\nÇıkmak için Enter'a basın...");
            Console.ReadLine();
        }
    }
}