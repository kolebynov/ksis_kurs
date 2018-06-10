using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}