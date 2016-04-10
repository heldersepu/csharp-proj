using System.Linq;
using System.Collections.Generic;
using EmployeesApp.Framework.DbSchema;

namespace EmployeesApp.DAL
{
    public partial class Data
    {
        public static IQueryable<Dependent> Dependents
        {
            get
            {
                using (var context = new DbModel())
                {
                    return context.Dependents.AsNoTracking();
                }
            }
        }
       
        public static Dependent AddDependent(int empid, Dependent dependent)
        {
            using (var context = new DbModel())
            {
                var emp = context.Employees.Where(x => x.Id == empid).FirstOrDefault();
                if (emp == null)
                    return null;
                if (emp.Dependents == null)
                    emp.Dependents = new List<Dependent>();
                var depend = new Dependent
                {
                    Name = dependent.Name,
                    Relationship = dependent.Relationship,
                    Age = dependent.Age,
                    Email = dependent.Email
                };
                emp.Dependents.Add(depend);
                context.SaveChanges();
                return depend;
            }
        }

        public static int? DeleteDependent(int id)
        {
            using (var context = new DbModel())
            {
                var dep = context.Dependents.Where(x => x.Id == id).FirstOrDefault();
                if (dep == null)
                    return null;
                context.Dependents.Remove(dep);
                context.SaveChanges();
                return id;
            }
        }
    }
}