using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CallRecords.Models
{
    [DataContract(Namespace = "")]
    public class CallsView
    {
        [DataMember]
        public ListView ListView { get; set; }

        [DataMember]
        public List<Call> Calls { get; set; }
    }
}