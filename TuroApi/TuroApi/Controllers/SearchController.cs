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
        public IHttpActionResult GetByZip(string zip, int items = 200)
        {
            var date = DateTime.Now.AddDays(1);
            var client = new RestClient(domain);
            var request = new RestRequest("api/search", Method.GET);

            request.AddParameter("location", zip);
            request.AddParameter("itemsPerPage", items);
            request.AddParameter("locationType", "ZIP");

            request.AddParameter("startDate", date.ToString("d"));
            request.AddParameter("startTime", date.ToString("H:m"));
            request.AddParameter("endDate", date.AddDays(7).ToString("d"));
            request.AddParameter("endTime", date.AddDays(7).ToString("H:m"));

            request.AddParameter("category", "ALL");
            request.AddParameter("maximumDistanceInMiles", "300");
            request.AddParameter("sortType", "RELEVANCE");

            request.AddParameter("isMapSearch", "false");
            request.AddParameter("latitude", "26.1512497");
            request.AddParameter("longitude", "-80.3101684");
            request.AddParameter("defaultZoomLevel", "14");
            request.AddParameter("international", "true");

            request.AddHeader("Referer", "https://turo.com/search");
            var resp = client.Execute(request);

            return Ok(JsonConvert.DeserializeObject(resp.Content));
        }
    }
}
