class SpecialArrayI
{
    //bit manüpülasyonu
    public static bool IsArraySpecial(int[] nums) {
        // Tek elemanlı diziler her zaman special'dır
        if (nums.Length == 1) return true;

        for (int i = 0; i < nums.Length - 1; i++) {
            // Eğer yan yana iki eleman AYNI paritedeyse (XOR'un son biti 0 ise)
            if (((nums[i] ^ nums[i + 1]) & 1) == 0) {
                // Kural bozuldu, hemen false dön ve çık
                return false;
            }
        }

        // Döngü bittiyse ve hiç false dönmediysek, her çift kurala uygundur
        return true;
    }
}