using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFS_WebApi.Models;
using WebApi.OutputCache.V2;

namespace TFS_WebApi.Controllers
{
    public class WorkCompletedController : BaseController
    {
        const string TEAM = "AN.Team";
        const string ASSIGNED = "System.AssignedTo";
        const string ORIGINAL = "Microsoft.VSTS.Scheduling.OriginalEstimate";
        const string REMAINIG = "Microsoft.VSTS.Scheduling.RemainingWork";
        const string COMPLETE = "Microsoft.VSTS.Scheduling.CompletedWork";

        // GET: api/WorkItems/2
        [CacheOutput(ClientTimeSpan = 1200, ServerTimeSpan = 1200)]
        public async Task<CompletedWork> Get(Guid id)
        {
            return await GetWork(id);
        }

        // GET: api/WorkItems?name=Sprint_2
        [CacheOutput(ClientTimeSpan = 1200, ServerTimeSpan = 1200)]
        public async Task<CompletedWork> GetByName(string name, int depth = 2)
        {
            var q = witClient.GetQueriesAsync(teamProjectName, depth: depth).Result;
            var item = q.WhereNameEquals(name);
            if (item == null) return null;
            return await GetWork(item.Id);
        }

        private async Task<CompletedWork> GetWork(Guid id)
        {
            var work = new CompletedWork();
            var q = await witClient.QueryByIdAsync(id);
            var asyncTasks = new List<Task<List<WorkItem>>>();
            foreach (var item in q.WorkItems)
            {
                asyncTasks.Add(witClient.GetWorkItemsAsync(new List<int> { item.Id }));
            }
            foreach (var task in asyncTasks)
            {
                var result = await task;
                var i = result.FirstOrDefault();
                if (i != null && i.Fields.ContainsKey(ASSIGNED))
                {
                    string team = i.Fields[TEAM].ToString();
                    string assigned = i.Fields[ASSIGNED].ToString();

                    double o, r, c; o = r = c = 0;
                    if (i.Fields.ContainsKey(ORIGINAL))
                        o = Convert.ToDouble(i.Fields[ORIGINAL].ToString());
                    if (i.Fields.ContainsKey(REMAINIG))
                        r = Convert.ToDouble(i.Fields[REMAINIG].ToString());
                    if (i.Fields.ContainsKey(COMPLETE))
                        c = Convert.ToDouble(i.Fields[COMPLETE].ToString());

                    work.Add(team, assigned, o, r, c);
                }
            }
            return work;
        }
    }
}
