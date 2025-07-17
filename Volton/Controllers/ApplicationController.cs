using Microsoft.AspNetCore.Mvc;
using Volton.Models;
using Volton.Helpers;

namespace Volton.Controllers
{
    public class ApplicationController : Controller
    {
        [HttpPost]
        public IActionResult Page1(string EnergySelection)
        {
            var customer = HttpContext.Session.GetObjectFromJson<Customer>("Customer") ?? new Customer();
            customer.SelectedPlan = EnergySelection;
            HttpContext.Session.SetObjectAsJson("Customer", customer);

                        var model = new HomeIndexViewModel
            {
                Cards = new List<HomeCardViewModel>
                {
                    new HomeCardViewModel { Title = "Home", ImagePath = "~/images/home.png" },
                    new HomeCardViewModel { Title = "The business", ImagePath = "~/images/company.png" },
                    new HomeCardViewModel { Title = "Common area of an apartment building", ImagePath = "~/images/apartment.png" }
                }
            };
            return View("page1", model);
        }

        public IActionResult Page1()
        {
            return View("page1", CreateHomeIndexViewModel());
        }

        [HttpPost]
        public IActionResult Step1(string selectedOption)
        {
            var customer = HttpContext.Session.GetObjectFromJson<Customer>("Customer") ?? new Customer();
            customer.PropertyType = selectedOption;
            HttpContext.Session.SetObjectAsJson("Customer", customer);

            return RedirectToAction("Page2");
        }

        [HttpPost]
        public IActionResult Step2(string selectedPackage)
        {
            var customer = HttpContext.Session.GetObjectFromJson<Customer>("Customer") ?? new Customer();
            customer.SelectedPackage = selectedPackage;
            HttpContext.Session.SetObjectAsJson("Customer", customer);

            return RedirectToAction("Page3");
        }

        public IActionResult Page2()
        {
            ViewData["CurrentStep"] = 2;
            var customer = HttpContext.Session.GetObjectFromJson<Customer>("Customer") ?? new Customer();

            var model = new PackagesViewModel
            {
                Packages = new List<Package>
                {
                    new Package
                    {
                        ImageUrl = Url.Content("~/images/day_home_flexi_plus.png"),
                        Title = "Volton Unique Flexi Plus",
                        Description = "Secure the lowest kilowatt-hour price on the energy market!"
                    },
                    new Package
                    {
                        ImageUrl = Url.Content("~/images/day_home_flat.png"),
                        Title = "Volton Unique Flat",
                        Description = "Keep a fixed charge on your account for 24 months!"
                    },
                    new Package
                    {
                        ImageUrl = Url.Content("~/images/day_home_flexi.png"),
                        Title = "Volton Unique Flexi",
                        Description = "Reduce your energy bill up to 43% for 24 months!"
                    }
                },
                SelectedPackage = customer.SelectedPackage
            };

            return View(model);
        }
        public IActionResult Page3()
        {
            ViewData["CurrentStep"] = 3;
            var customer = HttpContext.Session.GetObjectFromJson<Customer>("Customer") ?? new Customer();

            var model = new WarrantyViewModel
            {
                warentyInfo = customer.warentyInfo,
                AgreedSupplyPower = customer.AgreedSupplyPower
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Step3(string warentyInfo, string AgreedSupplyPower)
        {
            var customer = HttpContext.Session.GetObjectFromJson<Customer>("Customer") ?? new Customer();
            customer.warentyInfo = warentyInfo;
            customer.AgreedSupplyPower = AgreedSupplyPower;
            HttpContext.Session.SetObjectAsJson("Customer", customer);

            return RedirectToAction("Page4");
        }
        public IActionResult Page4()
        {
            return View();
        }
        public IActionResult EmailVerification()
        {
            return View();
        }

        private HomeIndexViewModel CreateHomeIndexViewModel()
        {
            return new HomeIndexViewModel
            {
                Cards = new List<HomeCardViewModel>
                {
                    new HomeCardViewModel { Title = "Home", ImagePath = "~/images/home.png" },
                    new HomeCardViewModel { Title = "The business", ImagePath = "~/images/company.png" },
                    new HomeCardViewModel { Title = "Common area of an apartment building", ImagePath = "~/images/apartment.png" }
                }
            };
        }
    }
}
