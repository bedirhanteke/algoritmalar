class vize1
{
    // 4 basamaklı rastgele bir sayı üretip basamaklarını toplayan metot
    public static int Vize1()
    {
        // Rastgele sayı üretmek için Random sınıfından bir nesne oluşturuyoruz.
        Random rnd = new Random();

        // 1000 ile 10000 (dahil değil) arasında rastgele 4 basamaklı bir tam sayı seçiyoruz.
        int sayı = rnd.Next(1000, 10000);

        // Orijinal sayıyı bozmamak için işlemleri yapacağımız 'a' değişkenine kopyalıyoruz.
        int a = sayı;

        // Basamakların toplamını biriktireceğimiz değişken (ilk değeri 0).
        int sonuc = 0;

        // 'a' değişkeni 0'dan büyük olduğu sürece döngü devam eder.
        while(a > 0)
        {
            // Geçici bir değişken oluşturup sayının son basamağını (birler basamağını) alıyoruz.
            // '%' operatörü mod alma işlemidir; 10 ile bölümünden kalan son rakamı verir.
            int temp = a % 10;

            // Sayıyı 10'a bölerek işlediğimiz son basamağı sayıdan atıyoruz.
            // C#'ta int / int işlemi tam sayı sonucu verdiği için küsurat silinir (Örn: 123 / 10 = 12).
            a /= 10;

            // Kopardığımız bu son basamağı genel toplama (sonuc) ekliyoruz.
            sonuc += temp;
        }

        // Döngü bittiğinde elde edilen toplamı geri döndürüyoruz.
        return sonuc;
    }
}