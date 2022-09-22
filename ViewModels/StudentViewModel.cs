using Magnifinance.Data.Entities;
using System.Collections.Generic;

namespace Magnifinance.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        //public List<Course> StudentCourse { get; set; }


        public List<StudentCourse> StudentCourse { get; set; }

        public List<SubjectGrade> SubjectGrade { get; set; }
    }
}
