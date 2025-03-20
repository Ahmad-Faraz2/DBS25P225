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
    public partial class ApproveRequestsForm: Form
    {
        public ApproveRequestsForm()
        {
            InitializeComponent();
        }

        private void dgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ApproveRequestsForm_Load(object sender, EventArgs e)
        {
           
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            int requestID = Convert.ToInt32(dgvRequests.CurrentRow.Cells["RequestID"].Value);
            string query = "UPDATE Requests SET Status = 'Approved' WHERE RequestID = @requestID";
            // Execute query
        }
    }
}
