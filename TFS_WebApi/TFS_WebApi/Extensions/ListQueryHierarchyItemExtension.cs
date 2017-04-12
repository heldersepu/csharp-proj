using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace TFS_WebApi
{
    public static class ListQueryHierarchyItemExtension
    {
        public static QueryHierarchyItem WhereNameEquals(this IList<QueryHierarchyItem> value, string name)
        {
            var qn = value.Where(x => x.Name == name).FirstOrDefault();
            if (qn == null)
            {
                foreach (var q in value)
                {
                    if (q.Children != null)
                    {
                        qn = q.Children.WhereNameEquals(name);
                        if (qn != null) return qn;
                    }
                }
            }
            return qn;
        }
    }
}