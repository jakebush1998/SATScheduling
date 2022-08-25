using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATScheduling.DATA.EF.Models//.Metadata
{
    #region Course
    [ModelMetadataType(typeof(CoursesMetadata))]
    public partial class Courses { }
    #endregion

    #region Enrollment
    [ModelMetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollments { }
    #endregion

    #region ScheduledClass
    [ModelMetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClass { }
    #endregion

    #region ScheduledClassStatus
    [ModelMetadataType(typeof(ScheduledClassStatusMetadata))]
    public partial class ScheduledClassStatus { }
    #endregion

    #region Student
    [ModelMetadataType(typeof(StudentMetadata))]
    public partial class Student { }
    #endregion

    #region StudentStatus
    [ModelMetadataType(typeof(StudentStatusMetadata))]
    public partial class StudentStatus { }
    #endregion
}
