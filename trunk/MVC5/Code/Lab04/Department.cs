using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socrates.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}