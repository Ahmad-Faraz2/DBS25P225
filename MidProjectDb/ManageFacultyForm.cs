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
            LoadFacultyGrid();
        }
        private void LoadFacultyGrid()
        {
            List<Faculty> faculties = facultyService.GetAllFaculty();
            dgvFaculty.DataSource = faculties;
        }

        private void ManageFaculty_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate required fields.
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Name and Email are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate numeric fields.
            if (!int.TryParse(txtDesignationId.Text.Trim(), out int designationId))
            {
                MessageBox.Show("Please enter a valid Designation ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtTeachingHours.Text.Trim(), out int teachingHours))
            {
                MessageBox.Show("Please enter valid Teaching Hours.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtUserId.Text.Trim(), out int userId))
            {
                MessageBox.Show("Please enter a valid User ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a new Faculty object using values from the form.
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

        private void dgvFaculty_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    txtDesignationId.Text = selectedFaculty.DesignationId.ToString();
                    txtResearchInterests.Text = selectedFaculty.ResearchInterests;
                    txtTeachingHours.Text = selectedFaculty.TotalTeachingHours.ToString();
                    txtUserId.Text = selectedFaculty.UserId.ToString();
                }
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
            txtDesignationId.Clear();
            txtResearchInterests.Clear();
            txtTeachingHours.Clear();
            txtUserId.Clear();
        }
    }
}
