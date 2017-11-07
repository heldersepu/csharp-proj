using System;
using UnQLiteNet;

namespace UnQliteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UnQLite unqlite = new UnQLite("test.db", UnQLiteOpenModel.Create | UnQLiteOpenModel.ReadWrite);
            for (int i = 100; i < 105; i++)
            {
                using (var t = unqlite.BeginTransaction())
                {
                    unqlite.Save($"key{i}", $"data {i} {i}");
                }
            }
            for (int i = 100; i < 105; i++)
            {
                string value = unqlite.Get($"key{i}");
                Console.WriteLine(value);
            }
            Console.ReadKey();
        }
    }
}
