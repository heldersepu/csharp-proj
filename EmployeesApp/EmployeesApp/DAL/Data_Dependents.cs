using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EmployeesApp.Framework.DbSchema;

namespace EmployeesApp.DAL
{
    public partial class Data
    {
        public static Dependent Dependent(string empid, string id)
        {
            using (var context = new DbModel<Employee>())
            {
                var emp = context.Get(empid);
                if (emp == null) return null;
                return emp.Dependents.Where(x => x.id == id).FirstOrDefault();
            }
        }

        public static async Task<Employee> AddDependent(string empid, Dependent dependent)
        {
            using (var context = new DbModel<Employee>())
            {
                var emp = context.Get(empid);
                if (emp == null)
                    return null;
                if (emp.Dependents == null)
                    emp.Dependents = new List<Dependent>();
                emp.Dependents.Add(dependent);
                return await context.Update(emp);
            }
        }

        public static async Task<Employee> DeleteDependent(string empid, string id)
        {
            using (var context = new DbModel<Employee>())
            {
                var emp = context.Get(empid);
                if (emp == null) return null;
                var dep = emp.Dependents.Where(x => x.id == id).FirstOrDefault();
                if (dep == null) return null;
                emp.Dependents.Remove(dep);
                return await context.Update(emp);
            }
        }
    }
}