using System;
using Newtonsoft.Json;

namespace EmployeesApp.Framework.DbSchema
{
    public class Dependent : IObj, IPerson
    {
        public Dependent()
        {
            id = Guid.NewGuid().ToString();
        }

        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        
        public string Name { get; set; }
        
        public string Relationship { get; set; }
        
        public string Email { get; set; }
        
        public int? Age { get; set; }
    }
}