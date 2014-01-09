using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geom
{
    class Program
    {
        static string clean_intersections(string polygon)
        {
            return polygon;
        }
        
        static void Main(string[] args)
        {
            Console.BufferHeight = 2400;
            Console.BufferWidth = 120;
            Console.WindowWidth = 120;
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine("");
            Console.WriteLine("  --- geom ---  ");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Press Enter to proceed...");            
            Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.DarkGray;
            foreach (string poly in util.polygons)
            {
                Console.ForegroundColor++;
                string cleanPoly = clean_intersections(poly);
                Console.WriteLine(cleanPoly);
                Console.WriteLine("");
                
            }

            Console.WriteLine("");
            Console.ReadLine();
        }        
    }
}
