using System;
using System.Linq;
using System.Runtime.Caching;
using System.Collections.Generic;
using EmployeesApp.Framework.DbSchema;

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
                using (var context = new DbModel())
                {
                    response = context.BenefitDiscounts.AsNoTracking().ToList();
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

        public static void AddDiscount(BenefitsDiscount benefitsDiscount)
        {
            using (var context = new DbModel())
            {
                context.BenefitDiscounts.Add(
                    new BenefitsDiscount
                    {
                        Percentage = benefitsDiscount.Percentage,
                        Type = benefitsDiscount.Type,
                        Value = benefitsDiscount.Value,
                        Description = benefitsDiscount.Description
                    }
                );
                context.SaveChanges();
            }
        }

        public static int? UpdateDiscount(int id, BenefitsDiscount benefitsDiscount)
        {
            using (var context = new DbModel())
            {
                var bd = context.BenefitDiscounts.Where(x => x.Id == id).FirstOrDefault();
                if (bd == null)
                    return null;
                bd.Percentage = benefitsDiscount.Percentage;
                bd.Type = benefitsDiscount.Type;
                bd.Value = benefitsDiscount.Value;
                bd.Description = benefitsDiscount.Description;
                context.SaveChanges();
                return id;
            }
        }

        public static int? DeleteDiscount(int id)
        {
            using (var context = new DbModel())
            {
                var bd = context.BenefitDiscounts.Where(x => x.Id == id).FirstOrDefault();
                if (bd == null)
                    return null;
                context.BenefitDiscounts.Remove(bd);
                context.SaveChanges();
                return id;
            }
        }
    }
}