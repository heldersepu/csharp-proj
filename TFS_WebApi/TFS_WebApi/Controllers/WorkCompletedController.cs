using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TFS_WebApi.Models;
using WebApi.OutputCache.V2;

namespace TFS_WebApi.Controllers
{
    public class WorkCompletedController : BaseController
    {
        const string ASSIGNED = "System.AssignedTo";
        const string ORIGINAL = "Microsoft.VSTS.Scheduling.OriginalEstimate";
        const string REMAINIG = "Microsoft.VSTS.Scheduling.RemainingWork";
        const string COMPLETE = "Microsoft.VSTS.Scheduling.CompletedWork";

        // GET: api/WorkItems/2
        [CacheOutput(ClientTimeSpan = 43200, ServerTimeSpan = 43200)]
        public IHttpActionResult Get(Guid id)
        {
            return Json(GetWork(id));
        }

        // GET: api/WorkItems?name=Sprint_2
        [CacheOutput(ClientTimeSpan = 43200, ServerTimeSpan = 43200)]
        public IHttpActionResult Get(string name, int depth = 2)
        {
            var q = witClient.GetQueriesAsync(teamProjectName, depth: depth).Result;
            var item = q.WhereNameEquals(name);
            if (item == null)
                return NotFound();
            return Json(GetWork(item.Id));
        }

        private SortedDictionary<string, Work> GetWork(Guid id)
        {
            var work = new SortedDictionary<string, Work>();
            var q = witClient.QueryByIdAsync(id).Result;
            foreach (var item in q.WorkItems)
            {
                var i = witClient.GetWorkItemsAsync(new List<int> { item.Id }).Result.FirstOrDefault();
                if (i != null && i.Fields.ContainsKey(ASSIGNED))
                {
                    string assigned = i.Fields[ASSIGNED].ToString();
                    double o, r, c; o = r = c = 0;
                    if (i.Fields.ContainsKey(ORIGINAL))
                        o = Convert.ToDouble(i.Fields[ORIGINAL].ToString());
                    if (i.Fields.ContainsKey(REMAINIG))
                        r = Convert.ToDouble(i.Fields[REMAINIG].ToString());
                    if (i.Fields.ContainsKey(COMPLETE))
                        c = Convert.ToDouble(i.Fields[COMPLETE].ToString());

                    if (work.ContainsKey(assigned))
                        work[assigned].Inc(o, r, c);
                    else
                        work.Add(assigned, new Work(o, r, c));
                }
            }
            return work;
        }
    }
}
