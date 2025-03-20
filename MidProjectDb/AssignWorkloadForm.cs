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
    public partial class AssignWorkloadForm: Form
    {
        public AssignWorkloadForm()
        {
            InitializeComponent();
        }

        private void AssignWorkloadForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {

            int facultyID = Convert.ToInt32(cmbFaculty.SelectedValue);
            string course = cmbCourse.SelectedItem.ToString();
            string semester = cmbSemester.SelectedItem.ToString();

            string query = "INSERT INTO Workload (FacultyID, Course, Semester) VALUES (@facultyID, @course, @semester)";
            // Execute query with parameters
        }
    }
}
