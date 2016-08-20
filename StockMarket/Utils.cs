using System;
using System.Collections.Generic;

namespace StockMarket
{
    public class Utils
    {
        public static List<int> RandomStock
        {
            get
            {
                int next;
                var r = new Random();
                var stock = new List<int> { r.Next(7, 19) };
                for (int i = 0; i < 70; i++)
                {
                    do
                    {
                        next = stock[stock.Count - 1] + r.Next(-1, 2);
                    } while (next > 18 || next < 7);
                    stock.Add(next);
                }
                return stock;
            }
        }

        public static void WriteChart(int x, int y, int next)
        {
            Console.CursorTop = 20 - y;
            Console.CursorLeft = x;
            char c = '=';
            if (y > next)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                c = '\\';
            }
            else if (next > y)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                c = '/';
            }
            Console.Write(c);
        }

        public static void WriteResult(StockDelta stockDelta)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorTop = 21 - stockDelta.start.value;
            for (int i = stockDelta.start.position; i <= stockDelta.end.position; i++)
            {                
                Console.CursorLeft = i;
                Console.CursorTop = 21 - stockDelta.start.value;
                Console.Write((char)9604);
                Console.CursorLeft = i;
                Console.CursorTop = 19 - stockDelta.end.value;
                Console.Write((char)9600);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorTop = 18;
            Console.CursorLeft = 0;           
            Console.WriteLine(" Result");
            Console.WriteLine(stockDelta.ToString());
            Console.ReadLine();
            Console.Clear();
        }


    }
}
