using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace algoritmalar.src
{
    public class RescursiveSubsetSUm
    {
        public static bool subset(int[] dizi, int indis, int hedef)
        {
            //hedef 0 ise firekt true döndürebilriz ya da azala azala hedef 0 a gelmişse
            if(hedef== 0) return true;
            // indis dizinin uzunluğundan büyük olmuşsa fasle döndüremek gerek 
            if(indis == dizi.Length) return false;
            
            if(subset(dizi, indis+1, hedef - dizi[indis])) return true;
            
            if(subset(dizi, indis+1, hedef)) return true;

            return false;

            
        }
    }
}