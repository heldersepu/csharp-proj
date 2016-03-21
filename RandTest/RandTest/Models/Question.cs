using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace RandTest.Models
{
    [DataContract(Namespace = "")]
    public class Question
    {
        public Question()
        {
            DateAdded = DateTime.Now;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public bool SingleAnswer { get; set; }

        [DataMember]
        public string Detail { get; set; }

        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }

        [DataMember]
        public List<Choice> Choices { get; set; }

        public Test Test { get; set; }
    }
}