namespace ReportingTasksWinform.Forms.Manager
{
    partial class Reports
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
            this.radVirtualGrid1 = new Telerik.WinControls.UI.RadVirtualGrid();
            this.projects_combobox = new System.Windows.Forms.ComboBox();
            this.workers_combo = new System.Windows.Forms.ComboBox();
            this.Teams_combo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.monthCalendar_start = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar_finish = new System.Windows.Forms.MonthCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radVirtualGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // radVirtualGrid1
            // 
            this.radVirtualGrid1.Location = new System.Drawing.Point(12, 234);
            this.radVirtualGrid1.MasterViewInfo.AllowColumnSort = false;
            this.radVirtualGrid1.MasterViewInfo.AllowCut = false;
            this.radVirtualGrid1.MasterViewInfo.AllowDelete = false;
            this.radVirtualGrid1.MasterViewInfo.AllowEdit = false;
            this.radVirtualGrid1.MasterViewInfo.AllowPaste = false;
            this.radVirtualGrid1.MasterViewInfo.ShowFilterRow = false;
            this.radVirtualGrid1.MasterViewInfo.ShowNewRow = false;
            this.radVirtualGrid1.Name = "radVirtualGrid1";
            this.radVirtualGrid1.Size = new System.Drawing.Size(1056, 381);
            this.radVirtualGrid1.TabIndex = 0;
            this.radVirtualGrid1.CellValueNeeded += new Telerik.WinControls.UI.VirtualGridCellValueNeededEventHandler(this.radVirtualGrid1_CellValueNeeded);
            this.radVirtualGrid1.CellFormatting += new Telerik.WinControls.UI.VirtualGridCellElementEventHandler(this.radVirtualGrid1_CellFormatting);
            this.radVirtualGrid1.RowExpanding += new Telerik.WinControls.UI.VirtualGridRowExpandingEventHandler(this.radVirtualGrid1_RowExpanding);
            this.radVirtualGrid1.QueryHasChildRows += new Telerik.WinControls.UI.VirtualGridQueryHasChildRowsEventHandler(this.radVirtualGrid1_QueryHasChildRows);
            // 
            // projects_combobox
            // 
            this.projects_combobox.FormattingEnabled = true;
            this.projects_combobox.Location = new System.Drawing.Point(85, 40);
            this.projects_combobox.Name = "projects_combobox";
            this.projects_combobox.Size = new System.Drawing.Size(121, 21);
            this.projects_combobox.TabIndex = 1;
            this.projects_combobox.SelectedIndexChanged += new System.EventHandler(this.projects_combobox_SelectedIndexChanged);
            // 
            // workers_combo
            // 
            this.workers_combo.FormattingEnabled = true;
            this.workers_combo.Location = new System.Drawing.Point(298, 40);
            this.workers_combo.Name = "workers_combo";
            this.workers_combo.Size = new System.Drawing.Size(121, 21);
            this.workers_combo.TabIndex = 2;
            this.workers_combo.SelectedIndexChanged += new System.EventHandler(this.projects_combobox_SelectedIndexChanged);
            // 
            // Teams_combo
            // 
            this.Teams_combo.FormattingEnabled = true;
            this.Teams_combo.Location = new System.Drawing.Point(541, 40);
            this.Teams_combo.Name = "Teams_combo";
            this.Teams_combo.Size = new System.Drawing.Size(121, 21);
            this.Teams_combo.TabIndex = 3;
            this.Teams_combo.SelectedIndexChanged += new System.EventHandler(this.projects_combobox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "AllProjects";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "AllWorkers";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(457, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "AllTeamLeader";
            // 
            // monthCalendar_start
            // 
            this.monthCalendar_start.Location = new System.Drawing.Point(694, 60);
            this.monthCalendar_start.Name = "monthCalendar_start";
            this.monthCalendar_start.TabIndex = 7;
            this.monthCalendar_start.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_start_DateChanged);
            // 
            // monthCalendar_finish
            // 
            this.monthCalendar_finish.Location = new System.Drawing.Point(949, 60);
            this.monthCalendar_finish.Name = "monthCalendar_finish";
            this.monthCalendar_finish.TabIndex = 8;
            this.monthCalendar_finish.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_finish_DateChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(781, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Begin Date ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1042, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Finish Date";
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 627);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.monthCalendar_finish);
            this.Controls.Add(this.monthCalendar_start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Teams_combo);
            this.Controls.Add(this.workers_combo);
            this.Controls.Add(this.projects_combobox);
            this.Controls.Add(this.radVirtualGrid1);
            this.Name = "Reports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.radVirtualGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       // private Telerik.WinControls.UI.RadPivotGrid radPivotGrid1;
        private Telerik.WinControls.UI.RadVirtualGrid radVirtualGrid1;
        private System.Windows.Forms.ComboBox projects_combobox;
        private System.Windows.Forms.ComboBox workers_combo;
        private System.Windows.Forms.ComboBox Teams_combo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MonthCalendar monthCalendar_start;
        private System.Windows.Forms.MonthCalendar monthCalendar_finish;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}