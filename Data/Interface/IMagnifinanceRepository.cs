using System.Collections.Generic;
using System.Threading.Tasks;
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

        Task<Course> UpdateCourse(string id, Course course);
        void AddEntity(object entity);
        bool SaveAll();
    }
}