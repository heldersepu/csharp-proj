using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Socrates.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}