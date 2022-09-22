namespace Magnifinance.Data.Entities
{
    public class SubjectGrade
    {
        public int SubjectGradeId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        //public int GradeId { get; set; }
        //public Grade Grade { get; set; }

        public string Grade { get; set; }
        public double GradePoint { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
