using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EmployeesApp.Models
{
    [DataContract(Namespace = "")]
    public class ReportChart
    {
        [DataMember]
        public string label { get; set; }

        [DataMember]
        public List<List<int>> data { get; set; }
    }
}