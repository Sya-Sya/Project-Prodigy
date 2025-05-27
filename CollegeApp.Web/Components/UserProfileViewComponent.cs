using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Web.Components
{
    public class UserProfileViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
