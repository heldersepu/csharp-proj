
using NLog;
using System;
using System.Linq;
using System.Web.Http;
using System.Linq.Dynamic;
using System.Collections.Generic;
using CallRecords.Models;

namespace CallRecords.Controllers
{
    public class CallsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get the Calls 
        /// </summary>
        /// <param name="count">The count of calls to retrieve</param>
        /// <returns>A list of calls</returns>
        public IHttpActionResult Get(int count = 100)
        {
            try
            {
                var calls = new List<Call>();
                using (var context = new DbModel())
                {
                    calls = context.Calls.Take(count).ToList();
                }
                return Ok(calls);
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Get the Calls 
        /// </summary>
        /// <param name="where">The condition to use as filter</param>
        /// <param name="count">The count of calls to retrieve</param>
        /// <returns>A list of calls</returns>
        public IHttpActionResult Get(string where, int count = 100)
        {
            try
            {
                var calls = new List<Call>();
                using (var context = new DbModel())
                {
                    calls = context.Calls
                        .Where(where)
                        .Take(count).ToList();
                }
                return Ok(calls);
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }       
    }
}
