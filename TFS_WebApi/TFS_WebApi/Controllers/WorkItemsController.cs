using System.Collections.Generic;
using System.Web.Http;

namespace TFS_WebApi.Controllers
{
    public class WorkItemsController : BaseController
    {
        // GET: api/WorkItems?id=2
        public IHttpActionResult Get(int id)
        {
            return Json(witClient.GetWorkItemsAsync(new List<int> { id }).Result);
        }
    }
}
