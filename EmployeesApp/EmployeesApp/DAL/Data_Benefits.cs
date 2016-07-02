using System;
using System.Runtime.Caching;
using EmployeesApp.Framework.DbSchema;

namespace EmployeesApp.DAL
{
    public partial class Data
    {
        public static Benefits Benefits(bool bypassCache)
        {
            var response = new Benefits();
            var memCache = MemoryCache.Default.Get(Constants.Cache.BENEFITS);
            if ((bypassCache) || (memCache == null))
            {
                using (var context = new DbModel<Benefits>())
                {
                    response = context.First();
                }
                var policy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromHours(1) };
                MemoryCache.Default.Add(Constants.Cache.BENEFITS, response, policy);
            }
            else
            {
                response = (Benefits)memCache;
            }
            return response;
        }
    }
}