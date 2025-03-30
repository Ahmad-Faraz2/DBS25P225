namespace MidProjectDb
{
    partial class AdminDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboardForm));
            this.btnManageFaculty = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnProcessRequests = new System.Windows.Forms.Button();
            this.btnAllocateCourses = new System.Windows.Forms.Button();
            this.btnUpdateInventory = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnManageFaculty
            // 
            this.btnManageFaculty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnManageFaculty.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnManageFaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageFaculty.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnManageFaculty.Location = new System.Drawing.Point(274, 119);
            this.btnManageFaculty.Name = "btnManageFaculty";
            this.btnManageFaculty.Size = new System.Drawing.Size(122, 30);
            this.btnManageFaculty.TabIndex = 54;
            this.btnManageFaculty.Text = "Manage Faculty";
            this.btnManageFaculty.UseVisualStyleBackColor = false;
            this.btnManageFaculty.Click += new System.EventHandler(this.btnManageFaculty_Click);
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
            this.Panel1.TabIndex = 51;
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
            this.label3.Size = new System.Drawing.Size(198, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Admin Dashboard";
            // 
            // btnProcessRequests
            // 
            this.btnProcessRequests.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnProcessRequests.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnProcessRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessRequests.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProcessRequests.Location = new System.Drawing.Point(274, 214);
            this.btnProcessRequests.Name = "btnProcessRequests";
            this.btnProcessRequests.Size = new System.Drawing.Size(122, 45);
            this.btnProcessRequests.TabIndex = 55;
            this.btnProcessRequests.Text = "Process Requests";
            this.btnProcessRequests.UseVisualStyleBackColor = false;
            this.btnProcessRequests.Click += new System.EventHandler(this.btnProcessrequests_Click);
            // 
            // btnAllocateCourses
            // 
            this.btnAllocateCourses.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAllocateCourses.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAllocateCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllocateCourses.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAllocateCourses.Location = new System.Drawing.Point(274, 167);
            this.btnAllocateCourses.Name = "btnAllocateCourses";
            this.btnAllocateCourses.Size = new System.Drawing.Size(122, 30);
            this.btnAllocateCourses.TabIndex = 56;
            this.btnAllocateCourses.Text = "Allocate Courses";
            this.btnAllocateCourses.UseVisualStyleBackColor = false;
            this.btnAllocateCourses.Click += new System.EventHandler(this.btnAllocateCourses_Click);
            // 
            // btnUpdateInventory
            // 
            this.btnUpdateInventory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdateInventory.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUpdateInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateInventory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUpdateInventory.Location = new System.Drawing.Point(274, 279);
            this.btnUpdateInventory.Name = "btnUpdateInventory";
            this.btnUpdateInventory.Size = new System.Drawing.Size(122, 30);
            this.btnUpdateInventory.TabIndex = 57;
            this.btnUpdateInventory.Text = "Update Inventory";
            this.btnUpdateInventory.UseVisualStyleBackColor = false;
            this.btnUpdateInventory.Click += new System.EventHandler(this.btnUpdateInventory_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogout.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLogout.Location = new System.Drawing.Point(274, 354);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(122, 30);
            this.btnLogout.TabIndex = 58;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGenerateReport.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnGenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGenerateReport.Location = new System.Drawing.Point(274, 318);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(122, 30);
            this.btnGenerateReport.TabIndex = 59;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnUpdateInventory);
            this.Controls.Add(this.btnAllocateCourses);
            this.Controls.Add(this.btnProcessRequests);
            this.Controls.Add(this.btnManageFaculty);
            this.Controls.Add(this.Panel1);
            this.Name = "AdminDashboardForm";
            this.Text = "AdminDashboard";
            this.Load += new System.EventHandler(this.AdminDashboardForm_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnManageFaculty;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnProcessRequests;
        private System.Windows.Forms.Button btnAllocateCourses;
        private System.Windows.Forms.Button btnUpdateInventory;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnGenerateReport;
    }
}