using System.Collections.Generic;
using DutchTreat.Data.Entities;
using Magnifinance.Data.Entities;
using Magnifinance.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Magnifinance.Data.Interface
{
    public interface IMagnifinanceRepository
    {
        //IEnumerable<Course> GetAllProducts();

        IEnumerable<Course> GetAllCourses();
        SubjectStudentViewModel GetStudentOfAllSubjectsByCourseId(int courseId);

        void AddEntity(object entity);
        bool SaveAll();
    }
}