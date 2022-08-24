using System;
using System.Collections.Generic;

namespace SATScheduling.DATA.EF.Models
{
    public partial class Course
    {
        public Course()
        {
            ScheduledClasses = new HashSet<ScheduledClass>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string CourseDescription { get; set; } = null!;
        public byte CreditHours { get; set; }
        public string? Cirriculum { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ScheduledClass> ScheduledClasses { get; set; }
    }
}
