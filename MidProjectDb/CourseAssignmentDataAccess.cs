using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    class CourseAssignmentDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public bool InsertAssignment(FacultyCourseAssignment assignment)
        {
            bool result = false;
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO faculty_courses (faculty_id, course_id, semester_id) " +
                               "VALUES (@faculty_id, @course_id, @semester_id)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@faculty_id", assignment.FacultyId);
                    cmd.Parameters.AddWithValue("@course_id", assignment.CourseId);
                    cmd.Parameters.AddWithValue("@semester_id", assignment.SemesterId);
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public bool UpdateAssignment(FacultyCourseAssignment assignment)
        {
            bool result = false;
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE faculty_courses SET faculty_id = @faculty_id, course_id = @course_id, " +
                               "semester_id = @semester_id WHERE faculty_course_id = @faculty_course_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@faculty_course_id", assignment.FacultyCourseId);
                    cmd.Parameters.AddWithValue("@faculty_id", assignment.FacultyId);
                    cmd.Parameters.AddWithValue("@course_id", assignment.CourseId);
                    cmd.Parameters.AddWithValue("@semester_id", assignment.SemesterId);
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public List<FacultyCourseAssignment> GetAllAssignments()
        {
            List<FacultyCourseAssignment> assignments = new List<FacultyCourseAssignment>();
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT faculty_course_id, faculty_id, course_id, semester_id FROM faculty_courses";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FacultyCourseAssignment assignment = new FacultyCourseAssignment
                            {
                                FacultyCourseId = reader.GetInt32("faculty_course_id"),
                                FacultyId = reader.GetInt32("faculty_id"),
                                CourseId = reader.GetInt32("course_id"),
                                SemesterId = reader.GetInt32("semester_id")
                            };
                            assignments.Add(assignment);
                        }
                    }
                }
            }
            return assignments;
        }
    }
}
