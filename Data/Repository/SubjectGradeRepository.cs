using Magnifinance.Data.Entities;
using Magnifinance.Data.Interface;
using Magnifinance.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Magnifinance.Data.Repository
{
    public class SubjectGradeRepository : ISubjectGradeRepository
    {
        private readonly MagnifinanceContext _ctx;
        private readonly ILogger<SubjectGradeRepository> _logger;

        public SubjectGradeRepository(MagnifinanceContext ctx, ILogger<SubjectGradeRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<SubjectGrade> GetAllSubjectsGrade()
        {
            try
            {
                _logger.LogInformation("GetAllSubjects was called...");

                return _ctx.SubjectGrades
                    .Include(s => s.Student)
                    .Include(p => p.Subject)
                           .OrderBy(p => p.SubjectId)
                           .ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all subjects: {ex}");
                return null;
            }
        }

        public double GetAvgOfStudentGreatByCourseId(SubjectStudentViewModel model)
        {
            try
            {
                _logger.LogInformation("GetAllSubjects was called...");

                List<SubjectGrade> grades =  _ctx.SubjectGrades
                    .Where(g=>model.StudentList.Contains(g.StudentId) && model.SubjectList.Contains(g.SubjectId))
                           .OrderBy(p => p.SubjectId)
                           .ToList();

                List<int> gradeList = new List<int>();

                double total = 0;
                double avg = 0;
                foreach (SubjectGrade g in grades)
                {
                    total += g.GradePoint;
                }

                try
                {
                    avg = total / grades.Count;
                    if (avg == double.NaN || grades.Count == 0 || total == 0) avg = 0;

                }
                catch {

                    avg = 0;
                }
                


                //IEnumerator enumeratorG = (grades).GetEnumerator();
                //try
                //{
                //    while (enumeratorG.MoveNext())
                //    {
                //        Student element = (Student)enumeratorSC.Current;
                //        int studentid = element.StudentId;

                //        if (!studentList.Contains(studentid))
                //        {
                //            studentList.Add(studentid);
                //        }
                //        // here is casting occures
                //        // loop body;
                //    }
                //}
                //finally
                //{
                //    IDisposable disposable = enumerator as System.IDisposable;
                //    if (disposable != null) disposable.Dispose();
                //}

                return avg;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all subjects: {ex}");
                return 0;
            }
        }


        public SubjectGrade GetSubjectPresentGradeForStudent(int subjectId, int studentId)
        {
            try
            {
                _logger.LogInformation("GetAllSubjects was called...");

                return _ctx.SubjectGrades
                    .Include(s => s.Student)
                    .Include(p => p.Subject)
                    .Where(g => g.StudentId == studentId && g.SubjectId == subjectId)
                           .OrderBy(p => p.SubjectId).FirstOrDefault();

  //              return _ctx.Orders
  //.Include(o => o.Items)
  //.ThenInclude(i => i.Product)
  //.Where(o => o.Id == id && o.User.UserName == username)
  //.FirstOrDefault();

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

        public void UpdateEntity(object entity)
        {
            _ctx.Update(entity);
        }
    }
}
