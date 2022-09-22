using System;

namespace Magnifinance.Data.Entities
{
    public class TeacherSubject
    {
        public int SubjectTeacherId { get; set; }
        public string Note { get; set; }

        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}
