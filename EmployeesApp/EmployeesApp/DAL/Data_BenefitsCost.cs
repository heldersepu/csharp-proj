using System;
using System.Linq;
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
                using (var context = new DbModel())
                {
                    response = context.CostOfBenefits.AsNoTracking().FirstOrDefault();
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

        public static void UpdateCosts(BenefitsCost benefitsCost)
        {
            using (var context = new DbModel())
            {
                var bCosts = context.CostOfBenefits.FirstOrDefault();
                bCosts.Employee = benefitsCost.Employee;
                bCosts.Dependent = benefitsCost.Dependent;
                bCosts.Description = benefitsCost.Description;
                context.SaveChanges();
            }
        }
       
    }
}