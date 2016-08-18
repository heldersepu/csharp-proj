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

            for (int i = 0; i < StockHistory.Count - 2; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(StockHistory[i]);

                if (StockHistory[i] > StockHistory[i + 1])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Sell");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Buy");
                }
            }            

            Console.ReadLine();
        }
    }
}
