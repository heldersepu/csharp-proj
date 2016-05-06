using System;

namespace JsonDeserialize
{

    public class BaseAccount
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class BaseAccount2
    {
        public string Email;
        public bool Active;
        public DateTime CreatedDate;
    }

}
