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
    public partial class HeadDashboardForm: Form
    {
        public HeadDashboardForm()
        {
            InitializeComponent();
        }

        private void btnAssignWorkLoad_Click(object sender, EventArgs e)
        {
            AssignWorkloadForm workloadForm = new AssignWorkloadForm();
            workloadForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoggedInUser.SetUser(0, 0);
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void btnAllocateRooms_Click(object sender, EventArgs e)
        {
            AllocateRoomsForm allocateroomsForm = new AllocateRoomsForm();
            allocateroomsForm.Show();
            this.Hide();
        }
    }
}
