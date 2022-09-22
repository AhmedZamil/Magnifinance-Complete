using System.Collections.Generic;

namespace Magnifinance.Data.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Title { get; set; }

        //public List<TeacherCourse> TeacherCourses { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
