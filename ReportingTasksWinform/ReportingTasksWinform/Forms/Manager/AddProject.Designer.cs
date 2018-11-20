namespace ReportingTasksWinform
{
    partial class AddProject
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
            this.textBoxNameProject = new System.Windows.Forms.TextBox();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.numericDevelopersHours = new System.Windows.Forms.NumericUpDown();
            this.numericQaHours = new System.Windows.Forms.NumericUpDown();
            this.numericUiUxhours = new System.Windows.Forms.NumericUpDown();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.dateFinish = new System.Windows.Forms.DateTimePicker();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.comboBoxTeamLeader = new System.Windows.Forms.ComboBox();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericDevelopersHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericQaHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUiUxhours)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNameProject
            // 
            this.textBoxNameProject.Location = new System.Drawing.Point(172, 81);
            this.textBoxNameProject.Name = "textBoxNameProject";
            this.textBoxNameProject.Size = new System.Drawing.Size(178, 20);
            this.textBoxNameProject.TabIndex = 0;
            // 
            // textBoxClientName
            // 
            this.textBoxClientName.Location = new System.Drawing.Point(172, 107);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.Size = new System.Drawing.Size(178, 20);
            this.textBoxClientName.TabIndex = 3;
            // 
            // numericDevelopersHours
            // 
            this.numericDevelopersHours.Location = new System.Drawing.Point(198, 187);
            this.numericDevelopersHours.Name = "numericDevelopersHours";
            this.numericDevelopersHours.Size = new System.Drawing.Size(154, 20);
            this.numericDevelopersHours.TabIndex = 4;
            // 
            // numericQaHours
            // 
            this.numericQaHours.Location = new System.Drawing.Point(198, 227);
            this.numericQaHours.Name = "numericQaHours";
            this.numericQaHours.Size = new System.Drawing.Size(154, 20);
            this.numericQaHours.TabIndex = 5;
            // 
            // numericUiUxhours
            // 
            this.numericUiUxhours.Location = new System.Drawing.Point(198, 253);
            this.numericUiUxhours.Name = "numericUiUxhours";
            this.numericUiUxhours.Size = new System.Drawing.Size(154, 20);
            this.numericUiUxhours.TabIndex = 6;
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(198, 279);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(138, 20);
            this.dateStart.TabIndex = 7;
            // 
            // dateFinish
            // 
            this.dateFinish.Location = new System.Drawing.Point(198, 305);
            this.dateFinish.Name = "dateFinish";
            this.dateFinish.Size = new System.Drawing.Size(138, 20);
            this.dateFinish.TabIndex = 8;
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonAddProduct.Font = new System.Drawing.Font("Aharoni", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonAddProduct.Location = new System.Drawing.Point(93, 365);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(219, 76);
            this.buttonAddProduct.TabIndex = 18;
            this.buttonAddProduct.Text = "Add project";
            this.buttonAddProduct.UseVisualStyleBackColor = false;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // comboBoxTeamLeader
            // 
            this.comboBoxTeamLeader.FormattingEnabled = true;
            this.comboBoxTeamLeader.Location = new System.Drawing.Point(172, 132);
            this.comboBoxTeamLeader.Name = "comboBoxTeamLeader";
            this.comboBoxTeamLeader.Size = new System.Drawing.Size(182, 21);
            this.comboBoxTeamLeader.TabIndex = 19;
            this.comboBoxTeamLeader.SelectedIndexChanged += new System.EventHandler(this.comboBoxTeamLeader_SelectedIndexChanged);
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(21, 138);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxUsers.Size = new System.Drawing.Size(126, 173);
            this.listBoxUsers.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label10.Location = new System.Drawing.Point(52, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 23);
            this.label10.TabIndex = 22;
            this.label10.Text = "name project";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label11.Location = new System.Drawing.Point(78, 278);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 23);
            this.label11.TabIndex = 23;
            this.label11.Text = "date start";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label12.Location = new System.Drawing.Point(89, 250);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 23);
            this.label12.TabIndex = 24;
            this.label12.Text = "UI/UX";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label13.Location = new System.Drawing.Point(82, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 23);
            this.label13.TabIndex = 25;
            this.label13.Text = "Qa hours";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label14.Location = new System.Drawing.Point(42, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(139, 23);
            this.label14.TabIndex = 26;
            this.label14.Text = "devalopers hours";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label15.Location = new System.Drawing.Point(52, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 23);
            this.label15.TabIndex = 27;
            this.label15.Text = "team leader";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label16.Location = new System.Drawing.Point(52, 107);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 23);
            this.label16.TabIndex = 28;
            this.label16.Text = "client name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(78, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 23);
            this.label1.TabIndex = 29;
            this.label1.Text = "date finish";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(27, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "anotherWorkers";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.comboBoxTeamLeader);
            this.panel1.Controls.Add(this.buttonAddProduct);
            this.panel1.Controls.Add(this.dateFinish);
            this.panel1.Controls.Add(this.dateStart);
            this.panel1.Controls.Add(this.numericUiUxhours);
            this.panel1.Controls.Add(this.numericQaHours);
            this.panel1.Controls.Add(this.numericDevelopersHours);
            this.panel1.Controls.Add(this.textBoxClientName);
            this.panel1.Controls.Add(this.textBoxNameProject);
            this.panel1.Location = new System.Drawing.Point(188, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 489);
            this.panel1.TabIndex = 31;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(87, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 34);
            this.label3.TabIndex = 30;
            this.label3.Text = " fill project details";
            // 
            // AddProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 529);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxUsers);
            this.Name = "AddProject";
            this.Text = "AddProduct";
            this.Load += new System.EventHandler(this.AddProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericDevelopersHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericQaHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUiUxhours)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNameProject;
        private System.Windows.Forms.TextBox textBoxClientName;
        private System.Windows.Forms.NumericUpDown numericDevelopersHours;
        private System.Windows.Forms.NumericUpDown numericQaHours;
        private System.Windows.Forms.NumericUpDown numericUiUxhours;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.DateTimePicker dateFinish;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.ComboBox comboBoxTeamLeader;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}