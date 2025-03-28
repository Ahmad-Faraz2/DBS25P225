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
    public partial class AdminDashboardForm: Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
           
        }

        private void btnManageFaculty_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageFaculty manageFacultyForm = new ManageFaculty();
            manageFacultyForm.Show();
            
        }

        private void btnAllocateCourses_Click(object sender, EventArgs e)
        {
            this.Hide();
            CourseAssignmentForm courseAssignmentForm = new CourseAssignmentForm();
            courseAssignmentForm.Show();
        }

        private void btnProcessrequests_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResourceApprovalForm resourceApprovalForm = new ResourceApprovalForm();
            resourceApprovalForm.Show();
        }

        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConsumablesInventoryForm inventoryForm = new ConsumablesInventoryForm();
            inventoryForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}
