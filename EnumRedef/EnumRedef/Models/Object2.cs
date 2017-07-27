namespace EnumRedef.Models
{
    public class Object2
    {
        public int Id { get; set; }

        [DataMember]
        public ObjectType? ObjectTypeID { get; set; }

    }
}