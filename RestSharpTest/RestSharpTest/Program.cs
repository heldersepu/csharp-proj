using RestSharp;
using System;
using System.Net;
using System.Collections.Generic;

namespace RestSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string domain = "http://devsaasaccountapp.azurewebsites.net/";
            var client = new RestClient(domain);
            var request = new RestRequest ("api/v1/Timezone", Method.GET);
            var resp = client.Execute<DataClass>(request);

            if (resp.StatusCode == HttpStatusCode.OK)
            {
                foreach (var item in resp.Data.Data)
                {
                    Console.WriteLine(item.Code + " = " + item.Name);
                }
            }
            else
            {
                //TODO: handle bad responces
            }
            Console.Read();
        }
    }

    public class DataClass
    {
        public List<TimeZoneModel> Data { get; set; }
    }

    public class TimeZoneModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string TZ { get; set; }
        public string Name { get; set; }
    }
}
