using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Volton.Models;
using Volton.ViewModels;
using Volton.Helpers;

namespace Volton.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var customer = TempData.Get<Customer>("Customer") ?? new Customer();
            TempData.Keep("Customer");
            
            var model = new HomeIndexViewModel
            {
                Cards = new List<HomeCardViewModel>
                {
                    new HomeCardViewModel { Id = 1, Title = "Electricity", ImagePath = "~/images/electricity_icon.png" },
                    new HomeCardViewModel { Id = 2, Title = "Natural Gas", ImagePath = "~/images/gas_icon.png" },
                    new HomeCardViewModel { Id = 3, Title = "Electricity and Gas", ImagePath = "~/images/electricity_gas_icon.png" }
                },
                SelectedEnergyId = customer.EnergySelectionId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int EnergySelectionId)
        {
            var customer = TempData.Get<Customer>("Customer") ?? new Customer();
            customer.EnergySelectionId = EnergySelectionId;
            TempData.Put("Customer", customer);
            return RedirectToAction("Onboarding", "Application");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
