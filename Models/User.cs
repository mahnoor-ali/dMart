using System.ComponentModel.DataAnnotations;

namespace DMART.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field can't be empty")]
        [StringLength(25)]
        public string Name { get; set; }

        [Required(ErrorMessage = " Email field can't be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(15, ErrorMessage = "Must be between 6 and 15 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(15, ErrorMessage = "Must be between 6 and 15 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        public string ConfirmPass { get; set; }

        [Required(ErrorMessage = "Please enter contact no.")]
        [StringLength(11, ErrorMessage = "Number must be 11 characters long")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        [StringLength(50, ErrorMessage = "Must be between 10 and 50 characters", MinimumLength = 10)]
        public string Address { get; set; }


        public User()
        {
        }
        public User(string nam, string address , string email, string pw, string confirmPw, string num)
        {
            Name= nam;
            Email= email;
            Password= pw;
            ConfirmPass= confirmPw;
            Number= num;
            Address = address;
        }
        public User(string email, string pw)
        {
            Email= email;
            Password = pw;
        }
    }
}
