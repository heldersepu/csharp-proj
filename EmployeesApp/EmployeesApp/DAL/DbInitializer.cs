using System.Threading.Tasks;
using EmployeesApp.Framework.DbSchema;

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
            using (var context = new DbModel<BenefitsCost>())
            {
                await context.Initialize();
                await context.Update(
                    new BenefitsCost
                    {
                        id = "1",
                        Employee = 1000.00,
                        Dependent = 500.00,
                        Description = "Yearly Benefits cost (Default)."
                    }
                );
            }
            using (var context = new DbModel<BenefitsDiscount>())
            {
                await context.Initialize();
                await context.Add(
                    new BenefitsDiscount
                    {
                        id = "1",
                        Percentage = 0.10,
                        Type = "StartsWith",
                        Value = "A",
                        Description = "Anyone whose name starts with ‘A’ gets a 10% discount."
                    }
                );
            }
            
        }
    }    
}