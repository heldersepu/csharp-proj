using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace Trie
{
    public static class Random
    {
        public static List<string> Words(int x, int y)
        {
            var words = new List<string> {
                "cars", "card", "cardboard", "carnival",
                "cartoon", "cat", "cats", "cow" };

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
                        p1 += 10; p2 -= 10;
                        string parag = t.Result.Content.Substring(p1, p2 - p1);
                        foreach (var word in parag.Split(' '))
                        {
                            if (!word.Contains("\\") && !word.Contains(">") && !word.Contains("<"))
                                words.Add(word.ToLower().Trim());
                        }
                    }
                }
            }
            words.Add("caterpillar");
            return words;
        }
    }
}
