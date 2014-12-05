using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Socrates.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName;  }
        }
    }
}