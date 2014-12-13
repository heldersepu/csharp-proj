using System;

namespace SampleLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            People people = new People() 
            {
                new Person("John", "Doe",  "132 Dr",    "305 456 7899"),
                new Person("Jane", "Doe",  "546 Road",  "786 789 8787"),
                new Person("John", "Doe",  "789 Ave",   "954 354 7982"),
                new Person("Jack", "Doe",  "467 St",    "954 342 7111"),
                new Person("John", "Deer", "123 Blvd",  "542 234 7982"),
            };

            Console.ForegroundColor = ConsoleColor.White;
            showList("  Entire List", people);

            Console.ForegroundColor = ConsoleColor.Green;
            showList("  Originals", people.Originals());
            
            Console.ForegroundColor = ConsoleColor.Red;
            showList("  Duplicates", people.Duplicates());

            Console.WriteLine("");
            Console.ReadLine();
        }

        static void showList(string message, People people)
        {            
            Console.WriteLine("");
            Console.WriteLine(message);
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
