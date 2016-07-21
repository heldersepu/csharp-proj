using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallRecords.Models
{
    [DataContract(Namespace = "")]
    public class Call
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Duration { get; set; }

        [DataMember]
        [StringLength(128)]
        public string PhoneNumber { get; set; }

        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime StartTime { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<Note> Notes { get; set; }
    }
}