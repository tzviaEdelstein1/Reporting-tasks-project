namespace ReportingTasksWinform
{
    partial class ManagementTeam
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
            this.comboBoxAllUsers = new System.Windows.Forms.ComboBox();
            this.comboBoxTeamLeader = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxAllUsers
            // 
            this.comboBoxAllUsers.FormattingEnabled = true;
            this.comboBoxAllUsers.Location = new System.Drawing.Point(80, 41);
            this.comboBoxAllUsers.Name = "comboBoxAllUsers";
            this.comboBoxAllUsers.Size = new System.Drawing.Size(154, 21);
            this.comboBoxAllUsers.TabIndex = 27;
            // 
            // comboBoxTeamLeader
            // 
            this.comboBoxTeamLeader.FormattingEnabled = true;
            this.comboBoxTeamLeader.Location = new System.Drawing.Point(455, 41);
            this.comboBoxTeamLeader.Name = "comboBoxTeamLeader";
            this.comboBoxTeamLeader.Size = new System.Drawing.Size(140, 21);
            this.comboBoxTeamLeader.TabIndex = 26;
            // 
            // ManagementTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxAllUsers);
            this.Controls.Add(this.comboBoxTeamLeader);
            this.Name = "ManagementTeam";
            this.Text = "ManagementTeam";
            this.Load += new System.EventHandler(this.ManagementTeam_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAllUsers;
        private System.Windows.Forms.ComboBox comboBoxTeamLeader;
    }
}