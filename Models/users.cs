using System.ComponentModel.DataAnnotations;

namespace dMart.Models
{
    public class users
    {
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(25)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }

        [Required (ErrorMessage = "Please repeat password")]
        public string ConfirmPass { get; set; }

        [Required(ErrorMessage = "Please enter your contact number")]
        [Range(11,12)]
        public int Number { get; set; }

        public users()
        {
        }
        public users(string user, string email, string pw, string confirmPw, int num)
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
