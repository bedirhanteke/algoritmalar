using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace algoritmalar.src
{
    public class MatrisKayanPencereToplamı
    {
        public static int EnBuyukToplam(int[,]matris, int altBoyut)
        {
            int satirSayisi = matris.GetLength(0);
            int sutunSayisi = matris.GetLength(1);
            int maxToplam = int.MinValue;
            //dış dögüler matris üzerinde pencereyi kaydırmak için yapılır 
            for(int i=0; i <=satirSayisi-altBoyut; i++)
            {
                for(int j = 0; j<= sutunSayisi - altBoyut; j++)
                {
                    int mevcutToplam = 0;
                    
                    //matris içinde dolaşacak çerçeve oluşturulur 
                    for(int x= i; x<i + altBoyut; x++) //satırı gezer x'i i ye eşitliyoruz daha pencere o konumdan başlasın 
                    {
                        for(int y=j; y< j + altBoyut; y++)
                        {
                            //çerçerçeve o an neredeyse mevcut değer içine toplamı biriktirir 
                            mevcutToplam += matris[x,y];
                        }
                    }
                }
            }

            return maxToplam;
        }
    }
}