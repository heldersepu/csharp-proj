using RestSharp;
using System;
using System.Web.Http;
using Newtonsoft.Json;
using TuroApi.Models;
using System.Collections.Generic;

namespace TuroApi.Controllers
{
    abstract public class BaseController : ApiController
    {
        const string domain = "https://turo.com/";

        protected List<Car> TuroSearch(GeoPoint location, int items, string make = null, string model = null)
        {
            var date = DateTime.Now.AddDays(1);
            var client = new RestClient(domain);
            var request = new RestRequest("api/search", Method.GET);

            request.AddParameter("itemsPerPage", items);
            request.AddParameter("latitude", location.Latitude);
            request.AddParameter("longitude", location.Longitude);

            if (make != null)
                request.AddParameter("makes", make);

            if (model != null)
                request.AddParameter("models", model);

            request.AddParameter("startDate", date.ToString("d"));
            request.AddParameter("startTime", date.ToString("H:m"));
            request.AddParameter("endDate", date.AddDays(7).ToString("d"));
            request.AddParameter("endTime", date.AddDays(7).ToString("H:m"));

            request.AddParameter("category", "ALL");
            request.AddParameter("maximumDistanceInMiles", "300");
            request.AddParameter("sortType", "RELEVANCE");

            request.AddParameter("isMapSearch", "false");
            request.AddParameter("defaultZoomLevel", "14");
            request.AddParameter("international", "true");

            request.AddHeader("Referer", "https://turo.com/search");
            var resp = client.Execute(request);
            dynamic data = JsonConvert.DeserializeObject(resp.Content);

            var cars = new List<Car>();
            foreach (var item in data.list)
            {
                cars.Add(new Car
                {
                    make = item.vehicle.make,
                    model = item.vehicle.model,
                    year = (int)item.vehicle.year,
                    tripsTaken = (int)item.renterTripsTaken,
                    dailyPrice = (double)item.rate.averageDailyPrice
                });
            }
            return cars;
        }
    }
}
