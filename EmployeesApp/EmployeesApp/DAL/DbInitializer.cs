using System.Data.Entity;
using System.Data.Entity.Migrations;
using EmployeesApp.Framework.DbSchema;

namespace EmployeesApp.DAL
{
    /// <summary>
    /// Initialize the database with the required values
    /// </summary>
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DbModel>
    {
        protected override void Seed(DbModel context)
        {
            context.CostOfBenefits.AddOrUpdate(
                new BenefitsCost
                {
                    Id = 1,
                    Employee = 1000.00,
                    Dependent = 500.00,
                    Description = "Yearly Benefits cost (Default)."
                }
            );
            context.BenefitDiscounts.AddOrUpdate(
                new BenefitsDiscount
                {
                    Id = 1,
                    Percentage = 0.10,
                    Type = "StartsWith",
                    Value = "A",
                    Description = "Anyone whose name starts with ‘A’ gets a 10% discount."
                }
            );
            context.SaveChanges();
        }
    }

    internal sealed class Configuration : DbMigrationsConfiguration<DbModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }
    }
}