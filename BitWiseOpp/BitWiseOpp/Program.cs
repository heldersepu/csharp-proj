using System;

namespace BitWiseOpp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            foreach (var arg in args)
            {
                if (int.TryParse(arg, out n))
                {
                    Console.Write(n);
                    Console.Write(" = ");
                    Console.WriteLine(CountBits(n));
                }
            }
            Console.Read();
        }

        static int CountBits(int value)
        {
            int count = 0;
            int bit = 1;
            for (int i = 0; i < 8; i++)
            {
                if ((bit & value) == bit)
                    count++;
                bit <<= 1;
            }
            return count;
        }
    }
}
