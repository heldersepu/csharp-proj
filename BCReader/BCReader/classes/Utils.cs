using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BCReader
{
    class Utils
    {
        public static void doSleep()
        {
            string[] chrs = { "\\", "|", "/", "*" };
            for (int i = 0; i < 60; i++)
            {
                foreach (string chr in chrs)
                {
                    Console.Write(chr);
                    Thread.Sleep(10);
                    Console.Write((char)8);
                }
                Console.Write(".");
                Thread.Sleep(5);
            }
            Console.WriteLine("");
        }
    }
}
