using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmployeesApp.Framework.DbSchema
{
    public class Benefits : IObj
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        public BenefitsCost Cost { get; set; }
        public List<BenefitsDiscount> Discounts { get; set; }
    }

    public class BenefitsCost
    {
        public double Employee { get; set; }
        public double Dependent { get; set; }
        public string Description { get; set; }
    }

    public class BenefitsDiscount
    {
        public BenefitsDiscount()
        {
            id = Guid.NewGuid().ToString();
        }
        public string id { get; set; }
        public double Percentage { get; set; }
        public string Predicate { get; set; }
        public string Description { get; set; }
    }
}