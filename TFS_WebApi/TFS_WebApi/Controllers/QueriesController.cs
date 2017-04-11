using System;
using System.Web.Http;

namespace TFS_WebApi.Controllers
{
    public class QueriesController : BaseController
    {
        // GET: api/Queries?depth=2
        public IHttpActionResult Get(int depth=2)
        {
            return Json(witClient.GetQueriesAsync(teamProjectName, depth: depth).Result);
        }

        // GET: api/Queries?queryid=2
        public IHttpActionResult Get(string queryid)
        {
            return Json(witClient.QueryByIdAsync(new Guid(queryid)).Result);
        }
    }
}
