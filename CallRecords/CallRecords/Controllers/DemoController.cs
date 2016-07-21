using NLog;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Collections.Generic;
using CallRecords.Models;

namespace CallRecords.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DemoController : ApiController
    {
        private static Random rnd = new Random();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly string[] FNames = { "Abigail", "Adam", "Adrian", "Alan", "Alexander", "Alexandra", "Alison", "Amanda", "Amelia", "Amy", "Andrea", "Andrew", "Angela", "Anna", "Anne", "Anthony", "Audrey", "Austin", "Ava", "Bella", "Benjamin", "Bernadette", "Blake", "Boris", "Brandon", "Brian", "Cameron", "Carl", "Carol", "Caroline", "Carolyn", "Charles", "Chloe", "Christian", "Christopher", "Claire", "Colin", "Connor", "Dan", "David", "Deirdre", "Diana", "Diane", "Dominic", "Donna", "Dorothy", "Dylan", "Edward", "Elizabeth", "Ella", "Emily", "Emma", "Eric", "Evan", "Faith", "Felicity", "Fiona", "Frank", "Gabrielle", "Gavin", "Gordon", "Grace", "Hannah", "Harry", "Heather", "Ian", "Irene", "Isaac", "Jack", "Jacob", "Jake", "James", "Jan", "Jane", "Jasmine", "Jason", "Jennifer", "Jessica", "Joan", "Joanne", "Joe", "John", "Jonathan", "Joseph", "Joshua", "Julia", "Julian", "Justin", "Karen", "Katherine", "Keith", "Kevin", "Kimberly", "Kylie", "Lauren", "Leah", "Leonard", "Liam", "Lillian", "Lily", "Lisa", "Lucas", "Luke", "Madeleine", "Maria", "Mary", "Matt", "Max", "Megan", "Melanie", "Michael", "Michelle", "Molly", "Natalie", "Nathan", "Neil", "Nicholas", "Nicola", "Oliver", "Olivia", "Owen", "Paul", "Penelope", "Peter", "Phil", "Piers", "Pippa", "Rachel", "Rebecca", "Richard", "Robert", "Rose", "Ruth", "Ryan", "Sally", "Sam", "Samantha", "Sarah", "Sean", "Sebastian", "Simon", "Sonia", "Sophie", "Stephanie", "Stephen", "Steven", "Stewart", "Sue", "Theresa", "Thomas", "Tim", "Tracey", "Trevor", "Una", "Vanessa", "Victor", "Victoria", "Virginia", "Wanda", "Warren", "Wendy", "William", "Yvonne", "Zoe" };
        private readonly string[] LNames = { "Abraham", "Allan", "Alsop", "Anderson", "Arnold", "Avery", "Bailey", "Baker", "Ball", "Bell", "Berry", "Black", "Blake", "Bond", "Bower", "Brown", "Buckland", "Burgess", "Butler", "Cameron", "Campbell", "Carr", "Chapman", "Churchill", "Clark", "Clarkson", "Coleman", "Cornish", "Davidson", "Davies", "Dickens", "Dowd", "Duncan", "Dyer", "Edmunds", "Ellison", "Ferguson", "Fisher", "Forsyth", "Fraser", "Gibson", "Gill", "Glover", "Graham", "Grant", "Gray", "Greene", "Hamilton", "Hardacre", "Harris", "Hart", "Hemmings", "Henderson", "Hill", "Hodges", "Howard", "Hudson", "Hughes", "Hunter", "Ince", "Jackson", "James", "Johnston", "Jones", "Kelly", "Kerr", "King", "Knox", "Lambert", "Langdon", "Lawrence", "Lee", "Lewis", "Lyman", "MacDonald", "Mackay", "Mackenzie", "MacLeod", "Manning", "Marshall", "Martin", "Mathis", "May", "McDonald", "McLean", "McGrath", "Metcalfe", "Miller", "Mills", "Mitchell", "Morgan", "Morrison", "Murray", "Nash", "Newman", "Nolan", "North", "Ogden", "Oliver", "Paige", "Parr", "Parsons", "Paterson", "Payne", "Peake", "Peters", "Piper", "Poole", "Powell", "Pullman", "Quinn", "Rampling", "Randall", "Rees", "Reid", "Roberts", "Robertson", "Ross", "Russell", "Rutherford", "Sanderson", "Scott", "Sharp", "Short", "Simpson", "Skinner", "Slater", "Smith", "Springer", "Stewart", "Sutherland", "Taylor", "Terry", "Thomson", "Tucker", "Turner", "Underwood", "Vance", "Vaughan", "Walker", "Wallace", "Walsh", "Watson", "Welch", "White", "Wilkins", "Wilson", "Wright", "Young" };

        private string RandomName
        {
            get { return FNames[rnd.Next(0, FNames.Length)] + " " + LNames[rnd.Next(0, LNames.Length)]; }
        }

        /// <summary>
        /// Add Demo data to the database (10 random calls will be added)
        /// </summary>
        /// <param name="count">The count of calls to add (default = 10)</param>
        /// <returns>Returns a list of those calls added</returns>        
        public IHttpActionResult Get(int count = 10)
        {
            try
            {
                var calls = new List<Call>();
                using (var context = new DbModel())
                {
                    context.Configuration.AutoDetectChangesEnabled = false;
                    for (int i = 0; i < count; i++)
                    {
                        string name = RandomName;
                        int temp = rnd.Next(28, 45);
                        long randNum = rnd.Next(1112222, 9998888);
                        long randAreaCode = rnd.Next(111, 999);
                        var newCall = new Call
                        {
                            Name = RandomName,
                            PhoneNumber = (randAreaCode * 10000000 + randNum).ToString() ,
                            Duration = temp * rnd.Next(1, 10),                       
                            StartTime = DateTime.Now.AddDays(-rnd.Next(500, (temp - 22) * 300)),
                        };                        
                        context.Calls.Add(newCall);
                        calls.Add(newCall);
                    }
                    context.SaveChanges();
                }
                return Ok(calls);
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }
    }
}
