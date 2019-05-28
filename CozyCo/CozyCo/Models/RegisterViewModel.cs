using System.ComponentModel.DataAnnotations;

namespace CozyCo.WebUI.Models
{
    public class RegisterViewModel
    {
        [EmailAddress, Required]
        public string Email { get; set; }

        [DataType(DataType.Password), Required]
        public string Password { get; set; }

        [DataType(DataType.Password), Required]
        [Compare("Password", ErrorMessage = "Make sure your passwords match.")]
        public string ConfirmPassword { get; set; }
    }
}