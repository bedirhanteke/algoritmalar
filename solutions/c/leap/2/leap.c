#include "leap.h"
bool leap_year(int year){
    bool artık_yıl_mı = false;
    if(year%4==0 && year%25!=0){
        artık_yıl_mı = true;
    }
    else if(year%16==0){
         artık_yıl_mı = true;
    }
    return artık_yıl_mı;
    
}