using AutoMapper;
using Magnifinance.Data.Entities;
using Magnifinance.Data.Interface;
using Magnifinance.ViewModels;
using MAGNIFINANCE.Web.ViewModels;
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
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository _repository;
        private readonly ILogger<SubjectsController> _logger;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectRepository repository,
            ILogger<SubjectsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<SubjectViewModel>> Get()
        {
            try
            {
                var subjects = _repository.GetAllSubjects();

                List<SubjectViewModel> subjectList = new List<SubjectViewModel>();
                foreach (Subject s in subjects)
                {
                    SubjectViewModel model = new SubjectViewModel()
                    {
                        SubjectId=s.SubjectId,
                        SubjectName=s.SubjectName,
                        SubjectTitle=s.SubjectTitle,
                        IsMajor=s.IsMajor,
                        CourseId=s.CourseId,
                        SubjectGrade=s.SubjectGrade,
                        Course=s.Course,
                        TeacherId=s.TeacherId,
                        SubjectTeacher=s.SubjectTeacher,
                        TotalStudents = s.SubjectGrade.Count
                    };
                    subjectList.Add(model);
                }

                return Ok(subjectList);

                //return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("failed to get products");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddSubjectViewModel subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SubjectViewModel model = new SubjectViewModel();
                    model.SubjectId = subject.SubjectId;
                    model.SubjectName = subject.SubjectName;
                    model.SubjectTitle = subject.SubjectTitle;
                    model.TeacherId = subject.TeacherId;
                    model.CourseId = subject.CourseId;

             

                    var newSubject = _mapper.Map<Subject>(model);

                    _repository.AddEntity(newSubject);
                    if (_repository.SaveAll())
                    {
                        return Created($"/api/subject/{newSubject.SubjectId}", _mapper.Map<SubjectViewModel>(newSubject));
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
