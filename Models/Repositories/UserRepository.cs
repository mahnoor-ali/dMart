using DMART.Models;
using Microsoft.Data.SqlClient;
using DMART.Models.Interfaces;

namespace DMART.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DMARTContext context;

        public UserRepository()
        {
            context = new DMARTContext();
        }

        //signup new user and create its account in database
        public int RegisterUser(User user)
        {
            context.UserAccounts.Add(user);
            context.SaveChanges();
            return user.Id;
        }

        //view all users accounts
        public List<User> ViewUsers()
        {
             List<User> users = context.UserAccounts.ToList();
             return users;
        }

        //validate that a user account doesn't exist with same email or phone no
        public bool validateNewUser(User user)
        {
           var userDetail = context.UserAccounts.Where(_user => _user.Number.Equals(user.Number) && _user.Email.Equals(user.Email));
           if (userDetail.Any()) //if user with this number or email already exist, don't register him as new user
            {
                return false;
            }
            return true;
        }

        //verify email and password for login
        public bool validateLogin(User user)
        {
            var userDetail = context.UserAccounts.Where(_user => _user.Email.Equals(user.Email) && _user.Password.Equals(user.Password));
            if (userDetail.Count()==1) //if user is found
            {
                return true;
            } 
            return false;
        }

        
        //get user details by email
        public string GetUserByEmail(string email)
        {
            User user = context.UserAccounts.First(user => user.Email.Equals(email));
            return user.Name;
        }
    }
}
