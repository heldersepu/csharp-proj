using EmployeesApp.Controllers;

namespace EmployeesApp.BussinessLogic
{
    /// <summary>
    /// Business logic for the discounts
    /// </summary>
    public class Discount
    {
        /// <summary>
        /// Logic for the Benefits discount
        /// </summary>
        /// <param name="Name">Name of person (Employee or Dependent)</param>
        /// <returns>Returns discount percentage</returns>
        public static double Benefits(string Name)
        {
            double percentage = 0;
            if (!string.IsNullOrEmpty(Name))
            {
                var Discounts = new BenefitsDiscountsController().Get();
                foreach (var discount in Discounts)
                {
                    switch (discount.Type)
                    {
                        case "StartsWith":
                            percentage = (Name.StartsWith(discount.Value)) ? discount.Percentage : 0;
                            break;
                        case "EndsWith":
                            percentage = (Name.EndsWith(discount.Value)) ? discount.Percentage : 0;
                            break;
                        case "Equals":
                            percentage = (Name.Equals(discount.Value)) ? discount.Percentage : 0;
                            break;
                    }
                }
            }
            return percentage;
        }
    }
}