public static class StringEX
{
    public static bool Contains(this string str, params string[] contains)
    {
        if (str == null || contains == null || contains.Length == 0) return false;

        foreach (string s in contains) if (str.Contains(s)) return true;

        return false;
    }
}