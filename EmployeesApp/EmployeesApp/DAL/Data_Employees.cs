using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EmployeesApp.Framework.DbSchema;

namespace EmployeesApp.DAL
{
    public partial class Data
    {
        public static List<Employee> Employees
        {
            get
            {
                using (var context = new DbModel<Employee>())
                {
                    return context.All.ToList();
                }
            }
        }

        public static Employee Employee(string id)
        {
            using (var context = new DbModel<Employee>())
            {
                return context.Get(id);
            }
        }

        public static async Task<Employee> AddEmployee(Employee employee)
        {
            using (var context = new DbModel<Employee>())
            {
                if (employee.Dependents == null)
                    employee.Dependents = new List<Dependent>();
                return await context.Add(employee);
            }
        }

        public static async Task<Employee> UpdateEmployee(string id, Employee employee)
        {
            using (var context = new DbModel<Employee>())
            {
                var emp = context.Get(id);
                if (emp == null)
                    return null;
                emp.Name = employee.Name;
                emp.Email = employee.Email;
                emp.Age = employee.Age;
                emp.PaycheckAmount = employee.PaycheckAmount;
                emp.PaychecksPerYear = employee.PaychecksPerYear;
                emp.HireDate = employee.HireDate;
                return await context.Update(emp);
            }
        }

        public static async Task<string> DeleteEmployee(string id)
        {
            using (var context = new DbModel<Employee>())
            {
                return await context.Remove(id);
            }
        }
    }
}