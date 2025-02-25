using MeeshoClone.Data;
using MeeshoClone.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace MeeshoClone.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Read()
        {
            List<Category> categories = _db.Category.ToList();
            return View("~/Views/Admin/Product/Category/Read.cshtml", categories);
            //return View("~/Views/Admin/Product/Category/Read.cshtml");
        }

        public IActionResult Create()
        {
            return View("~/Views/Admin/Product/Category/Create.cshtml");
        }
        [HttpPost]
        public IActionResult Create(Category obj) {
            if (ModelState.IsValid)
            {
                
                obj.CreatedDate = DateTime.Now;
                obj.IsActive = true;
                _db.Category.Add(obj);
                _db.SaveChanges();
                TempData["Message"] = "Category added Successfully....";
                TempData["Type"] = "Success";
                return RedirectToAction("Read", "Category");
            }
            return View("~/Views/Admin/Product/Category/Create.cshtml");
        }
    }
}
