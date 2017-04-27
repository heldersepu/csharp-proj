using System.Collections.Generic;

namespace TFS_WebApi.Models
{
    public class CompletedWork : SortedDictionary<string, SortedDictionary<string, Work>>
    {
        public void Add(string team, string assigned, double o, double r, double c)
        {
            if (this.ContainsKey(team))
            {
                if (this[team].ContainsKey(assigned))
                    this[team][assigned].Inc(o, r, c);
                else
                    this[team].Add(assigned, new Work(o, r, c));
            }
            else
            {
                var x = new SortedDictionary<string, Work>();
                x.Add(assigned, new Work(o, r, c));
                this.Add(team, x);
            }
        }
    }
}