using System.Linq;
using System.Web.Http;

namespace Socrates.Controllers
{

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    public class TwoApiController : ApiController
    {
        Product[] products = new Product[] 
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };
        
        public IHttpActionResult Get(string id)
        {
            var crs = products.ToList(); // FirstOrDefault((p) => p.Id == id);
            if (crs == null)
            {
                return NotFound();
            }
            return Ok(crs);
        }
    }
}
