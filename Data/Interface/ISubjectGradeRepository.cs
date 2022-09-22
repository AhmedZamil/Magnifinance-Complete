using Magnifinance.Data.Entities;
using Magnifinance.ViewModels;
using System.Collections.Generic;

namespace Magnifinance.Data.Interface
{
    public interface ISubjectGradeRepository
    {
        IEnumerable<SubjectGrade> GetAllSubjectsGrade();
        SubjectGrade GetSubjectPresentGradeForStudent(int subjectId, int studentId);
        double GetAvgOfStudentGreatByCourseId(SubjectStudentViewModel model);
        void AddEntity(object entity);
        void UpdateEntity(object entity);
        bool SaveAll();
    }
}
