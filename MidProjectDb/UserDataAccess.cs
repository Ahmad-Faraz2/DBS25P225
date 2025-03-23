using MySql.Data.MySqlClient;
using System;

namespace MidProjectDb
{
    public class UserDataAccess
    {
        public bool ValidateUser(string username, string password)
        {
            bool isValid = false;
            using (MySqlConnection conn = new DatabaseHelper().GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username=@username AND password_hash=@password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    isValid = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            return isValid;
        }

        public bool InsertUser(User user)
        {
            bool result = false;
            using (MySqlConnection conn = new DatabaseHelper().GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO users (username, email, password_hash, role_id) " +
               "VALUES (@username, @email, @password, @role_id)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@role_id", user.RoleId);
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
        public User GetUserByCredentials(string username, string password)
        {
            User user = null;
            using (MySqlConnection conn = new DatabaseHelper().GetConnection())
            {
                conn.Open();
                string query = "SELECT user_id, username, email, role_id FROM users " +
                               "WHERE username=@username AND password_hash=@password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);  // assuming you removed hashing
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
            return user;
        }
    }
}
