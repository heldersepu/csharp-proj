using System;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ReadJSON
{
    class parseJSON
    {
        public static void reader(string json)
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Token: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(reader.TokenType);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(", Value: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(reader.Value);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Token: {0}", reader.TokenType);
                }
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        public static void dynamic(string json)
        {
            dynamic dJSON = JsonConvert.DeserializeObject(json);
            if (dJSON.Type == JTokenType.Array)
            {
                foreach (dynamic jNode in dJSON)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Name: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(jNode.name);
                }
            }

        }

    }
}
