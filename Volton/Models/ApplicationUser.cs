using Microsoft.AspNetCore.Identity;

namespace Volton.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int SelectedPlanId { get; set; } 
        public int PackageId { get; set; } 
        public int AgreedSupplyPower { get; set; }
        public int warentyInfo { get; set; }
        
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
