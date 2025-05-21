using CollegeApp.Application.Interface;
using CollegeApp.Domain.StudentModels;
using CollegeApp.Infrastructure.Repositories.AgentRepo;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
        private readonly IAgentRepository _AgentServices;

        public StudentController(IStudentServices studentServices, IAgentRepository agentservices)
        {
            _studentServices = studentServices;
            _AgentServices = agentservices;
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

        [HttpGet("agents")]
        public async Task<IActionResult> GetAll()
        {
            var agent = await _AgentServices.GetAllAgentAsync();
            return Ok(agent);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var agent = await _AgentServices.GetAgentByIdAsync(id);
        //    return agent is not null ? Ok(agent) : NotFound();
        //}
    }
}
