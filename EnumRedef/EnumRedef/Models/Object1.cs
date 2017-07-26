namespace EnumRedef.Models
{
    public class Object1
    {
        public int Id { get; set; }

        public ObjectType ObjectTypeID { get { return ObjectType.Message; } set { } }

    }
}