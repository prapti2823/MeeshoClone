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
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User obj)
        {
            if (ModelState.IsValid)
            {
                obj.IsActive = true;
                _db.User.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Login", "Authentication");
            }
            return View();
        }
    }
}
