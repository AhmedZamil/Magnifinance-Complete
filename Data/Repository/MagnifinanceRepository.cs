using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Data.Entities;
using Magnifinance.Data;
using Magnifinance.Data.Entities;
using Magnifinance.Data.Interface;
using Magnifinance.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Magnifinance.Data.Repository
{
    public class MagnifinanceRepository : IMagnifinanceRepository
    {
        private readonly MagnifinanceContext _ctx;
        private readonly ILogger<MagnifinanceRepository> _logger;

        public MagnifinanceRepository(MagnifinanceContext ctx, ILogger<MagnifinanceRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }


        public IEnumerable<Course> GetAllCourses()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called...");

                return _ctx.Courses.Include(c=>c.StudentCourses).ThenInclude(sc=>sc.Student)
                    .Include(s => s.Subjects).ThenInclude(t=>t.SubjectTeacher).OrderBy(p => p.Title)
                           .ToList();


            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public SubjectStudentViewModel GetStudentOfAllSubjectsByCourseId(int courseId)
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called...");

               Course course =  _ctx.Courses.Where(co=>co.CourseId == courseId).Include(c => c.StudentCourses).ThenInclude(sc => sc.Student)
                    .Include(s => s.Subjects).ThenInclude(t => t.SubjectTeacher).OrderBy(p => p.Title).FirstOrDefault();


                List<int> studentList = new List<int>();
                List<int> subjectList = new List<int>();

                SubjectStudentViewModel subjectStudent = new SubjectStudentViewModel();


                IEnumerator enumeratorSC = (course.StudentCourses).GetEnumerator();
                try
                {
                    while (enumeratorSC.MoveNext())
                    {
                        StudentCourse element = (StudentCourse)enumeratorSC.Current;
                        int studentid = element.StudentId;

                        if (!studentList.Contains(studentid))
                        {
                            studentList.Add(studentid);
                        }
                        // here is casting occures
                        // loop body;
                    }
                }
                finally
                {
                    IDisposable disposable = enumeratorSC as System.IDisposable;
                    if (disposable != null) disposable.Dispose();
                }


               
                IEnumerator enumeratorS = (course.Subjects).GetEnumerator();
                try
                {
                    while (enumeratorS.MoveNext())
                    {
                        Subject element = (Subject)enumeratorS.Current;
                        int subjectid = element.SubjectId;

                        if (!subjectList.Contains(subjectid))
                        {
                            subjectList.Add(subjectid);
                        }
                        // here is casting occures
                        // loop body;
                    }
                }
                finally
                {
                    IDisposable disposable = enumeratorSC as System.IDisposable;
                    if (disposable != null) disposable.Dispose();
                }

                subjectStudent.SubjectList = subjectList;
                subjectStudent.StudentList = studentList;

                return subjectStudent;


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
