using Microsoft.AspNetCore.Mvc;

namespace otopark.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
