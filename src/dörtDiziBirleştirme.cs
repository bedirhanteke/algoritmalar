using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace algoritmalar.src
{
    public class dörtDiziBirleştirme
    {

        public static int[] DizileriBirlestir(int[] A, int[] B, int[] C, int[] D)
        {
            int[] X = new int[A.Length + B.Length + C.Length + D.Length];
            int aIndex = 0, bIndex = 0, cIndex = C.Length - 1, dIndex = D.Length - 1;

            for (int i = 0; i < X.Length; i++)
            {
                if (aIndex < A.Length && (bIndex >= B.Length || A[aIndex] <= B[bIndex]) && (cIndex < 0 || A[aIndex] <= C[cIndex]) && (dIndex < 0 || A[aIndex] <= D[dIndex]))
                {
                    X[i] = A[aIndex];
                    aIndex++;
                }
                else if (bIndex < B.Length && (cIndex < 0 || B[bIndex] <= C[cIndex]) && (dIndex < 0 || B[bIndex] <= D[dIndex]))
                {
                    X[i] = B[bIndex];
                    bIndex++;
                }
                else if (cIndex >= 0 && (dIndex < 0 || C[cIndex] <= D[dIndex]))
                {
                    X[i] = C[cIndex];
                    cIndex--;
                }
                else
                {
                    X[i] = D[dIndex];
                    dIndex--;
                }
            }

            return X; // Sıralanmış diziyi döndür
        }

    }
}