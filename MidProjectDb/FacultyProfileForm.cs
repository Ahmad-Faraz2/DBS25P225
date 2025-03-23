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
    public partial class FacultyProfileForm: Form
    {
        private FacultyService facultyService = new FacultyService();
        public FacultyProfileForm()
        {
            InitializeComponent();
        }

        public void LoadFaculty(Faculty faculty)
        {
            txtFacultyId.Text = faculty.FacultyId.ToString();
            txtName.Text = faculty.Name;
            txtEmail.Text = faculty.Email;
            txtContact.Text = faculty.Contact;
            txtDesignationId.Text = faculty.DesignationId.ToString();
            txtResearchInterests.Text = faculty.ResearchInterests;
            txtTeachingHours.Text = faculty.TotalTeachingHours.ToString();
            txtUserId.Text = faculty.UserId.ToString();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FacultyProfileForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDesignationId.Text.Trim(), out int designationId))
            {
                MessageBox.Show("Please enter a valid Designation ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtTeachingHours.Text.Trim(), out int teachingHours))
            {
                MessageBox.Show("Please enter a valid number for Teaching Hours.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtUserId.Text.Trim(), out int userId))
            {
                MessageBox.Show("Please enter a valid User ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Faculty newFaculty = new Faculty
            {
                // FacultyId is auto-generated, so it's not set here.
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
                MessageBox.Show("Faculty profile saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error saving faculty profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
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
