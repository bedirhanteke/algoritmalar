public class UstBulma
{
    

public static double HizliHesapla(double taban, long us)
{
    double sonuc = 1.0;

    // x^n = (x^2)^(n/2) kimliğini kullanıyoruz.
    // Her adımda üssü yarıya indirip tabanın karesini alıyoruz.
    // Böylece problemi her seferinde yarıya indiriyoruz: O(log n)

    while (us > 0)
    {
        // Üs tek sayıysa (yani binary'de en sağdaki bit 1 ise):
        // x^9 = x^1 * x^8 gibi — o "tek kalan" x'i sonuca şimdi katıyoruz.
        // Çünkü üssü 2'ye böldüğümüzde bu bit kaybolacak, kaçırırız.
        if ((us & 1) == 1)
        {
            sonuc *= taban;
        }

        // x^n = (x^2)^(n/2) kimliği burada devreye giriyor.
        // Tabanı x'ten x²'ye yükseltiyoruz.
        // Bir sonraki iterasyonda bu taban x⁴, sonra x⁸ olacak...
        // Yani her döngüde taban: x → x² → x⁴ → x⁸ → ...
        taban *= taban;

        // Üssü 2'ye bölüyoruz (sağa bit kaydırma = 2'ye bölme).
        // 9 (1001) → 4 (0100) → 2 (0010) → 1 (0001) → 0 (dur)
        // Her bit, o kuvvetin sonuca girip girmeyeceğini söylüyor.
        us >>= 1;
    }

    // Örnek: 3^9
    // us=9(1001): bit=1 → sonuc=3,     taban=9,   us=4
    // us=4(0100): bit=0 → sonuc=3,     taban=81,  us=2
    // us=2(0010): bit=0 → sonuc=3,     taban=6561,us=1
    // us=1(0001): bit=1 → sonuc=3*6561=19683=3^9  ✓

    return sonuc;
}
}