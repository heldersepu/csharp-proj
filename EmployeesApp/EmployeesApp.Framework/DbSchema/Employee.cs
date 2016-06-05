using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmployeesApp.Framework.DbSchema
{
    public class Employee : IObj, IPerson
    {
        public Employee()
        {
            id = Guid.NewGuid().ToString();
        }

        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int? Age { get; set; }

        public double PaycheckAmount { get; set; }

        public double PaychecksPerYear { get; set; }

        public DateTime HireDate { get; set; }

        public List<Dependent> Dependents { get; set; }
    }
}