using System;
using System.Runtime.Serialization;

namespace RandTest.Models
{
    [DataContract(Namespace = "")]
    public class Choice
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Detail { get; set; }

        public bool Answer { get; set; }

        public Question Question { get; set; }
    }
}