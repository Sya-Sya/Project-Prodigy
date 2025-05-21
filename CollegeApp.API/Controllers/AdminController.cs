using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.API.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
