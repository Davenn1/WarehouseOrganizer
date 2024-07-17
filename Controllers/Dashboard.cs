using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using Wearhouse3.Class;

namespace Wearhouse3.Controllers
{
    public class Dashboard : Controller
    {
        
        public IActionResult Index(User user)
        {
            var userInfo = JsonConvert.DeserializeObject<userinfo>(HttpContext.Session.GetString("SessionUser"));
            ViewBag.username = userInfo.username;
            ViewBag.userID = userInfo.userID;

            if (string.IsNullOrEmpty(userInfo.username)) 
            {
                return RedirectToAction("Index", "Login");
            }
            return View("Index", user);
        }

        public IActionResult addCategory(User user) {
            return View();
        }

        public ActionResult LogOut() {
            return RedirectToAction("Index", "Login"); 
        }

        public string getName()
        {
            string name = HttpContext.Session.GetString("Name").ToString();
            return name;
        }
    }
}
