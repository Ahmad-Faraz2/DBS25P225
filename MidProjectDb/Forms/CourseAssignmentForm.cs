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
            LoadFacultyDropdown();
            LoadCourseDropdown();
            LoadSemesterDropdown();
            LoadAssignments();
        }
        private void LoadFacultyDropdown()
        {
            // Replace with actual retrieval from your database.
            FacultyService facultyService = new FacultyService();
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
            // Assuming Semester has a helper property for display, such as "DisplayTerm"
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
            int facultyId = (int)cmbFaculty.SelectedValue;
            int courseId = (int)cmbCourse.SelectedValue;
            int semesterId = (int)cmbSemester.SelectedValue;

            FacultyCourseAssignment assignment = new FacultyCourseAssignment
            {
                FacultyId = facultyId,
                CourseId = courseId,
                SemesterId = semesterId
            };

            bool result = assignmentService.AssignCourse(assignment);
            if (result)
            {
                MessageBox.Show("Course assigned successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAssignments();
            }
            else
            {
                MessageBox.Show("Error assigning course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAssignments.CurrentRow != null)
            {
                FacultyCourseAssignment selectedAssignment = dgvAssignments.CurrentRow.DataBoundItem as FacultyCourseAssignment;
                if (selectedAssignment != null)
                {
                    selectedAssignment.FacultyId = (int)cmbFaculty.SelectedValue;
                    selectedAssignment.CourseId = (int)cmbCourse.SelectedValue;
                    selectedAssignment.SemesterId = (int)cmbSemester.SelectedValue;

                    bool result = assignmentService.UpdateAssignment(selectedAssignment);
                    if (result)
                    {
                        MessageBox.Show("Assignment updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAssignments();
                    }
                    else
                    {
                        MessageBox.Show("Error updating assignment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an assignment to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbFaculty.SelectedIndex = 0;
            cmbCourse.SelectedIndex = 0;
            cmbSemester.SelectedIndex = 0;
        }
    }
}
