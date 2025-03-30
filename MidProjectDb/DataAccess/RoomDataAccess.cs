using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class RoomDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT room_id, room_name, room_type, capacity FROM rooms";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Room room = new Room
                            {
                                RoomId = reader.GetInt32("room_id"),
                                RoomName = reader.GetString("room_name"),
                                RoomType = reader.GetString("room_type"),
                                Capacity = reader.GetInt32("capacity")
                            };
                            rooms.Add(room);
                        }
                    }
                }
            }
            return rooms;
        }
    }
}
