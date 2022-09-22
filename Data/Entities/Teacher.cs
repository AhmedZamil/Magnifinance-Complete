using System;
using System.Collections.Generic;

namespace Magnifinance.Data.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public bool IsActive { get; set; }
        public List<Subject> TeacherSubjects { get; set; }
    }
}
