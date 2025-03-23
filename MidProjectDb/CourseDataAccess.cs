using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    class CourseDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT course_id, course_name, course_type, credit_hours, contact_hours FROM courses";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Course course = new Course
                            {
                                CourseId = reader.GetInt32("course_id"),
                                CourseName = reader.GetString("course_name"),
                                CourseType = reader.GetString("course_type"),
                                CreditHours = reader.GetInt32("credit_hours"),
                                ContactHours = reader.GetInt32("contact_hours")
                            };
                            courses.Add(course);
                        }
                    }
                }
            }
            return courses;
        }
    }
}
