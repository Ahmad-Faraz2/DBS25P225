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
    public partial class RoleSelectionForm: Form
    {
        public RoleSelectionForm()
        {
            InitializeComponent();

            cmbRoles.DataSource = new string[] { "Department Head", "Faculty", "Admin" };
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void txtEmailOrUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void btnSelectRole_Click(object sender, EventArgs e)
        {
            string selectedRole = cmbRoles.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please select a role to continue.", "Role Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Redirect based on the selected role.
            //if (selectedRole == "Department Head")
            //{
            //    DeptHeadDashboardForm dashboard = new DeptHeadDashboardForm();
            //    dashboard.Show();
            //}
            else if (selectedRole == "Faculty")
            {
                FacultyDashboardForm dashboard = new FacultyDashboardForm();
                dashboard.Show();
            }
            else if (selectedRole == "Admin")
            {
                AdminDashboardForm dashboard = new AdminDashboardForm();
                dashboard.Show();
            }

            this.Hide(); // Hide the Role Selection Form.
        }

        private void RoleSelectionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
