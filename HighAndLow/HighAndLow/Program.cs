using System;
using System.Linq;

namespace HighAndLow
{
    class Program
    {
        static void Main(string[] args)
        {
            const string test = "4 5 29 54 4 0 -214 542 -64 1 -3 6 -6";
            const int loops = 100000;
            DateTime sTime;

            for (var x = 1; x < 10; x++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                sTime = DateTime.Now;
                for (var i = 1; i < loops; i++)
                    HighAndLow1(test);
                Console.Write(" Test1: " + sTime.Diff());
                Console.Write("\t");

                Console.ForegroundColor = ConsoleColor.Cyan;
                sTime = DateTime.Now;
                for (var i = 1; i < loops; i++)
                    HighAndLow2(test);
                Console.Write(" Test2: " + sTime.Diff());

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write("Press Enter to continue ... ");
            Console.Read();
        }

        public static string HighAndLow1(string numbers)
        {
            var parsed = numbers.Split().Select(int.Parse);
            return parsed.Max() + " " + parsed.Min();
        }

        public static string HighAndLow2(string numbers)
        {
            int max, min;
            var arrNum = numbers.Split();
            max = min = int.Parse(arrNum[0]);
            for (var i = 1; i < arrNum.Length; i++)
            {
                int num = int.Parse(arrNum[i]);
                if (num > max)
                    max = num;
                else if (num < min)
                    min = num;
            }
            return max.ToString() + " " + min.ToString();
        }
    }

    public static class DateTimeExtension
    {
        public static double Diff(this DateTime value)
        {
            return Math.Round((DateTime.Now - value).TotalMilliseconds);
        }
    }
}
