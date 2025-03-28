using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

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
            try
            {
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
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("The username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error inserting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string query = @"
            SELECT u.user_id, u.role_id, u.username, u.email,
                   f.faculty_id 
            FROM users u
            LEFT JOIN faculty f ON u.user_id = f.user_id
            WHERE u.username = @username AND u.password_hash = @password";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserId = reader.GetInt32("user_id"),
                                RoleId = reader.GetInt32("role_id"),
                                Username = reader.GetString("username"),
                                Email = reader.GetString("email"),
                                FacultyId = reader["faculty_id"] != DBNull.Value ? (int?)reader["faculty_id"] : null
                            };
                        }
                    }
                }
            }
            return user;
        }
    }
}
