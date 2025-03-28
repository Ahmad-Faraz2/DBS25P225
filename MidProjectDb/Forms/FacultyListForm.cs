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
    public partial class FacultyListForm: Form
    {
        private FacultyService facultyService = new FacultyService();
        public FacultyListForm()
        {
            InitializeComponent();
            LoadFacultyList();
        }

        private void LoadFacultyList()
        {
            List<Faculty> facultyList = facultyService.GetAllFaculty();
            dgvFaculty.DataSource = facultyList;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFacultyList();
        }

        private void btnAddNewFaculty_Click(object sender, EventArgs e)
        {
            FacultyProfileForm profileForm = new FacultyProfileForm();
            profileForm.ShowDialog();
            LoadFacultyList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvFaculty.CurrentRow != null)
            {
                Faculty selectedFaculty = dgvFaculty.CurrentRow.DataBoundItem as Faculty;
                if (selectedFaculty != null)
                {
                    // Assume FacultyProfileForm has a method LoadFaculty to populate the form with existing data.
                    FacultyProfileForm profileForm = new FacultyProfileForm();
                    profileForm.LoadFaculty(selectedFaculty);
                    profileForm.ShowDialog();
                    LoadFacultyList(); // Refresh after editing.
                }
            }
            else
            {
                MessageBox.Show("Please select a record to edit.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFaculty.CurrentRow != null)
            {
                Faculty selectedFaculty = dgvFaculty.CurrentRow.DataBoundItem as Faculty;
                if (selectedFaculty != null)
                {
                    if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool result = facultyService.DeleteFaculty(selectedFaculty.FacultyId);
                        if (result)
                        {
                            MessageBox.Show("Deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Deletion failed.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        LoadFacultyList();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
