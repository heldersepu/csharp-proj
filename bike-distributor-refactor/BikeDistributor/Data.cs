using System.Collections.Generic;

namespace BikeDistributor
{
    /// <summary>
    /// All data, at some point this data should be retreived from a DB
    /// </summary>
    public struct Data
    {
        public struct Bikes
        {
            public readonly static Bike Defy = new Bike("Giant", "Defy 1", Bike.OneThousand);
            public readonly static Bike Elite = new Bike("Specialized", "Venge Elite", Bike.TwoThousand);
            public readonly static Bike DuraAce = new Bike("Specialized", "S-Works Venge Dura-Ace", Bike.FiveThousand);
            public readonly static Bike TrekTF = new Bike("Trek", "Top Fuel", Bike.FiveThousand);
        }

        public readonly static List<Discount> Discounts = new List<Discount>
        {
            new Discount { Id = 1, Condition = "Bike.Price == 5000 && Quantity >= 20", Percentage = .9d },
            new Discount { Id = 2, Condition = "Bike.Price == 2000 && Quantity >= 10", Percentage = .8d },
            new Discount { Id = 3, Condition = "Bike.Price == 1000 && Quantity >= 5", Percentage = .8d },
        };
    }
}
