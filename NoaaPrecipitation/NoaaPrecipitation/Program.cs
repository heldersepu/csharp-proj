using System;
using System.Collections.Generic;
using RestSharp;

namespace NoaaPrecipitation
{
    class Program
    {
        static  void Main(string[] args)
        {
            string domain = "http://www.ncdc.noaa.gov";
            string baseUrl = "cdo-web/api/v2/data?datasetid=GHCND&datatypeid=PRCP&startdate=2016-06-01&enddate=2016-06-30&locationid=ZIP:33309&limit=10&offset={0}";
            int offset = 1;
            int rainfall = 0;
            int count = 0;
            int resultsetCount = 0;

            var client = new RestClient(domain);
            do
            {
                var request = new RestRequest(string.Format(baseUrl, offset), Method.GET);
                request.AddHeader("Token", "gIhwWSlrEZoeXiuGItfTihUCoFBDizRe");
                var resp = client.Execute<Data>(request);
                offset += 10;

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    resultsetCount = resp.Data.metadata.resultset.count;
                    foreach (var rain in resp.Data.results)
                    {
                        rainfall += rain.value;
                        count++;
                    }
                }
                else
                {
                    //TODO: Handle Bad resp
                }
            }
            while (count < resultsetCount);

            Console.WriteLine(rainfall);
            Console.Read();
        }

        #region Model
        public class Data
        {
            public Metadata metadata { get; set; }
            public List<Result> results { get; set; }

        }
        public class Result
        {
            public string station { get; set; }
            public int value { get; set; }
        }

        public class Metadata
        {
            public Resultset resultset { get; set; }

        }
        public class Resultset
        {
            public int count { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
        }
        #endregion
    }
}
