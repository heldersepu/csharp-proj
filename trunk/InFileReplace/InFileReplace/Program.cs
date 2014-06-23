using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace InFileReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() > 2)
            {
                DoReplace(args[0], args[1], args[2]);
            }
            else
            {
                printHelp();
            }
        }

        static void DoReplace(string FileName, string search, string replace)
        {
            if (File.Exists(FileName))
            {
                string readText = File.ReadAllText(FileName);
                File.Delete(FileName);
                Regex rgx = new Regex(search);
                readText = rgx.Replace(readText, replace);
                File.WriteAllText(FileName, readText);
            }
            else
            {
                Console.WriteLine("Given file does not exist!");
            }
        }

        static void printHelp()
        {
            Console.WriteLine("");
            Console.WriteLine("Usage: ");
            Console.WriteLine("InFileReplace [File] [Search Word] [Replacement Word]");
            Console.WriteLine("");
        }
    }
}
