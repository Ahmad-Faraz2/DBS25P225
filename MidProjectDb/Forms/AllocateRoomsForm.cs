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
    public partial class AllocateRoomsForm: Form
    {
        private FacultyService facultyService = new FacultyService();
        private RoomService roomService = new RoomService();
        private SemesterService semesterService = new SemesterService();
        private FacultyRoomAllocationService allocationService = new FacultyRoomAllocationService();
        public AllocateRoomsForm()
        {
            InitializeComponent();
        }

        private void AllocateRoomsForm_Load(object sender, EventArgs e)
        {
            LoadFacultyDropdown();
            LoadRoomDropdown();
            LoadSemesterDropdown();
            LoadAllocations();
        }
        private void LoadFacultyDropdown()
        {
            List<Faculty> faculties = facultyService.GetAllFaculty();
            cmbFaculty.DataSource = faculties;
            cmbFaculty.DisplayMember = "Name";
            cmbFaculty.ValueMember = "FacultyId";
        }

        private void LoadRoomDropdown()
        {
            List<Room> rooms = roomService.GetAllRooms();
            cmbRoom.DataSource = rooms;
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomId";
        }

        private void LoadSemesterDropdown()
        {
            List<Semester> semesters = semesterService.GetAllSemesters();
            cmbSemester.DataSource = semesters;
            cmbSemester.DisplayMember = "DisplayTerm";
            cmbSemester.ValueMember = "SemesterId";
        }

        private void LoadAllocations()
        {
            List<FacultyRoomAllocation> allocations = allocationService.GetAllAllocations();
            dgvAllocations.DataSource = allocations;
        }

        private void btnAllocate_Click(object sender, EventArgs e)
        {
            if (cmbFaculty.SelectedItem == null || cmbRoom.SelectedItem == null || cmbSemester.SelectedItem == null)
            {
                MessageBox.Show("Please ensure Faculty, Room, and Semester are selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtReservedHours.Text) || !int.TryParse(txtReservedHours.Text.Trim(), out int reservedHours))
            {
                MessageBox.Show("Please enter a valid number for Reserved Hours.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FacultyRoomAllocation allocation = new FacultyRoomAllocation
            {
                FacultyId = (int)cmbFaculty.SelectedValue,
                RoomId = (int)cmbRoom.SelectedValue,
                SemesterId = (int)cmbSemester.SelectedValue,
                ReservedHours = reservedHours
            };

            bool result = allocationService.AssignRoom(allocation);
            if (result)
            {
                MessageBox.Show("Room allocated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadAllocations();
            }
            else
            {
                MessageBox.Show("Failed to allocate room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            if (cmbFaculty.Items.Count > 0)
                cmbFaculty.SelectedIndex = 0;
            if (cmbRoom.Items.Count > 0)
                cmbRoom.SelectedIndex = 0;
            if (cmbSemester.Items.Count > 0)
                cmbSemester.SelectedIndex = 0;
            txtReservedHours.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HeadDashboardForm headDashboard = new HeadDashboardForm();
            headDashboard.Show();
            this.Close();
        }
    }
}
