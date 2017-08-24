using Microsoft.Rest;
using OffleaseOnly;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TuroApi;

namespace CountingCars
{
    class Program
    {

        static void Main(string[] args)
        {
            var turo = new TuroApiClient(new ApiKeyCredentials());
            var echoGet = turo.Echo.Get("1,1");
            Console.WriteLine(echoGet.ToString());

            try
            {
                var echoPost = turo.Echo.Post();
                Console.WriteLine(echoPost.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

            var offlease = new OffleaseOnlyClient(new ApiKeyCredentials());
            var cars = offlease.Cars.Get("cleanCarFax=1");
            foreach (var c in cars)
            {
                Console.Write(c.Make + " ");
                Console.WriteLine(c.Model);
            }

            Console.ReadKey();
        }
    }

    class ApiKeyCredentials : ServiceClientCredentials
    {
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("apiKey", "123456");
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}
