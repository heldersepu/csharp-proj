using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesApp.Models
{
    [DataContract(Namespace = "")]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int? Age { get; set; }

        [DataMember]
        public double PaycheckAmount { get; set; }

        [DataMember]
        public double PaychecksPerYear { get; set; }

        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime HireDate { get; set; }

        [DataMember]
        public List<Dependent> Dependents { get; set; }
    }
}