using CollegeApp.Application.Interface;
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

        [HttpGet]
        public IActionResult GetStudentList()
        {
            var students = _studentServices.GetAllStudents();
            return Ok(students);
        }
    }
}
