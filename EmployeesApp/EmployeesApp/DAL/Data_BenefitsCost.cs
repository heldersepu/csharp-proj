using System;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Caching;
using EmployeesApp.Framework.DbSchema;

namespace EmployeesApp.DAL
{
    public partial class Data
    {
        public static BenefitsCost Costs(bool bypassCache)
        {
            var response = new BenefitsCost();
            var memCache = MemoryCache.Default.Get(Constants.Cache.BENEFITS_COST);
            if ((bypassCache) || (memCache == null))
            {
                using (var context = new DbModel<BenefitsCost>())
                {
                    response = context.First();
                }
                var policy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromHours(1) };
                MemoryCache.Default.Add(Constants.Cache.BENEFITS_COST, response, policy);
            }
            else
            {
                response = (BenefitsCost)memCache;
            }
            return response;
        }

        public static async Task<BenefitsCost> UpdateCosts(BenefitsCost benefitsCost)
        {
            using (var context = new DbModel<BenefitsCost>())
            {
                var bCosts = context.First();
                bCosts.Employee = benefitsCost.Employee;
                bCosts.Dependent = benefitsCost.Dependent;
                bCosts.Description = benefitsCost.Description;
                return await context.Update(bCosts);
            }
        }
       
    }
}