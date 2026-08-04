#ifndef DARTS_H
#define DARTS_H

#include <stdint.h> // uint8_t kullanabilmek için kütüphane

// Testin beklediği x ve y koordinatlarını tutan struct yapısı
typedef struct {
    float x;
    float y;
} coordinate_t;

// Puanı hesaplayacak fonksiyonun bildirimi
uint8_t score(coordinate_t position);

#endif