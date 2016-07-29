using System;

namespace HighAndLow
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "4 5 29 54 4 0 -214 542 -64 1 -3 6 -6";
            var r = new Random();
            for (var x = 1; x < 50; x++)
                test += " " + r.Next(-500, 500);
            const int loops = 100000;
            DateTime sTime;

            for (var x = 1; x < 10; x++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                sTime = DateTime.Now;
                for (var i = 1; i < loops; i++)
                    Kata.HighAndLow1(test);
                Console.Write(" Test1: " + sTime.Diff());
                Console.Write("\t");

                Console.ForegroundColor = ConsoleColor.Cyan;
                sTime = DateTime.Now;
                for (var i = 1; i < loops; i++)
                    Kata.HighAndLow2(test);
                Console.Write(" Test2: " + sTime.Diff());

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write("Press Enter to continue ... ");
            Console.Read();
        }

        
    }
}
