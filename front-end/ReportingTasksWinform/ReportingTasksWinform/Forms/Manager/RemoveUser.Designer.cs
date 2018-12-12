namespace ReportingTasksWinform.Forms.Manager
{
    partial class RemoveUser
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxAllUsersRemove = new System.Windows.Forms.ComboBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.comboBoxAllUsersRemove);
            this.panel1.Controls.Add(this.buttonRemove);
            this.panel1.Location = new System.Drawing.Point(238, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 278);
            this.panel1.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 278);
            this.panel2.TabIndex = 27;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(62, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(171, 21);
            this.comboBox1.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Font = new System.Drawing.Font("Aharoni", 15.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(52, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 52);
            this.button1.TabIndex = 24;
            this.button1.Text = "Remove User";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxAllUsersRemove
            // 
            this.comboBoxAllUsersRemove.FormattingEnabled = true;
            this.comboBoxAllUsersRemove.Location = new System.Drawing.Point(62, 50);
            this.comboBoxAllUsersRemove.Name = "comboBoxAllUsersRemove";
            this.comboBoxAllUsersRemove.Size = new System.Drawing.Size(171, 21);
            this.comboBoxAllUsersRemove.TabIndex = 25;
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
            // 
            // RemoveUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "RemoveUser";
            this.Text = "RemoveUser";
            this.Load += new System.EventHandler(this.RemoveUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxAllUsersRemove;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}