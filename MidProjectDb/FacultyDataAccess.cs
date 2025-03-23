using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MidProjectDb
{
    public class FacultyDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public List<Faculty> GetAllFaculty()
        {
            List<Faculty> faculties = new List<Faculty>();
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT faculty_id, name, email, contact, designation_id, research_area, total_teaching_hours, user_id FROM faculty";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Faculty f = new Faculty
                            {
                                FacultyId = reader.GetInt32("faculty_id"),
                                Name = reader.GetString("name"),
                                Email = reader.GetString("email"),
                                Contact = reader.GetString("contact"),
                                DesignationId = reader.GetInt32("designation_id"),
                                ResearchInterests = reader["research_area"].ToString(),
                                TotalTeachingHours = reader.GetInt32("total_teaching_hours"),
                                UserId = reader.GetInt32("user_id")
                            };
                            faculties.Add(f);
                        }
                    }
                }
            }
            return faculties;
        }
        public bool InsertFaculty(Faculty faculty)
        {
            bool result = false;
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO faculty (name, email, contact, designation_id, research_area, total_teaching_hours, user_id) " +
                               "VALUES (@name, @email, @contact, @designation_id, @research_area, @total_teaching_hours, @user_id)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", faculty.Name);
                    cmd.Parameters.AddWithValue("@email", faculty.Email);
                    cmd.Parameters.AddWithValue("@contact", faculty.Contact);
                    cmd.Parameters.AddWithValue("@designation_id", faculty.DesignationId);
                    cmd.Parameters.AddWithValue("@research_area", faculty.ResearchInterests);
                    cmd.Parameters.AddWithValue("@total_teaching_hours", faculty.TotalTeachingHours);
                    cmd.Parameters.AddWithValue("@user_id", faculty.UserId);

                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public bool UpdateFaculty(Faculty faculty)
        {
            bool result = false;
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                
                string query = "UPDATE faculty SET name = @name, email = @email, contact = @contact, " +
                               "designation_id = @designation_id, research_area = @research_area, total_teaching_hours = @total_teaching_hours, user_id = @user_id " +
                               "WHERE faculty_id = @faculty_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@faculty_id", faculty.FacultyId);
                    cmd.Parameters.AddWithValue("@name", faculty.Name);
                    cmd.Parameters.AddWithValue("@email", faculty.Email);
                    cmd.Parameters.AddWithValue("@contact", faculty.Contact);
                    cmd.Parameters.AddWithValue("@designation_id", faculty.DesignationId);
                    cmd.Parameters.AddWithValue("@research_area", faculty.ResearchInterests);
                    cmd.Parameters.AddWithValue("@total_teaching_hours", faculty.TotalTeachingHours);
                    cmd.Parameters.AddWithValue("@user_id", faculty.UserId);

                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public bool DeleteFaculty(int facultyId)
        {
            bool result = false;
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                
                string query = "DELETE FROM faculty WHERE faculty_id = @faculty_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@faculty_id", facultyId);
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}
