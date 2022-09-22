using Magnifinance.Data.Entities;
using System.Collections.Generic;

namespace Magnifinance.ViewModels
{
    public class SubjectViewModel
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectTitle { get; set; }
        public bool IsMajor { get; set; }

        public int CourseId { get; set; }
        public List<SubjectGrade> SubjectGrade { get; set; }
        public Course Course { get; set; }

        public int TeacherId { get; set; }
        public Teacher SubjectTeacher { get; set; }

        public int TotalStudents { get; set; }
    }
}
