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
    public partial class FacultyDashboardForm: Form
    {
        public FacultyDashboardForm()
        {
            InitializeComponent();
        }

        private void btnFacultyProfile_Click(object sender, EventArgs e)
        {
            FacultyProfileForm profileForm = new FacultyProfileForm();
            profileForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void btnViewCourses_Click(object sender, EventArgs e)
        {
            AssignedCoursesForm assignedCoursesForm = new AssignedCoursesForm();
            assignedCoursesForm.Show();
        }

        private void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            FacultyRequestForm requestForm = new FacultyRequestForm();
            requestForm.Show();
        }

        private void btnTrackRequests_Click(object sender, EventArgs e)
        {
            RequestStatusForm statusForm = new RequestStatusForm();
            statusForm.Show();
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            FacultyProfileForm profileForm = new FacultyProfileForm();
            profileForm.Show();
        }

        private void FacultyDashboardForm_Load(object sender, EventArgs e)
        {

        }
    }
}
