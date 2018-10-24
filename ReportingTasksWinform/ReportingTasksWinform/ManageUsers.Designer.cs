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
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AddUser = new System.Windows.Forms.TabPage();
            this.EditUser = new System.Windows.Forms.TabPage();
            this.RemoveUser = new System.Windows.Forms.TabPage();
            this.comboBoxUserKindEdit = new System.Windows.Forms.ComboBox();
            this.comboBoxTeamLeaderEdit = new System.Windows.Forms.ComboBox();
            this.textBoxPasswordEdit = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxEmailEdit = new System.Windows.Forms.TextBox();
            this.textBoxUserNameEdit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.comboBoxTeamLeader = new System.Windows.Forms.ComboBox();
            this.comboBoxUserKind = new System.Windows.Forms.ComboBox();
            this.comboBoxAllUsers = new System.Windows.Forms.ComboBox();
            this.comboBoxAllUsersRemove = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.AddUser.SuspendLayout();
            this.EditUser.SuspendLayout();
            this.RemoveUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(372, 221);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(142, 52);
            this.buttonAddUser.TabIndex = 22;
            this.buttonAddUser.Text = "AddUser";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(290, 218);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(142, 52);
            this.buttonUpdate.TabIndex = 23;
            this.buttonUpdate.Text = "updateUser";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(257, 136);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(142, 52);
            this.buttonRemove.TabIndex = 24;
            this.buttonRemove.Text = "Remove User";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AddUser);
            this.tabControl1.Controls.Add(this.EditUser);
            this.tabControl1.Controls.Add(this.RemoveUser);
            this.tabControl1.Location = new System.Drawing.Point(23, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 332);
            this.tabControl1.TabIndex = 26;
            // 
            // AddUser
            // 
            this.AddUser.Controls.Add(this.buttonAddUser);
            this.AddUser.Controls.Add(this.textBoxPassword);
            this.AddUser.Controls.Add(this.comboBoxUserKind);
            this.AddUser.Controls.Add(this.label1);
            this.AddUser.Controls.Add(this.comboBoxTeamLeader);
            this.AddUser.Controls.Add(this.label2);
            this.AddUser.Controls.Add(this.label3);
            this.AddUser.Controls.Add(this.label5);
            this.AddUser.Controls.Add(this.label4);
            this.AddUser.Controls.Add(this.textBoxEmail);
            this.AddUser.Controls.Add(this.textBoxUserName);
            this.AddUser.Location = new System.Drawing.Point(4, 22);
            this.AddUser.Name = "AddUser";
            this.AddUser.Padding = new System.Windows.Forms.Padding(3);
            this.AddUser.Size = new System.Drawing.Size(721, 306);
            this.AddUser.TabIndex = 0;
            this.AddUser.Text = "AddUser";
            this.AddUser.UseVisualStyleBackColor = true;
            // 
            // EditUser
            // 
            this.EditUser.Controls.Add(this.comboBoxAllUsers);
            this.EditUser.Controls.Add(this.comboBoxUserKindEdit);
            this.EditUser.Controls.Add(this.comboBoxTeamLeaderEdit);
            this.EditUser.Controls.Add(this.textBoxPasswordEdit);
            this.EditUser.Controls.Add(this.buttonUpdate);
            this.EditUser.Controls.Add(this.label11);
            this.EditUser.Controls.Add(this.textBoxEmailEdit);
            this.EditUser.Controls.Add(this.textBoxUserNameEdit);
            this.EditUser.Controls.Add(this.label12);
            this.EditUser.Controls.Add(this.label13);
            this.EditUser.Controls.Add(this.label14);
            this.EditUser.Controls.Add(this.label15);
            this.EditUser.Location = new System.Drawing.Point(4, 22);
            this.EditUser.Name = "EditUser";
            this.EditUser.Padding = new System.Windows.Forms.Padding(3);
            this.EditUser.Size = new System.Drawing.Size(721, 306);
            this.EditUser.TabIndex = 1;
            this.EditUser.Text = "EditUser";
            this.EditUser.UseVisualStyleBackColor = true;
            // 
            // RemoveUser
            // 
            this.RemoveUser.Controls.Add(this.comboBoxAllUsersRemove);
            this.RemoveUser.Controls.Add(this.buttonRemove);
            this.RemoveUser.Location = new System.Drawing.Point(4, 22);
            this.RemoveUser.Name = "RemoveUser";
            this.RemoveUser.Size = new System.Drawing.Size(721, 306);
            this.RemoveUser.TabIndex = 2;
            this.RemoveUser.Text = "RemoveUser";
            this.RemoveUser.UseVisualStyleBackColor = true;
            // 
            // comboBoxUserKindEdit
            // 
            this.comboBoxUserKindEdit.FormattingEnabled = true;
            this.comboBoxUserKindEdit.Location = new System.Drawing.Point(258, 167);
            this.comboBoxUserKindEdit.Name = "comboBoxUserKindEdit";
            this.comboBoxUserKindEdit.Size = new System.Drawing.Size(140, 21);
            this.comboBoxUserKindEdit.TabIndex = 31;
            // 
            // comboBoxTeamLeaderEdit
            // 
            this.comboBoxTeamLeaderEdit.FormattingEnabled = true;
            this.comboBoxTeamLeaderEdit.Location = new System.Drawing.Point(258, 133);
            this.comboBoxTeamLeaderEdit.Name = "comboBoxTeamLeaderEdit";
            this.comboBoxTeamLeaderEdit.Size = new System.Drawing.Size(140, 21);
            this.comboBoxTeamLeaderEdit.TabIndex = 30;
            // 
            // textBoxPasswordEdit
            // 
            this.textBoxPasswordEdit.Location = new System.Drawing.Point(258, 100);
            this.textBoxPasswordEdit.Name = "textBoxPasswordEdit";
            this.textBoxPasswordEdit.Size = new System.Drawing.Size(140, 20);
            this.textBoxPasswordEdit.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(197, 167);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "user kind";
            // 
            // textBoxEmailEdit
            // 
            this.textBoxEmailEdit.Location = new System.Drawing.Point(258, 60);
            this.textBoxEmailEdit.Name = "textBoxEmailEdit";
            this.textBoxEmailEdit.Size = new System.Drawing.Size(140, 20);
            this.textBoxEmailEdit.TabIndex = 27;
            // 
            // textBoxUserNameEdit
            // 
            this.textBoxUserNameEdit.Location = new System.Drawing.Point(258, 32);
            this.textBoxUserNameEdit.Name = "textBoxUserNameEdit";
            this.textBoxUserNameEdit.Size = new System.Drawing.Size(140, 20);
            this.textBoxUserNameEdit.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(189, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "team leader";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(195, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "password";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(195, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "email";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(195, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "user name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "user name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "team leader";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(374, 43);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(140, 20);
            this.textBoxUserName.TabIndex = 4;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(374, 71);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(140, 20);
            this.textBoxEmail.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "user kind";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(374, 111);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(140, 20);
            this.textBoxPassword.TabIndex = 7;
            // 
            // comboBoxTeamLeader
            // 
            this.comboBoxTeamLeader.FormattingEnabled = true;
            this.comboBoxTeamLeader.Location = new System.Drawing.Point(374, 144);
            this.comboBoxTeamLeader.Name = "comboBoxTeamLeader";
            this.comboBoxTeamLeader.Size = new System.Drawing.Size(140, 21);
            this.comboBoxTeamLeader.TabIndex = 20;
            // 
            // comboBoxUserKind
            // 
            this.comboBoxUserKind.FormattingEnabled = true;
            this.comboBoxUserKind.Location = new System.Drawing.Point(374, 178);
            this.comboBoxUserKind.Name = "comboBoxUserKind";
            this.comboBoxUserKind.Size = new System.Drawing.Size(140, 21);
            this.comboBoxUserKind.TabIndex = 21;
            // 
            // comboBoxAllUsers
            // 
            this.comboBoxAllUsers.FormattingEnabled = true;
            this.comboBoxAllUsers.Location = new System.Drawing.Point(493, 63);
            this.comboBoxAllUsers.Name = "comboBoxAllUsers";
            this.comboBoxAllUsers.Size = new System.Drawing.Size(154, 21);
            this.comboBoxAllUsers.TabIndex = 33;
            this.comboBoxAllUsers.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAllUsers_SelectedIndexChanged);
            // 
            // comboBoxAllUsersRemove
            // 
            this.comboBoxAllUsersRemove.FormattingEnabled = true;
            this.comboBoxAllUsersRemove.Location = new System.Drawing.Point(444, 43);
            this.comboBoxAllUsersRemove.Name = "comboBoxAllUsersRemove";
            this.comboBoxAllUsersRemove.Size = new System.Drawing.Size(171, 21);
            this.comboBoxAllUsersRemove.TabIndex = 25;
            this.comboBoxAllUsersRemove.SelectedIndexChanged += new System.EventHandler(this.comboBoxAllUsersRemove_SelectedIndexChanged);
            // 
            // ManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "ManageUsers";
            this.Text = "ManageUsers";
            this.Load += new System.EventHandler(this.ManageUsers_Load);
            this.tabControl1.ResumeLayout(false);
            this.AddUser.ResumeLayout(false);
            this.AddUser.PerformLayout();
            this.EditUser.ResumeLayout(false);
            this.EditUser.PerformLayout();
            this.RemoveUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AddUser;
        private System.Windows.Forms.TabPage EditUser;
        private System.Windows.Forms.ComboBox comboBoxUserKindEdit;
        private System.Windows.Forms.ComboBox comboBoxTeamLeaderEdit;
        private System.Windows.Forms.TextBox textBoxPasswordEdit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxEmailEdit;
        private System.Windows.Forms.TextBox textBoxUserNameEdit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage RemoveUser;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.ComboBox comboBoxUserKind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTeamLeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.ComboBox comboBoxAllUsers;
        private System.Windows.Forms.ComboBox comboBoxAllUsersRemove;
    }
}