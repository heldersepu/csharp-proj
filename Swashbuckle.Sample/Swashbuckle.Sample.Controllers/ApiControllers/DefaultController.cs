using System.Collections.Generic;
using System.Web.Http;

namespace SwashbuckleSample.ApiControllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Deleting stuff
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
        }
    }
}
