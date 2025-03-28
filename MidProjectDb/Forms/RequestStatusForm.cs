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
    public partial class RequestStatusForm: Form
    {
        private FacultyRequestService requestService = new FacultyRequestService();
        public RequestStatusForm()
        {
            InitializeComponent();
        }

        private void RequestStatusForm_Load(object sender, EventArgs e)
        {
            LoadRequests();
        }

        private void LoadRequests()
        {
            if (LoggedInUser.FacultyId == null)
            {
                MessageBox.Show("Only faculty members can view their requests.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<FacultyRequest> requests = requestService.GetRequestsForFaculty(LoggedInUser.FacultyId.Value);

            dgvRequests.DataSource = requests;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRequests();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FacultyDashboardForm facultyDashboard = new FacultyDashboardForm();
            facultyDashboard.Show();
            this.Close();
        }
    }
}
