namespace Volton.Models
{
    public class Customer
    {
                public int Id { get; set; }
        public string? UserId { get; set; }
        public string Preference { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string EnergySelection { get; set; } = string.Empty;
        public int EnergySelectionId { get; set; }
        public int SelectedPlanId { get; set; } 
        public string SelectedPlan { get; set; } = string.Empty;
        public string PropertyType { get; set; } = string.Empty;
        public int PackageId { get; set; } 
        public string SelectedPackage { get; set; } = string.Empty;
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
