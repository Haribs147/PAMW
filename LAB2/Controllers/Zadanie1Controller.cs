using Microsoft.AspNetCore.Mvc;
using LAB2.Models;

namespace LAB2.Controllers
{
    public class Zadanie1Controller : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                model.Result = model.Number1 + model.Number2;
            }

            return View(model);
        }
    }
}
