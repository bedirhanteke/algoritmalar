#include "collatz_conjecture.h"
int steps(int start)
{
    if(start <= 0 ){
            return -1;} 
    int sayi = 0;
    while (1){
        
        if(start == 1){
            return sayi;}
        
        if((start & 1) == 0){
            start = start >> 1;
            sayi++;
        }
        else {
            start = 3 * start + 1;
            sayi++;}
    }
}