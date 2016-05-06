using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace JsonDeserialize
{
    class Program
    {
        const string url = @"https://raw.githubusercontent.com/";
        const string resource = @"heldersepu/csharp-proj/master/JsonDeserialize/JsonDeserialize/";

        static void Main(string[] args)
        {
            DoTest<BaseAccount>("BaseAccount.json").Wait();
            Console.WriteLine("\n\n");
            DoTest<Account>("Account.json").Wait();
            Console.WriteLine("\n\n");
            DoTest<CompanyInfo>("CompanyInfo.json").Wait();
            Console.Read();
        }

        static async Task DoTest<T>(string file)
        {
            Console.ForegroundColor = ConsoleColor.White;
            var x = UseNewtonsoft<T>(file);
            Console.WriteLine(JsonConvert.SerializeObject(x));

            Console.ForegroundColor = ConsoleColor.Green;
            x = await UseRestSharp<T>(resource + file);
            Console.WriteLine((x == null) ? "No Data": JsonConvert.SerializeObject(x));
        }

        static async Task<T> UseRestSharp<T>(string resource)
        {
            var request = new RestRequest(resource, Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.OnBeforeDeserialization = r => { r.ContentType = "application/json"; };
            var resp = await new RestClient(url).ExecuteTaskAsync<T>(request);
            return resp.Data;
        }

        static T UseNewtonsoft<T>(string file)
        {
            string json = File.ReadAllText(file, Encoding.UTF8);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
