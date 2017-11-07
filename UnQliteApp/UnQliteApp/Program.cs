using System;
using System.Data.Unqlite;

namespace UnQliteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new UnqliteDB("unqlite.db"))
            {
                var session =  db.OpenSession();
                for (int i = 100; i < 105; i++)
                    session.Save($"key{i}", $"data {i}.{i}");

                for (int i = 100; i < 105; i++)
                    Console.WriteLine($"key{i} = " + session.Get($"key{i}"));
            }
            Console.ReadKey();
        }
    }
}
