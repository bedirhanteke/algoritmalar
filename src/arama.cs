using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace algoritmalar.src
{
    public class Arama
    {

        private static int Main(string[] args)
        {
            return 0;
        }
        static int  LinearSearch(int[] arr, int aranan) //dizi sıralı değilse tek çare budur
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
                if (arr[i] == aranan)
                    return i;
            return -1;
        }
           static int BinarySearch(int[] arr, int aranan) //soru çıkacak burdan //dizi sıralıysa en güvenli seçenek
            {
                int n = arr.Length;
                int sol = 0, sag = n - 1;
                while (sol <= sag)
                {
                    int orta = sol + (sag - sol) / 2;
                    if (arr[orta] == aranan)
                        return orta;
                    if (arr[orta] < aranan)
                        sol = orta + 1;
                    else
                        sag = orta - 1;
                }
                return -1;  
            }
        static int jumpSearch(int[] arr, int aranan) //test yorum boşluk doldurma gelebilir  //blok blok taramak için kullanılır  
        {
            int n = arr.Length;
            int adim = (int)Math.Floor(Math.Sqrt(n));
            int sol = 0, sag = 0;
            while (sag < n && arr[sag] < aranan)
            {
                sol = sag;
                sag += adim;
                if (sag > n - 1)
                    sag = n;
            }
            for (int i = sol; i < sag; i++)
                if (arr[i] == aranan)
                    return i;
            return -1;
        }
        static int YardımcıBinarySearch(int[] arr, int sol, int sag, int aranan)
        {
            while (sol <= sag)
            {
                int orta = sol + (sag - sol) / 2;
                if (arr[orta] == aranan)
                    return orta;
                if (arr[orta] < aranan)
                    sol = orta + 1;
                else
                    sag = orta - 1;
            }
            return -1;
        }
        static int exponentialSearch(int[] arr, int aranan) //test yorum boşluk doldurma gelebilir // dizi çok büyükse ve aranan eleman dizinin başına yakınsa kullanılır
        {
            int n = arr.Length;
            if (arr[0] == aranan)
                return 0;
            int i = 1;
            while (i < n && arr[i] <= aranan)
                i *= 2;
            return YardımcıBinarySearch(arr, i / 2, Math.Min(i, n - 1), aranan);
        }


    }
}