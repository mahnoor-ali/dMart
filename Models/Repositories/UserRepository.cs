using dMart.Models;
using Microsoft.Data.SqlClient;
using DMART.Models.Interfaces;

namespace DMART.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        const string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pharmaCare;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //signup new user and create its account in database
        public void RegisterUser(users user)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlParameter p1 = new SqlParameter("u", user.Username);
            SqlParameter p2 = new SqlParameter("e", user.Email);
            SqlParameter p3 = new SqlParameter("phone", user.Number);
            SqlParameter p4 = new SqlParameter("pw", user.Password);
            string query = "INSERT INTO Users(username,email,phone,password) VALUES (@u, @e, @phone, @pw)";
            SqlCommand comand = new SqlCommand(query, con);
            comand.Parameters.Add(p1);
            comand.Parameters.Add(p2);
            comand.Parameters.Add(p3);
            comand.Parameters.Add(p4);
            comand.ExecuteNonQuery();
            con.Close();
        }

        //view all users accounts
        public List<users> ViewUsers()
        {
            List<users> usersList = new List<users>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = "SELECT * FROM Users";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                users user = new users();
                user.Username = dr.GetString(1);
                user.Email = dr.GetString(2);
                user.Number = dr.GetString(3);
                usersList.Add(user);
            }
            con.Close();
            return usersList;
        }

        //validate that a user account doesn't exist with same email or phone no
        public bool validateNewUser(users user)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlParameter p1 = new SqlParameter("n", user.Number);
            SqlParameter p2 = new SqlParameter("e", user.Email);
            string query = "SELECT * FROM Users WHERE email=@e OR phone=@n";
            SqlCommand comand = new SqlCommand(query, con);
            comand.Parameters.Add(p1);
            comand.Parameters.Add(p2);
            SqlDataReader dr = comand.ExecuteReader();
            while (dr.Read())
            {
                return false; //return false if user with this number or email already exist
            }
            return true; //return true if both number and email are not registered
        }

        //verify email and password for login
        public bool validateLogin(users user)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlParameter p1 = new SqlParameter("p", user.Password);
            SqlParameter p2 = new SqlParameter("e", user.Email);
            string query = "SELECT * FROM Users WHERE email=@e AND password=@p";
            SqlCommand comand = new SqlCommand(query, con);
            comand.Parameters.Add(p1);
            comand.Parameters.Add(p2);
            SqlDataReader dr = comand.ExecuteReader();
            while (dr.Read())
            {
                return true; //login sucessful
            }
            return false;
        }

    }
}
