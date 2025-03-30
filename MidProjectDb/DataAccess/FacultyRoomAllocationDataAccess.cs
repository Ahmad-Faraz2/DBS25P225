using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class FacultyRoomAllocationDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public bool InsertAllocation(FacultyRoomAllocation allocation)
        {
            bool result = false;
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO faculty_room_allocations (faculty_id, room_id, reserved_hours, semester_id) " +
                               "VALUES (@faculty_id, @room_id, @reserved_hours, @semester_id)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@faculty_id", allocation.FacultyId);
                    cmd.Parameters.AddWithValue("@room_id", allocation.RoomId);
                    cmd.Parameters.AddWithValue("@reserved_hours", allocation.ReservedHours);
                    cmd.Parameters.AddWithValue("@semester_id", allocation.SemesterId);
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public List<FacultyRoomAllocation> GetAllAllocations()
        {
            List<FacultyRoomAllocation> allocations = new List<FacultyRoomAllocation>();
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT fra.allocation_id, fra.faculty_id, fra.room_id, fra.reserved_hours, fra.semester_id,
                           r.room_name
                    FROM faculty_room_allocations fra
                    JOIN rooms r ON fra.room_id = r.room_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FacultyRoomAllocation allocation = new FacultyRoomAllocation
                            {
                                AllocationId = reader.GetInt32("allocation_id"),
                                FacultyId = reader.GetInt32("faculty_id"),
                                RoomId = reader.GetInt32("room_id"),
                                ReservedHours = reader.GetInt32("reserved_hours"),
                                SemesterId = reader.GetInt32("semester_id"),
                                RoomName = reader.GetString("room_name")
                            };
                            allocations.Add(allocation);
                        }
                    }
                }
            }
            return allocations;
        }
    }
}
