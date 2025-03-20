using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace MidProjectDb.Properties
{
    public partial class ResetPasswordForm: Form
    {
        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if(newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

        }

        private void ResetPasswordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
