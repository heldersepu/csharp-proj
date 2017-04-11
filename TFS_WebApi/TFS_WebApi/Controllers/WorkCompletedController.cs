using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TFS_WebApi.Controllers
{
    public class WorkCompletedController : BaseController
    {
        // GET: api/WorkItems?id=2
        public IHttpActionResult Get(string queryid)
        {
            var work = new SortedDictionary<string, double>();
            var q = witClient.QueryByIdAsync(new Guid(queryid)).Result;
            foreach (var item in q.WorkItems)
            {
                var i = witClient.GetWorkItemsAsync(new List<int> { item.Id }).Result.FirstOrDefault();
                if (i != null && i.Fields.ContainsKey("System.AssignedTo"))
                {
                    string assigned = i.Fields["System.AssignedTo"].ToString();
                    double CompletedWork = Convert.ToDouble(i.Fields["Microsoft.VSTS.Scheduling.CompletedWork"].ToString());
                    if (work.ContainsKey(assigned))
                        work[assigned] += CompletedWork;
                    else
                        work.Add(assigned, CompletedWork);
                }
            }
            return Json(work);
        }
    }
}
