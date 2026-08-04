#include "darts.h"

uint8_t score(coordinate_t position) {
    // Struct içindeki x ve y değerlerini alıp mesafenin karesini hesaplıyoruz
    float mesafe_kare = (position.x * position.x) + (position.y * position.y);

    // Dışarıda kalma durumu (Yarıçap karesi > 100)
    if (mesafe_kare > 100.0f) {
        return 0;
    }
    // Dış çember (Yarıçap karesi > 25)
    else if (mesafe_kare > 25.0f) {
        return 1;
    }
    // Orta çember (Yarıçap karesi > 1)
    else if (mesafe_kare > 1.0f) {
        return 5;
    }
    // İç çember (Yukarıdaki şartların hiçbiri değilse tam merkezdedir)
    else {
        return 10;
    }
}