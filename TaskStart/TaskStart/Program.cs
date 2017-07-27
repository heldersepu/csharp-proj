using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            new Task(DoLoop).Start();
            Console.ReadKey();
        }

        static void DoLoop()
        {
            string chars = "-\\|/-.oO0Oo.";
            Console.Write("  ");
            while (1 == 1)
            {
                foreach (char chr in chars)
                {
                    Console.Write(chr);
                    Thread.Sleep(100);
                    Console.Write((char)8);
                }
            }
        }
    }
}
