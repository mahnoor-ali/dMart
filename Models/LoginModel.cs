using System.ComponentModel.DataAnnotations;

namespace DMART.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = " Email field can't be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(15, ErrorMessage = "Must be between 6 and 15 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
