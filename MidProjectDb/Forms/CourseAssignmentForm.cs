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
    public partial class CourseAssignmentForm: Form
    {
        private CourseAssignmentService assignmentService = new CourseAssignmentService();
        private CourseService courseService = new CourseService();
        private SemesterService semesterService = new SemesterService();
        private FacultyService facultyService = new FacultyService();
        public CourseAssignmentForm()
        {
            InitializeComponent();
        }
        private void LoadFacultyDropdown()
        {
            List<Faculty> faculties = facultyService.GetAllFaculty();
            cmbFaculty.DataSource = faculties;
            cmbFaculty.DisplayMember = "Name";
            cmbFaculty.ValueMember = "FacultyId";
        }
        private void LoadCourseDropdown()
        {
            List<Course> courses = courseService.GetAllCourses();
            cmbCourse.DataSource = courses;
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseId";
        }
        private void LoadAssignments()
        {
            List<FacultyCourseAssignment> assignments = assignmentService.GetAllAssignments();
            dgvAssignments.DataSource = assignments;
        }
        private void LoadSemesterDropdown()
        {
            List<Semester> semesters = semesterService.GetAllSemesters();
            cmbSemester.DataSource = semesters;
            cmbSemester.DisplayMember = "DisplayTerm";
            cmbSemester.ValueMember = "SemesterId";
        }
        private void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvAssignments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            FacultyCourseAssignment assignment = new FacultyCourseAssignment
            {
                FacultyId = (int)cmbFaculty.SelectedValue,
                CourseId = (int)cmbCourse.SelectedValue,
                SemesterId = (int)cmbSemester.SelectedValue
            };

            bool result = assignmentService.AssignCourse(assignment);
            if (result)
            {
                MessageBox.Show("Course assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadAssignments();
            }
            else
            {
                MessageBox.Show("Failed to assign course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAssignments.CurrentRow == null)
            {
                MessageBox.Show("Please select an assignment to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FacultyCourseAssignment selectedAssignment = dgvAssignments.CurrentRow.DataBoundItem as FacultyCourseAssignment;
            if (selectedAssignment == null)
            {
                MessageBox.Show("Assignment selection error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FacultyCourseAssignment updatedAssignment = new FacultyCourseAssignment
            {
                FacultyCourseId = selectedAssignment.FacultyCourseId,
                FacultyId = (int)cmbFaculty.SelectedValue,
                CourseId = (int)cmbCourse.SelectedValue,
                SemesterId = (int)cmbSemester.SelectedValue
            };

            bool result = assignmentService.UpdateAssignment(updatedAssignment);
            if (result)
            {
                MessageBox.Show("Assignment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAssignments();
            }
            else
            {
                MessageBox.Show("Failed to update assignment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            if (cmbFaculty.Items.Count > 0)
            {
                cmbFaculty.SelectedIndex = 0;
            }
            if (cmbCourse.Items.Count > 0)
            {
                cmbCourse.SelectedIndex = 0;
            }
            if (cmbSemester.Items.Count > 0)
            {
                cmbSemester.SelectedIndex = 0;
            }
        }
        private void CourseAssignmentForm_Load(object sender, EventArgs e)
        {
            LoadFacultyDropdown();
            LoadCourseDropdown();
            LoadSemesterDropdown();
            LoadAssignments();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboardForm adminDashboard = new AdminDashboardForm();
            adminDashboard.Show();
            this.Close();
        }
    }
}
