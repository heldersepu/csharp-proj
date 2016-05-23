using NLog;
using System;
using System.Linq;
using System.Web.Http;
using CallRecords.Models;

namespace CallRecords.Controllers
{
    public class ListViewsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Returns all ListViews
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            try
            {
                using (var context = new DbModel())
                {
                    return Ok(context.ListViews.Where(x => x.Name != null).ToList());
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }
    }
}
