using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magnifinance.Data.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public int Age { get; set; }
        //public List<Course> StudentCourse { get; set; }


        public List<StudentCourse> StudentCourse { get; set; }

        public List<SubjectGrade> SubjectGrade { get; set; }

    }

}
