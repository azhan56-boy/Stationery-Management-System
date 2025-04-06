using Microsoft.AspNetCore.Mvc;
using Stationery_Management_System.db_context;
using Stationery_Management_System.Models;

namespace Stationery_Management_System.Controllers
{
    public class Assistant_Manager_Controller : Controller
    {
        sqldb db;


        public Assistant_Manager_Controller(sqldb db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("Name");
            var userRole = HttpContext.Session.GetString("Role");

            if (userRole == "Assistant_Manager")
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



        public IActionResult Addusers()
        {
            var userName = HttpContext.Session.GetString("Name");
            var userRole = HttpContext.Session.GetString("Role");
            if (userName is not null)
            {
                if (userRole == "Assistant_Manager")
                {
                    ViewBag.username = userName;
                    TempData["userroles"] = userRole;
                    return View();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin_");
            };
        }

        [HttpPost]
        public IActionResult Addusers(users us)
        {
            var userId = HttpContext.Session.GetInt32("Id");
            us.Add_By = userId;
            us.UserPassword = "123456789";
            db.users.Add(us);
            db.SaveChanges();
            ModelState.Clear();
            TempData["Addusers"] = "user added successfully";
            return RedirectToAction("users");
        }


        public IActionResult user_Edit(int id)
        {
            var userName = HttpContext.Session.GetString("Name");
            var userRole = HttpContext.Session.GetString("Role");
            if (userName is not null)
            {
                if (userRole == "Assistant_Manager")
                {
                    TempData["userroles"] = userRole;
                    ViewBag.username = userName;
                    var user = db.users.Find(id);
                    return View(user);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return RedirectToAction("Login" ,"Admin_");
            };
        }

        [HttpPost]
        public IActionResult user_Edit(users us)
        {
            db.users.Update(us);
            db.SaveChanges();
            ModelState.Clear();
            TempData["user_Edit"] = "User Updated successfully";
            return RedirectToAction("users");
        }


        public IActionResult users()
        {
            var userName = HttpContext.Session.GetString("Name");
            var userRole = HttpContext.Session.GetString("Role");
            var userId = HttpContext.Session.GetInt32("Id"); // Logged-in user's ID

            if (userName is not null)
            {
                if (userRole == "Assistant_Manager")
                {
                    TempData["userroles"] = userRole;
                    ViewBag.username = userName;

                    // Fetch users added by the currently logged-in Assistant Manager
                    var userList = db.users.Where(u => u.Add_By == userId).ToList();

                    return View(userList);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin_");
            }
        }







        public IActionResult Profile()
        {
            var userName = HttpContext.Session.GetString("Name");
            var userId = HttpContext.Session.GetInt32("Id");
            var userRole = HttpContext.Session.GetString("Role");

            if (userId == null)
            {
                return RedirectToAction("Login", "Admin_");
            }

            if (userRole != "Assistant_Manager")
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



    }
}
