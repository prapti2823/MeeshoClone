using MeeshoClone.Data;
using MeeshoClone.Migrations;
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

        public IActionResult Read()
        {
            var user = _db.User.ToList();
            return View("~/Views/Admin/User Management/Read.cshtml", user);
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
            return View("~/Views/Admin/User Management/Read.cshtml", user);
        }

        [HttpPost]
        public IActionResult Edit(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.User.Update(obj);
                _db.SaveChanges();
                TempData["Message"] = "User Updated....";
                TempData["Type"] = "Success";
                return RedirectToAction("Read", "User");
            }
            return View("~/Views/Admin/User Management/Read.cshtml");
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
            return View("~/Views/Admin/User Management/Read.cshtml", user);
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
