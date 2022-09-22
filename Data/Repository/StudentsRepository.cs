using Magnifinance.Data.Entities;
using Magnifinance.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Magnifinance.Data.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly MagnifinanceContext _ctx;
        private readonly ILogger<StudentsRepository> _logger;

        public StudentsRepository(MagnifinanceContext ctx, ILogger<StudentsRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            try
            {
                _logger.LogInformation("GetAllStudents was called...");

                return _ctx.Students.Include(s=>s.SubjectGrade).ThenInclude(g=>g.Subject).OrderBy(p => p.FirstName)
                           .ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all subjects: {ex}");
                return null;
            }
        }

        public IEnumerable<Course> GetAllCourses()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called...");

                return _ctx.Courses.Include(s => s.Subjects).OrderBy(p => p.Title)
                           .ToList();


            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }
        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void AddEntity(object entity)
        {
            _ctx.Add(entity);
        }
    }
}
