using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace TFS_WebApi.Controllers
{
    public class WorkItemAndChildrenController : BaseController
    {
        // GET api/<controller>/5
        public async Task<IHttpActionResult> Get(int id)
        {
            var parent = await witClient.GetWorkItemAsync(id, expand: WorkItemExpand.Relations);
            parent.Fields = null;
            for (int i = parent.Relations.Count - 1; i >= 0 ; i--)
            {
                if (!parent.Relations[i].Rel.EndsWith("forward"))
                    parent.Relations.RemoveAt(i);
            }
            return Json(parent);
        }
    }
}