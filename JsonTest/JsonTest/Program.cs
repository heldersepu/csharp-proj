using Newtonsoft.Json.Serialization;

namespace JsonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new DefaultContractResolver
            {
                IgnoreSerializableAttribute = false,
                IgnoreSerializableInterface = false,
                //IgnoreIsSpecifiedmembers = false
            };
        }
    }
}
