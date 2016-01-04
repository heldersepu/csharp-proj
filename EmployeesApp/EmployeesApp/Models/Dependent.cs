using System.Runtime.Serialization;

namespace EmployeesApp.Models
{
    [DataContract(Namespace = "")]
    public class Dependent
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Relationship { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int? Age { get; set; }

        public Employee Employee { get; set; }

    }
}