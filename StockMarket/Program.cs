using System;
using System.Collections.Generic;

namespace StockMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var StockHistory = new List<int> {
                12, 14, 14, 15, 16, 14, 12, 10, 11, 12, 13, 14, 10, 11, 12, 17
            };

            foreach (var stock in StockHistory)
            {
                Console.WriteLine(stock);
            }

            Console.ReadLine();
        }
    }
}
