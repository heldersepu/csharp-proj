using System;
using System.Web.Http;

namespace TFS_WebApi.Controllers
{
    public class QueriesController : BaseController
    {
        // GET: api/Queries/2
        public IHttpActionResult Get(Guid id)
        {
            return Json(witClient.QueryByIdAsync(id).Result);
        }

        // GET: api/Queries?depth=2
        public IHttpActionResult Get(int depth=2)
        {
            return Json(witClient.GetQueriesAsync(teamProjectName, depth: depth).Result);
        }
    }
}
