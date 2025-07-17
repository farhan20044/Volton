namespace Volton.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Preference { get; set; } = string.Empty;
        public string warentyInfo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string SelectedPlan { get; set; } = string.Empty;
        public string PropertyType { get; set; } = string.Empty;
        public string SelectedPackage { get; set; } = string.Empty;
        public string AgreedSupplyPower { get; set; } = string.Empty;

    }
       
    
}
