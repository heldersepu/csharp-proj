using System;
using System.Diagnostics;
using System.IO;

namespace FileVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                if (File.Exists(arg))
                {
                    try
                    {
                        var versionInfo = FileVersionInfo.GetVersionInfo(arg);
                        Console.WriteLine(versionInfo.ProductVersion);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERROR: " + e.Message);
                    }
                }
            }
        }
    }
}
