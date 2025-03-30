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

            try
            {
                using (MySqlConnection conn = new DatabaseHelper().GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Allocations (FacultyID, Room, TimeSlot) VALUES (@facultyID, @room, @timeSlot)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@facultyID", facultyID);
                        cmd.Parameters.AddWithValue("@room", room);
                        cmd.Parameters.AddWithValue("@timeSlot", timeSlot);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Resource allocation successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Resource allocation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error allocating resource: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AllocateResourcesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
