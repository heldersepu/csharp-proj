using System;

namespace ASCII
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 500; i++)
            {
                Console.Write(i);
                Console.Write(" ");
                Console.WriteLine((char)i);
            }
            Console.Read();
        }
    }
}
