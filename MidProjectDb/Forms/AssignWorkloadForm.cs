using MySql.Data.MySqlClient;
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
        private FacultyService facultyService = new FacultyService();
        private ProjectService projectService = new ProjectService();
        private SemesterService semesterService = new SemesterService();
        private FacultyProjectService facultyProjectService = new FacultyProjectService();

        public AssignWorkloadForm()
        {
            InitializeComponent();
        }

        private void AssignWorkloadForm_Load(object sender, EventArgs e)
        {
            LoadFacultyDropdown();
            LoadProjectDropdown();
            LoadSemesterDropdown();
            LoadFacultyProjects();
        }
        private void LoadFacultyDropdown()
        {
            List<Faculty> faculties = facultyService.GetAllFaculty();
            cmbFaculty.DataSource = faculties;
            cmbFaculty.DisplayMember = "Name";
            cmbFaculty.ValueMember = "FacultyId";
        }

        private void LoadProjectDropdown()
        {
            List<Project> projects = projectService.GetAllProjects();
            cmbProject.DataSource = projects;
            cmbProject.DisplayMember = "Title";
            cmbProject.ValueMember = "ProjectId";
        }

        private void LoadSemesterDropdown()
        {
            List<Semester> semesters = semesterService.GetAllSemesters();
            cmbSemester.DataSource = semesters;
            cmbSemester.DisplayMember = "DisplayTerm";
            cmbSemester.ValueMember = "SemesterId";
        }

        private void LoadFacultyProjects()
        {
            List<FacultyProject> projects = facultyProjectService.GetAllProjects();
            dgvFacultyProjects.DataSource = projects;
        }
        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (cmbFaculty.SelectedItem == null || cmbProject.SelectedItem == null || cmbSemester.SelectedItem == null)
            {
                MessageBox.Show("Please ensure faculty, project, and semester are selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int supervisionHours = 0;
            if (!string.IsNullOrWhiteSpace(txtSupervisionHours.Text))
            {
                if (!int.TryParse(txtSupervisionHours.Text.Trim(), out supervisionHours))
                {
                    MessageBox.Show("Please enter a valid number for supervision hours.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            FacultyProject assignment = new FacultyProject
            {
                FacultyId = (int)cmbFaculty.SelectedValue,
                ProjectId = (int)cmbProject.SelectedValue,
                SemesterId = (int)cmbSemester.SelectedValue,
                SupervisionHours = supervisionHours  // if supervision hours are not mandatory, 0 can be acceptable
            };

            bool result = facultyProjectService.AssignProject(assignment);
            if (result)
            {
                MessageBox.Show("Project assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadFacultyProjects(); // Refresh the DataGridView.
            }
            else
            {
                MessageBox.Show("Failed to assign project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            if (cmbFaculty.Items.Count > 0)
                cmbFaculty.SelectedIndex = 0;
            if (cmbProject.Items.Count > 0)
                cmbProject.SelectedIndex = 0;
            if (cmbSemester.Items.Count > 0)
                cmbSemester.SelectedIndex = 0;
            txtSupervisionHours.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HeadDashboardForm headDashboard = new HeadDashboardForm();
            headDashboard.Show();
            this.Close();
        }
    }
}
