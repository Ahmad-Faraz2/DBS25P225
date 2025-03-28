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
    public partial class FacultyRequestForm: Form
    {
        private FacultyRequestService requestService = new FacultyRequestService();
        private ConsumableService consumableService = new ConsumableService();
        public FacultyRequestForm()
        {
            InitializeComponent();
            LoadResourceTypes();
        }

        private void LoadResourceTypes()
        {
            List<Consumable> consumables = consumableService.GetAllConsumables();
            cmbResourceType.DataSource = consumables;
            cmbResourceType.DisplayMember = "ItemName";
            cmbResourceType.ValueMember = "ConsumableId";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FacultyDashboardForm facultyDashboard = new FacultyDashboardForm();
            facultyDashboard.Show();
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (LoggedInUser.FacultyId == null)
            {
                MessageBox.Show("Only faculty members can submit resource requests.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbResourceType.SelectedItem == null || string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please select a resource type and enter the quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity))
            {
                MessageBox.Show("Please enter a valid numeric quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FacultyRequest request = new FacultyRequest
            {
                FacultyId = LoggedInUser.FacultyId.Value,
                ItemId = (int)cmbResourceType.SelectedValue,
                Quantity = quantity,
                RequestDate = DateTime.Now,
                StatusId = 8
            };

            bool result = requestService.SubmitRequest(request);
            if (result)
            {
                MessageBox.Show("Request submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show("Error submitting the request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbResourceType.SelectedIndex = 0;
            txtQuantity.Clear();
        }
        private void ClearFields()
        {
            if (cmbResourceType.Items.Count > 0)
                cmbResourceType.SelectedIndex = 0;
            txtQuantity.Clear();
        }
    }
}
