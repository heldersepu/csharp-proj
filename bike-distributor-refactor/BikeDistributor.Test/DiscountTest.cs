using Xunit;
using System.Collections.Generic;
using System;
using Microsoft.QualityTools.Testing.Fakes;

namespace BikeDistributor.Test
{
    public class DiscountTest
    {
        [Fact]
        public void DiscountNull()
        {
            var line = new Line(Data.Bikes.TrekTF, 1);
            Assert.Equal(line.Cost(null), Bike.FiveThousand);
        }

        [Fact]
        public void DiscountBlank()
        {
            var disc = new List<Discount> {
                new Discount { Id = 1, Condition = "", Percentage = .5d }
            };
            var line = new Line(Data.Bikes.TrekTF, 1);
            Assert.Equal(Bike.FiveThousand, line.Cost(disc));
        }

        [Fact]
        public void DiscountBad()
        {
            var disc = new List<Discount> {
                new Discount { Id = 1, Condition = "BAD_DISCOUNT", Percentage = .5d }
            };
            var line = new Line(Data.Bikes.TrekTF, 1);
            Assert.Equal(Bike.FiveThousand, line.Cost(disc));
        }

        [Fact]
        public void DiscountNegative()
        {
            var disc = new List<Discount> {
                new Discount { Id = 1, Condition = "Bike.Brand == \"Trek\"", Percentage = -.5d }
            };
            var line = new Line(Data.Bikes.TrekTF, 1);
            Assert.Equal(Bike.FiveThousand, line.Cost(disc));
        }

        [Fact]
        public void DiscountZero()
        {
            var disc = new List<Discount> {
                new Discount { Id = 1, Condition = "Bike.Brand == \"Trek\"", Percentage = 0 }
            };
            var line = new Line(Data.Bikes.TrekTF, 1);
            Assert.Equal(Bike.FiveThousand, line.Cost(disc));
        }

        [Fact]
        public void DiscountTimeSensitive()
        {
            var disc = new List<Discount> { // 4th JULY SUPER SALE - Trek @ 50%
                new Discount { Id = 1, Condition = "Bike.Brand == \"Trek\" && DateTimeNow > DateTime(2015, 07, 01) && DateTimeNow < DateTime(2015, 07, 05)", Percentage = .5d }
            };
            var line = new Line(Data.Bikes.TrekTF, 1);
            double expected = Bike.FiveThousand * .5d;
            Assert.NotEqual(expected, line.Cost(disc));
            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2015, 07, 02);
                Assert.Equal(expected, line.Cost(disc));
            }
        }

        [Fact]
        public void DiscountOneTrekTF()
        {
            var line = new Line(Data.Bikes.TrekTF, 1);
            Assert.Equal(Bike.FiveThousand, line.Cost(Data.Discounts));
        }

        [Fact]
        public void DiscountTwentyTrekTF()
        {
            var line = new Line(Data.Bikes.TrekTF, 20);
            Assert.Equal(20 * Bike.FiveThousand * .9d, line.Cost(Data.Discounts));
        }

        [Fact]
        public void DiscountFiveGiant()
        {
            var line = new Line(Data.Bikes.Defy, 5);
            Assert.Equal(5 * Bike.OneThousand * .8d, line.Cost(Data.Discounts));
        }

    }
}


