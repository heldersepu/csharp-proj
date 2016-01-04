using System.Runtime.Serialization;

namespace EmployeesApp.Models
{
    [DataContract(Namespace = "")]
    public class ReportNode
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Salary { get; set; }

        [DataMember]
        public double Benefits { get; set; }

        [DataMember]
        public double Total { get; set; }

    }
}