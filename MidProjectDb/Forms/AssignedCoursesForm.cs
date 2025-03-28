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
    public partial class AssignedCoursesForm: Form
    {
        private CourseAssignmentService assignmentService = new CourseAssignmentService();
        public AssignedCoursesForm()
        {
            InitializeComponent();
        }

        private void AssignedCoursesForm_Load(object sender, EventArgs e)
        {
            LoadAssignedCourses();
        }
        private void LoadAssignedCourses()
        {
            if (LoggedInUser.FacultyId == null)
            {
                MessageBox.Show("You are not registered as a faculty member. No assigned courses to display.",
                                "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<FacultyCourseAssignment> assignments =
                assignmentService.GetAssignmentsForFaculty(LoggedInUser.FacultyId.Value);

            dgvAssignedCourses.DataSource = assignments;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAssignedCourses();
        }
    }
}
