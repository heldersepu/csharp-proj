using System;
using System.IO;

namespace RecRmDir
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                if (Directory.Exists(arg))
                    RecRmDir(arg);
            }
        }

        static void RecRmDir(string directory)
        {
            try
            {
                Directory.Delete(directory);
            }
            catch
            {
                DeleteDirectories(directory);
                DeleteFiles(directory);
            }
        }

        static void DeleteDirectories(string directory)
        {
            try
            {
                foreach (var dir in Directory.EnumerateDirectories(directory))
                {
                    RecRmDir(dir);
                }
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
            }
        }

        static void DeleteFiles(string directory)
        {
            foreach (var file in Directory.EnumerateFiles(directory))
            {
                try
                {
                    File.Delete(file);
                }
                catch { }
            }
        }
    }
}
