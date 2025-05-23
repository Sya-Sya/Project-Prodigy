using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Web.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
