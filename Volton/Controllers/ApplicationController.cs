using Microsoft.AspNetCore.Mvc;
using Volton.Models;

namespace Volton.Controllers
{
    public class ApplicationController : Controller
    {
        [HttpPost]
        public IActionResult Page1(string EnergySelection)
        {
            // Optionally store EnergySelection for later use
            // TempData["EnergySelection"] = EnergySelection;
            return RedirectToAction("Page1");
        }
        public IActionResult Page1()
        {
            var model = new HomeIndexViewModel
            {
                Cards = new List<HomeCardViewModel>
                {
                    new HomeCardViewModel { Title = "Home", ImagePath = "~/images/home.png" },
                    new HomeCardViewModel { Title = "The business", ImagePath = "~/images/company.png" },
                    new HomeCardViewModel { Title = "Common area of an apartment building", ImagePath = "~/images/apartment.png" }
                }
            };
            return View(model);
        }
        public IActionResult Page2()
        {
            return View();
        }
        public IActionResult Page3()
        {
            return View();
        }
        public IActionResult Page4()
        {
            return View();
        }
    }
}
