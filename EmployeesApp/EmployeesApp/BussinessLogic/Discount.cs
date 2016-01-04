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
        /// <param name="Name">Name of person cheking for discounts</param>
        /// <returns>Returns discount percentage</returns>
        public static double Benefits(string Name)
        {
            double percentage = 0;
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
            return percentage;
        }
    }
}