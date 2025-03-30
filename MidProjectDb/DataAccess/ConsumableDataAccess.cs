using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    class ConsumableDataAccess
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public List<Consumable> GetAllConsumables()
        {
            List<Consumable> consumables = new List<Consumable>();
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT consumable_id, item_name FROM consumables";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Consumable item = new Consumable
                            {
                                ConsumableId = reader.GetInt32("consumable_id"),
                                ItemName = reader.GetString("item_name")
                            };
                            consumables.Add(item);
                        }
                    }
                }
            }
            return consumables;
        }

        public bool InsertConsumable(Consumable consumable)
        {
            bool result = false;
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO consumables (item_name) VALUES (@item_name)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@item_name", consumable.ItemName);
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public bool UpdateConsumable(Consumable consumable)
        {
            bool result = false;
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE consumables SET item_name = @item_name WHERE consumable_id = @consumable_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@item_name", consumable.ItemName);
                    cmd.Parameters.AddWithValue("@consumable_id", consumable.ConsumableId);
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public bool DeleteConsumable(int consumableId)
        {
            bool result = false;
            using (MySqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM consumables WHERE consumable_id = @consumable_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@consumable_id", consumableId);
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}
