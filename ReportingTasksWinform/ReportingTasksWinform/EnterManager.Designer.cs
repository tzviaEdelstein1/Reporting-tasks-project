namespace ReportingTasksWinform
{
    partial class EnterManager
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
            this.buttonAddProject = new System.Windows.Forms.Button();
            this.buttonManageUsers = new System.Windows.Forms.Button();
            this.buttonManageReports = new System.Windows.Forms.Button();
            this.buttonManagementTeam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddProject
            // 
            this.buttonAddProject.Location = new System.Drawing.Point(69, 25);
            this.buttonAddProject.Name = "buttonAddProject";
            this.buttonAddProject.Size = new System.Drawing.Size(121, 32);
            this.buttonAddProject.TabIndex = 0;
            this.buttonAddProject.Text = "AddProject";
            this.buttonAddProject.UseVisualStyleBackColor = true;
            this.buttonAddProject.Click += new System.EventHandler(this.buttonAddProject_Click);
            // 
            // buttonManageUsers
            // 
            this.buttonManageUsers.Location = new System.Drawing.Point(212, 25);
            this.buttonManageUsers.Name = "buttonManageUsers";
            this.buttonManageUsers.Size = new System.Drawing.Size(121, 32);
            this.buttonManageUsers.TabIndex = 1;
            this.buttonManageUsers.Text = "ManageUsers";
            this.buttonManageUsers.UseVisualStyleBackColor = true;
            this.buttonManageUsers.Click += new System.EventHandler(this.buttonManageUsers_Click);
            // 
            // buttonManageReports
            // 
            this.buttonManageReports.Location = new System.Drawing.Point(355, 25);
            this.buttonManageReports.Name = "buttonManageReports";
            this.buttonManageReports.Size = new System.Drawing.Size(121, 32);
            this.buttonManageReports.TabIndex = 2;
            this.buttonManageReports.Text = "ManageReports";
            this.buttonManageReports.UseVisualStyleBackColor = true;
            this.buttonManageReports.Click += new System.EventHandler(this.buttonManageReports_Click);
            // 
            // buttonManagementTeam
            // 
            this.buttonManagementTeam.Location = new System.Drawing.Point(482, 25);
            this.buttonManagementTeam.Name = "buttonManagementTeam";
            this.buttonManagementTeam.Size = new System.Drawing.Size(121, 32);
            this.buttonManagementTeam.TabIndex = 3;
            this.buttonManagementTeam.Text = "ManagementTeam";
            this.buttonManagementTeam.UseVisualStyleBackColor = true;
            this.buttonManagementTeam.Click += new System.EventHandler(this.buttonManagementTeam_Click);
            // 
            // EnterManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonManagementTeam);
            this.Controls.Add(this.buttonManageReports);
            this.Controls.Add(this.buttonManageUsers);
            this.Controls.Add(this.buttonAddProject);
            this.Name = "EnterManager";
            this.Text = "EnterManager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddProject;
        private System.Windows.Forms.Button buttonManageUsers;
        private System.Windows.Forms.Button buttonManageReports;
        private System.Windows.Forms.Button buttonManagementTeam;
    }
}