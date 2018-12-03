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
            this.btnLogout = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AddProject = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.Reports = new System.Windows.Forms.ToolStripMenuItem();
            this.AddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.EditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(445, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(129, 32);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddProject,
            this.ManageUsers,
            this.Reports});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AddProject
            // 
            this.AddProject.Name = "AddProject";
            this.AddProject.Size = new System.Drawing.Size(81, 20);
            this.AddProject.Text = "Add project";
            this.AddProject.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ManageUsers
            // 
            this.ManageUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddUser,
            this.EditUser,
            this.DeleteUser});
            this.ManageUsers.Name = "ManageUsers";
            this.ManageUsers.Size = new System.Drawing.Size(93, 20);
            this.ManageUsers.Text = "Manage Users";
        
            // 
            // Reports
            // 
            this.Reports.Name = "Reports";
            this.Reports.Size = new System.Drawing.Size(59, 20);
            this.Reports.Text = "Reports";
            this.Reports.Click += new System.EventHandler(this.Reports_Click);
            // 
            // AddUser
            // 
            this.AddUser.Name = "AddUser";
            this.AddUser.Size = new System.Drawing.Size(180, 22);
            this.AddUser.Text = "Add user";
            this.AddUser.Click += new System.EventHandler(this.AddUser_Click);
            // 
            // EditUser
            // 
            this.EditUser.Name = "EditUser";
            this.EditUser.Size = new System.Drawing.Size(180, 22);
            this.EditUser.Text = "Edit User";
            this.EditUser.Click += new System.EventHandler(this.EditUser_Click);
            // 
            // DeleteUser
            // 
            this.DeleteUser.Name = "DeleteUser";
            this.DeleteUser.Size = new System.Drawing.Size(180, 22);
            this.DeleteUser.Text = "DeleteUser";
            this.DeleteUser.Click += new System.EventHandler(this.DeleteUser_Click);
            // 
            // EnterManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 509);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EnterManager";
            this.Text = "EnterManager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AddProject;
        private System.Windows.Forms.ToolStripMenuItem ManageUsers;
        private System.Windows.Forms.ToolStripMenuItem Reports;
        private System.Windows.Forms.ToolStripMenuItem AddUser;
        private System.Windows.Forms.ToolStripMenuItem EditUser;
        private System.Windows.Forms.ToolStripMenuItem DeleteUser;
    }
}