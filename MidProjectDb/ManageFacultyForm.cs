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
    public partial class ManageFaculty: Form
    {
        public ManageFaculty()
        {
            InitializeComponent();
        }

        private void ManageFaculty_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string designation = txtDesignation.Text;
            string role = cmbRole.SelectedItem.ToString();

            string query = "INSERT INTO Faculty (Name, Designation, Role) VALUES (@name, @designation, @role)";
            MySqlParameter[] parameters = {
        new MySqlParameter("@name", name),
        new MySqlParameter("@designation", designation),
        new MySqlParameter("@role", role)
    };

        }
    }
}
