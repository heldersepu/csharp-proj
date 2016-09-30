using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            foreach (var word in rndWords(10, 40))
            {
                trie.Add(word);
                dict[word] = true;
                count++;
            }

            Console.Clear();

            // hello test
            bench("hello", 0);
            // test an early find on list
            bench("cardboard", 30);
            // test the last one on list
            bench("caterpillar", 60);

            Console.WriteLine();
            Console.WriteLine(count);
            Console.Read();
        }

        static List<string> rndWords(int x, int y)
        {
            var words = new List<string> {
                "cars", "card", "cardboard", "carnival",
                "cartoon", "cat", "cats", "cow" };
            for (int J = 0; J < 6; J++)
                words.AddRange(words);

            var client = new RestClient("http://randomtextgenerator.com/");
            var request = new RestRequest("", Method.GET);
            for (int J = 0; J < x; J++)
            {
                var ts = new List<Task<IRestResponse>>();
                for (int i = 0; i < y; i++)
                {
                    ts.Add(client.ExecuteGetTaskAsync(request));
                }
                foreach (var t in ts)
                {
                    t.Wait();
                    int p1 = t.Result.Content.IndexOf("textarea");
                    int p2 = t.Result.Content.LastIndexOf("textarea");
                    if (p1 < p2)
                    {
                        string parag = t.Result.Content.Substring(p1, p2 - p1);
                        foreach (var word in parag.Split(' '))
                        {
                            words.Add(word);
                        }
                    }
                }
            }
            words.Add("caterpillar");
            return words;
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
