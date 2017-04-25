using Nustache.Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BikeDistributor
{
    /// <summary>
    /// Purchase Order
    /// </summary>
    public class Order
    {
        private const double TaxRate = .0725d;
        private readonly IList<Line> _lines = new List<Line>();

        public Order(string company)
        {
            Company = company;
        }

        public string Company { get; private set; }

        public void AddLine(Line line)
        {
            _lines.Add(line);
        }

        /// <summary>
        /// Create an object with everything we need for a receipt
        /// </summary>
        /// <returns>Return object with all the properties need for the Receipt</returns>
        public object ReceiptData(List<Discount> Discounts)
        {
            var totalAmount = 0d;
            List<object> lines = new List<object>();
            if (_lines.Any())
            {
                foreach (var line in _lines)
                {
                    var thisAmount = line.Cost(Discounts);
                    lines.Add(new
                    {
                        line.Quantity,
                        Brand = line.Bike.Brand,
                        Model = line.Bike.Model,
                        Cost = thisAmount.ToString("C")
                    });
                    totalAmount += thisAmount;
                }
            }
            var tax = totalAmount * TaxRate;

            return new
            {
                Company,
                totalAmount = totalAmount.ToString("C"),
                lines,
                tax = tax.ToString("C"),
                total = (totalAmount + tax).ToString("C")
            };
        }

        /// <summary>
        /// Generate a text receipt
        /// </summary>
        /// <returns>Returns a text receipt</returns>
        public string Receipt(List<Discount> Discounts)
        {
            return Render.StringToString(File.ReadAllText(".\\Templates\\Receipt.txt"), ReceiptData(Discounts));
        }

        /// <summary>
        /// Generate an HTML receipt
        /// </summary>
        /// <returns>Returns a receipt in HTML format</returns>
        public string HtmlReceipt(List<Discount> Discounts)
        {
            return Render.StringToString(File.ReadAllText(".\\Templates\\Receipt.html"), ReceiptData(Discounts));
        }
    }
}
