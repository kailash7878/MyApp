using Microsoft.AspNetCore.Mvc;

namespace MyApp.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
