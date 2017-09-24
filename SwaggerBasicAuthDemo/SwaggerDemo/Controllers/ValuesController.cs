using SwaggerDemo.Attributes;
using System.Collections.Generic;
using System.Web.Http;

namespace SwaggerDemo.Controllers
{
    [BasicAuthentication]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
