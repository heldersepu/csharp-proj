using System;
using System.Data.Unqlite;

namespace UnQliteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = new UnqliteDB("unqlite.db").OpenSession())
            {
                for (int i = 100; i < 105; i++)
                    session.Save($"key{i}", Data.SampleParent(i));

                for (int i = 100; i < 105; i++)
                {
                    var parent = session.Get<Parent>($"key{i}");
                    Console.WriteLine($"Parent.Id= " + parent.Id);
                    foreach (var child in parent.Children)
                    {
                        Console.WriteLine($"   Child.Id= " + child.Id);
                        Console.WriteLine($"   Child.Data= " + child.Data);
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
