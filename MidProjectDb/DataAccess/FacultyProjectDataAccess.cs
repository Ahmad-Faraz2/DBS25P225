using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    class FacultyProjectDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public bool InsertFacultyProject(FacultyProject project)
        {
            bool result = false;
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO faculty_projects (faculty_id, project_id, semester_id, supervision_hours) " +
                               "VALUES (@faculty_id, @project_id, @semester_id, @supervision_hours)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@faculty_id", project.FacultyId);
                    cmd.Parameters.AddWithValue("@project_id", project.ProjectId);
                    cmd.Parameters.AddWithValue("@semester_id", project.SemesterId);
                    cmd.Parameters.AddWithValue("@supervision_hours", project.SupervisionHours);
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public List<FacultyProject> GetAllFacultyProjects()
        {
            List<FacultyProject> projects = new List<FacultyProject>();
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT fp.faculty_project_id, fp.faculty_id, fp.project_id, fp.semester_id, fp.supervision_hours,
                           p.title AS ProjectTitle,
                           CONCAT(s.term, ' ', s.year) AS DisplayTerm
                    FROM faculty_projects fp
                    JOIN projects p ON fp.project_id = p.project_id
                    JOIN semesters s ON fp.semester_id = s.semester_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FacultyProject project = new FacultyProject
                            {
                                FacultyProjectId = reader.GetInt32("faculty_project_id"),
                                FacultyId = reader.GetInt32("faculty_id"),
                                ProjectId = reader.GetInt32("project_id"),
                                SemesterId = reader.GetInt32("semester_id"),
                                SupervisionHours = reader["supervision_hours"] != DBNull.Value ? reader.GetInt32("supervision_hours") : 0,
                                ProjectTitle = reader.GetString("ProjectTitle"),
                                DisplayTerm = reader.GetString("DisplayTerm")
                            };
                            projects.Add(project);
                        }
                    }
                }
            }
            return projects;
        }
    }
}
