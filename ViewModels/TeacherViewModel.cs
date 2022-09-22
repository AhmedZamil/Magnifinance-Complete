using Magnifinance.Data.Entities;
using System.Collections.Generic;

namespace MAGNIFINANCE.Web.ViewModels
{
    public class TeacherViewModel
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public bool IsActive { get; set; }
        public List<Subject> TeacherSubjects { get; set; }
    }
}
