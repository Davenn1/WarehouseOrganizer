using Microsoft.AspNetCore.Mvc;
using Wearhouse3.Data;
using Wearhouse3.Class;
using Newtonsoft.Json;

namespace Wearhouse3.Controllers
{
    public class CategoryController : Controller
    {
        private readonly WearhouseDbContext _context;
        public CategoryController(WearhouseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
      
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
