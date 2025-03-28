using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class FacultyRequestDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public bool InsertRequest(FacultyRequest request)
        {
            bool result = false;
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO faculty_requests (faculty_id, item_id, quantity, status_id, request_date) " +
                               "VALUES (@faculty_id, @item_id, @quantity, @status_id, @request_date)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@faculty_id", request.FacultyId);
                    cmd.Parameters.AddWithValue("@item_id", request.ItemId);
                    cmd.Parameters.AddWithValue("@quantity", request.Quantity);
                    cmd.Parameters.AddWithValue("@status_id", request.StatusId);
                    cmd.Parameters.AddWithValue("@request_date", request.RequestDate);
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public List<FacultyRequest> GetRequestsByFaculty(int facultyId)
        {
            List<FacultyRequest> requests = new List<FacultyRequest>();
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT request_id, faculty_id, item_id, quantity, status_id, request_date " +
                               "FROM faculty_requests WHERE faculty_id = @faculty_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@faculty_id", facultyId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FacultyRequest req = new FacultyRequest
                            {
                                RequestId = reader.GetInt32("request_id"),
                                FacultyId = reader.GetInt32("faculty_id"),
                                ItemId = reader.GetInt32("item_id"),
                                Quantity = reader.GetInt32("quantity"),
                                StatusId = reader.GetInt32("status_id"),
                                RequestDate = reader.GetDateTime("request_date")
                            };
                            requests.Add(req);
                        }
                    }
                }
            }
            return requests;
        }
    }
}
