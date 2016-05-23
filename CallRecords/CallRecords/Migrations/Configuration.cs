using CallRecords.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CallRecords.Migrations
{
    public class AppDbInitializer : MigrateDatabaseToLatestVersion<DbModel, Configuration>
    {
    }

    public class Configuration : DbMigrationsConfiguration<DbModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DbModel context)
        {
            context.CommonFilters.AddOrUpdate(
                new[] {
                    new CommonFilter {Id = 1, Field = "Id", Operation = "<{0}", Type = "digits",
                        Description = "Id is less than"},
                    new CommonFilter {Id = 2, Field = "Id", Operation = ">{0}", Type = "digits",
                        Description = "Id is greater than"},
                    new CommonFilter {Id = 3, Field = "Duration", Operation = "<{0}", Type = "digits",
                        Description = "Duration less than (seconds)" },
                    new CommonFilter {Id = 4, Field = "Duration", Operation = ">{0}", Type = "digits",
                        Description = "Duration greater than (seconds)" },
                    new CommonFilter {Id = 5, Field = "Name", Operation = ".Contains(\"{0}\")", Type = "text",
                        Description = "Name Contains" },
                    new CommonFilter {Id = 6, Field = "PhoneNumber", Operation = ".Contains(\"{0}\")", Type = "text",
                        Description = "PhoneNumber Contains" },
                });
            context.SaveChanges();

            context.Filters.AddOrUpdate(
                new[] {
                    new Filter {Id = 1, CommonFilter_Id = 0, Where = "Id>0" },
                    new Filter {Id = 2, CommonFilter_Id = 1, Where = "Id<50" },
                    new Filter {Id = 3, CommonFilter_Id = 2, Where = "Id>30" },                    
                    new Filter {Id = 4, CommonFilter_Id = 3, Where = "Duration<60" },
                    new Filter {Id = 5, CommonFilter_Id = 4, Where = "Duration>300" },
                    new Filter {Id = 6, CommonFilter_Id = 0, Where = "StartTime<DateTime(2000,1,1)" },
                    new Filter {Id = 7, CommonFilter_Id = 0, Where = "Name.Contains(\"Neil\") OR Name.Contains(\"Lisa\")" },
                });
            context.SaveChanges();

            context.ListViews.AddOrUpdate(
                new[] {
                    new ListView {Id = 1, Name= null, ReadOnly = true,
                        Filters = context.Filters.Where(x => x.Id == 1).ToList() },
                    new ListView {Id = 2, Name = "All calls with ID in a range", ReadOnly = true,
                        Filters = context.Filters.Where(x => (x.Id == 2 || x.Id == 3)).ToList() },
                    new ListView {Id = 3, Name = "Quick Calls", ReadOnly = true,
                        Filters = context.Filters.Where(x => x.Id == 4).ToList() },
                    new ListView {Id = 4, Name = "Long Calls", ReadOnly = true,
                        Filters = context.Filters.Where(x => x.Id == 5).ToList() },
                    new ListView {Id = 5, Name = "Pre Y2K", ReadOnly = true,
                        Filters = context.Filters.Where(x => x.Id == 6).ToList() },
                    new ListView {Id = 6, Name = "Neil OR Lisa", ReadOnly = true,
                        Filters = context.Filters.Where(x => x.Id == 7).ToList() },
                });

        }
    }
}