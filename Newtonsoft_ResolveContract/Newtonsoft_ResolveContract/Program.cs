using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;

namespace Newtonsoft_ResolveContract
{
    class Program
    {
        static void Main(string[] args)
        {
            CountingLockTest();
            //HugeClassTest();
            Console.ReadKey();
        }

        static void HugeClassTest()
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
        }


        static void CountingLockTest()
        {
            Console.WriteLine("\n Newtonsoft.Json.Serialization.DefaultContractResolver");
            var resolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            WriteProps((JsonObjectContract)resolver.ResolveContract(typeof(CountingLock)));

            Console.WriteLine("\n Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver");
            var r = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            WriteProps((JsonObjectContract)r.ResolveContract(typeof(CountingLock)));

            Console.WriteLine("\n System.Net.Http.Formatting.JsonContractResolver");
            var resolv = new System.Net.Http.Formatting.JsonContractResolver(new Formatter());
            WriteProps((JsonObjectContract)resolv.ResolveContract(typeof(CountingLock)));
        }

        static void WriteProps(JsonObjectContract joc)
        {
            foreach (var prop in joc.Properties)
            {
                Console.WriteLine($"{prop.PropertyName}");
            }
        }
    }

    public class Formatter : MediaTypeFormatter
    {
        public override bool CanReadType(Type type)
        {
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }
    }
}
