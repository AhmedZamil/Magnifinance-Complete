using Magnifinance.Data.Entities;
using System.Collections.Generic;

namespace Magnifinance.ViewModels
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Title { get; set; }

        public List<Subject> Subjects { get; set; }

        public int TotalTeachers { get; set; }

        public int TotalStudents { get; set; }

        public double AverageOfGrades { get; set; }
    }
}
