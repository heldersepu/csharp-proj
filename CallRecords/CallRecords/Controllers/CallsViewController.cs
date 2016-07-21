using NLog;
using System;
using System.Linq;
using System.Web.Http;
using System.Linq.Dynamic;
using System.Data.Entity;
using CallRecords.Models;

namespace CallRecords.Controllers
{
    public class CallsViewController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets all the calls associated to a ListView
        /// </summary>
        /// <param name="id">The id of the ListView to retrives</param>
        /// <returns>The ListView and all the calls the match the filters</returns>
        public IHttpActionResult Get(int id)
        {
            try
            {
                var cv = new CallsView();
                using (var context = new DbModel())
                {
                    var lv = context.ListViews
                        .Include(x => x.Filters)
                        .Where(x => x.Id == id)
                        .FirstOrDefault();
                    if (lv == null)
                        return NotFound();
                    cv.ListView = lv;
                    var calls = context.Calls.Where("ID>0");
                    foreach (var filter in lv.Filters)
                    {
                        calls = calls.Where(filter.Where);
                    }
                    cv.Calls = calls.ToList();
                }
                return Ok(cv);
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }
    }
}
