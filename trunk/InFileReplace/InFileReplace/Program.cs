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
                try
                {                    
                    string readText = File.ReadAllText(FileName);
                    string newText = readText;                    
                    try
                    {
                        Regex rgx = new Regex(search);
                        newText = rgx.Replace(readText, replace);
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bad Regex replacement!");
                        Console.WriteLine(e.Message);
                        newText = readText;
                    }
                    if (newText != readText)
                    {
                        File.Delete(FileName);
                        File.WriteAllText(FileName, newText);
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} Exception caught.", e);
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
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
