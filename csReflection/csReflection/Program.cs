using System;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WindowHeight = 40;
            
            serverTool.wmi2 wmi = new serverTool.wmi2();
            foreach (MethodInfo objMethod in wmi.GetType().GetMethods())
            {
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.WriteLine(objMethod.Name);
                foreach (ParameterInfo objParameter in objMethod.GetParameters())
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("   " + objParameter.Name);
                }
            }
            Console.ReadKey();
        }
    }
}
