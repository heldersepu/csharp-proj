using System.Runtime.Serialization;

namespace EmployeesApp.Framework.DbSchema
{
    [DataContract(Namespace = "")]
    public class BenefitsDiscount
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public double Percentage { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}