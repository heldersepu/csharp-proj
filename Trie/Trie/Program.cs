using System;
using System.Collections.Generic;

namespace Trie
{
    class Program
    {
        static Trie trie;
        static Dictionary<string, bool> dict;

        static void Main(string[] args)
        {
            long count = 0;
            trie = new Trie();
            dict = new Dictionary<string, bool>();
            foreach (var word in Random.Words(10, 40))
            {
                trie.Add(word);
                dict[word] = true;
                count++;
            }

            Console.Clear();

            // 123 test
            bench("123", 0);
            // test an early find on list
            bench("car", 30);
            // test the last one on list
            bench("caterpillar", 60);

            Console.WriteLine();
            Console.WriteLine(count);
            Console.Read();
        }

        static void bench(string word, int pos)
        {
            DateTime sTime;
            const int LOOPS = 100000;
            Console.CursorTop = 0;
            Console.CursorLeft = pos;
            Console.Write("-- " + word + " --\n");
            Console.CursorTop++;
            for (int J = 0; J < 10; J++)
            {
                sTime = DateTime.Now;
                for (int i = 0; i < LOOPS; i++)
                    trie.Contains(word);
                Console.CursorLeft = pos;
                Console.Write("  Trie: " + sTime.Diff());
                Console.CursorTop++;


                sTime = DateTime.Now;
                for (int i = 0; i < LOOPS; i++)
                    dict.ContainsKey(word);
                Console.CursorLeft = pos;
                Console.Write("  Dict: " + sTime.Diff());
                Console.CursorTop += 2;
            }
        }
    }

    public static class DateTimeExtension
    {
        public static int Diff(this DateTime value)
        {
            return (int)(DateTime.Now - value).TotalMilliseconds;
        }
    }
}
