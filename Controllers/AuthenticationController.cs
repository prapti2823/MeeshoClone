using MeeshoClone.Data;
using MeeshoClone.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace MeeshoClone.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly ApplicationDbContext _db;

        public AuthenticationController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(String Email, String Password)
        {
            var user = _db.User.FirstOrDefault(u => u.Email == Email);
            if (user != null && BCrypt.Net.BCrypt.Verify(Password, user.Password))
            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                if (user.Role == "Admin")
                {
                    TempData["Message"] = "Welcome Admin";
                    TempData["Type"] = "Success";
                    return RedirectToAction("Index", "Admin");
                }
                if (user.Role == "User")
                {
                    TempData["Message"] = "Welcome User";
                    TempData["Type"] = "Success";
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["Message"] = "Invalid Credentials";
            TempData["Type"] = "Error";
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User obj)
        {
            if (ModelState.IsValid)
            {
                obj.Password = BCrypt.Net.BCrypt.HashPassword(obj.Password);
                obj.Role = "User";
                obj.CreatedDate = DateTime.Now;
                obj.IsActive = true;
                _db.User.Add(obj);
                _db.SaveChanges();
                TempData["Message"] = "Registration Done Successfully....";
                TempData["Type"] = "Success";
                return RedirectToAction("Login", "Authentication");
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "Logout Successfully.....";
            TempData["Type"] = "Success";
            return RedirectToAction("Login");
        }
    }
}
