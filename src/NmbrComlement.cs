class NmbrComlement
{
    public int FindComplement(int num) {
        // Pozitif tam sayı dendiği için genellikle 1'den başlar, 0 için önlem:
        if (num == 0) return 1;

        // Başlangıçta maskemizi 1 (2^0) olarak belirliyoruz.
        int maske = 1;

        // Mantık: Sayıdan büyük olan İLK 2'nin kuvvetini bulmak.
        // Bit dünyasında sola kaydırmak (<< 1), sayıyı 2 ile çarpmakla aynıdır.
        while (maske < num) {
            // Maskeyi 1 sola kaydır (2 ile çarp) ve en sağdaki biti 1 yap ( | 1 ).
            // Örn: 1 -> 11 (3) -> 111 (7) -> 1111 (15)
            maske = (maske << 1) | 1;
        }

        // Maske (tamamı 1'lerden oluşan sayı) ile asıl sayımızı XOR'luyoruz.
        // XOR işlemi farklı bitleri 1, aynı bitleri 0 yapar; yani bitleri ters çevirir.
        return maske ^ num;
    }

}
   