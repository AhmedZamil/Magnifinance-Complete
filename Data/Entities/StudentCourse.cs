using System;

namespace Magnifinance.Data.Entities
{
    public class StudentCourse
    {
        public int StudentCourseId { get; set; }
        public string Note { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }



    }
}
