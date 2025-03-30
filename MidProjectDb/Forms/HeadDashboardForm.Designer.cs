namespace MidProjectDb
{
    partial class HeadDashboardForm
    {
        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeadDashboardForm));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAssignWorkLoad = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAllocateRooms = new System.Windows.Forms.Button();
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
            this.Panel1.TabIndex = 52;
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
            this.label3.Size = new System.Drawing.Size(188, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Head Dashboard";
            // 
            // btnAssignWorkLoad
            // 
            this.btnAssignWorkLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAssignWorkLoad.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAssignWorkLoad.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAssignWorkLoad.Location = new System.Drawing.Point(358, 144);
            this.btnAssignWorkLoad.Name = "btnAssignWorkLoad";
            this.btnAssignWorkLoad.Size = new System.Drawing.Size(117, 39);
            this.btnAssignWorkLoad.TabIndex = 53;
            this.btnAssignWorkLoad.Text = "Assign WorkLoad";
            this.btnAssignWorkLoad.UseVisualStyleBackColor = false;
            this.btnAssignWorkLoad.Click += new System.EventHandler(this.btnAssignWorkLoad_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogout.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLogout.Location = new System.Drawing.Point(358, 243);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(117, 39);
            this.btnLogout.TabIndex = 54;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAllocateRooms
            // 
            this.btnAllocateRooms.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAllocateRooms.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAllocateRooms.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAllocateRooms.Location = new System.Drawing.Point(358, 189);
            this.btnAllocateRooms.Name = "btnAllocateRooms";
            this.btnAllocateRooms.Size = new System.Drawing.Size(117, 39);
            this.btnAllocateRooms.TabIndex = 55;
            this.btnAllocateRooms.Text = "Allocate Rooms";
            this.btnAllocateRooms.UseVisualStyleBackColor = false;
            this.btnAllocateRooms.Click += new System.EventHandler(this.btnAllocateRooms_Click);
            // 
            // HeadDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAllocateRooms);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnAssignWorkLoad);
            this.Controls.Add(this.Panel1);
            this.Name = "HeadDashboardForm";
            this.Text = "Form1";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAssignWorkLoad;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAllocateRooms;
    }
}