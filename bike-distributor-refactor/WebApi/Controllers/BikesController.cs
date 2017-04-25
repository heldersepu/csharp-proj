using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using BikeDistributor;
using WebApi.DAL;

namespace WebApi.Controllers
{
    public class BikesController : ApiController
    {
        // GET: api/Bikes
        public List<Bike> Get()
        {
            using (var context = new DbModel<Bike>())
            {
                return context.All.ToList();
            }
        }

        // GET: api/Bikes/G1
        public Bike GetById(string id)
        {
            using (var context = new DbModel<Bike>())
            {
                return context.Get(id);
            }
        }

        // POST: api/Bikes
        public IHttpActionResult Post([FromBody]string value)
        {
            throw new System.NotImplementedException();
        }

        // PUT: api/Bikes/G1
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            throw new System.NotImplementedException();
        }

        // DELETE: api/Bikes/G1
        public IHttpActionResult Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
