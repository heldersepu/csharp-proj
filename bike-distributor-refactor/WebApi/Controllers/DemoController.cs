using System.Threading.Tasks;
using System.Web.Http;
using BikeDistributor.MockData;
using BikeDistributor;
using WebApi.DAL;

namespace WebApi.Controllers
{
    public class DemoController : ApiController
    {
        // GET: api/Demo
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new DbModel<Discount>())
            {
                await context.Initialize();
                foreach (var item in Data.Discounts)
                {
                    await context.Add(item);
                }
            }

            using (var context = new DbModel<Bike>())
            {
                await context.Initialize();
                await context.Add(Data.Bikes.Defy);
                await context.Add(Data.Bikes.Elite);
                await context.Add(Data.Bikes.DuraAce);
                await context.Add(Data.Bikes.TrekTF);
            }

            return Ok(System.DateTime.Now);
        }
    }
}
