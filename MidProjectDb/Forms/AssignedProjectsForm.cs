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
    public partial class AssignedProjectsForm: Form
    {
        private FacultyProjectService facultyProjectService = new FacultyProjectService();
        public AssignedProjectsForm()
        {
            InitializeComponent();
        }

        private void AssignedProjectsForm_Load(object sender, EventArgs e)
        {
            LoadAssignedProjects();
        }
        private void LoadAssignedProjects()
        { 
            if (LoggedInUser.FacultyId == null)
            {
                MessageBox.Show("No faculty record is associated with your account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvAssignedProjects.DataSource = null;
                return;
            }

            List<FacultyProject> assignments = facultyProjectService.GetProjectsForFaculty(LoggedInUser.FacultyId.Value);

            dgvAssignedProjects.DataSource = assignments;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAssignedProjects();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FacultyDashboardForm facultyDashboard = new FacultyDashboardForm();
            facultyDashboard.Show();
            this.Close();
        }
    }
}
