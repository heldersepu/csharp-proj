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
                    OutputVersion(arg);
                }
                else
                {
                    int pos = arg.LastIndexOf("\\");
                    if (pos > 0)
                    {
                        foreach (var file in Directory.GetFiles(arg.Substring(0,pos), arg.Substring(pos+1)))
                        {
                            OutputVersion(file);
                        }
                    }
                }
            }
        }

        static void OutputVersion(string file)
        {
            try
            {
                var versionInfo = FileVersionInfo.GetVersionInfo(file);
                Console.Write(versionInfo.InternalName);
                Console.Write(" \t");
                Console.WriteLine(versionInfo.ProductVersion);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }
}
