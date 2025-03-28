using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MidProjectDb
{
    public class UserService
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private UserDataAccess userDataAccess = new UserDataAccess();

        public bool AuthenticateUser(string username, string password)
        {
            return userDataAccess.ValidateUser(username, password);
        }
        public User AuthenticateUserAndGetUser(string username, string password)
        {
            return userDataAccess.GetUserByCredentials(username, password);
        }

        public bool RegisterUser(User user)
        {
            return userDataAccess.InsertUser(user);
        }
        public User GetUserByEmail(string email)
        {
            User user = null;
            try
            {
                using (MySqlConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT user_id, username, email, role_id FROM users WHERE email = @email";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User
                                {
                                    UserId = reader.GetInt32("user_id"),
                                    Username = reader.GetString("username"),
                                    Email = reader.GetString("email"),
                                    RoleId = reader.GetInt32("role_id")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
                throw new Exception("Error retrieving user by email: " + ex.Message, ex);
            }
            return user;
        }
    }
}
