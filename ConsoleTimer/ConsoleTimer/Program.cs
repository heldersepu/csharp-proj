using System;
using System.Threading;
namespace ConsoleTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            showTimer(5);
            showTimer(110);
        }

        static void showTimer(double TimeInSec)
        {
            Console.Write("          ");
            string outPut = TimeInSec.ToString("F");
            int max = outPut.Length;
            string backSpace = new String(Convert.ToChar(8), max);
            while (TimeInSec > 0)
            {
                Console.Write(backSpace);
                outPut = TimeInSec.ToString("F");
                Console.Write(new String(' ', max - outPut.Length));
                Console.Write(outPut);
                TimeInSec -= 0.01;
                Thread.Sleep(10);                
            }
            Console.Write(backSpace);
            Console.WriteLine("0.00");
        }
    }
}
