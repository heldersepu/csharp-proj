using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace TFS_WebApi.Controllers
{
    public class QueriesController : BaseController
    {
        // GET: api/Queries/2
        public async Task<IHttpActionResult> Get(Guid id)
        {
            return Json(await witClient.QueryByIdAsync(id));
        }

        // GET: api/Queries?depth=2
        public async Task<IHttpActionResult> GetWithDepth(int depth)
        {
            if (depth < 2) depth = 2;
            return Json(await witClient.GetQueriesAsync(teamProjectName, depth: depth));
        }
    }
}
