using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleLinq
{
    class Program
    {
        class Person
        {
            public string Fname;
            public string Lname;
            public string Address;
            public string Phone;

            public Person(string name, string lname, string address, string phone)
            {
                this.Fname = name;
                this.Lname = lname;
                this.Address = address;
                this.Phone = phone;
            }

            public override string ToString()
            {
                return this.Fname + " " + this.Lname + " Address:" + this.Address + " Phone:" + this.Phone;
            }
        }

        class People : List<Person>
        {
            /** USE LINQ for the following 2 Methods **/

            public List<Person> Originals()
            {
                /** Return a list of unique based on Fname & Lname **/
                return this;
            }

            public List<Person> Duplicates()
            {
                /** Return a list of duplicates **/
                return this;
            }
        }

        static void Main(string[] args)
        {
            People people = new People() 
            {
                new Person("John", "Doe", "132 Dr",   "305 456 7899"),
                new Person("Jane", "Doe", "546 Road", "786 789 8787"),
                new Person("John", "Doe", "789 Ave",  "954 354 7982")
            };

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("Entire List");            
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Originals");
            foreach (Person person in people.Originals())
            {
                Console.WriteLine(person);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("Duplicates");
            foreach (Person person in people.Duplicates())
            {
                Console.WriteLine(person);
            }

            Console.ReadLine();
        }
    }
}
