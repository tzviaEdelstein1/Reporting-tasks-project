using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportingTasksWinform
{
    public partial class EnterWorkers : Form
    { int count = 0;
        DateTime startDate;
        public EnterWorkers()
        {
            InitializeComponent();
        }

        private void EnterWorkers_Load(object sender, EventArgs e)
        {
            StartTimer();
            buttonTask.BackColor = Color.Green;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
                var d = DateTime.Now -startDate;
                labelTimer.Text = d.ToString(@"hh\:mm\:ss");
   

        }

        Timer tmr = null;

        private void StartTimer()
        {
            tmr = new Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString();
        }

        private void buttonTask_Click(object sender, EventArgs e)
        {
            if (buttonTask.Text == "Start task")
            {
                startDate = DateTime.Now;
                timer1.Interval = 1000;
                timer1.Start();
                buttonTask.Text = "End task";
                buttonTask.BackColor = Color.Red;
            }
            else
            {
                startDate = DateTime.Now;
                var countTimer = labelTimer.Text;
                buttonTask.Text = "Start task";
                timer1.Stop();
                buttonTask.BackColor = Color.Green;
            }
        }

        private void buttonContacting_Click(object sender, EventArgs e)
        {

        }
    }
}
