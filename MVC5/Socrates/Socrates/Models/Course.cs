using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Socrates.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public float Duration { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime AvailabilityDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}