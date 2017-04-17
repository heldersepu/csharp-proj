using Xunit;
using System;

namespace BikeDistributor.Test
{
    public class OrderTest
    {
        Order order;
        public OrderTest()
        {
            order = new Order("Anywhere Bike Shop");
        }

        [Fact]
        public void ReceiptOneDefy()
        {
            string ResultStatementOneDefy = @"Order Receipt for Anywhere Bike Shop 	1 x Giant Defy 1 = $1,000.00 Sub-Total: $1,000.00 Tax: $72.50 Total: $1,072.50";
            order.AddLine(new Line(Data.Bikes.Defy, 1));
            Assert.Equal(ResultStatementOneDefy, order.Receipt().Replace(Environment.NewLine, " "));
        }

        [Fact]
        public void ReceiptOneElite()
        {
            string ResultStatementOneElite = @"Order Receipt for Anywhere Bike Shop 	1 x Specialized Venge Elite = $2,000.00 Sub-Total: $2,000.00 Tax: $145.00 Total: $2,145.00";
            order.AddLine(new Line(Data.Bikes.Elite, 1));
            Assert.Equal(ResultStatementOneElite, order.Receipt().Replace(Environment.NewLine, " "));
        }

        [Fact]
        public void ReceiptOneDuraAce()
        {
            string ResultStatementOneDuraAce = @"Order Receipt for Anywhere Bike Shop 	1 x Specialized S-Works Venge Dura-Ace = $5,000.00 Sub-Total: $5,000.00 Tax: $362.50 Total: $5,362.50";
            order.AddLine(new Line(Data.Bikes.DuraAce, 1));
            Assert.Equal(ResultStatementOneDuraAce, order.Receipt().Replace(Environment.NewLine, " "));
        }

        [Fact]
        public void HtmlReceiptOneDefy()
        {
            string HtmlResultStatementOneDefy = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Giant Defy 1 = $1,000.00</li></ul><h3>Sub-Total: $1,000.00</h3><h3>Tax: $72.50</h3><h2>Total: $1,072.50</h2></body></html>";
            order.AddLine(new Line(Data.Bikes.Defy, 1));
            Assert.Equal(HtmlResultStatementOneDefy, order.HtmlReceipt().Replace(Environment.NewLine, ""));
        }

        [Fact]
        public void HtmlReceiptOneElite()
        {
            string HtmlResultStatementOneElite = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized Venge Elite = $2,000.00</li></ul><h3>Sub-Total: $2,000.00</h3><h3>Tax: $145.00</h3><h2>Total: $2,145.00</h2></body></html>";
            order.AddLine(new Line(Data.Bikes.Elite, 1));
            Assert.Equal(HtmlResultStatementOneElite, order.HtmlReceipt().Replace(Environment.NewLine, ""));
        }

        [Fact]
        public void HtmlReceiptOneDuraAce()
        {
            string HtmlResultStatementOneDuraAce = @"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized S-Works Venge Dura-Ace = $5,000.00</li></ul><h3>Sub-Total: $5,000.00</h3><h3>Tax: $362.50</h3><h2>Total: $5,362.50</h2></body></html>";
            order.AddLine(new Line(Data.Bikes.DuraAce, 1));
            Assert.Equal(HtmlResultStatementOneDuraAce, order.HtmlReceipt().Replace(Environment.NewLine, ""));
        }
    }
}


