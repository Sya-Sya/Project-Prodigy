using CollegeApp.Application.Interface;
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

        [HttpGet]
        public IActionResult GetStudentList()
        {
            var students = _studentServices.GetAllStudents();
            return Ok(students);
        }

        [HttpGet]
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
