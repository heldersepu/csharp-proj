using EmployeesApp.Models;
using EmployeesApp.Controllers;

namespace EmployeesApp.BussinessLogic
{
    /// <summary>
    /// Business logic for the deductions
    /// </summary>
    public class Deduction
    {
        /// <summary>
        /// Logic for the Benefits deduction
        /// </summary>
        /// <param name="employee">Employee cheking for deductions</param>
        /// <returns>Returns yearly deduction amount</returns>
        public static double Benefits(Employee employee)
        {
            double amount = 0;
            var cost = new BenefitsCostController().Get();
            if (cost != null)
            {
                amount = cost.Employee * (1 - Discount.Benefits(employee.Name));
                foreach (var dependent in employee.Dependents)
                {
                    amount += cost.Dependent * (1 - Discount.Benefits(dependent.Name));
                }
            }
            return amount;
        }
    }
}