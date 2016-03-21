using System;
using System.Text;

namespace BenchmarkStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Loops = 10000;
            DateTime sTime;

            for (int j = 1; j <= 10; j++)
            {
                string sDest = "";
                Console.WriteLine();
                Console.WriteLine("Loops = " + Loops * j);

                // string concatenation.
                sTime = DateTime.Now;
                for (int i = 0; i < Loops * j; i++)
                    sDest += RandomLetter.Next();
                Console.WriteLine(" Concatenation: " + sTime.Diff());

                // StringBuilder.
                sTime = DateTime.Now;
                var sb = new StringBuilder();
                for (int i = 0; i < Loops * j; i++)
                    sb.Append(RandomLetter.Next());
                sDest = sb.ToString();
                Console.WriteLine(" StringBuilder: " + sTime.Diff());
            }

            Console.WriteLine();
            Console.Write("Press Enter to finish ... ");
            Console.Read();
        }
    }

    public static class DateTimeExtension
    {
        public static double Diff(this DateTime value)
        {
            return (DateTime.Now - value).TotalMilliseconds;
        }
    }

    public static class RandomLetter
    {
        static Random rnd = new Random();
        public static char Next()
        {
            return (char)('a' + rnd.Next(0, 26));
        }
    }
}
