namespace BikeDistributor
{
    public class Discount: IObj
    {
        public string id { get; set; }
        public string Condition { get; set; }
        public double Percentage { get; set; }
    }
}
