using Microsoft.AspNetCore.Mvc;

namespace Wearhouse3.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
