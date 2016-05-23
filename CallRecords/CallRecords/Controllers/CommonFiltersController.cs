using NLog;
using System;
using System.Linq;
using System.Web.Http;
using System.Runtime.Caching;
using System.Collections.Generic;
using CallRecords.Models;

namespace CallRecords.Controllers
{
    public class CommonFiltersController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Return all the CommonFilter
        /// </summary>
        /// <param name="bypassCache">Option to go directly to the DB default false</param>
        /// <returns>Return all the CommonFilter</returns>
        public IHttpActionResult Get(bool bypassCache = false)
        {
            try
            {
                var response = new List<CommonFilter>();
                var memCache = MemoryCache.Default.Get("CommonFilters");
                if ((bypassCache) || (memCache == null))
                {
                    using (var context = new DbModel())
                    {
                        response = context.CommonFilters.ToList();
                    }
                    var policy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromHours(1) };
                    MemoryCache.Default.Add("CommonFilters", response, policy);
                }
                else
                {
                    response = (List<CommonFilter>)memCache;
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }
    }
}
