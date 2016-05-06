using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
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
            DoTest().Wait();
        }

        static async Task DoTest()
        {
            var account = UseNewtonsoft<Account>("Account.json");
            Debug.WriteLine(account.Email);
            account = await UseRestSharp<Account>(url, resource + "Account.json");

            BaseAccount baccount = UseNewtonsoft<BaseAccount>("BaseAccount.json");
            Debug.WriteLine(baccount.Email);
            baccount = await UseRestSharp<BaseAccount>(url, resource + "BaseAccount.json");
        }

        static async Task<T> UseRestSharp<T>(string baseUrl, string resource)
        {
            var request = new RestRequest(resource, Method.GET);
            request.RequestFormat = DataFormat.Json;
            var client = new RestClient(baseUrl);
            var resp = await client.ExecuteTaskAsync<T>(request);
            
            return resp.Data;
        }

        static T UseNewtonsoft<T>(string file)
        {
            string json = File.ReadAllText(file, Encoding.UTF8); ;
            return JsonConvert.DeserializeObject<T>(json);            
        }
    }


    public class BaseAccount
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Account: BaseAccount
    {        
        public IList<string> Roles { get; set; }
        public Dictionary<int,string> Locations { get; set; }
    }
}
