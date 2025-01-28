using Microsoft.AspNetCore.Mvc;

namespace MeeshoClone.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
