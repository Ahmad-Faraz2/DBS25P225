using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    class ProjectDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT project_id, title, description FROM projects";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Project project = new Project
                            {
                                ProjectId = reader.GetInt32("project_id"),
                                Title = reader.GetString("title"),
                                Description = reader.GetString("description")
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
