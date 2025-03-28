namespace MidProjectDb
{
    partial class FacultyDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacultyDashboardForm));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFacultyProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnViewCourses = new System.Windows.Forms.Button();
            this.btnSubmitRequest = new System.Windows.Forms.Button();
            this.btnTrackRequests = new System.Windows.Forms.Button();
            this.btnUpdateProfile = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Panel1.Controls.Add(this.pictureBox1);
            this.Panel1.Controls.Add(this.label3);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(800, 74);
            this.Panel1.TabIndex = 60;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(340, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Faculty Dashboard";
            // 
            // btnFacultyProfile
            // 
            this.btnFacultyProfile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFacultyProfile.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnFacultyProfile.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFacultyProfile.Location = new System.Drawing.Point(306, 103);
            this.btnFacultyProfile.Name = "btnFacultyProfile";
            this.btnFacultyProfile.Size = new System.Drawing.Size(98, 24);
            this.btnFacultyProfile.TabIndex = 61;
            this.btnFacultyProfile.Text = "Faculty Profile";
            this.btnFacultyProfile.UseVisualStyleBackColor = false;
            this.btnFacultyProfile.Click += new System.EventHandler(this.btnFacultyProfile_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogout.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLogout.Location = new System.Drawing.Point(316, 281);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 62;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnViewCourses
            // 
            this.btnViewCourses.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnViewCourses.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnViewCourses.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnViewCourses.Location = new System.Drawing.Point(306, 133);
            this.btnViewCourses.Name = "btnViewCourses";
            this.btnViewCourses.Size = new System.Drawing.Size(98, 37);
            this.btnViewCourses.TabIndex = 63;
            this.btnViewCourses.Text = "View Assigned Courses";
            this.btnViewCourses.UseVisualStyleBackColor = false;
            this.btnViewCourses.Click += new System.EventHandler(this.btnViewCourses_Click);
            // 
            // btnSubmitRequest
            // 
            this.btnSubmitRequest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubmitRequest.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSubmitRequest.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSubmitRequest.Location = new System.Drawing.Point(306, 178);
            this.btnSubmitRequest.Name = "btnSubmitRequest";
            this.btnSubmitRequest.Size = new System.Drawing.Size(98, 37);
            this.btnSubmitRequest.TabIndex = 64;
            this.btnSubmitRequest.Text = "Submit Resource Request";
            this.btnSubmitRequest.UseVisualStyleBackColor = false;
            this.btnSubmitRequest.Click += new System.EventHandler(this.btnSubmitRequest_Click);
            // 
            // btnTrackRequests
            // 
            this.btnTrackRequests.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTrackRequests.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnTrackRequests.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTrackRequests.Location = new System.Drawing.Point(306, 221);
            this.btnTrackRequests.Name = "btnTrackRequests";
            this.btnTrackRequests.Size = new System.Drawing.Size(98, 26);
            this.btnTrackRequests.TabIndex = 65;
            this.btnTrackRequests.Text = "Track Requests";
            this.btnTrackRequests.UseVisualStyleBackColor = false;
            this.btnTrackRequests.Click += new System.EventHandler(this.btnTrackRequests_Click);
            // 
            // btnUpdateProfile
            // 
            this.btnUpdateProfile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdateProfile.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUpdateProfile.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUpdateProfile.Location = new System.Drawing.Point(306, 248);
            this.btnUpdateProfile.Name = "btnUpdateProfile";
            this.btnUpdateProfile.Size = new System.Drawing.Size(98, 27);
            this.btnUpdateProfile.TabIndex = 66;
            this.btnUpdateProfile.Text = "Update Profile";
            this.btnUpdateProfile.UseVisualStyleBackColor = false;
            this.btnUpdateProfile.Click += new System.EventHandler(this.btnUpdateProfile_Click);
            // 
            // FacultyDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdateProfile);
            this.Controls.Add(this.btnTrackRequests);
            this.Controls.Add(this.btnSubmitRequest);
            this.Controls.Add(this.btnViewCourses);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnFacultyProfile);
            this.Controls.Add(this.Panel1);
            this.Name = "FacultyDashboardForm";
            this.Text = "Faculty Dasboard";
            this.Load += new System.EventHandler(this.FacultyDashboardForm_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFacultyProfile;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnViewCourses;
        private System.Windows.Forms.Button btnSubmitRequest;
        private System.Windows.Forms.Button btnTrackRequests;
        private System.Windows.Forms.Button btnUpdateProfile;
    }
}