using Microsoft.AspNetCore.Mvc;
using Stationery_Management_System.db_context;
using Stationery_Management_System.Models;

namespace Stationery_Management_System.Controllers
{
    public class Employee_Controller : Controller
    {
        sqldb db;


        public Employee_Controller(sqldb db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("Name");
            var userRole = HttpContext.Session.GetString("Role");

            if (userRole == "Employee")
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



        //public IActionResult Profile()
        //{


        //    var userId = HttpContext.Session.GetInt32("Id"); // ✅ Getting UserId from Session

        //    if (userId == null)
        //    {
        //        return RedirectToAction("Login"); // Redirect if session expired
        //    }

        //    var user = db.users.Find(userId); // Fetch user details from DB

        //    if (user == null)
        //    {
        //        return NotFound(); // If user not found in DB
        //    }

        //    return View(user); // Pass user object to view
        //}


        public IActionResult Profile()
        {
            var userName = HttpContext.Session.GetString("Name");
            var userId = HttpContext.Session.GetInt32("Id");
            var userRole = HttpContext.Session.GetString("Role");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            if (userRole != "Employee")
            {
                return NotFound();
            }

            var user = db.users.Find(userId);

            if (user == null)
            {
                return NotFound();
            }
            TempData["userroles"] = userRole;
            ViewBag.username = userName;
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

        public IActionResult stationery()
        {

            return View();
        }





        }
}