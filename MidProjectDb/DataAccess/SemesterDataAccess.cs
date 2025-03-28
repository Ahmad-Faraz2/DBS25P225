using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    class SemesterDataAccess
    {  
           private DatabaseHelper dbHelper = new DatabaseHelper();

           public List<Semester> GetAllSemesters()
            {
                List<Semester> semesters = new List<Semester>();
                using (MySqlConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT semester_id, term, year FROM semesters";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Semester sem = new Semester
                                {
                                    SemesterId = reader.GetInt32("semester_id"),
                                    Term = reader.GetString("term"),
                                    Year = reader.GetInt32("year")
                                };
                                semesters.Add(sem);
                            }
                        }
                    }
                }
                return semesters;
            }
    }
}
