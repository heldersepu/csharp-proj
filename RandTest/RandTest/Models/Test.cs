using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RandTest.Models
{
    [DataContract(Namespace = "")]
    public class Test
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<Question> Questions { get; set; }
    }
}