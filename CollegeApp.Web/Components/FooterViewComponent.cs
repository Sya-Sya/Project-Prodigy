using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Web.Components
{
    public class FooterViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}