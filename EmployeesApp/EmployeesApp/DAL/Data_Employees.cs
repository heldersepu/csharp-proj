using System.Linq;
using System.Data.Entity;
using EmployeesApp.Framework.DbSchema;

namespace EmployeesApp.DAL
{
    public partial class Data
    {
        public static IQueryable<Employee> Employees
        {
            get
            {
                using (var context = new DbModel())
                {
                    return context.Employees
                        .AsNoTracking()
                        .Include(x => x.Dependents);
                }
            }
        }

        public static Employee AddEmployee(Employee employee)
        {
            using (var context = new DbModel())
            {
                var emp = new Employee
                {
                    Name = employee.Name,
                    Email = employee.Email,
                    Age = employee.Age,
                    PaycheckAmount = employee.PaycheckAmount,
                    PaychecksPerYear = employee.PaychecksPerYear,
                    HireDate = employee.HireDate
                };
                context.Employees.Add(emp);
                context.SaveChanges();
                return emp;
            }
        }
                
        public static Employee UpdateEmployee(int id, Employee employee)
        {
            using (var context = new DbModel())
            {
                var emp = context.Employees.Where(x => x.Id == id).FirstOrDefault();
                if (emp == null)
                    return null;
                emp.Name = employee.Name;
                emp.Email = employee.Email;
                emp.Age = employee.Age;
                emp.PaycheckAmount = employee.PaycheckAmount;
                emp.PaychecksPerYear = employee.PaychecksPerYear;
                emp.HireDate = employee.HireDate;
                context.SaveChanges();
                return emp;
            }
        }

        public static int? DeleteEmployee(int id)
        {
            using (var context = new DbModel())
            {
                var emp = context.Employees.Where(x => x.Id == id).FirstOrDefault();
                if (emp == null)
                    return null;
                context.Employees.Remove(emp);
                context.SaveChanges();
                return id;
            }
        }
    }
}