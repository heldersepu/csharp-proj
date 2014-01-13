using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace geom
{
    class Program
    {
        
        static string clean_intersections(string polygon)
        {
            string[] splitted = polygon.Split(new char[] { ')' });
            polygon = "";
            for(int i = 0; i < splitted.Length - 1; i++)
            {
                if (splitted[i] != "")
                {
                    splitted[i] = cleanCoordinates(splitted[i]);
                    polygon += splitted[i] + ")";
                }
                else
                    polygon += splitted[i] + ")";
            }
                return polygon;
        }

        private static string cleanCoordinates(string poly)
        {
            Dictionary<int, string> scondSplit = new Dictionary<int, string>();
            
            //CLEANING STRING FROM NON-COORDINATES CHARACTERS
            int pos = poly.LastIndexOf('(') + 1;
            string firstHalf = poly.Substring(0, pos);
            string secondHalf = poly.Substring(pos);
            poly = secondHalf.Replace(", ", "|");
            string[] array = poly.Split(new char[] { '|' }); 
                        
            if(array[0] == array[array.Length - 1])
            {
                //ADD UNIQUE ITEMS TO THE DICTIONARY
                for(int i=0; i < array.Length; i++)
                {
                    if (scondSplit.Where(x => x.Value == array[i]).Count() == 0)
                        scondSplit.Add(i, array[i]);
                }
                scondSplit.Add(array.Length-1, array[array.Length-1]);

                //CONCATENATION OF POLY
                poly = firstHalf;
                foreach(var pair in scondSplit)
                {                                    
                    poly += pair.Value + ", ";
                }

                return poly.Substring(0,poly.Length -2);
            }
            else
                return "Invalid Polygon";
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
