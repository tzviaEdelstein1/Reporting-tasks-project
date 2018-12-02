namespace ReportingTasksWinform
{
    partial class ViewingProjects
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
            this.comboBoxAllYourProjects = new System.Windows.Forms.ComboBox();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.labelClientName = new System.Windows.Forms.Label();
            this.labelDevelopersHours = new System.Windows.Forms.Label();
            this.labelQaHours = new System.Windows.Forms.Label();
            this.labelUiUxHours = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelFinishDate = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTeamLeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxAllYourProjects
            // 
            this.comboBoxAllYourProjects.FormattingEnabled = true;
            this.comboBoxAllYourProjects.Location = new System.Drawing.Point(433, 69);
            this.comboBoxAllYourProjects.Name = "comboBoxAllYourProjects";
            this.comboBoxAllYourProjects.Size = new System.Drawing.Size(159, 21);
            this.comboBoxAllYourProjects.TabIndex = 0;
            this.comboBoxAllYourProjects.SelectedIndexChanged += new System.EventHandler(this.comboBoxAllYourProjects_SelectedIndexChanged);
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Location = new System.Drawing.Point(175, 63);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(68, 13);
            this.labelProjectName.TabIndex = 1;
            this.labelProjectName.Text = "ProjectName";
            // 
            // labelClientName
            // 
            this.labelClientName.AutoSize = true;
            this.labelClientName.Location = new System.Drawing.Point(175, 92);
            this.labelClientName.Name = "labelClientName";
            this.labelClientName.Size = new System.Drawing.Size(61, 13);
            this.labelClientName.TabIndex = 2;
            this.labelClientName.Text = "ClientName";
            // 
            // labelDevelopersHours
            // 
            this.labelDevelopersHours.AutoSize = true;
            this.labelDevelopersHours.Location = new System.Drawing.Point(175, 125);
            this.labelDevelopersHours.Name = "labelDevelopersHours";
            this.labelDevelopersHours.Size = new System.Drawing.Size(89, 13);
            this.labelDevelopersHours.TabIndex = 3;
            this.labelDevelopersHours.Text = "DevelopersHours";
            // 
            // labelQaHours
            // 
            this.labelQaHours.AutoSize = true;
            this.labelQaHours.Location = new System.Drawing.Point(178, 150);
            this.labelQaHours.Name = "labelQaHours";
            this.labelQaHours.Size = new System.Drawing.Size(49, 13);
            this.labelQaHours.TabIndex = 4;
            this.labelQaHours.Text = "QaHours";
            // 
            // labelUiUxHours
            // 
            this.labelUiUxHours.AutoSize = true;
            this.labelUiUxHours.Location = new System.Drawing.Point(176, 177);
            this.labelUiUxHours.Name = "labelUiUxHours";
            this.labelUiUxHours.Size = new System.Drawing.Size(58, 13);
            this.labelUiUxHours.TabIndex = 5;
            this.labelUiUxHours.Text = "UiUxHours";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(178, 217);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(52, 13);
            this.labelStartDate.TabIndex = 6;
            this.labelStartDate.Text = "StartDate";
            // 
            // labelFinishDate
            // 
            this.labelFinishDate.AutoSize = true;
            this.labelFinishDate.Location = new System.Drawing.Point(175, 248);
            this.labelFinishDate.Name = "labelFinishDate";
            this.labelFinishDate.Size = new System.Drawing.Size(57, 13);
            this.labelFinishDate.TabIndex = 7;
            this.labelFinishDate.Text = "FinishDate";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(579, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(227, 235);
            this.dataGridView1.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTeamLeader);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.labelFinishDate);
            this.panel1.Controls.Add(this.labelStartDate);
            this.panel1.Controls.Add(this.labelUiUxHours);
            this.panel1.Controls.Add(this.labelQaHours);
            this.panel1.Controls.Add(this.labelDevelopersHours);
            this.panel1.Controls.Add(this.labelClientName);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.labelProjectName);
            this.panel1.Location = new System.Drawing.Point(44, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 326);
            this.panel1.TabIndex = 17;
            // 
            // labelTeamLeader
            // 
            this.labelTeamLeader.AutoSize = true;
            this.labelTeamLeader.Location = new System.Drawing.Point(172, 288);
            this.labelTeamLeader.Name = "labelTeamLeader";
            this.labelTeamLeader.Size = new System.Drawing.Size(62, 13);
            this.labelTeamLeader.TabIndex = 39;
            this.labelTeamLeader.Text = "team leader";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(78, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 23);
            this.label1.TabIndex = 38;
            this.label1.Text = "Project Details";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label15.Location = new System.Drawing.Point(33, 281);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 23);
            this.label15.TabIndex = 35;
            this.label15.Text = "team leader";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label10.Location = new System.Drawing.Point(43, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 23);
            this.label10.TabIndex = 37;
            this.label10.Text = "date finish";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label16.Location = new System.Drawing.Point(55, 85);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 23);
            this.label16.TabIndex = 36;
            this.label16.Text = "client name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label11.Location = new System.Drawing.Point(43, 217);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 23);
            this.label11.TabIndex = 31;
            this.label11.Text = "date start";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label12.Location = new System.Drawing.Point(55, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 23);
            this.label12.TabIndex = 32;
            this.label12.Text = "UI/UX";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label13.Location = new System.Drawing.Point(43, 143);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 23);
            this.label13.TabIndex = 33;
            this.label13.Text = "Qa hours";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label14.Location = new System.Drawing.Point(14, 118);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(139, 23);
            this.label14.TabIndex = 34;
            this.label14.Text = "devalopers hours";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label17.Location = new System.Drawing.Point(55, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 23);
            this.label17.TabIndex = 30;
            this.label17.Text = "name project";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(575, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 23);
            this.label2.TabIndex = 39;
            this.label2.Text = "Workers in this project";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(438, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 23);
            this.label3.TabIndex = 39;
            this.label3.Text = "choose project";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ViewingProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 530);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxAllYourProjects);
            this.Name = "ViewingProjects";
            this.Text = "ViewingProjects";
            this.Load += new System.EventHandler(this.ViewingProjects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAllYourProjects;
        private System.Windows.Forms.Label labelProjectName;
        private System.Windows.Forms.Label labelClientName;
        private System.Windows.Forms.Label labelDevelopersHours;
        private System.Windows.Forms.Label labelQaHours;
        private System.Windows.Forms.Label labelUiUxHours;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelFinishDate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTeamLeader;
    }
}