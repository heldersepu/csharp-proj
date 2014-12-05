using System.Web.Http;

namespace Socrates.Controllers
{
    public class FirstApiController : ApiController
    {
        public string Get(string id)
        {
            return "Hello World " + id;
        }
    }
}
