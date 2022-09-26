using DMART.Models;

namespace DMART.Models.Interfaces
{
    public interface IUserRepository
    {
        public int RegisterUser(User user);
        public List<User> ViewUsers();
        public bool validateNewUser(User user);
        public bool validateLogin(User user);
        public string GetUserByEmail(string email);

    }
}
