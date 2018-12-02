namespace ReportingTasksWinform
{
    partial class ManageUsers
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
            this.components = new System.ComponentModel.Container();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AddUser = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxUserKind = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxTeamLeader = new System.Windows.Forms.ComboBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.EditUser = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxUserKindEdit = new System.Windows.Forms.ComboBox();
            this.comboBoxTeamLeaderEdit = new System.Windows.Forms.ComboBox();
            this.textBoxEmailEdit = new System.Windows.Forms.TextBox();
            this.textBoxUserNameEdit = new System.Windows.Forms.TextBox();
            this.comboBoxAllUsers = new System.Windows.Forms.ComboBox();
            this.RemoveUser = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxAllUsersRemove = new System.Windows.Forms.ComboBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.AddUser.SuspendLayout();
            this.panel3.SuspendLayout();
            this.EditUser.SuspendLayout();
            this.panel2.SuspendLayout();
            this.RemoveUser.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonUpdate.Font = new System.Drawing.Font("Aharoni", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonUpdate.Location = new System.Drawing.Point(92, 197);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(174, 66);
            this.buttonUpdate.TabIndex = 23;
            this.buttonUpdate.Text = "updateUser";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AddUser);
            this.tabControl1.Controls.Add(this.EditUser);
            this.tabControl1.Controls.Add(this.RemoveUser);
            this.tabControl1.Location = new System.Drawing.Point(23, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 376);
            this.tabControl1.TabIndex = 26;
            // 
            // AddUser
            // 
            this.AddUser.Controls.Add(this.panel3);
            this.AddUser.Location = new System.Drawing.Point(4, 22);
            this.AddUser.Name = "AddUser";
            this.AddUser.Padding = new System.Windows.Forms.Padding(3);
            this.AddUser.Size = new System.Drawing.Size(721, 350);
            this.AddUser.TabIndex = 0;
            this.AddUser.Text = "AddUser";
            this.AddUser.UseVisualStyleBackColor = true;
            this.AddUser.Click += new System.EventHandler(this.AddUser_Click);
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
            this.panel3.Location = new System.Drawing.Point(238, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(344, 321);
            this.panel3.TabIndex = 43;
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
            // EditUser
            // 
            this.EditUser.Controls.Add(this.label10);
            this.EditUser.Controls.Add(this.panel2);
            this.EditUser.Controls.Add(this.comboBoxAllUsers);
            this.EditUser.Location = new System.Drawing.Point(4, 22);
            this.EditUser.Name = "EditUser";
            this.EditUser.Padding = new System.Windows.Forms.Padding(3);
            this.EditUser.Size = new System.Drawing.Size(721, 350);
            this.EditUser.TabIndex = 1;
            this.EditUser.Text = "EditUser";
            this.EditUser.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label10.Location = new System.Drawing.Point(521, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 23);
            this.label10.TabIndex = 38;
            this.label10.Text = "choose user to update";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.comboBoxUserKindEdit);
            this.panel2.Controls.Add(this.comboBoxTeamLeaderEdit);
            this.panel2.Controls.Add(this.buttonUpdate);
            this.panel2.Controls.Add(this.textBoxEmailEdit);
            this.panel2.Controls.Add(this.textBoxUserNameEdit);
            this.panel2.Location = new System.Drawing.Point(141, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 306);
            this.panel2.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(88, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 37;
            this.label9.Text = "email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(33, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 23);
            this.label8.TabIndex = 36;
            this.label8.Text = "team leader";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(56, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 23);
            this.label7.TabIndex = 35;
            this.label7.Text = "user kind";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(62, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 23);
            this.label6.TabIndex = 34;
            this.label6.Text = "UserName";
            // 
            // comboBoxUserKindEdit
            // 
            this.comboBoxUserKindEdit.FormattingEnabled = true;
            this.comboBoxUserKindEdit.Location = new System.Drawing.Point(158, 141);
            this.comboBoxUserKindEdit.Name = "comboBoxUserKindEdit";
            this.comboBoxUserKindEdit.Size = new System.Drawing.Size(140, 21);
            this.comboBoxUserKindEdit.TabIndex = 31;
            // 
            // comboBoxTeamLeaderEdit
            // 
            this.comboBoxTeamLeaderEdit.FormattingEnabled = true;
            this.comboBoxTeamLeaderEdit.Location = new System.Drawing.Point(158, 107);
            this.comboBoxTeamLeaderEdit.Name = "comboBoxTeamLeaderEdit";
            this.comboBoxTeamLeaderEdit.Size = new System.Drawing.Size(140, 21);
            this.comboBoxTeamLeaderEdit.TabIndex = 30;
            // 
            // textBoxEmailEdit
            // 
            this.textBoxEmailEdit.Location = new System.Drawing.Point(158, 70);
            this.textBoxEmailEdit.Name = "textBoxEmailEdit";
            this.textBoxEmailEdit.Size = new System.Drawing.Size(140, 20);
            this.textBoxEmailEdit.TabIndex = 27;
            // 
            // textBoxUserNameEdit
            // 
            this.textBoxUserNameEdit.Location = new System.Drawing.Point(158, 42);
            this.textBoxUserNameEdit.Name = "textBoxUserNameEdit";
            this.textBoxUserNameEdit.Size = new System.Drawing.Size(140, 20);
            this.textBoxUserNameEdit.TabIndex = 26;
            // 
            // comboBoxAllUsers
            // 
            this.comboBoxAllUsers.FormattingEnabled = true;
            this.comboBoxAllUsers.Location = new System.Drawing.Point(525, 62);
            this.comboBoxAllUsers.Name = "comboBoxAllUsers";
            this.comboBoxAllUsers.Size = new System.Drawing.Size(154, 21);
            this.comboBoxAllUsers.TabIndex = 33;
            this.comboBoxAllUsers.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAllUsers_SelectedIndexChanged);
            // 
            // RemoveUser
            // 
            this.RemoveUser.Controls.Add(this.panel1);
            this.RemoveUser.Location = new System.Drawing.Point(4, 22);
            this.RemoveUser.Name = "RemoveUser";
            this.RemoveUser.Size = new System.Drawing.Size(721, 350);
            this.RemoveUser.TabIndex = 2;
            this.RemoveUser.Text = "RemoveUser";
            this.RemoveUser.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboBoxAllUsersRemove);
            this.panel1.Controls.Add(this.buttonRemove);
            this.panel1.Location = new System.Drawing.Point(256, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 278);
            this.panel1.TabIndex = 26;
            // 
            // comboBoxAllUsersRemove
            // 
            this.comboBoxAllUsersRemove.FormattingEnabled = true;
            this.comboBoxAllUsersRemove.Location = new System.Drawing.Point(62, 50);
            this.comboBoxAllUsersRemove.Name = "comboBoxAllUsersRemove";
            this.comboBoxAllUsersRemove.Size = new System.Drawing.Size(171, 21);
            this.comboBoxAllUsersRemove.TabIndex = 25;
            this.comboBoxAllUsersRemove.SelectedIndexChanged += new System.EventHandler(this.comboBoxAllUsersRemove_SelectedIndexChanged);
            // 
            // buttonRemove
            // 
            this.buttonRemove.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonRemove.Font = new System.Drawing.Font("Aharoni", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonRemove.Location = new System.Drawing.Point(52, 108);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(219, 52);
            this.buttonRemove.TabIndex = 24;
            this.buttonRemove.Text = "Remove User";
            this.buttonRemove.UseVisualStyleBackColor = false;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 412);
            this.Controls.Add(this.tabControl1);
            this.Name = "ManageUsers";
            this.Text = "ManageUsers";
            this.Load += new System.EventHandler(this.ManageUsers_Load);
            this.tabControl1.ResumeLayout(false);
            this.AddUser.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.EditUser.ResumeLayout(false);
            this.EditUser.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.RemoveUser.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AddUser;
        private System.Windows.Forms.TabPage EditUser;
        private System.Windows.Forms.ComboBox comboBoxUserKindEdit;
        private System.Windows.Forms.ComboBox comboBoxTeamLeaderEdit;
        private System.Windows.Forms.TextBox textBoxEmailEdit;
        private System.Windows.Forms.TextBox textBoxUserNameEdit;
        private System.Windows.Forms.TabPage RemoveUser;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.ComboBox comboBoxUserKind;
        private System.Windows.Forms.ComboBox comboBoxTeamLeader;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.ComboBox comboBoxAllUsers;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxAllUsersRemove;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}