using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EmployeesApp.Framework.DbSchema;

namespace EmployeesApp.DAL
{
    public partial class Data
    {
        public static List<BenefitsDiscount> Discounts(bool bypassCache)
        {
            return Benefits(bypassCache).Discounts;
        }

        public static async Task<Benefits> AddDiscount(BenefitsDiscount benefitsDiscount)
        {
            using (var context = new DbModel<Benefits>())
            {
                var benef = context.First();
                benef.Discounts.Add(benefitsDiscount);
                return await context.Update(benef);
            }
        }

        public static async Task<Benefits> UpdateDiscount(string id, BenefitsDiscount benefitsDiscount)
        {
            using (var context = new DbModel<Benefits>())
            {
                var benef = context.First();
                var bd = benef.Discounts.Where( x => x.id == id).FirstOrDefault();
                if (bd == null)
                    return null;
                bd.Percentage = benefitsDiscount.Percentage;
                bd.Predicate = benefitsDiscount.Predicate;
                bd.Description = benefitsDiscount.Description;
                return await context.Update(benef);
            }
        }

        public static async Task<Benefits> DeleteDiscount(string id)
        {
            using (var context = new DbModel<Benefits>())
            {
                var benef = context.First();
                var bd = benef.Discounts.Where(x => x.id == id).FirstOrDefault();
                if (bd == null)
                    return null;
                benef.Discounts.Remove(bd);
                return await context.Update(benef);
            }
        }
    }
}