using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socrates.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
        public float Duration { get; set; }
        public string Description { get; set; }
        public DateTime AvailabilityDate { get; set; }
        public bool IsActive { get; set; }

        public Department Department { get; set; }
        public ICollection<Instructor> Instructors { get; set;  }
    }
}