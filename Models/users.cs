namespace dMart.Models
{
    public class users
    {

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPass { get; set; }
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
