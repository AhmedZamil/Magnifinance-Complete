using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using Magnifinance.Data.Entities;
using Magnifinance.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Magnifinance.Data.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly MagnifinanceContext _ctx;
        private readonly ILogger<SubjectRepository> _logger;

        public SubjectRepository(MagnifinanceContext ctx, ILogger<SubjectRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            try
            {
                _logger.LogInformation("GetAllSubjects was called...");

                return _ctx.Subjects
                    .Include(s=>s.SubjectGrade).ThenInclude(g=>g.Student)
                    .Include(p=>p.Course)
                    .Include(m=>m.SubjectTeacher)
                           .OrderBy(p => p.SubjectName)
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
