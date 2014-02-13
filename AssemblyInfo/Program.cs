using System;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace AssemblyInfo
{
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            Application.ThreadException += ApplicationThreadException;
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainTypeResolve;
            
            if (args.Length == 1)
            {
                if (File.Exists(args[0]))
                    doFile(args[0]);
                else if (Directory.Exists(args[0]))
                {
                    foreach (string strFile in Directory.GetFiles(args[0]))
                        if (strFile.Substring(strFile.Length -4).ToLower() == ".dll")
                            doFile(strFile);
                }
            }
            else
            {
                Console.WriteLine(Resource.UsageString);
                Console.ReadLine();
            }
        }

        static void doFile(string filePath)
        {
            string assemblyullName = Path.GetFullPath(filePath);

            try
            {
                //required to change directory for loading referenced assemblies
                Environment.CurrentDirectory = Path.GetDirectoryName(filePath);
                Assembly assembly = Assembly.LoadFile(assemblyullName);

                AssemblyInfoLoader aInfo = new AssemblyInfoLoader(assembly);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(filePath);

                Console.ForegroundColor = ConsoleColor.Green;
                if (aInfo.JitTrackingEnabled)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" : Debug=");
                Console.Write(aInfo.JitTrackingEnabled);

                Console.ForegroundColor = ConsoleColor.Green;
                if (!aInfo.JitOptimized)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Optimized=");
                Console.WriteLine(aInfo.JitOptimized);

                Console.ForegroundColor = ConsoleColor.Green;
            }
            catch (Exception ex)
            {
                //if try to load win32 binary, then it will throw BadImageFormat exception...
                //which doesn't contain any HResult. So, just search for it.
                if (ex.Message.Contains(Resource.NotDotNetAssemblyErrorMessage) || ex.Message.Contains("0x80131018"))
                    Console.WriteLine(string.Format(Resource.NotDotNetAssembly, filePath));
                else
                    Console.WriteLine(string.Format(Resource.LoadError, ex.Message));
            }
        }

        static Assembly CurrentDomainTypeResolve(object sender, ResolveEventArgs args)
        {
            if (null != args && !String.IsNullOrEmpty(args.Name))
            {
                string[] parts = args.Name.Split(',');
                if (parts.Length > 0)
                {
                    string name = parts[0] + ".dll";
                    if (File.Exists(name))
                    {
                        try
                        {
                            return Assembly.LoadFile((new FileInfo(name)).FullName);
                        }
                        catch (ArgumentException) { }
                        catch (IOException) { }
                        catch (BadImageFormatException) { }
                    }
                }
            }
            return null;
        }

        static void ApplicationThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Console.WriteLine(string.Format(Resource.LoadError, e.Exception.Message));
            Application.Exit();
        }
    }
}
