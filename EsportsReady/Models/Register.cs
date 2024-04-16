using System.ComponentModel.DataAnnotations;

namespace EsportsReady.Models
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords must match!")]
        public string ConfirmPassword { get; set; }
    }
}
