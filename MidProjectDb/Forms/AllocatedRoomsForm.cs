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
    public partial class AllocatedRoomsForm: Form
    {
        private FacultyRoomAllocationService allocationService = new FacultyRoomAllocationService();
        public AllocatedRoomsForm()
        {
            InitializeComponent();
        }

        private void AllocatedRoomsForm_Load(object sender, EventArgs e)
        {
            LoadAllocations();
        }
        private void LoadAllocations()
        {
            if (LoggedInUser.FacultyId == null)
            {
                MessageBox.Show("No faculty record is associated with your account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvAllocatedRooms.DataSource = null;
                return;
            }

            List<FacultyRoomAllocation> allAllocations = allocationService.GetAllAllocations();
            List<FacultyRoomAllocation> myAllocations = allAllocations.Where(a => a.FacultyId == LoggedInUser.FacultyId.Value).ToList();
            dgvAllocatedRooms.DataSource = myAllocations;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllocations();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FacultyDashboardForm dashboard = new FacultyDashboardForm();
            dashboard.Show();
            this.Close();
        }
    }
}
