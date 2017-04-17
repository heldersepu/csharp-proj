using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System;
using NLog;

namespace BikeDistributor
{
    /// <summary>
    /// A bicycle line
    /// </summary>
    public class Line
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Line(Bike bike, int quantity)
        {
            Bike = bike;
            Quantity = quantity;
        }

        public Bike Bike { get; private set; }
        public int Quantity { get; private set; }
        public DateTime DateTimeNow
        {
            get { return DateTime.Now; }
        }

        /// <summary>
        /// Calculate the cost for the entire line
        /// </summary>
        /// <param name="discounts">list of discounts</param>
        /// <returns>Returns total cost for the line</returns>
        public double Cost(List<Discount> discounts)
        {
            double thisAmount = Quantity * Bike.Price;
            if (discounts != null)
            {
                var obj = new List<Line> { this };
                foreach (var discount in discounts.OrderBy(x => x.Id))
                {
                    try
                    {
                        if (discount.Percentage > 0
                            && !string.IsNullOrEmpty(discount.Condition)
                            && obj.Where(discount.Condition).Any())
                        {
                            thisAmount *= discount.Percentage;
                            break;
                        }
                    }
                    catch (System.Exception e)
                    {
                        logger.Error(e);
                    }
                }
            }
            return thisAmount;
        }
    }
}
