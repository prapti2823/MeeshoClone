using MeeshoClone.Data;
using MeeshoClone.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace MeeshoClone.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Read()
        {
            List<User> users = _db.User.ToList();
            return View("~/Views/Admin/User Management/Read.cshtml", users);
        }

        public IActionResult Edit(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            User user = _db.User.Find(Id);
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/User Management/Edit.cshtml", user);
        }

        [HttpPost]
        public IActionResult Edit(User obj)
        {
            var existingUser = _db.User.Find(obj.Id);
            if (existingUser == null)
            {
                return NotFound();
            }

            // 🔹 Keep the existing password
            obj.Password = existingUser.Password;
            obj.CreatedDate = existingUser.CreatedDate;

            ModelState.Remove("Password");

            if (ModelState.IsValid)
            {
                _db.User.Update(obj);
                _db.SaveChanges();
                TempData["Message"] = "User Updated....";
                TempData["Type"] = "Success";
                return RedirectToAction("Read", "User");
            }
            return View("~/Views/Admin/User Management/Edit.cshtml",obj);
        }

        public IActionResult Delete(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            User user = _db.User.Find(Id);
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/User Management/Delete.cshtml", user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteUser(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var user = _db.User.Find(Id);
            if (user == null)
            {
                return NotFound();
            }
            _db.User.Remove(user);
            _db.SaveChanges();
            TempData["Message"] = "User Deleted....";
            TempData["Type"] = "Success";
            return RedirectToAction("Read", "User");
        }
    }
}
