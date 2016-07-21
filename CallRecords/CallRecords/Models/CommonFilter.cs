using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace CallRecords.Models
{
    [DataContract(Namespace = "")]
    public class CommonFilter
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [StringLength(64)]
        public string Field { get; set; }

        [DataMember]
        [StringLength(64)]
        public string Operation { get; set; }

        [DataMember]
        [StringLength(16)]
        public string Type { get; set; }

        [DataMember]
        [StringLength(128)]
        public string Description { get; set; }        
    }
}