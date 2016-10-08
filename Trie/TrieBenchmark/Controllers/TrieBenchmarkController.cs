using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Http;
using Trie;

namespace TrieBenchmark.Controllers
{
    public class TrieBenchmarkController : ApiController
    {
        static List<string> words = Trie.Random.Words(1, 10);
        const int LOOPS = 100000;
        const int TESTS = 10;

        public dynamic Get(int count)
        {
            while (words.Count < count)
                words.AddRange(Trie.Random.Words(5, 10));

            DateTime sTime;
            var trie = new Trie.Trie();
            var dict = new Dictionary<string, bool>();
            var testWords = new List<string> {"123", "car", "caterpillar" };

            var trieData = new List<List<int>>();
            var dictData = new List<List<int>>();
            int x = 0;
            int jumps = 5000;
            while (x < count)
            {
                foreach (var word in words.Take(jumps).Skip(x))
                {
                    trie.Add(word);
                    dict[word] = true;
                }

                int dictZum = 0;
                int trieZum = 0;
                foreach (var word in testWords)
                {
                    for (int J = 0; J < TESTS; J++)
                    {
                        sTime = DateTime.Now;
                        for (int i = 0; i < LOOPS; i++)
                            trie.Contains(word);
                        trieZum += sTime.Diff();

                        sTime = DateTime.Now;
                        for (int i = 0; i < LOOPS; i++)
                            dict.ContainsKey(word);
                        dictZum += sTime.Diff();
                    }
                }
                x += jumps;
                trieData.Add(new List<int> { x, trieZum / (TESTS * testWords.Count) });
                dictData.Add(new List<int> { x, dictZum / (TESTS * testWords.Count) });
            }

            dynamic chart = new ExpandoObject();
            chart.Label = "TrieBenchmark";
            chart.TrieData = trieData;
            chart.DictData = dictData;

            return Json(chart);
        }
    }
}
