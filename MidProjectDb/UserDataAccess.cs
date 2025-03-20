using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class UserDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public bool ValidateUser(string username, string password)
        {
            bool isValid = false;
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username=@username AND password_hash=SHA2(@password, 256)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    isValid = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            return isValid;
        }
    }
}
