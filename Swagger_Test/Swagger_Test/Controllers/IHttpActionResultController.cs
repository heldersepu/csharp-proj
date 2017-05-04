using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Swagger_Test.Controllers
{
    public class IHttpActionResultController : ApiController
    {
        // GET: api/IHttpActionResult
        [ResponseType(typeof(IEnumerable<string>))]
        public IHttpActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        public IHttpActionResult Post()
        {
            throw new NotImplementedException();
        }
    }
}
