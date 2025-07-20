using System.Collections.Generic;

namespace Volton.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<HomeCardViewModel> Cards { get; set; } = new List<HomeCardViewModel>();
        public int? SelectedPlanId { get; set; }
        public int? SelectedEnergyId { get; set; }
        
        // Apartment content choices
        public string AppartmentIsCustomer { get; set; } = string.Empty;
        public string AppartmentInterestType { get; set; } = string.Empty;
        
        // Home content choices
        public string HomeIsCustomer { get; set; } = string.Empty;
        public string HomeSecondPower { get; set; } = string.Empty;
        public string HomeInterestType { get; set; } = string.Empty;
        public string HomeCounterType { get; set; } = string.Empty;
        
        // Business content choices
        public string BusinessInterestType { get; set; } = string.Empty;
    }
} 