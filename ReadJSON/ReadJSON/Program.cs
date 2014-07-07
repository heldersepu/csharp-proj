using System;
using System.IO;
using System.Net;


namespace ReadJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                foreach (string arg in args)
                {
                    string url = readUrl(arg);
                    parseJSON.dynamic(url);
                }
                Console.ReadLine();
            }
            else if (File.Exists("C:\\sample.json"))
            {
                parseJSON.dynamic(File.ReadAllText("C:\\sample.json"));
            }

        }

        static string readUrl(string url)
        {
            string s = "";
            using (WebClient client = new WebClient())
            {
                s = client.DownloadString(url);
            }
            return s;
        }

       
    }
}
