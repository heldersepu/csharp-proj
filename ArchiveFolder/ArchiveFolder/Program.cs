using System;

using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() > 0)
            {
                DoArchive(args[0]);
            }
            else
            {
                printHelp();
            }
        }

        static void DoArchive(string DirPath)
        {
            try
            {
                foreach (string folder in Directory.GetDirectories(DirPath))
                {
                    DoMove(DirPath, folder);
                }                
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} Exception caught.", e);
                Console.WriteLine(e.Message);
            }
        }

        static void DoMove(string DirPath, string folder)
        {
            int n;
            string dirname = folder.Replace(DirPath, "");
            dirname = dirname.Trim('\\');
            if (int.TryParse(dirname.Substring(0,1), out n))
            {
                if (!Directory.Exists(DirPath + "\\Archive"))
                {
                    Directory.CreateDirectory(DirPath + "\\Archive");
                }
                Directory.Move(folder, DirPath + "\\Archive\\" + dirname);
            }
        }

        static void printHelp()
        {
            Console.WriteLine("");
            Console.WriteLine("Usage: ");
            Console.WriteLine("ArchiveFolder DirectoryPath");
            Console.WriteLine("");
        }
    }
}
