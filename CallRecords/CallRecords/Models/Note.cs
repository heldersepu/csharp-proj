using System.Runtime.Serialization;

namespace CallRecords.Models
{
    [DataContract(Namespace = "")]
    public class Note
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Detail { get; set; }

        public Call Call { get; set; }
    }
}