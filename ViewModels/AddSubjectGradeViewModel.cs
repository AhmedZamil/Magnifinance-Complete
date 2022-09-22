namespace MAGNIFINANCE.Web.ViewModels
{
    public class AddSubjectGradeViewModel
    {
        public int SubjectGradeId { get; set; }
        public int StudentId { get; set; }

        //public int GradeId { get; set; }
        //public Grade Grade { get; set; }

        public string Grade { get; set; }
        public double GradePoint { get; set; }

        public int SubjectId { get; set; }
    }
}
