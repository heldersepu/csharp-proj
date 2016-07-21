using System.Threading.Tasks;
using EmployeesApp.Framework.DbSchema;
using System.Collections.Generic;

namespace EmployeesApp.DAL
{
    /// <summary>
    /// Initialize the database with the required values
    /// </summary>
    public class DbInitializer
    {
        static public async Task Initialize()
        {
            using (var context = new DbModel<Employee>())
            {
                await context.Initialize();
            }

            using (var context = new DbModel<Benefits>())
            {
                await context.Initialize();
                await context.Update(
                    new Benefits
                    {
                        id = "1",
                        Cost = initCost,
                        Discounts = initDiscount
                    }
                );
            }
        }

        private static BenefitsCost initCost
        {
            get
            {
                return new BenefitsCost
                {
                    Employee = 1000.00,
                    Dependent = 500.00,
                    Description = "Yearly Benefits cost (Default)."
                };
            }
        }

        private static List<BenefitsDiscount> initDiscount
        {
            get
            {
                return new List<BenefitsDiscount>
                {
                    new BenefitsDiscount
                    {
                        Percentage = 0.10,
                        Predicate = "Name.StartsWith(\"A\")",
                        Description = "Anyone whose name starts with ‘A’ gets a 10% discount."
                    }
                };
            }
        }

    }
}