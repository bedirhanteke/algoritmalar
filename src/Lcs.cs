using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace algoritmalar.src
{
    public class Lcs
    {
        public static void Lcss() { 
        string s1 = "bedirhantekesinemtekin";
        string s2 = "sinemtekinbedirhanteke";
        int n = s1.Length;
        int m = s2.Length;


        int[,] matris = new int [n+1, m+1];

        for(int i= 1; i<=n; i++)
            {
                for(int j=1; j<= m; j++)
                {
                    if(s1[i-1]== s1[j - 1])
                    {
                        //eğer karakterler eşleşiyorsa 
                        // çaprazdaki değerlere 1 ekler 
                        matris[i,j] = matris[i-1, j-1]+1;
                    }
                    //karakterler eşlemiyorsa 
                    else
                    {
                        //üsteki veya saoldaki değerden büyük olanı al 
                        if(matris[i-1, j]> matris[i, j - 1])
                        {
                            matris[i,j]= matris[i-1,j];
                        }
                        else
                        {
                            matris[i,j] = matris[i, j-1];
                        }
                    }


                }
            }




        }
    }
}