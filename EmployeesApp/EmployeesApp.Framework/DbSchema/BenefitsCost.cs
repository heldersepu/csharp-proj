using System.Runtime.Serialization;

namespace EmployeesApp.Framework.DbSchema
{
    [DataContract(Namespace = "")]
    public class BenefitsCost
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public double Employee { get; set; }

        [DataMember]
        public double Dependent { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}