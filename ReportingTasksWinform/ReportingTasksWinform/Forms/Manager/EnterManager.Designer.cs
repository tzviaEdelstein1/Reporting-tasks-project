﻿namespace ReportingTasksWinform
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnLogout = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(12, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(754, 457);
            this.tabControl1.TabIndex = 5;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(12, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(129, 32);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 36);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EnterManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 509);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl1);
            this.IsMdiContainer = true;
            this.Name = "EnterManager";
            this.Text = "EnterManager";
            this.Load += new System.EventHandler(this.EnterManager_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button button1;
    }
}