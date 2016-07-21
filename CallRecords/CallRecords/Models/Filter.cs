using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace CallRecords.Models
{
    [DataContract(Namespace = "")]
    public class Filter
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CommonFilter_Id { get; set; }        

        [DataMember]
        [StringLength(128)]
        public string Where { get; set; }

        public ListView ListView { get; set; }
    }
}