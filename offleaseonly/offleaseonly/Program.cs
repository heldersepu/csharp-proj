using Offleaseonly;
using System;

namespace offleaseonly
{
    class Program
    {
        static void Main(string[] args)
        {

            var offlease = new OffleaseonlyClient();
            foreach (var c in offlease.Cars.Get(1, 0, "cleanCarFax=1"))
            {
                Console.Write(c.Color + " ");
                Console.Write(c.Make + " ");
                Console.Write(c.Model + " ");
                Console.Write(c.Vin + " ");
            }
            Console.Read();

        }
    }
}
