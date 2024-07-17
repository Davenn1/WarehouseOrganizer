using Microsoft.AspNetCore.Mvc;
using Wearhouse3.Class;
using Wearhouse3.Data;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections;
using System.Security.Permissions;
using HtmlAgilityPack;


namespace Wearhouse3.Controllers
{

    public class LoginController : Controller
    {

        public object Viewbag {
            get;
        }
        private readonly WearhouseDbContext _context;
        public LoginController(WearhouseDbContext context)
        {
            _context = context; 
        }
        private User GetUsers(User user) {
            var userDetail = _context.User.Where(x => x.UserID == user.UserID).FirstOrDefault();
            


            return userDetail;
        }

        private List<Category> GetCategory()
        {
            var category = _context.Category.Select(x => new Category
            {
                UserID = x.UserID,
                CategoryName = x.CategoryName,
            });


            return category.ToList();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InvalidPassword(User user) {
            return View();
        }
        [HttpPost]
        public ActionResult Authorise(User user)
        {

            var userDetail = _context.User.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

            if (userDetail == null)
            {
                user.Password = "Invalid Username or password";

                return View("Index", user);
            }
            else
            {
                var userinfo = new userinfo() { userID = userDetail.UserID.ToString(), username = userDetail.Name.ToString() };
                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(userinfo));
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        public ActionResult AddCategory(User user)
        {
            List<Category> products = _context.Category.ToList();
            var userInfo = JsonConvert.DeserializeObject<userinfo>(HttpContext.Session.GetString("SessionUser"));
            ViewBag.username = userInfo.username;
            ViewBag.userID = userInfo.userID;
            return View(products);
        }

        [HttpPost]
        public void AddCategoryName(Category category)
        {

            
            var categoryName = Request.Form["name"];
            var userInfo = JsonConvert.DeserializeObject<userinfo>(HttpContext.Session.GetString("SessionUser"));
            //int catNo = _context.Category.Where(catid=>catid.UserID == userInfo.userID).Count();

            //Console.WriteLine(catNo);


            //if (catNo >= 0)
            //{
                //catNo = catNo + 1;
            //}
            var categories = new Category
            {
                CategoryID = string.Concat(userInfo.userID.Trim(), "_" ,categoryName),
                CategoryName = categoryName,
                UserID = userInfo.userID,
            };

            
            _context.Category.Add(categories);
            _context.SaveChanges();

            RedirectToAction("AddCategory", "Login");
            ;
        }

        [HttpPost]
        public void Edit(Category category) {

            
            
            string categoryNameEdited = Request.Form["edit"];
            var categoryNameNew = Request.Form["nameedit"];
            var userInfo = JsonConvert.DeserializeObject<userinfo>(HttpContext.Session.GetString("SessionUser"));

            Console.WriteLine(categoryNameEdited);
            
            var editedValue = _context.Category.Where(x => x.UserID == userInfo.userID && x.CategoryName == categoryNameEdited).FirstOrDefault();

            editedValue.CategoryName = categoryNameNew;

            _context.SaveChanges();

            RedirectToAction("AddCategory", "Login");
            

        }

        [HttpPost]
        public async void Delete(Category category) {
            string categoryNameDelete = Request.Form["namedelete"];
            var userInfo = JsonConvert.DeserializeObject<userinfo>(HttpContext.Session.GetString("SessionUser"));
            var deleteValue = _context.Category.FirstOrDefault(x => userInfo.userID == x.UserID && x.CategoryName == categoryNameDelete);

            _context.Category.Remove(deleteValue);
            _context.SaveChanges();

            RedirectToAction("AddCategory", "Login");
        } 


        public ActionResult AboutUs()
        {
            var userInfo = JsonConvert.DeserializeObject<userinfo>(HttpContext.Session.GetString("SessionUser"));
            ViewBag.username = userInfo.username;
            ViewBag.userID = userInfo.userID;
            return View();


        }

        public ActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
