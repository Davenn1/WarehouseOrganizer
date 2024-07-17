using Microsoft.AspNetCore.Mvc;

namespace Wearhouse3.Controllers
{
    public class AboutUsController : Controller
    {

        public IActionResult Index()
        {
            var userInfo = HttpContext.Session.GetString("SessionUser");


            if (string.IsNullOrEmpty(userInfo))
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
