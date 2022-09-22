using AutoMapper;
using DutchTreat.Data.Entities;
using Magnifinance.Data.Entities;
using Magnifinance.Data.Interface;
using Magnifinance.Hubs;
using Magnifinance.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Magnifinance.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CourseController : ControllerBase
    {
        private readonly IMagnifinanceRepository _repository;
        private readonly ISubjectGradeRepository _subjectGradeRepo;
        private readonly ILogger<CourseController> _logger;
        private readonly IMapper _mapper;

        private readonly IHubContext<UniversityHub> _universityHub;

        public CourseController(IMagnifinanceRepository repository,
            ISubjectGradeRepository subjectGradeRepo,
            ILogger<CourseController> logger,
            IMapper mapper,
            IHubContext<UniversityHub> universityHub)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _subjectGradeRepo = subjectGradeRepo;
            _universityHub = universityHub;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<CourseViewModel>>> Get()
        {
            try
            {
                Order order = new Order();
                await _universityHub.Clients.All.SendAsync("NewOrder", order);
                var courses = _repository.GetAllCourses();

               

                List<CourseViewModel> coursesList = new List<CourseViewModel>();
                foreach (Course c in courses)
                {
                    List<int> teacherIdList = new List<int>();
                    IEnumerator enumerator = (c.Subjects).GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Subject element = (Subject)enumerator.Current;
                            int id = element.SubjectTeacher.TeacherId;
                            
                            if (!teacherIdList.Contains(id))
                            {
                                teacherIdList.Add(id);
                            }
                              // here is casting occures
                                                                         // loop body;
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as System.IDisposable;
                        if (disposable != null) disposable.Dispose();
                    }


                    SubjectStudentViewModel studentOfSubs = _repository.GetStudentOfAllSubjectsByCourseId(c.CourseId);
                    double average = _subjectGradeRepo.GetAvgOfStudentGreatByCourseId(studentOfSubs);
                    //var totalsubjects = c.Subjects.ForEach(t=>t.SubjectTeacher.TeacherId> 0)
                    CourseViewModel model = new CourseViewModel()
                    {
                        CourseId = c.CourseId,
                        CourseName = c.CourseName,
                        Title = c.Title,
                        Subjects = c.Subjects,
                        TotalTeachers= teacherIdList.Count,
                        TotalStudents = c.StudentCourses.Count,
                        AverageOfGrades = average

                    };
                    coursesList.Add(model);
                }

                return Ok(coursesList);

                //return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("failed to get products");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] CourseViewModel course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newCourse = _mapper.Map<Course>(course);

                    _repository.AddEntity(newCourse);
                    if (_repository.SaveAll())
                    {
                        return Created($"/api/orders/{newCourse.CourseId}", _mapper.Map<CourseViewModel>(newCourse));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save new order: {ex}");
            }

            return BadRequest("Failed to save new order.");
        }

        //public ActionResult<IEnumerable<CourseViewModel>> Get()
        //{
        //    try
        //    {
        //        IEnumerable<Course> courses = _repository.GetAllProducts();
        //        List<CourseViewModel> coursesList = new List<CourseViewModel>();
        //        foreach (Course c in courses)
        //        {
        //            CourseViewModel model = new CourseViewModel()
        //            {
        //                CourseId = c.CourseId,
        //                CourseName = c.CourseName,
        //                Title = c.Title,
        //            };
        //            coursesList.Add(model);
        //        }

        //        return Ok(coursesList);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Failed to get products: {ex}");
        //        return BadRequest("failed to get products");
        //    }
        //}
    }
}
