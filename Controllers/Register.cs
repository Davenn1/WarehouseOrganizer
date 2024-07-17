using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;
using Wearhouse3.Data;

namespace Wearhouse3.Controllers
{
    public class Register : Controller
    {
        private readonly WearhouseDbContext _context;
        
        [HttpPost]
        public Register(WearhouseDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Success()
        {

            return View();
        }
    }
}
