using System.Web.Http;

namespace TuroApi.Controllers
{
    public class SearchController : BaseController
    {
        const string domain = "https://turo.com/";

        // GET: api/Search
        public IHttpActionResult GetByZip(string zip, int items = 200)
        {
            var data = TuroSearch(zip, items);
            return Ok(data.list);
        }
    }
}
