using NLog;
using System.Data.Entity;

namespace RandTest.Models
{
    public class DbModel : DbContext
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DbModel() : base("name=RandTest")
        {
            this.Database.Log = x => logger.Trace(x);
        }

        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Choice> Choices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .HasMany(x => x.Questions)
                .WithRequired(x => x.Test)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Question>()
                .HasMany(x => x.Choices)
                .WithRequired(x => x.Question)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}