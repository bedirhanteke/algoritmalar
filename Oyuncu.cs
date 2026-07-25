using System;

public class Oyuncu
{
    public string Isim { get; set; }
    public int Hiz { get; set; }

    public void DashAt()
    {
        Console.WriteLine($"{Isim} ileri atildi! Anlik Hiz: {Hiz * 2}");
    }
}
