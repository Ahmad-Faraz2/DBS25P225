using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidProjectDb
{
    public partial class ConsumablesInventoryForm: Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        public ConsumablesInventoryForm()
        {
            InitializeComponent();
        }

        private void InventoryManagementForm_Load(object sender, EventArgs e)
        {
            LoadConsumables();
        }
        private void LoadConsumables()
        {
            try
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
                dgvConsumables.DataSource = consumables;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading consumables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Please enter an item name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (MySqlConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO consumables (item_name) VALUES (@item_name)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@item_name", txtItemName.Text.Trim());
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Consumable added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            LoadConsumables();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add consumable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding consumable: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvConsumables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return; // Ignore header clicks

            DataGridViewRow row = dgvConsumables.Rows[e.RowIndex];
            txtConsumableId.Text = row.Cells["ConsumableId"].Value.ToString();
            txtItemName.Text = row.Cells["ItemName"].Value.ToString();
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConsumableId.Text))
            {
                MessageBox.Show("Please select a consumable to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Please enter an item name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (MySqlConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE consumables SET item_name = @item_name WHERE consumable_id = @consumable_id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@item_name", txtItemName.Text.Trim());
                        cmd.Parameters.AddWithValue("@consumable_id", int.Parse(txtConsumableId.Text));
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Consumable updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            LoadConsumables();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update consumable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating consumable: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConsumableId.Text))
            {
                MessageBox.Show("Please select a consumable to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (MySqlConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM consumables WHERE consumable_id = @consumable_id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@consumable_id", int.Parse(txtConsumableId.Text));
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Consumable deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            LoadConsumables();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete consumable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting consumable: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFields()
        {
            txtConsumableId.Clear();
            txtItemName.Clear();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboardForm adminDashboard = new AdminDashboardForm();
            adminDashboard.Show();
            this.Close();
        }
    }
}
