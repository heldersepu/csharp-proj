using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Newtonsoft_ResolveContract
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(HugeClass);

            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss.fff"));
            Console.WriteLine("Reflection GetProperties");

            var propList = new List<JsonProperty>();
            foreach (var field in type.GetFields())
            {
                propList.Add(new JsonProperty() { PropertyName = field.Name });
            }

            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss.fff"));
            Console.WriteLine("ResolveContract");

            var resolver = new DefaultContractResolver();
            var jsonContract = resolver.ResolveContract(type);

            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss.fff"));
            Console.ReadKey();
        }
    }
}
