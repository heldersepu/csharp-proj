using Newtonsoft.Json;

namespace EmployeesApp.Framework.DbSchema
{
    public class BenefitsCost : IObj
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        
        public double Employee { get; set; }
        
        public double Dependent { get; set; }
        
        public string Description { get; set; }
    }
}