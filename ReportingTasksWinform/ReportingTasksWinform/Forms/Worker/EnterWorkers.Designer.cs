namespace ReportingTasksWinform
{
    partial class EnterWorkers
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonTask = new System.Windows.Forms.Button();
            this.labelTimer = new System.Windows.Forms.Label();
            this.buttonContacting = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(121, 27);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(35, 13);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "label1";
            // 
            // buttonTask
            // 
            this.buttonTask.Font = new System.Drawing.Font("Aharoni", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonTask.Location = new System.Drawing.Point(43, 60);
            this.buttonTask.Name = "buttonTask";
            this.buttonTask.Size = new System.Drawing.Size(160, 52);
            this.buttonTask.TabIndex = 1;
            this.buttonTask.Text = "Start task";
            this.buttonTask.UseVisualStyleBackColor = true;
            this.buttonTask.Click += new System.EventHandler(this.buttonTask_Click);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(93, 152);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(35, 13);
            this.labelTimer.TabIndex = 2;
            this.labelTimer.Text = "label1";
            // 
            // buttonContacting
            // 
            this.buttonContacting.Font = new System.Drawing.Font("Aharoni", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonContacting.Location = new System.Drawing.Point(506, 346);
            this.buttonContacting.Name = "buttonContacting";
            this.buttonContacting.Size = new System.Drawing.Size(228, 62);
            this.buttonContacting.TabIndex = 3;
            this.buttonContacting.Text = "Contacting the manager";
            this.buttonContacting.UseVisualStyleBackColor = true;
            this.buttonContacting.Click += new System.EventHandler(this.buttonContacting_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(475, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(297, 262);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 185);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "hours";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "actualHours";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(392, 182);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            this.chart1.UseWaitCursor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(232, 8);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(129, 32);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // EnterWorkers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonContacting);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.buttonTask);
            this.Controls.Add(this.labelTime);
            this.Name = "EnterWorkers";
            this.Text = "EnterWorkers";
            this.Load += new System.EventHandler(this.EnterWorkers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonTask;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Button buttonContacting;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnLogout;
    }
}