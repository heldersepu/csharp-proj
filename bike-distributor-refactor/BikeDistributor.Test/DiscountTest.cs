using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace BikeDistributor.Test
{
    [TestClass]
    public class DiscountTest
    {
        [TestMethod]
        public void DiscountNull()
        {
            var line = new Line(Data.Bikes.TrekTF, 1);
            Assert.AreEqual(line.Cost(null), Bike.FiveThousand);
        }

        [TestMethod]
        public void DiscountBlank()
        {
            var disc = new List<Discount> {
                new Discount { Id = 1, Condition = "", Percentage = .5d }
            };
            var line = new Line(Data.Bikes.TrekTF, 1);
            Assert.AreEqual(Bike.FiveThousand, line.Cost(disc));
        }

        [TestMethod]
        public void DiscountBad()
        {
            var disc = new List<Discount> {
                new Discount { Id = 1, Condition = "BAD_DISCOUNT", Percentage = .5d }
            };
            var line = new Line(Data.Bikes.TrekTF, 1);
            Assert.AreEqual(Bike.FiveThousand, line.Cost(disc));
        }

        [TestMethod]
        public void DiscountNegative()
        {
            var disc = new List<Discount> {
                new Discount { Id = 1, Condition = "Bike.Brand == \"Trek\"", Percentage = -.5d }
            };
            var line = new Line(Data.Bikes.TrekTF, 1);
            Assert.AreEqual(Bike.FiveThousand, line.Cost(disc));
        }

        [TestMethod]
        public void DiscountZero()
        {
            var disc = new List<Discount> {
                new Discount { Id = 1, Condition = "Bike.Brand == \"Trek\"", Percentage = 0 }
            };
            var line = new Line(Data.Bikes.TrekTF, 1);
            Assert.AreEqual(Bike.FiveThousand, line.Cost(disc));
        }

        [TestMethod]
        public void DiscountTimeSensitive()
        {
            var disc = new List<Discount> { // 4th JULY SUPER SALE - Trek @ 50% 
                new Discount { Id = 1, Condition = "Bike.Brand == \"Trek\" && DateTimeNow > DateTime(2016, 07, 01) && DateTimeNow < DateTime(2016, 07, 05)", Percentage = .5d }
            };
            var line = new Line(Data.Bikes.TrekTF, 1);
            double expected = Bike.FiveThousand;
            if (DateTime.Now > new DateTime(2016, 07, 01) && DateTime.Now < new DateTime(2016, 07, 05))
                expected *= .5d;
            Assert.AreEqual(expected, line.Cost(disc));
        }

        [TestMethod]
        public void DiscountOneTrekTF()
        {            
            var line = new Line(Data.Bikes.TrekTF, 1);
            Assert.AreEqual(Bike.FiveThousand, line.Cost(Data.Discounts));
        }

        [TestMethod]
        public void DiscountTwentyTrekTF()
        {
            var line = new Line(Data.Bikes.TrekTF, 20);
            Assert.AreEqual(20 * Bike.FiveThousand * .9d, line.Cost(Data.Discounts));
        }

        [TestMethod]
        public void DiscountFiveGiant()
        {
            var line = new Line(Data.Bikes.Defy, 5);
            Assert.AreEqual(5 * Bike.OneThousand * .8d, line.Cost(Data.Discounts));
        }

    }
}


