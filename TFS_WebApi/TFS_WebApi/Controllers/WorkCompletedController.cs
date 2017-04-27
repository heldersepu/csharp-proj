using System;
using System.Collections.Generic;
using System.Linq;
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
        [CacheOutput(ClientTimeSpan = 43200, ServerTimeSpan = 43200)]
        public CompletedWork Get(Guid id)
        {
            return GetWork(id);
        }

        // GET: api/WorkItems?name=Sprint_2
        [CacheOutput(ClientTimeSpan = 43200, ServerTimeSpan = 43200)]
        public CompletedWork GetByName(string name, int depth = 2)
        {
            var q = witClient.GetQueriesAsync(teamProjectName, depth: depth).Result;
            var item = q.WhereNameEquals(name);
            if (item == null) return null;
            return GetWork(item.Id);
        }

        private CompletedWork GetWork(Guid id)
        {
            var work = new CompletedWork();
            var q = witClient.QueryByIdAsync(id).Result;
            foreach (var item in q.WorkItems)
            {
                var i = witClient.GetWorkItemsAsync(new List<int> { item.Id }).Result.FirstOrDefault();
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
