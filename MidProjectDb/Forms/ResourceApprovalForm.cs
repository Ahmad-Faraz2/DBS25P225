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
    public partial class ResourceApprovalForm: Form
    {
        private FacultyRequestService requestService = new FacultyRequestService();
        public ResourceApprovalForm()
        {
            InitializeComponent();
        }

        private void dgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ApproveRequestsForm_Load(object sender, EventArgs e)
        {
            LoadRequests();
        }
        private void LoadRequests()
        {
            List<FacultyRequest> allRequests = requestService.GetAllRequests();
            List<FacultyRequest> pendingRequests = allRequests.FindAll(r => r.StatusId == 8);
            dgvRequests.DataSource = pendingRequests;
        }
        private void btnApprove_Click(object sender, EventArgs e)
        {
            UpdateSelectedRequestStatus(9);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            UpdateSelectedRequestStatus(10);
        }

        private void btnFulfill_Click(object sender, EventArgs e)
        {
            UpdateSelectedRequestStatus(11);
        }
        private void UpdateSelectedRequestStatus(int newStatusId)
        {
            if (dgvRequests.CurrentRow == null)
            {
                MessageBox.Show("Please select a request.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FacultyRequest selectedRequest = dgvRequests.CurrentRow.DataBoundItem as FacultyRequest;
            if (selectedRequest == null)
            {
                MessageBox.Show("Error retrieving the selected request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result = requestService.UpdateRequestStatus(selectedRequest.RequestId, newStatusId);
            if (result)
            {
                MessageBox.Show("Request status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRequests();
            }
            else
            {
                MessageBox.Show("Failed to update request status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboardForm adminDashboard = new AdminDashboardForm();
            adminDashboard.Show();
            this.Close();
        }
    }
}
