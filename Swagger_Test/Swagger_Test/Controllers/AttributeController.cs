using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("attrib")]
    public class AttributeController : ApiController
    {
        [Route("{name}")]
        public void Post([FromUri]string name)
        {
        }

        [Route("{id}")]
        public void Post([FromBody]int id)
        {
        }
    }
}
