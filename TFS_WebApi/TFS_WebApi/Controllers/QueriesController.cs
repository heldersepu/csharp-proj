using System.Web.Http;

namespace TFS_WebApi.Controllers
{
    public class QueriesController : BaseController
    {
        // GET: api/Projects
        public IHttpActionResult Get()
        {
            return Json(witClient.GetQueriesAsync(teamProjectName, depth: 2).Result);
        }
    }
}
