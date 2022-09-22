using AutoMapper;
using Magnifinance.Data;
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
    public class SubjectGradeController : ControllerBase
    {
        private readonly ISubjectGradeRepository _repository;
        private readonly ILogger<SubjectGradeController> _logger;
        private readonly IMapper _mapper;

        public SubjectGradeController(ISubjectGradeRepository repository,
            ILogger<SubjectGradeController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<SubjectGradeViewModel>> Get()
        {
            try
            {
                var allSubjectGrades = _repository.GetAllSubjectsGrade();

                List<SubjectGradeViewModel> subjectGradeList = new List<SubjectGradeViewModel>();
                foreach (SubjectGrade sg in allSubjectGrades)
                {
                    SubjectGradeViewModel model = new SubjectGradeViewModel()
                    {
                        SubjectGradeId= sg.SubjectGradeId,
                        StudentId = sg.StudentId,
                        Student = sg.Student,
                        Grade = sg.Grade,
                        GradePoint = sg.GradePoint,
                        SubjectId = sg.SubjectId,
                        Subject = sg.Subject

                    };
                    subjectGradeList.Add(model);
                }

                return Ok(subjectGradeList);

                //return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("failed to get products");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddSubjectGradeViewModel subjectGrade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SubjectGradeViewModel model = new SubjectGradeViewModel();
                    model.SubjectId = subjectGrade.SubjectId;
                    model.StudentId= subjectGrade.StudentId;
                    model.GradePoint = subjectGrade.GradePoint;
                    if (model.GradePoint > 1 && model.GradePoint < 2) model.Grade = "C";
                    if (model.GradePoint > 2 && model.GradePoint <= 2) model.Grade = "B";
                    if (model.GradePoint > 3 && model.GradePoint <= 3.5) model.Grade = "A";
                    if (model.GradePoint > 3.5 && model.GradePoint <= 4) model.Grade = "A+";

                   
                    model.SubjectGradeId = subjectGrade.SubjectGradeId;

                    var presentGrade = _repository.GetSubjectPresentGradeForStudent(subjectGrade.StudentId, subjectGrade.SubjectId);


                    //if (presentGrade != null)
                    //{
                    //    return BadRequest("All Ready Exist a grade");
                    //}

                    if (presentGrade != null)
                    {
                        presentGrade.Grade = model.Grade;
                        presentGrade.GradePoint = model.GradePoint;

                        _repository.UpdateEntity(presentGrade);
                        if (_repository.SaveAll())
                        {
                            return Created($"/api/subjectgrade/{presentGrade.SubjectGradeId}", _mapper.Map<SubjectGradeViewModel>(presentGrade));
                        }
                    }

                    var newSubjectGrade = _mapper.Map<SubjectGrade>(model);
                    //newStudent.EnrollmentDate = DateTime.UtcNow;

                    _repository.AddEntity(newSubjectGrade);
                    if (_repository.SaveAll())
                    {
                        return Created($"/api/subjectgrade/{newSubjectGrade.SubjectGradeId}", _mapper.Map<SubjectGradeViewModel>(newSubjectGrade));
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
