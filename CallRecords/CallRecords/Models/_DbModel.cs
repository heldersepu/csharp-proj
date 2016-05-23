using NLog;
using System.Data.Entity;
using CallRecords.Migrations;

namespace CallRecords.Models
{
    public class DbModel : DbContext
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DbModel() : base("name=CallRecordsModel")
        {
            Database.Log = x => logger.Trace(x);
            Database.SetInitializer(new AppDbInitializer());
        }

        public virtual DbSet<Call> Calls { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<CommonFilter> CommonFilters { get; set; }
        public virtual DbSet<Filter> Filters { get; set; }
        public virtual DbSet<ListView> ListViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Call>()
                .HasMany(e => e.Notes)
                .WithRequired(x => x.Call)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ListView>()
                .HasMany(e => e.Filters);

            base.OnModelCreating(modelBuilder);
        }
    }
}