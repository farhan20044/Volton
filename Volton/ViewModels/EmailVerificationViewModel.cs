using System.ComponentModel.DataAnnotations;

namespace Volton.ViewModels
{
    public class EmailVerificationViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
    }
} 