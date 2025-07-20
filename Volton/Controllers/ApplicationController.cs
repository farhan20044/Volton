using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Volton.Models;
using Volton.Helpers;
using Volton.Constants;
using Volton.ViewModels;
using Volton.Data;

namespace Volton.Controllers
{
    public class ApplicationController : Controller
    {
                private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        
        public IActionResult Onboarding()
        {
            var user = TempData.Get<ApplicationUser>("UserData") ?? new ApplicationUser();
            TempData.Keep("UserData");
            var model = CreateHomeIndexViewModel();
            model.SelectedPlanId = user.SelectedPlanId;
            model.AppartmentIsCustomer = user.AppartmentIsCustomer;
            model.AppartmentInterestType = user.AppartmentInterestType;
            model.HomeIsCustomer = user.HomeIsCustomer;
            model.HomeSecondPower = user.HomeSecondPower;
            model.HomeInterestType = user.HomeInterestType;
            model.HomeCounterType = user.HomeCounterType;
            model.BusinessInterestType = user.BusinessInterestType;
            return View("onboarding", model);
        }

        public IActionResult Packages()
        {
            var user = TempData.Get<ApplicationUser>("UserData") ?? new ApplicationUser();
            TempData.Keep("UserData");
            var model = new PackagesViewModel
            {
                Packages = new List<Package>
                {
                    new Package
                    {
                        Id = 1,
                        ImageUrl = Url.Content("~/images/day_home_flexi_plus.png"),
                        Title = "Volton Unique Flexi Plus",
                        Description = "Secure the lowest kilowatt-hour price on the energy market!"
                    },
                    new Package
                    {
                        Id = 2,
                        ImageUrl = Url.Content("~/images/day_home_flat.png"),
                        Title = "Volton Unique Flat",
                        Description = "Keep a fixed charge on your account for 24 months!"
                    },
                    new Package
                    {
                        Id = 3,
                        ImageUrl = Url.Content("~/images/day_home_flexi.png"),
                        Title = "Volton Unique Flexi",
                        Description = "Reduce your energy bill up to 43% for 24 months!"
                    },
                    new Package
                    {
                        Id = 4,
                        ImageUrl = Url.Content("~/images/day_home_flexi.png"), 
                        Title = "Volton Solar Pro",
                        Description = "Maximize your savings with our premium solar package!"
                    }
                },
                SelectedPackageId = user.PackageId
            };

            return View(model);
        }
        public IActionResult Warenty()
        {
            var user = TempData.Get<ApplicationUser>("UserData") ?? new ApplicationUser();
            TempData.Keep("UserData");

            var model = new WarrantyViewModel
            {
                warentyInfo = user.warentyInfo,
                AgreedSupplyPower = user.AgreedSupplyPower
            };

            return View(model);
        }

        public IActionResult Documents()
        {

            return View();
        }
        public IActionResult EmailVerification()
        {
            return View(new Volton.ViewModels.EmailVerificationViewModel());
        }

        [HttpPost]
                public async Task<IActionResult> EmailVerification(EmailVerificationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userData = TempData.Get<ApplicationUser>("UserData");
            if (userData == null)
            {
                return RedirectToAction("Onboarding");
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                SelectedPlanId = userData.SelectedPlanId,
                PackageId = userData.PackageId,
                AgreedSupplyPower = userData.AgreedSupplyPower,
                warentyInfo = userData.warentyInfo,
                AppartmentIsCustomer = userData.AppartmentIsCustomer,
                AppartmentInterestType = userData.AppartmentInterestType,
                HomeIsCustomer = userData.HomeIsCustomer,
                HomeSecondPower = userData.HomeSecondPower,
                HomeInterestType = userData.HomeInterestType,
                HomeCounterType = userData.HomeCounterType,
                BusinessInterestType = userData.BusinessInterestType
            };

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                TempData.Remove("UserData");
                return RedirectToAction("Onboarding");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Step1(int selectedPlanId, string AppartmentIsCustomer = "", string AppartmentInterestType = "", 
            string HomeIsCustomer = "", string HomeSecondPower = "", string HomeInterestType = "", string HomeCounterType = "",
            string BusinessInterestType = "")
        {
                        var user = TempData.Get<ApplicationUser>("UserData") ?? new ApplicationUser();
            user.SelectedPlanId = selectedPlanId;
            user.AppartmentIsCustomer = AppartmentIsCustomer;
            user.AppartmentInterestType = AppartmentInterestType;
            user.HomeIsCustomer = HomeIsCustomer;
            user.HomeSecondPower = HomeSecondPower;
            user.HomeInterestType = HomeInterestType;
            user.HomeCounterType = HomeCounterType;
            user.BusinessInterestType = BusinessInterestType;
            TempData.Put("UserData", user);
            return RedirectToAction(PageNames.Packages);
        }

        [HttpPost]
        public IActionResult Step2(int selectedPackageId)
        {
                        var user = TempData.Get<ApplicationUser>("UserData") ?? new ApplicationUser();
            user.PackageId = selectedPackageId;
            TempData.Put("UserData", user);

            return RedirectToAction(PageNames.Warenty);
        }

        [HttpPost]
        public IActionResult Step3(int warentyInfo, int AgreedSupplyPower)
        {
                        var user = TempData.Get<ApplicationUser>("UserData") ?? new ApplicationUser();
            user.warentyInfo = warentyInfo;
            user.AgreedSupplyPower = AgreedSupplyPower;
            TempData.Put("UserData", user);

            return RedirectToAction(PageNames.Documents);
        }
        
        private HomeIndexViewModel CreateHomeIndexViewModel()
        {
            return new HomeIndexViewModel
            {
                Cards = new List<HomeCardViewModel>
                {
                    new HomeCardViewModel { Id = 1, Title = "Home", ImagePath = "~/images/home.png" },
                    new HomeCardViewModel { Id = 2, Title = "The business", ImagePath = "~/images/company.png" },
                    new HomeCardViewModel { Id = 3, Title = "Common area of an apartment building", ImagePath = "~/images/apartment.png" }
                }
            };
        }
    }
}
