using CollegeApp.Application.Interface;
using CollegeApp.Infrastructure.Repositories.AgentRepo;
using CollegeApp.Infrastructure.Services;
using CollegeApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CollegeApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentServices _studentServices;
        private readonly IAgentRepository _AgentServices;

        public HomeController(ILogger<HomeController> logger, IStudentServices studentServices, IAgentRepository agentservices)
        {
            _logger = logger;
            _studentServices = studentServices;
            _AgentServices = agentservices;
        }

        public async Task<IActionResult> Index()
        {
            var students = _studentServices.GetAllStudents();
            var lit = await _AgentServices.GetAllAgentAsync();
            return View(lit);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
