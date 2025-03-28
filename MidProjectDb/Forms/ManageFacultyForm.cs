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
    public partial class ManageFaculty: Form
    {
        private FacultyService facultyService = new FacultyService();
        public ManageFaculty()
        {
            InitializeComponent();
        }
        private void LoadFacultyGrid()
        {
            List<Faculty> faculties = facultyService.GetAllFaculty();
            dgvFaculty.DataSource = faculties;
        }
        private void LoadDesignations()
        {
            try
            {
                List<KeyValuePair<int, string>> designations = new List<KeyValuePair<int, string>>();
                using (MySqlConnection conn = new DatabaseHelper().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT lookup_id, value FROM lookup WHERE category = 'Designations'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("lookup_id");
                                string val = reader.GetString("value");
                                designations.Add(new KeyValuePair<int, string>(id, val));
                            }
                        }
                    }
                }
                cmbDesignation.DataSource = new BindingSource(designations, null);
                cmbDesignation.DisplayMember = "Value";
                cmbDesignation.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading designations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ManageFaculty_Load(object sender, EventArgs e)
        {
            LoadFacultyGrid();
            LoadDesignations();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDesignation_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtResearchInterests_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFaculty.CurrentRow != null)
            {
                Faculty selectedFaculty = dgvFaculty.CurrentRow.DataBoundItem as Faculty;
                if (selectedFaculty != null)
                {
                    if (MessageBox.Show("Are you sure you want to delete this faculty?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool result = facultyService.DeleteFaculty(selectedFaculty.FacultyId);
                        if (result)
                        {
                            MessageBox.Show("Faculty deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            LoadFacultyGrid();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete faculty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a faculty to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboardForm adminDashboard = new AdminDashboardForm();
            adminDashboard.Show();
            this.Close();
        }
        private void ClearFields()
        {
            txtFacultyId.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtContact.Clear();
            if (cmbDesignation.Items.Count > 0)
            {
                cmbDesignation.SelectedIndex = 0;
            }
            txtResearchInterests.Clear();
            txtTeachingHours.Clear();
            txtUserId.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Name and Email are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtTeachingHours.Text.Trim(), out int teachingHours))
            {
                MessageBox.Show("Please enter valid Teaching Hours.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? userId = null;
            if (int.TryParse(txtUserId.Text.Trim(), out int parsedUserId))
            {
                userId = parsedUserId;
            }

            int designationId = (int)cmbDesignation.SelectedValue;

            Faculty newFaculty = new Faculty
            {
                Name = txtName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Contact = txtContact.Text.Trim(),
                DesignationId = designationId,
                ResearchInterests = txtResearchInterests.Text.Trim(),
                TotalTeachingHours = teachingHours,
                UserId = userId
            };

            bool result = facultyService.SaveFaculty(newFaculty);
            if (result)
            {
                MessageBox.Show("Faculty saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadFacultyGrid();
            }
            else
            {
                MessageBox.Show("Failed to save faculty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFacultyId.Text))
            {
                MessageBox.Show("Please select a faculty record to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Name and Email are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtTeachingHours.Text.Trim(), out int teachingHours))
            {
                MessageBox.Show("Please enter valid Teaching Hours.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int facultyId = int.Parse(txtFacultyId.Text);
            int designationId = (int)cmbDesignation.SelectedValue;

            int? userId = null;
            if (int.TryParse(txtUserId.Text.Trim(), out int parsedUserId))
            {
                userId = parsedUserId;
            }

            Faculty updatedFaculty = new Faculty
            {
                FacultyId = facultyId,
                Name = txtName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Contact = txtContact.Text.Trim(),
                ResearchInterests = txtResearchInterests.Text.Trim(),
                TotalTeachingHours = teachingHours,
                DesignationId = designationId,
                UserId = userId
            };

            bool result = facultyService.UpdateFaculty(updatedFaculty);
            if (result)
            {
                MessageBox.Show("Faculty updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFacultyGrid();
            }
            else
            {
                MessageBox.Show("Failed to update faculty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFaculty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFaculty.CurrentRow != null)
            {
                Faculty selectedFaculty = dgvFaculty.CurrentRow.DataBoundItem as Faculty;
                if (selectedFaculty != null)
                {
                    txtFacultyId.Text = selectedFaculty.FacultyId.ToString();
                    txtName.Text = selectedFaculty.Name;
                    txtEmail.Text = selectedFaculty.Email;
                    txtContact.Text = selectedFaculty.Contact;
                    if (selectedFaculty.DesignationId.HasValue)
                        cmbDesignation.SelectedValue = selectedFaculty.DesignationId.Value;
                    else
                        cmbDesignation.SelectedIndex = 0;
                    txtResearchInterests.Text = selectedFaculty.ResearchInterests;
                    txtTeachingHours.Text = selectedFaculty.TotalTeachingHours.HasValue ? selectedFaculty.TotalTeachingHours.Value.ToString() : "";
                    txtUserId.Text = selectedFaculty.UserId.HasValue ? selectedFaculty.UserId.Value.ToString() : "";
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
