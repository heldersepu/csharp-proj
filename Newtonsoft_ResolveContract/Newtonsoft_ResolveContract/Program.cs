using Newtonsoft.Json.Serialization;
using System;

namespace Newtonsoft_ResolveContract
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(HugeClass);

            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Reflection GetProperties");

            foreach (var property in type.GetProperties())
            {
                var x = property.Name;
            }

            Console.WriteLine(DateTime.Now);
            Console.WriteLine("ResolveContract");

            var resolver = new DefaultContractResolver();
            JsonContract jsonContract = resolver.ResolveContract(type);            

            Console.WriteLine(DateTime.Now);
            Console.ReadKey();
        }
    }
}
