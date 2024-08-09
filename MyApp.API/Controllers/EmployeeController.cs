using Microsoft.AspNetCore.Mvc;

namespace MyApp.API.Controllers
{
    public class EmployeeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }
    }
}
