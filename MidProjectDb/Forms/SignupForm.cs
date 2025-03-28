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
    public partial class SignupForm: Form
    {
        private UserService userService = new UserService();
        private FacultyService facultyService = new FacultyService();
        public SignupForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadRoles();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }
        private void LoadRoles()
        {
            List<Role> roles = new List<Role>();
            try
            {
                using (MySqlConnection conn = new DatabaseHelper().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT lookup_id, value FROM lookup WHERE category = 'UserRoles'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Role role = new Role
                                {
                                    LookupId = reader.GetInt32("lookup_id"),
                                    Value = reader.GetString("value")
                                };
                                roles.Add(role);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading roles: " + ex.Message);
            }
            cmbRole.DataSource = roles;
            cmbRole.DisplayMember = "Value";
            cmbRole.ValueMember = "LookupId";
        }

        private void btnSignup_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User newUser = new User
            {
                Username = txtUsername.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text.Trim(),  
                RoleId = ((Role)cmbRole.SelectedItem).LookupId
            };

            bool result = userService.RegisterUser(newUser);
            if (result)
            {
                MessageBox.Show("Signup successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (newUser.RoleId == 2)
                {
                    User registeredUser = userService.GetUserByEmail(newUser.Email);
                    if (registeredUser != null)
                    {
                        bool linkResult = facultyService.LinkFacultyRecord(newUser.Email, registeredUser.UserId);
                        if (!linkResult)
                        {
                            MessageBox.Show("Signup succeeded, but failed to link the faculty record. Please contact admin.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            Faculty linkedFaculty = facultyService.GetFacultyByEmail(newUser.Email);
                            if (linkedFaculty != null)
                            {
                                LoggedInUser.SetUser(registeredUser.UserId, registeredUser.RoleId, linkedFaculty.FacultyId);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to retrieve user information for linking.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoginForm login = new LoginForm();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Signup failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
