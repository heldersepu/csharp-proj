using RestSharp;
using System;
using System.Web.Http;
using Newtonsoft.Json;

namespace TuroApi.Controllers
{
    public class SearchController : ApiController
    {
        const string domain = "https://turo.com/";

        // GET: api/Search
        public IHttpActionResult Get()
        {
            var now = DateTime.Now;
            var client = new RestClient(domain);
            var request = new RestRequest("api/search", Method.GET);

            request.AddQueryParameter("location", "FL+33323+USA");
            request.AddQueryParameter("locationType", "ZIP");

            request.AddQueryParameter("startDate", "05-30-2017");
            request.AddQueryParameter("startTime", "10:00");

            request.AddQueryParameter("endDate", "06-05-2017");
            request.AddQueryParameter("endTime", "10:00");

            request.AddQueryParameter("region", "FL");
            request.AddQueryParameter("country", "US");

            request.AddQueryParameter("category", "ALL");
            request.AddQueryParameter("maximumDistanceInMiles", "300");
            request.AddQueryParameter("sortType", "RELEVANCE");

            request.AddQueryParameter("isMapSearch", "false");
            request.AddQueryParameter("latitude", "26.1512497");
            request.AddQueryParameter("longitude", "-80.3101684");

            request.AddQueryParameter("defaultZoomLevel", "14");
            request.AddQueryParameter("international", "true");
            request.AddQueryParameter("itemsPerPage", "200");

            request.AddHeader("Referer", "https://turo.com/search");
            var resp = client.Execute(request);

            return Ok(JsonConvert.DeserializeObject(resp.Content));
        }        
    }
}
