using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleList
{
    class Program
    {
        static void Main(string[] args)
        {
            myList abc = new myList()
            {
                new node("d", 8),
                new node("a", 2),
                new node("c", 6),
                new node("b", 4)
            };

            foreach (node n in abc)
            {
                Console.Write("  ");
                Console.Write(n.name);
                Console.Write(" = ");
                Console.Write(n.value);
                Console.WriteLine("");
            }
            Console.ReadLine();
        }

        class myList : List<node>
        {
            /** Add your code here **/
        }

        class node
        {
            public node(string n, int v)
            {
                name = n;
                value = v;
            }
            public string name;
            public int value;
        }
    }
}
