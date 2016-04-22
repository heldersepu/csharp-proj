using System;

namespace SampleLinq
{
    class Person
    {
        public string Fname;
        public string Lname;
        public string Address;
        public string Phone;
        public Guid Id;

        public Person(string name, string lname, string address, string phone)
        {
            this.Fname = name;
            this.Lname = lname;
            this.Address = address;
            this.Phone = phone;
            this.Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return this.Fname + " " + this.Lname + " Address:" + this.Address + " Phone:" + this.Phone;
        }
    }
}
