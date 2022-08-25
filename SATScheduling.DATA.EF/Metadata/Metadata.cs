using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATScheduling.DATA.EF.Models //.Metadata
{
    #region Course
    public class CourseMetadata
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Name is required")]
        [StringLength(50)]
        [Display(Name = "Course")]
        public string CourseName { get; set; } = null!;

        [Required(ErrorMessage = "Course Description is required")]
        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; } = null!;

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

    #region ScheduledClass
    public class ScheduledClassMetadata
    {
        public int ScheduledClassId { get; set; }

        public int CourseId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]//0:d => MM/dd/yyyy
        [Display(Name = "Start Date")]
        [Required]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]//0:d => MM/dd/yyyy
        [Display(Name = "End Date")]
        [Required]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Instructor Name is required")]
        [StringLength(40)]
        [Display(Name = "Instructor Name")]
        public string InstructorName { get; set; } = null!;

        [Required(ErrorMessage = "Location is required")]
        [StringLength(20)]
        [Display(Name = "Location")]
        public string Location { get; set; } = null!;

      
        public int SCSID { get; set; }
    }
    #endregion

    #region ScheduledClassStatus
    public class ScheduledClassStatusMetadata
    {
        public int SCSID { get; set; }
        //PK, doesnt need any further rules

        [Required(ErrorMessage = "Scheduled Class Status is Required")]
        [StringLength(50)]
        [Display(Name = "Scheduled Class Status")]
        public string SCSName { get; set; } = null!;
    }
    #endregion

    #region Student
    public class StudentMetadata
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [StringLength(15)]
        public string? Major { get; set; }

        [StringLength(50)]
        public string? Address { get; set; }

        [StringLength(25)]
        public string? City { get; set; }

        [StringLength(2)]
        public string? State { get; set; }

        [StringLength(10)]
        [Display(Name = "Zip Code")]
        public string? ZipCode { get; set; }

        [StringLength(13)]
        public string? Phone { get; set; }

        [StringLength(60)]
        [Required]
        public string Email { get; set; } = null!;

        [StringLength(100)]
        [Display(Name = "Photo")]
        public string? PhotoUrl { get; set; }

        public int SSID { get; set; }
    }
    #endregion

    #region StudentStatus
    public class StudentStatusMetadata
    {
        public int SSID { get; set; }

        [StringLength(30)]
        [Display(Name = "Student Status")]
        [Required]
        public string SSName { get; set; } = null!;

        [StringLength(250)]
        [Display(Name = "Student Status Description")]
        public string? SSDescription { get; set; }
    }
    #endregion
}
