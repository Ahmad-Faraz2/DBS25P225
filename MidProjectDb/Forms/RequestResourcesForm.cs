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
    public partial class RequestResourcesForm : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private int facultyId;
        public RequestResourcesForm(int facultyId)
        {
            InitializeComponent();
            this.facultyId = facultyId;
        }

        private void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            if (cmbConsumables.SelectedItem == null || string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please select a consumable and enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid numeric quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int consumableId = ((KeyValuePair<int, string>)cmbConsumables.SelectedItem).Key;

            try
            {
                using (MySqlConnection conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO resource_requests (faculty_id, consumable_id, quantity, status) VALUES (@faculty_id, @consumable_id, @quantity, 'Pending')";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@faculty_id", facultyId);
                        cmd.Parameters.AddWithValue("@consumable_id", consumableId);
                        cmd.Parameters.AddWithValue("@quantity", quantity);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Resource request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to submit request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RequestResourcesForm_Load(object sender, EventArgs e)
        {
            LoadConsumables();
        }
        private void LoadConsumables()
        {
            try
            {
                List<KeyValuePair<int, string>> consumables = new List<KeyValuePair<int, string>>();
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
                                int id = reader.GetInt32("consumable_id");
                                string name = reader.GetString("item_name");
                                consumables.Add(new KeyValuePair<int, string>(id, name));
                            }
                        }
                    }
                }
                cmbConsumables.DataSource = new BindingSource(consumables, null);
                cmbConsumables.DisplayMember = "Value";
                cmbConsumables.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading consumables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            if (cmbConsumables.Items.Count > 0)
            {
                cmbConsumables.SelectedIndex = 0;
            }
            txtQuantity.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FacultyDashboardForm facultyDashboard = new FacultyDashboardForm();
            facultyDashboard.Show();
            this.Close();
        }
    }
}
