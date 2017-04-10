using Offleaseonly;
using Offleaseonly.Models;
using System;
using System.Collections.Generic;

namespace offleaseonly
{
    class Program
    {
        static void Main(string[] args)
        {

            var offlease = new OffleaseonlyClient();
            IList<Car> cars = null;

            try
            {
                cars = offlease.Cars.Get(1, 0, "cleanCarFax=1");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }

            if (cars != null)
            {
                foreach (var c in cars)
                {
                    Console.Write(c.Color + " ");
                    Console.Write(c.Make + " ");
                    Console.Write(c.Model + " ");
                    Console.Write(c.Vin + " ");
                }
            }

            Console.Read();

        }
    }
}
