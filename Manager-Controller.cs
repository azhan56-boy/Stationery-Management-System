using Microsoft.AspNetCore.Mvc;
using Stationery_Management_System.db_context;
using Stationery_Management_System.Models;

namespace Stationery_Management_System.Controllers
{
    public class Manager_Controller : Controller
    {

        sqldb db;


        public Manager_Controller(sqldb db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("Name");
            var userRole = HttpContext.Session.GetString("Role");
            if (userRole == "Manager")
            {
                TempData["userroles"] = userRole;
                ViewBag.username = userName;
                return View();
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Admin_");

        }



      



        public IActionResult Profile()
        {
            var userName = HttpContext.Session.GetString("Name");
            var userId = HttpContext.Session.GetInt32("Id"); 
            var userRole = HttpContext.Session.GetString("Role"); 

            if (userId == null)
            {
                return RedirectToAction("Login"); 
            }

            if (userRole != "Manager") 
            {
                return NotFound(); 
            }

            var user = db.users.Find(userId); 

            if (user == null)
            {
                return NotFound(); 
            }

            ViewBag.username = userName;
            TempData["userroles"] = userRole;

            return View(user); 
        }



        [HttpPost]
        public IActionResult Profile(users user)
        {
            var existingUser = db.users.Find(user.userId);

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.UserName = user.UserName;
            existingUser.UserEmail = user.UserEmail;
            existingUser.UserPhone = user.UserPhone;
            existingUser.UserPassword = user.UserPassword; 

            db.SaveChanges();
            TempData["ProfileUpdate"] = "Profile updated successfully";
            return RedirectToAction("Profile");
        }

    }
}
