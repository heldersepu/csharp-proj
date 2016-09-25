using System;
using System.Collections.Generic;

namespace Trie
{
    class Program
    {
        static List<string> words;
        static Trie trie;

        static void Main(string[] args)
        {
            words = new List<string> {
                "cars", "card", "cardboard", "carnival",
                "cartoon", "cat", "cats", "cow" };
            for (int J = 0; J < 6; J++)
                words.AddRange(words);
            words.Add("caterpillar");

            trie = new Trie();
            foreach (var word in words)
                trie.Add(word);

            // test a not found
            bench("hello", 0);
            // test an early find on list
            bench("cardboard", 30);
            // test a last one on list
            bench("caterpillar", 60);

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
                    words.Contains(word);
                Console.CursorLeft = pos;
                Console.Write("  List: " + sTime.Diff());
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
