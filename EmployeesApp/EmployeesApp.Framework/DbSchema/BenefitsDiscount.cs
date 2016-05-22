using Newtonsoft.Json;

namespace EmployeesApp.Framework.DbSchema
{
    public class BenefitsDiscount : IObj
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        
        public double Percentage { get; set; }
        
        public string Type { get; set; }
        
        public string Value { get; set; }
        
        public string Description { get; set; }
    }
}