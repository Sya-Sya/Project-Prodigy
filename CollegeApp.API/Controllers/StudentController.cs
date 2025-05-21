using CollegeApp.Application.Interface;
using CollegeApp.Domain.StudentModels;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpPost("addStudent")]
        public IActionResult AddStudent(StudentCommonModel model)
        {
            var students = _studentServices.AddStudent(model);
            return Ok(students);
        }

        [HttpGet("students")]
        public IActionResult GetStudentList()
        {
            var students = _studentServices.GetAllStudents();
            return Ok(students);
        }

        [HttpPost("GetById")]
        public IActionResult GetSpeceficStudent(int id)
        {
            var students = _studentServices.GetStudentById(id);
            return Ok(students);
        }

        [HttpPost("delete")]
        public IActionResult DeleteStudent(int id)
        {
            var students = _studentServices.DeleteStudent(id);
            return Ok(students);
        }

        [HttpPost("update")]
        public IActionResult Updatedata(StudentCommonModel model)
        {
            var agent = _studentServices.UpdateStudent(model);
            return Ok(agent);
        }
    }
}