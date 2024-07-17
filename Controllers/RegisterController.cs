using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Wearhouse3.Class;
using Wearhouse3.Data;
using Wearhouse3.Models;

namespace Wearhouse3.Controllers
{
    public class RegisterController : Controller
    {
        private readonly WearhouseDbContext _context;
        public RegisterController(WearhouseDbContext context)
        {
            _context = context;
        }

        public IActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user) {

            var usersId = _context.User.Max(usid => usid.UserID);
            long UserNo;
            var Name = user.Name;
            var Email = user.Email;
            var Password = user.Password;
            var pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[-+_!@#$%^&*.,?]).+$";
            Regex rg = new Regex(pattern);
            Int64.TryParse(usersId, out UserNo);

            if (UserNo >= 0) {
                UserNo = UserNo + 1;
            }

            if (Name.Trim().Length == 0) {

            } else if (rg.IsMatch(user.Password)) {

            } else {
                var users = new User
                {
                    UserID = UserNo.ToString(),
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password
                };

                _context.User.Add(users);
                _context.SaveChanges();

                return View("Index2", user);
            }
            return View("Index2", user);
        }

        
    }
}