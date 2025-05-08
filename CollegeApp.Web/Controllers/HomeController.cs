using CollegeApp.Application.Interface;
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

        public HomeController(ILogger<HomeController> logger, IStudentServices studentServices)
        {
            _logger = logger;
            _studentServices = studentServices;
        }

        public IActionResult Index()
        {
            var students = _studentServices.GetAllStudents();
            return View(students);
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
