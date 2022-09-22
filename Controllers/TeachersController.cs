using AutoMapper;
using Magnifinance.Data.Entities;
using Magnifinance.Data.Interface;
using Magnifinance.ViewModels;
using MAGNIFINANCE.Web.Data.Interface;
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
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _repository;
        private readonly ILogger<TeachersController> _logger;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherRepository repository,
            ILogger<TeachersController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<TeacherViewModel>> Get()
        {
            try
            {
                var teachers = _repository.GetAllTeachers();

                List<TeacherViewModel> teacherList = new List<TeacherViewModel>();
                foreach (Teacher t in teachers)
                {
                    TeacherViewModel model = new TeacherViewModel()
                    {
                        TeacherId=t.TeacherId,
                        FirstName=t.FirstName,  
                        LastName=t.LastName,
                        Age=t.Age,
                        IsActive=t.IsActive,
                        TeacherSubjects= t.TeacherSubjects


                    };
                    teacherList.Add(model);
                }

                return Ok(teacherList);

                //return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("failed to get products");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] TeacherViewModel teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newTeacher = _mapper.Map<Teacher>(teacher);

                    _repository.AddEntity(newTeacher);
                    if (_repository.SaveAll())
                    {
                        return Created($"/api/subject/{newTeacher.TeacherId}", _mapper.Map<TeacherViewModel>(newTeacher));
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
    }
}
