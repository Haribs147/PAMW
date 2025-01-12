using Microsoft.AspNetCore.Mvc;

namespace LAB3.Controllers
{
    public class Zadanie3Controller : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
