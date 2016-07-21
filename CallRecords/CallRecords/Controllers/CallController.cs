using NLog;
using System;
using System.Linq;
using System.Web.Http;
using CallRecords.Models;


namespace CallRecords.Controllers
{
    public class CallController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get one call by id
        /// </summary>
        /// <param name="id">The id of the call</param>
        /// <returns>Returns the call that matches the given id</returns>
        public IHttpActionResult Get(int id)
        {
            try
            {
                Call call = null;
                using (var context = new DbModel())
                {
                    call = context.Calls.Where(x => x.Id == id).FirstOrDefault();
                }
                if (call != null)
                    return Ok(call);
                return NotFound();
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }
    }
}
