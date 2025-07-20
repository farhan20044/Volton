using System.ComponentModel.DataAnnotations;
using Volton.Constants;

namespace Volton.ViewModels
{
    public class WarrantyViewModel
    {
        [Display(Name = "Previous Supplier Warranty")]
        [Range(0, int.MaxValue, ErrorMessage = ValidationMessages.NegativeValueError)]
        public int? warentyInfo { get; set; }

        public int? AgreedSupplyPower { get; set; }
    }
}
