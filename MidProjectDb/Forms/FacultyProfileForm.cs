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
    public partial class FacultyProfileForm: Form
    {
        private FacultyService facultyService = new FacultyService();
        public FacultyProfileForm()
        {
            InitializeComponent();
        }
        private void LoadFacultyGrid()
        {
            if (LoggedInUser.FacultyId != null)
            {
                Faculty faculty = facultyService.GetFacultyById(LoggedInUser.FacultyId.Value);
                if (faculty != null)
                {
                    List<Faculty> list = new List<Faculty> { faculty };
                    dgvFaculty.DataSource = list;
                }
                else
                {
                    dgvFaculty.DataSource = null;
                }
            }
            else
            {
                dgvFaculty.DataSource = null;
                MessageBox.Show("No faculty record exists. Please update your profile.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void LoadFaculty(Faculty faculty)
        {
            txtFacultyId.Text = faculty.FacultyId.ToString();
            txtName.Text = faculty.Name;
            txtEmail.Text = faculty.Email;
            txtContact.Text = faculty.Contact;
            if (faculty.DesignationId.HasValue)
            {
                cmbDesignation.SelectedValue = faculty.DesignationId.Value;
            }
            else
            {
                cmbDesignation.SelectedIndex = 0;
            }

            txtResearchInterests.Text = faculty.ResearchInterests;
            txtTeachingHours.Text = faculty.TotalTeachingHours.ToString();
            txtUserId.Text = faculty.UserId.ToString();
        }
        private void LoadFacultyData()
        {
            if (LoggedInUser.FacultyId == null)
            {
                MessageBox.Show("No faculty record available for this user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Faculty faculty = facultyService.GetFacultyById(LoggedInUser.FacultyId.Value);
            if (faculty != null)
            {
                LoadFaculty(faculty);
            }
            else
            {
                MessageBox.Show("Faculty record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            LoadDesignations();
            LoadFacultyGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Name and Email are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? teachingHours = null;
            if (!string.IsNullOrWhiteSpace(txtTeachingHours.Text))
            {
                if (int.TryParse(txtTeachingHours.Text.Trim(), out int hours))
                {
                    teachingHours = hours;
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for Total Teaching Hours.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int designationId = (int)cmbDesignation.SelectedValue;

            int? userId = null;
            if (int.TryParse(txtUserId.Text.Trim(), out int parsedUserId))
            {
                userId = parsedUserId;
            }

            Faculty facultyRecord = new Faculty
            {
                Name = txtName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Contact = txtContact.Text.Trim(),
                ResearchInterests = txtResearchInterests.Text.Trim(),
                TotalTeachingHours = teachingHours,
                DesignationId = designationId,
                UserId = userId
            };

            bool result;
            if (string.IsNullOrWhiteSpace(txtFacultyId.Text))
            {
                result = facultyService.SaveFaculty(facultyRecord);
                if (result)
                {
                    MessageBox.Show("Faculty record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                facultyRecord.FacultyId = int.Parse(txtFacultyId.Text);
                result = facultyService.UpdateFaculty(facultyRecord);
                if (result)
                {
                    MessageBox.Show("Faculty profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (!result)
            {
                MessageBox.Show("Error saving faculty record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadFacultyGrid();

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtContact.Clear();
            txtResearchInterests.Clear();
            txtTeachingHours.Clear();
            txtUserId.Clear();
            if (cmbDesignation.Items.Count > 0)
            {
                cmbDesignation.SelectedIndex = 0;
            }
        }

        private void cmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FacultyDashboardForm facultyDashboard = new FacultyDashboardForm();
            facultyDashboard.Show();
            this.Close();
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
                    // Set designation using the ComboBox.
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
    }
}
