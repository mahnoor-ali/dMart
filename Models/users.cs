using System.ComponentModel.DataAnnotations;

namespace dMart.Models
{
    public class users
    {
        [Required(ErrorMessage = "Name field can't be empty")]
        [StringLength(25)]
        public string Username { get; set; }

        [Required(ErrorMessage = " Email field can't be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }

        [Required (ErrorMessage = "Please repeat password")]
        public string ConfirmPass { get; set; }

        [Required(ErrorMessage = "Please enter contact no.")]
        public string Number { get; set; }

        public users()
        {
        }
        public users(string user, string email, string pw, string confirmPw, string num)
        {
            Username= user;
            Email= email;
            Password= pw;
            ConfirmPass= confirmPw;
            Number= num;
        }
        public users(string email, string pw)
        {
            Email= email;
            Password = pw;
        }
    }
}
