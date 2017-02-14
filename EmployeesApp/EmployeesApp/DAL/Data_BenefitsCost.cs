using System.Threading.Tasks;
using EmployeesApp.Framework.DbSchema;

namespace EmployeesApp.DAL
{
    public partial class Data
    {
        public static BenefitsCost Costs(bool bypassCache)
        {
            return Benefits(bypassCache).Cost;
        }

        public static async Task<Benefits> UpdateCosts(BenefitsCost benefitsCost)
        {
            using (var context = new DbModel<Benefits>())
            {
                var benef = context.First();
                benef.Cost.Employee = benefitsCost.Employee;
                benef.Cost.Dependent = benefitsCost.Dependent;
                benef.Cost.Description = benefitsCost.Description;
                return await context.Update(benef);
            }
        }

    }
}