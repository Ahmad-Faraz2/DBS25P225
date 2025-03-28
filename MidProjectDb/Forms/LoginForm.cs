using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MidProjectDb;            

namespace MidProjectDb
{
    public partial class LoginForm: Form
    {
        private UserService userService = new UserService();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

   


        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignupForm signup = new SignupForm();
            signup.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User loggedInUser = userService.AuthenticateUserAndGetUser(username, password);

            if (loggedInUser != null)
            {
                if (loggedInUser.RoleId == 2)
                {
                    LoggedInUser.SetUser(loggedInUser.UserId, loggedInUser.RoleId, loggedInUser.FacultyId);

                    MessageBox.Show("Login successful! You are logged in as a Faculty Member.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FacultyDashboardForm facultyDashboard = new FacultyDashboardForm();
                    facultyDashboard.Show();
                }
                else if (loggedInUser.RoleId == 1)
                {
                    LoggedInUser.SetUser(loggedInUser.UserId, loggedInUser.RoleId);
                    MessageBox.Show("Login successful! You are logged in as an Admin.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminDashboardForm adminDashboard = new AdminDashboardForm();
                    adminDashboard.Show();
                }
                else if (loggedInUser.RoleId == 3)
                {
                    LoggedInUser.SetUser(loggedInUser.UserId, loggedInUser.RoleId);
                    MessageBox.Show("Login successful! You are logged in as a Department Head.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HeadDashboardForm headDashboard = new HeadDashboardForm();
                    headDashboard.Show();
                }
                else
                {
                    MessageBox.Show("User role not recognized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordForm forgotPassword = new ForgotPasswordForm();
            forgotPassword.Show();
            this.Hide();
        }
    }
}
