using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeDistributor
{
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

        public string Receipt()
        {
            var totalAmount = 0d;
            var result = new StringBuilder(string.Format("Order Receipt for {0}{1}", Company, Environment.NewLine));
            foreach (var line in _lines)
            {
                var thisAmount = 0d;
                switch (line.Bike.Price)
                {
                    case Bike.OneThousand:
                        if (line.Quantity >= 20)
                            thisAmount += line.Quantity * line.Bike.Price * .9d;
                        else
                            thisAmount += line.Quantity * line.Bike.Price;
                        break;
                    case Bike.TwoThousand:
                        if (line.Quantity >= 10)
                            thisAmount += line.Quantity * line.Bike.Price * .8d;
                        else
                            thisAmount += line.Quantity * line.Bike.Price;
                        break;
                    case Bike.FiveThousand:
                        if (line.Quantity >= 5)
                            thisAmount += line.Quantity * line.Bike.Price * .8d;
                        else
                            thisAmount += line.Quantity * line.Bike.Price;
                        break;
                }
                result.AppendLine(string.Format("\t{0} x {1} {2} = {3}", line.Quantity, line.Bike.Brand, line.Bike.Model, thisAmount.ToString("C")));
                totalAmount += thisAmount;
            }
            result.AppendLine(string.Format("Sub-Total: {0}", totalAmount.ToString("C")));
            var tax = totalAmount * TaxRate;
            result.AppendLine(string.Format("Tax: {0}", tax.ToString("C")));
            result.Append(string.Format("Total: {0}", (totalAmount + tax).ToString("C")));
            return result.ToString();
        }

        public string HtmlReceipt()
        {
            var totalAmount = 0d;
            var result = new StringBuilder(string.Format("<html><body><h1>Order Receipt for {0}</h1>", Company));
            if (_lines.Any())
            {
                result.Append("<ul>");
                foreach (var line in _lines)
                {
                    var thisAmount = 0d;
                    switch (line.Bike.Price)
                    {
                        case Bike.OneThousand:
                            if (line.Quantity >= 20)
                                thisAmount += line.Quantity*line.Bike.Price*.9d;
                            else
                                thisAmount += line.Quantity*line.Bike.Price;
                            break;
                        case Bike.TwoThousand:
                            if (line.Quantity >= 10)
                                thisAmount += line.Quantity*line.Bike.Price*.8d;
                            else
                                thisAmount += line.Quantity*line.Bike.Price;
                            break;
                        case Bike.FiveThousand:
                            if (line.Quantity >= 5)
                                thisAmount += line.Quantity*line.Bike.Price*.8d;
                            else
                                thisAmount += line.Quantity*line.Bike.Price;
                            break;
                    }
                    result.Append(string.Format("<li>{0} x {1} {2} = {3}</li>", line.Quantity, line.Bike.Brand, line.Bike.Model, thisAmount.ToString("C")));
                    totalAmount += thisAmount;
                }
                result.Append("</ul>");
            }
            result.Append(string.Format("<h3>Sub-Total: {0}</h3>", totalAmount.ToString("C")));
            var tax = totalAmount * TaxRate;
            result.Append(string.Format("<h3>Tax: {0}</h3>", tax.ToString("C")));
            result.Append(string.Format("<h2>Total: {0}</h2>", (totalAmount + tax).ToString("C")));
            result.Append("</body></html>");
            return result.ToString();
        }

    }
}
