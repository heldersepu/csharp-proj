using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TFS_WebApi.Models;

namespace TFS_WebApi.Controllers
{
    public class WorkItemAndChildrenController : BaseController
    {
        // GET api/<controller>/5
        public async Task<WorkObj> Get(int id)
        {
            var parent = await witClient.GetWorkItemAsync(id, expand: WorkItemExpand.Relations);
            var workObj = new WorkObj(parent);

            var asyncTasks = new List<Task<WorkObj>>();
            foreach (var child in parent.Relations)
            {
                if (child.Rel.EndsWith("Forward"))
                {
                    int pos = child.Url.LastIndexOf("/");
                    if (pos > 1)
                    {
                        int cid = int.Parse(child.Url.Substring(pos + 1));
                        asyncTasks.Add(Get(cid));
                    }
                }
            }

            foreach (var task in asyncTasks)
            {
                var result = await task;
                workObj.children.Add(result);
            }

            return workObj;
        }
    }
}