using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
        
        public static string onlyNumbers(string myString)
        {
            return Regex.Replace(myString, "[^0-9]", "");
        }
    }
}
