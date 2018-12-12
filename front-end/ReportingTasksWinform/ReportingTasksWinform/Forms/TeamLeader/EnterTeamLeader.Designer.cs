namespace ReportingTasksWinform
{
    partial class EnterTeamLeader
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
            this.menuChar = new System.Windows.Forms.ToolStripMenuItem();
            this.updateHours = new System.Windows.Forms.ToolStripMenuItem();
            this.viewingProjects = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(758, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(129, 32);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuChar,
            this.updateHours,
            this.viewingProjects});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(918, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuChar
            // 
            this.menuChar.Name = "menuChar";
            this.menuChar.Size = new System.Drawing.Size(42, 20);
            this.menuChar.Text = "char";
            this.menuChar.Click += new System.EventHandler(this.menuChar_Click);
            // 
            // updateHours
            // 
            this.updateHours.Name = "updateHours";
            this.updateHours.Size = new System.Drawing.Size(89, 20);
            this.updateHours.Text = "update hours";
            this.updateHours.Click += new System.EventHandler(this.updateHours_Click);
            // 
            // viewingProjects
            // 
            this.viewingProjects.Name = "viewingProjects";
            this.viewingProjects.Size = new System.Drawing.Size(102, 20);
            this.viewingProjects.Text = "viewingProjects";
            this.viewingProjects.Click += new System.EventHandler(this.viewingProjects_Click);
            // 
            // EnterTeamLeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 585);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EnterTeamLeader";
            this.Text = "EnterTeamLeader";
            //this.Load += new System.EventHandler(this.EnterTeamLeader_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuChar;
        private System.Windows.Forms.ToolStripMenuItem updateHours;
        private System.Windows.Forms.ToolStripMenuItem viewingProjects;
    }
}