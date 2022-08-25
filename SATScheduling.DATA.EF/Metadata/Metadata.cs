using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATScheduling.DATA.EF.Models //.Metadata
{
    #region Course
    public class CoursesMetadata
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Name is required")]
        [StringLength(50)]
        [Display(Name = "Course")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Course Description is required")]
        [StringLength(int.MaxValue)]
        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = "Credit hours is required")]
        [Display(Name = "Credit Hours")]
        public int CreditHours { get; set; }

        [StringLength(250)]
        [Display(Name = "Cirriculum")]
        public string ? Cirriculum { get; set; }

        [StringLength(500)]
        [Display(Name = "Notes")]
        public string ? Notes { get; set; }

        [Required(ErrorMessage = "Active is required")]
        [Display(Name = "Is active?")]
        public bool IsActive { get; set; }


    }
    #endregion

    #region Enrollment
    public class EnrollmentMetadata
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int ScheduledClassId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]//0:d => MM/dd/yyyy
        [Display(Name = "Enrollment Date")]
        [Required]
        public DateTime EnrollmentDate { get; set; }
    }
    #endregion

    #region SATContext
    public class SATContextMetadata
    {

    }
    #endregion

    #region ScheduledClass
    public class ScheduledClassMetadata
    {

    }
    #endregion

    #region ScheduledClassStatus
    public class ScheduledClassStatusMetadata
    {

    }
    #endregion

    #region Student
    public class StudentMetadata
    {

    }
    #endregion

    #region StudentStatus
    public class StudentStatusMetadata
    {

    }
    #endregion




}
