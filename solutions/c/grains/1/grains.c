#include "grains.h"

uint64_t square(uint8_t index) {
     if (index < 1 || index > 64) {
        return 0;
    }
    uint64_t degisken = 1; 
    for(int i = 1; i < index; i++){
        degisken <<= 1; }
    return degisken;}
uint64_t total(void){
    return 0xFFFFFFFFFFFFFFFF;}
    
