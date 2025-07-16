using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Volton.Models;

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
            var model = new HomeIndexViewModel
            {
                Cards = new List<HomeCardViewModel>
                {
                    new HomeCardViewModel { Title = "Electricity", ImagePath = "~/images/electricity_icon.png" },
                    new HomeCardViewModel { Title = "Natural Gas", ImagePath = "~/images/gas_icon.png" },
                    new HomeCardViewModel { Title = "Electricity and Gas", ImagePath = "~/images/electricity_gas_icon.png" }
                }
            };
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
