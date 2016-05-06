using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonDeserialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = UseNewtonsoft(@"Account.json");
            Console.WriteLine(account.Email);
        }

        static Account UseNewtonsoft(string file)
        {
            string json = File.ReadAllText(file, Encoding.UTF8); ;
            return JsonConvert.DeserializeObject<Account>(json);            
        }
    }

    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
        public Dictionary<int,string> Locations { get; set; }
    }
}
