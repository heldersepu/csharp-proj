using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace TFS_WebApi.Controllers
{
    public class WorkItemsController : BaseController
    {
        // GET: api/WorkItems/2
        public async Task<IHttpActionResult> Get(int id)
        {
            return Json(await witClient.GetWorkItemsAsync(new List<int> { id }, expand: WorkItemExpand.Relations));
        }
    }
}
