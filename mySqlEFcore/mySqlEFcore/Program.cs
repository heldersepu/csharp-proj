    using Microsoft.EntityFrameworkCore;

    namespace mySqlEFcore
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var context = new LibraryContext())
                {
                    context.Database.Migrate();
                    context.Publishers.Add(new Publisher { ID = 1 });
                    context.SaveChanges();
                }
            }

            private class Publisher
            {
                public int ID { get; set; }
            }

            private class LibraryContext : DbContext
            {
                public DbSet<Publisher> Publishers { get; set; }

                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseMySQL("server=localhost;database=library;user=root;password=123456;SslMode=none;");
                }

                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    base.OnModelCreating(modelBuilder);
                    modelBuilder.Entity<Publisher>(entity => { entity.HasKey(e => e.ID); });
                }
            }
        }
    }
