using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Socrates.Models
{
    public class SocratesContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructor { get; set; }

        public SocratesContext(string connStr) : base(connStr) { }
    }

    
}