namespace ReportingTasksWinform.Forms.Manager
{
    partial class AddUser
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxUserKind = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxTeamLeader = new System.Windows.Forms.ComboBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.buttonAddUser);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.textBoxPassword);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.comboBoxUserKind);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.comboBoxTeamLeader);
            this.panel3.Controls.Add(this.textBoxEmail);
            this.panel3.Controls.Add(this.textBoxUserName);
            this.panel3.Location = new System.Drawing.Point(228, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(344, 321);
            this.panel3.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(42, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 42;
            this.label1.Text = "password";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label11.Location = new System.Drawing.Point(74, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 23);
            this.label11.TabIndex = 41;
            this.label11.Text = "email";
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonAddUser.Font = new System.Drawing.Font("Aharoni", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonAddUser.Location = new System.Drawing.Point(116, 210);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(142, 52);
            this.buttonAddUser.TabIndex = 22;
            this.buttonAddUser.Text = "AddUser";
            this.buttonAddUser.UseVisualStyleBackColor = false;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label12.Location = new System.Drawing.Point(27, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 23);
            this.label12.TabIndex = 40;
            this.label12.Text = "team leader";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(136, 96);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(140, 20);
            this.textBoxPassword.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label13.Location = new System.Drawing.Point(35, 159);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 23);
            this.label13.TabIndex = 39;
            this.label13.Text = "user kind";
            // 
            // comboBoxUserKind
            // 
            this.comboBoxUserKind.FormattingEnabled = true;
            this.comboBoxUserKind.Location = new System.Drawing.Point(136, 163);
            this.comboBoxUserKind.Name = "comboBoxUserKind";
            this.comboBoxUserKind.Size = new System.Drawing.Size(140, 21);
            this.comboBoxUserKind.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label14.Location = new System.Drawing.Point(35, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 23);
            this.label14.TabIndex = 38;
            this.label14.Text = "UserName";
            // 
            // comboBoxTeamLeader
            // 
            this.comboBoxTeamLeader.FormattingEnabled = true;
            this.comboBoxTeamLeader.Location = new System.Drawing.Point(136, 129);
            this.comboBoxTeamLeader.Name = "comboBoxTeamLeader";
            this.comboBoxTeamLeader.Size = new System.Drawing.Size(140, 21);
            this.comboBoxTeamLeader.TabIndex = 20;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(136, 56);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(140, 20);
            this.textBoxEmail.TabIndex = 5;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(136, 28);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(140, 20);
            this.textBoxUserName.TabIndex = 4;
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Name = "AddUser";
            this.Text = "AddUser";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxUserKind;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxTeamLeader;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxUserName;
    }
}