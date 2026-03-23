static public class Ogrenci 
{
    // Özellikler (Fields)
    public static string Ad = "Bedirhan";
    public static string Bolum = "Bilgisayar Mühendisliği";

    // Metot (Davranış)
    static public void SelamVer() 
    {
        Console.WriteLine($"Merhaba, ben {Ad}. {Bolum} bölümünde okuyorum.");
    }
}