using System.Collections.Generic;
using System.Web.Http;
using TuroApi.Models;

namespace TuroApi.Controllers
{
    public class SearchController : BaseController
    {
        const string domain = "https://turo.com/";

        // GET: api/Search
        public IHttpActionResult GetByZip(string zip, int items = 200)
        {
            var data = TuroSearch(zip, items);

            var cars = new List<Car>();
            foreach (var item in data.list)
            {
                cars.Add(new Car {
                    make = item.vehicle.make,
                    model = item.vehicle.model,
                    year = (int)item.vehicle.year,
                    tripsTaken = (int)item.renterTripsTaken,
                    dailyPrice = (double)item.rate.averageDailyPrice
                });
            }
            return Ok(cars);
        }
    }
}
