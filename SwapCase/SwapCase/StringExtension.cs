namespace System
{
    public static class StringExtension
    {
        public static string SwapCase(this string str)
        {
            string x = "";
            foreach (var c in str)
            {
                if ((c >= 'A') && (c <= 'Z'))
                    x += (char)(c + 32);
                else if ((c >= 'a') && (c <= 'z'))
                    x += (char)(c - 32);
                else
                    x += c;
            }
            return x;
        }
    }
}
