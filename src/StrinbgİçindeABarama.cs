using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace algoritmalar.src
{
    public class StrinbgİçindeABarama
    {
    public static int SayaciDondur(string st)
    {
        int toplamSayac = 0; // Tüm metindeki toplam "AB" sayısını tutacak değişken

        // Her 8'li grubu kontrol et
        for (int i = 0; i <= st.Length - 8; i += 8)
        {
         // Her 8'li grupta "AB" sayısını bul
            for (int j = i; j <= i + 7; j++)
        {
            if (st[j] == 'A' && st[j + 1] == 'B')
            {
                toplamSayac++; // "AB" buldukça genel sayacı artır
            }
        }
    }
    return toplamSayac; // Bulunan toplam "AB" sayısını geri döndür
    }         
}
}