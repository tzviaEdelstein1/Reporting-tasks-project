namespace ReportingTasksWinform.Forms.Manager
{
    partial class EditUser
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
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxUserKindEdit = new System.Windows.Forms.ComboBox();
            this.comboBoxTeamLeaderEdit = new System.Windows.Forms.ComboBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxEmailEdit = new System.Windows.Forms.TextBox();
            this.textBoxUserNameEdit = new System.Windows.Forms.TextBox();
            this.comboBoxAllUsers = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label10.Location = new System.Drawing.Point(550, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 23);
            this.label10.TabIndex = 41;
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
            this.panel2.Location = new System.Drawing.Point(170, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 306);
            this.panel2.TabIndex = 40;
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
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click_1);
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
            this.comboBoxAllUsers.Location = new System.Drawing.Point(554, 92);
            this.comboBoxAllUsers.Name = "comboBoxAllUsers";
            this.comboBoxAllUsers.Size = new System.Drawing.Size(154, 21);
            this.comboBoxAllUsers.TabIndex = 39;
            this.comboBoxAllUsers.SelectedIndexChanged += new System.EventHandler(this.comboBoxAllUsers_SelectedIndexChanged_1);
            // 
            // EditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.comboBoxAllUsers);
            this.Name = "EditUser";
            this.Text = "EditUser";
            this.Load += new System.EventHandler(this.EditUser_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxUserKindEdit;
        private System.Windows.Forms.ComboBox comboBoxTeamLeaderEdit;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxEmailEdit;
        private System.Windows.Forms.TextBox textBoxUserNameEdit;
        private System.Windows.Forms.ComboBox comboBoxAllUsers;
    }
}