using System.Text;

namespace System
{
    public static class StringExtension
    {
        public static string SwapCase(this string str)
        {
            var x = new StringBuilder();
            var diff = (char)('a' - 'A');
            foreach (var c in str)
            {
                if ((c >= 'A') && (c <= 'Z'))
                    x.Append((char)(c + diff));
                else if ((c >= 'a') && (c <= 'z'))
                    x.Append((char)(c - diff));
                else
                    x.Append(c);
            }
            return x.ToString();
        }
    }
}
