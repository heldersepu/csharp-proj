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
                string filePath = args.GetValue(0).ToString();
                string assemblyullName = Path.GetFullPath(filePath);

                try
                {
                    //required to change directory for loading referenced assemblies
                    Environment.CurrentDirectory = Path.GetDirectoryName(filePath);
                    Assembly assembly = Assembly.LoadFile(assemblyullName);

                    AssemblyInfoLoader aInfo = new AssemblyInfoLoader(assembly);
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (aInfo.JitTrackingEnabled)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(filePath);
                    Console.Write(" : Debug=");
                    Console.Write(aInfo.JitTrackingEnabled);
                    Console.Write(" Optimized=");
                    Console.Write(aInfo.JitOptimized);                        
                }
                catch (Exception ex)
                {
                    //if try to load win32 binary, then it will throw BadImageFormat exception...
                    //which doesn't contain any HResult. So, just search for it.
                    if (ex.Message.Contains(Resource.NotDotNetAssemblyErrorMessage) || ex.Message.Contains("0x80131018"))
                        Console.WriteLine(string.Format(Resource.NotDotNetAssembly, filePath), Resource.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Console.WriteLine(string.Format(Resource.LoadError, ex.Message), Resource.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Console.WriteLine(Resource.UsageString, Resource.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Console.WriteLine(string.Format(Resource.LoadError, e.Exception.Message), Resource.AppName, MessageBoxButtons.OK);
            Application.Exit();
        }
    }
}
