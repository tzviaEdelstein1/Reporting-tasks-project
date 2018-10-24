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
            this.buttonViewingProjects = new System.Windows.Forms.Button();
            this.buttonUpdatHours = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonViewingProjects
            // 
            this.buttonViewingProjects.Location = new System.Drawing.Point(113, 27);
            this.buttonViewingProjects.Name = "buttonViewingProjects";
            this.buttonViewingProjects.Size = new System.Drawing.Size(198, 38);
            this.buttonViewingProjects.TabIndex = 0;
            this.buttonViewingProjects.Text = "Viewing projects";
            this.buttonViewingProjects.UseVisualStyleBackColor = true;
            this.buttonViewingProjects.Click += new System.EventHandler(this.buttonViewingProjects_Click);
            // 
            // buttonUpdatHours
            // 
            this.buttonUpdatHours.Location = new System.Drawing.Point(355, 25);
            this.buttonUpdatHours.Name = "buttonUpdatHours";
            this.buttonUpdatHours.Size = new System.Drawing.Size(227, 43);
            this.buttonUpdatHours.TabIndex = 1;
            this.buttonUpdatHours.Text = "Update hours";
            this.buttonUpdatHours.UseVisualStyleBackColor = true;
            this.buttonUpdatHours.Click += new System.EventHandler(this.buttonUpdatHours_Click);
            // 
            // EnterTeamLeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonUpdatHours);
            this.Controls.Add(this.buttonViewingProjects);
            this.Name = "EnterTeamLeader";
            this.Text = "EnterTeamLeader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonViewingProjects;
        private System.Windows.Forms.Button buttonUpdatHours;
    }
}