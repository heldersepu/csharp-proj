using NLog;
using System.Data.Entity;

namespace EmployeesApp.Models
{
    public class DbModel : DbContext
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DbModel() : base("name=EmployeeModel")
        {
            this.Database.Log = x => logger.Trace(x);
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Dependent> Dependents { get; set; }
        public virtual DbSet<BenefitsCost> CostOfBenefits { get; set; }
        public virtual DbSet<BenefitsDiscount> BenefitDiscounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(x => x.Dependents)
                .WithRequired(x => x.Employee)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }

}