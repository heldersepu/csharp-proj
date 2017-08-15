using ContractPlugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PluginSystem
{
    public class Program
    {
        const string DIR = "..\\..\\..";

        static void Main(string[] args)
        {
            var dllFiles = Directory.GetFiles(DIR, "Plugin*.DLL", SearchOption.AllDirectories);
            var plugins = new HashSet<Assembly>();

            var references = typeof(Program).Assembly.GetReferencedAssemblies();
            foreach (var dllPath in dllFiles.Where(x => new Regex(@"\d+").Match(x).Success))
            {
                string name = Path.GetFileNameWithoutExtension(dllPath);
                if (!references.Any(x => x.Name == name) && !plugins.Any(x => x.GetName().Name == name))
                    plugins.Add(Assembly.LoadFrom(dllPath));
            }


            foreach (var plugin in plugins.OrderBy(x => x.GetName().Name))
                WriteData(plugin);
            Console.WriteLine("");

            foreach (var plugin in plugins.OrderByDescending(x => x.GetName().Name))
                WriteData(plugin);
            Console.ReadKey();
        }

        public static void WriteData(Assembly plugin)
        {
            var type = plugin.GetExportedTypes().Single();
            var res = typeof(Contract).IsAssignableFrom(type);
            if (res)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"IsAssignableFrom = {res}  \t{plugin.GetName().Name} ");
        }
    }
}
