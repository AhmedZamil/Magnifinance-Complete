using Magnifinance.Data;
using Magnifinance.Data.Entities;
using MAGNIFINANCE.Web.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MAGNIFINANCE.Web.Data.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MagnifinanceContext _ctx;
        private readonly ILogger<TeacherRepository> _logger;

        public TeacherRepository(MagnifinanceContext ctx, ILogger<TeacherRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            try
            {
                _logger.LogInformation("GetAllSubjects was called...");

                return _ctx.Teachers
                    .Include(s => s.TeacherSubjects)
                           .OrderBy(p => p.FirstName)
                           .ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all subjects: {ex}");
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
