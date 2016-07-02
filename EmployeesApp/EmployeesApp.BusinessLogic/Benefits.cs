using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
using EmployeesApp.Framework.Interfaces;
using EmployeesApp.Framework.DbSchema;

namespace EmployeesApp.BusinessLogic
{
    /// <summary>
    /// Business logic for the Benefits
    /// </summary>
    public class Benefits : IBenefits
    {
        BenefitsCost cost;
        List<BenefitsDiscount> discounts;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Cost">Cost of benefits</param>
        /// <param name="Discounts">List of Benefits Discount</param>
        public Benefits(BenefitsCost Cost, List<BenefitsDiscount> Discounts)
        {
            cost = Cost;
            discounts = Discounts;
        }

        /// <summary>
        /// Logic for the Benefits deduction
        /// </summary>
        /// <param name="employee">Employee cheking for deductions</param>
        /// <returns>Returns yearly deduction amount</returns>
        public double Deduction(Employee employee)
        {
            double amount = 0;
            if (cost != null)
            {
                amount = cost.Employee * (1 - Discount(employee));
                if (employee.Dependents != null)
                {
                    foreach (var dependent in employee.Dependents)
                    {
                        amount += cost.Dependent * (1 - Discount(dependent));
                    }
                }
            }
            return amount;
        }

        /// <summary>
        /// Logic for the Benefits discount
        /// </summary>
        /// <param name="person">The Person (Employee or Dependent)</param>
        /// <returns>Returns discount percentage</returns>
        public double Discount(IPerson person)
        {
            double percentage = 0;
            if (person != null)
            {
                var p = new List<IPerson> { person };
                foreach (var d in discounts)
                {
                    try
                    {
                        if (p.Where(d.Predicate).Any())
                            return d.Percentage;
                    }
                    catch { }
                }
            }
            return percentage;
        }
    }
}
