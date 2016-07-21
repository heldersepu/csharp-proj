using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace CallRecords.Models
{
    [DataContract(Namespace = "")]
    public class ListView
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [StringLength(128)]
        public string Name { get; set; }

        [DataMember]
        public bool ReadOnly { get; set; }

        [DataMember]
        public List<Filter> Filters { get; set; }
    }
}