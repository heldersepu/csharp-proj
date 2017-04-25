using System;

namespace BikeDistributor
{
    /// <summary>
    /// Everything about the bicycles
    /// </summary>
    public class Bike : IObj
    {
        public const int OneThousand = 1000;
        public const int TwoThousand = 2000;
        public const int FiveThousand = 5000;

        public Bike(string id, string brand, string model, int price)
        {
            this.id = id;
            Brand = brand;
            Model = model;
            Price = price;
        }

        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Price { get; set; }
        public string id { get; set; }
    }
}
