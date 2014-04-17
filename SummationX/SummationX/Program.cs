using System;
using System.Collections.Generic;
using System.Text;

namespace SummationX
{
    class Program
    {

        static public int SummX1(int max)
        {
            int sum = 0;
            
            for (int i = 0; i <= max; i++)
                if ((i % 3 == 0) || (i % 5 == 0))
                    sum += i;
            
            return sum;
        }

        static public int SummX2(int max)
        {
            int sum = 0;

            for (int i = 0; i <= max; i += 3)
                sum += i;
            for (int i = 0; i <= max; i += 5)
                sum += i;
            for (int i = 0; i <= max; i += 15)
                sum -= i;
            
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Summation of multiples of 3 and 5");
            int max = 10000;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("SummX1 ");
            Console.WriteLine(SummX1(max));

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("SummX2 ");
            Console.WriteLine(SummX2(max));

            Console.ReadLine();
        }
    }
}
