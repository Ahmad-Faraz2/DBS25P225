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
    public partial class AllocateResourcesForm: Form
    {
        public AllocateResourcesForm()
        {
            InitializeComponent();
        }

        private void btnAllocate_Click(object sender, EventArgs e)
        {
            int facultyID = Convert.ToInt32(cmbFaculty.SelectedValue);
            string room = cmbRoom.SelectedItem.ToString();
            string timeSlot = cmbTimeSlot.SelectedItem.ToString();

            string query = "INSERT INTO Allocations (FacultyID, Room, TimeSlot) VALUES (@facultyID, @room, @timeSlot)";
            // Execute query
        }

        private void AllocateResourcesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
