#include "hamming.h"
#include <string.h>

int compute(const char *lhs, const char *rhs)
{
    // 1. Eşit uzunlukta mı kontrolü
    if (strlen(lhs) != strlen(rhs)) {
        return -1;
    }

    int fark_sayisi = 0;

    // 2. String sonuna ('\0') gelene kadar gezme
    while (*lhs != '\0') {
        if (*lhs != *rhs) { // lhs ile rhs karşılaştırılıyor
            fark_sayisi++;
        }
        lhs++; // Bir sonraki karaktere geç
        rhs++; // Bir sonraki karaktere geç
    }

    return fark_sayisi;
}