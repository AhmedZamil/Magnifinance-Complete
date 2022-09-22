using AutoMapper;
using Magnifinance.Data;
using Magnifinance.Data.Entities;
using Magnifinance.Data.Interface;
using Magnifinance.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Magnifinance.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _repository;
        private readonly ILogger<StudentsController> _logger;
        private readonly IMapper _mapper;

        public StudentsController(IStudentsRepository repository,
            ILogger<StudentsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<StudentViewModel>> Get()
        {
            try
            {
                var students = _repository.GetAllStudents();

                List<StudentViewModel> studentsList = new List<StudentViewModel>();
                foreach (Student s in students)
                {
                    StudentViewModel model = new StudentViewModel()
                    {
                        StudentId= s.StudentId,
                        FirstName=s.FirstName,
                        LastName=s.LastName,
                        Age=s.Age,
                        StudentCourse=s.StudentCourse,
                        SubjectGrade=s.SubjectGrade
                        
                    };
                    studentsList.Add(model);
                }

                return Ok(studentsList);

                //return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("failed to get products");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] StudentViewModel student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newStudent= _mapper.Map<Student>(student);
                    newStudent.EnrollmentDate = DateTime.UtcNow;

                    _repository.AddEntity(newStudent);
                    if (_repository.SaveAll())
                    {
                        return Created($"/api/students/{newStudent.StudentId}", _mapper.Map<StudentViewModel>(newStudent));
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
