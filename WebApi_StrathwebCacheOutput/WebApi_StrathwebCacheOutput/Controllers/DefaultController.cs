using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace WebApi_StrathwebCacheOutput.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        //[CacheOutput(ClientTimeSpan = 120, ServerTimeSpan = 120)]
        [CacheOutput(ClientTimeSpan = 120, ServerTimeSpan = 120, ExcludeQueryStringFromCacheKey = false)]
        public long Get(int id)
        {
            return DateTime.Now.Ticks;
        }
    }
}
