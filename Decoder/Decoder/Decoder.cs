using System.Collections.Generic;

namespace Decoder
{
    public class Decoder
    {
        public static int CountDeco(string message, Dictionary<string, string> keys)
        {
            int x = 0;
            foreach (var posibility in Posibilities(message))
            {
                bool ok = true;
                foreach (var key in posibility)
                {
                    if (!keys.ContainsKey(key))
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok) x++;
            }
            return x;
        }

        public static List<List<string>> Posibilities(string message)
        {
            var x = new List<List<string>>();
            for (int i = 1; i <= message.Length; i++)
            {
                var m = new List<string>();
                for (int j = 0; j < message.Length; j++)
                {
                    try
                    {
                        m.Add(message.Substring(j, i));
                    }
                    catch { }
                }
                x.Add(m);
            }
            return x;
        }
    }
}
