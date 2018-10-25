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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonTask = new System.Windows.Forms.Button();
            this.labelTimer = new System.Windows.Forms.Label();
            this.buttonContacting = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.buttonContacting.Location = new System.Drawing.Point(597, 346);
            this.buttonContacting.Name = "buttonContacting";
            this.buttonContacting.Size = new System.Drawing.Size(137, 62);
            this.buttonContacting.TabIndex = 3;
            this.buttonContacting.Text = "Contacting the manager";
            this.buttonContacting.UseVisualStyleBackColor = true;
            this.buttonContacting.Click += new System.EventHandler(this.buttonContacting_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(366, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(297, 262);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // EnterWorkers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonContacting);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.buttonTask);
            this.Controls.Add(this.labelTime);
            this.Name = "EnterWorkers";
            this.Text = "EnterWorkers";
            this.Load += new System.EventHandler(this.EnterWorkers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
    }
}