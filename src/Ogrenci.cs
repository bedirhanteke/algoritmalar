public class Ogrenci 
{
    // Özellikler (Fields)
    public string Ad;
    public string Bolum;

    // Metot (Davranış)
    public void SelamVer() 
    {
        Console.WriteLine($"Merhaba, ben {Ad}. {Bolum} bölümünde okuyorum.");
    }
}