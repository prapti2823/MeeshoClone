using MeeshoClone.Data;
using MeeshoClone.Models.Supplier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeeshoClone.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SupplierController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult BecomeSupplier()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BecomeSupplier(Supplier obj)
        {
            //var user = Convert.ToInt32(HttpContextAccessor.HttpContext.Session.GetString("UserId"));
            if (ModelState.IsValid)
            {
                obj.UserId = 3;
                obj.CreatedDate = DateTime.Now;
                obj.IsActive = true;
                _db.Supplier.Add(obj);
                _db.SaveChanges();
                TempData["Message"] = "Supplier created successfully....";
                TempData["Type"] = "Success";
                return RedirectToAction("Login", "Authentication");
            }
            return View("~/Views/Supplier/BecomeSupplier.cshtml");
        }

        [HttpGet]
        public IActionResult Read()
        {
            List<Supplier> suppliers = _db.Supplier.ToList();
            return View("~/Views/Admin/Supplier/Read.cshtml", suppliers);
        }

        public IActionResult Edit(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Supplier supplier = _db.Supplier.Find(Id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Supplier/Edit.cshtml", supplier);
        }

        [HttpPost]
        public IActionResult Edit(Supplier obj)
        {
            var existingUser = _db.Supplier.Find(obj.Id);
            if (existingUser == null)
            {
                return NotFound();
            }
            obj.BankAccountNumber = existingUser.BankAccountNumber;
            obj.BankName = existingUser.BankName;
            obj.Postcode = existingUser.Postcode;
            obj.IFSCCode = existingUser.IFSCCode;
            obj.UpdatedDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _db.Supplier.Update(obj);
                _db.SaveChanges();
                TempData["Message"] = "Supplier Updated....";
                TempData["Type"] = "Success";
                return RedirectToAction("Read", "Supplier");
            }
            return View("~/Views/Admin/Supplier/Edit.cshtml");
        }

        public IActionResult Delete(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Supplier supplier = _db.Supplier.Find(Id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Supplier/Delete.cshtml", supplier);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteSupplier(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var supplier = _db.Supplier.Find(Id);
            if (supplier == null)
            {
                return NotFound();
            }
            _db.Supplier.Remove(supplier);
            _db.SaveChanges();
            TempData["Message"] = "Supplier Deleted....";
            TempData["Type"] = "Success";
            return RedirectToAction("Read", "Supplier");
        }
    }
}
