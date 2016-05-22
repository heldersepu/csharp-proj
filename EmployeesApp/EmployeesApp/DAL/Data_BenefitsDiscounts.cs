using System;
using System.Linq;
using System.Runtime.Caching;
using System.Collections.Generic;
using EmployeesApp.Framework.DbSchema;
using System.Threading.Tasks;

namespace EmployeesApp.DAL
{
    public partial class Data
    {
        public static List<BenefitsDiscount> Discounts(bool bypassCache)
        {
            var response = new List<BenefitsDiscount>();
            var memCache = MemoryCache.Default.Get(Constants.Cache.BENEFITS_DISCOUNT);
            if ((bypassCache) || (memCache == null))
            {
                using (var context = new DbModel<BenefitsDiscount>())
                {
                    response = context.All.ToList();
                }
                var policy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromHours(1) };
                MemoryCache.Default.Add(Constants.Cache.BENEFITS_DISCOUNT, response, policy);
            }
            else
            {
                response = (List<BenefitsDiscount>)memCache;
            }
            return response;
        }

        public static async Task<BenefitsDiscount> AddDiscount(BenefitsDiscount benefitsDiscount)
        {
            using (var context = new DbModel<BenefitsDiscount>())
            {
                return await context.Add(benefitsDiscount);
            }
        }

        public static async Task<BenefitsDiscount> UpdateDiscount(string id, BenefitsDiscount benefitsDiscount)
        {
            using (var context = new DbModel<BenefitsDiscount>())
            {
                var bd = context.Get(id);
                if (bd == null)
                    return null;
                bd.Percentage = benefitsDiscount.Percentage;
                bd.Type = benefitsDiscount.Type;
                bd.Value = benefitsDiscount.Value;
                bd.Description = benefitsDiscount.Description;
                return await context.Update(bd);
            }
        }

        public static async Task<string> DeleteDiscount(string id)
        {
            using (var context = new DbModel<BenefitsDiscount>())
            {
                return await context.Remove(id);
            }
        }
    }
}