using EmployeesApp.Framework.Interfaces;
using EmployeesApp.Framework.DbSchema;
using System.Collections.Generic;

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
                amount = cost.Employee * (1 - Discount(employee.Name));
                if (employee.Dependents != null)
                {
                    foreach (var dependent in employee.Dependents)
                    {
                        amount += cost.Dependent * (1 - Discount(dependent.Name));
                    }
                }
            }
            return amount;
        }

        /// <summary>
        /// Logic for the Benefits discount
        /// </summary>
        /// <param name="name">Name of person (Employee or Dependent)</param>
        /// <returns>Returns discount percentage</returns>
        public double Discount(string name)
        {
            double percentage = 0;
            if (!string.IsNullOrEmpty(name))
            {
                foreach (var discount in discounts)
                {
                    switch (discount.Type)
                    {
                        case "StartsWith":
                            percentage = (name.StartsWith(discount.Value)) ? discount.Percentage : 0;
                            break;
                        case "EndsWith":
                            percentage = (name.EndsWith(discount.Value)) ? discount.Percentage : 0;
                            break;
                        case "Equals":
                            percentage = (name.Equals(discount.Value)) ? discount.Percentage : 0;
                            break;
                    }
                }
            }
            return percentage;
        }
    }
}
