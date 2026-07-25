#include "difference_of_squares.h"

unsigned int square_of_sum(unsigned int number) {
    unsigned int toplam = 0;
    
    for (unsigned int i = 1; i <= number; i++) {
        toplam += i;
    }
    
    return toplam * toplam;
}

unsigned int sum_of_squares(unsigned int number) {
    unsigned int karelerinToplami = 0;
    
    for (unsigned int i = 1; i <= number; i++) {
        karelerinToplami += (i * i);
    }
    
    return karelerinToplami;
}

unsigned int difference_of_squares(unsigned int number) { return square_of_sum(number) - sum_of_squares(number);
}