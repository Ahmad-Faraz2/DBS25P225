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
            this.Close();
        }

        private void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            FacultyRequestForm requestForm = new FacultyRequestForm();
            requestForm.Show();
            this.Close();
        }

        private void btnTrackRequests_Click(object sender, EventArgs e)
        {
            RequestStatusForm statusForm = new RequestStatusForm();
            statusForm.Show();
            this.Close();   
        }

        private void FacultyDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void btnViewProjects_Click(object sender, EventArgs e)
        {
            AssignedProjectsForm projectForm = new AssignedProjectsForm();
            projectForm.Show();
            this.Close();
        }

        private void btnViewRooms_Click(object sender, EventArgs e)
        {
            AllocatedRoomsForm roomsForm = new AllocatedRoomsForm();
            roomsForm.Show();
            this.Close();
        }
    }
}
