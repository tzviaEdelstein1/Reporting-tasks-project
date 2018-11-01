using Newtonsoft.Json;
using ReportingTasksWinform.Models;
using ReportingTasksWinform.Reqests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ReportingTasksWinform
{
    public partial class EnterWorkers : Form
    {
        TimeSpan d;
        string projectId;
        int count = 0;
        string countTimer;
        DateTime startDate;
        DateTime endDate;
        List<Unknown> projectDetails = new List<Unknown>();
        List<Unknown> projectDetailsByDate;
        double time;
        public EnterWorkers()
        {
            InitializeComponent();
        }

        private void EnterWorkers_Load(object sender, EventArgs e)
        {
            StartTimer();
            buttonTask.BackColor = Color.Green;
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            string countTimer;
            //get the datails of project        
            projectDetails = ProjectsRequst.GetProjectsAndHoursByUserId();
            if (projectDetails != null)
                dataGridView1.DataSource = projectDetails;

            projectDetailsByDate = ProjectsRequst.GetProjectsAndHoursByUserIdAccordingTheMonth();
            if (projectDetailsByDate != null)
                fillChart();

        }

        private void fillChart()
        {
            Dictionary<string, int> allocatedHours = new Dictionary<string, int>();
            List<float> workedHours = new List<float>();
            if (projectDetailsByDate != null)
            {
                foreach (var item in projectDetailsByDate)
                {
                    allocatedHours.Add(item.Name, Convert.ToInt32(item.allocatedHours));
                    //if (item.Hours !=)
                    workedHours.Add((float)item.Hours);
                    //else workedHours.Add(0);
                }
                chart1.Series[0].Points.DataBindXY(allocatedHours.Keys, allocatedHours.Values);
                chart1.Series[1].Points.DataBindXY(allocatedHours.Keys, workedHours);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = DateTime.Now - startDate;
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
                //dataGridView1.SelectedRows.
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    projectId = dataGridView1.CurrentRow.Cells["Id"].FormattedValue.ToString();
                }
            }
            else
            {
                TimeSpan span = DateTime.Now - startDate;
                double a = span.Hours;
                double z = span.Minutes;
                var x = span.Seconds;
                time = a + z / 60;
                startDate = DateTime.Now;
                countTimer = labelTimer.Text;
                buttonTask.Text = "Start task";
                timer1.Stop();
                buttonTask.BackColor = Color.Green;
                addActulHoursToWorker();

            }
        }

        private void addActulHoursToWorker()
        {  //-----------------------------צריך לסכום את מספר השעות!!!!!!!!!!!!------------
            ActualHours actualHours = new ActualHours() { CountHours = time, date = DateTime.Now, UserId = Global.UserId, ProjectId = Convert.ToInt32(projectId) };
            HoursRequst.AddActualHours(actualHours);
        }

        private void buttonContacting_Click(object sender, EventArgs e)
        {
            ConactingTheManager conactingTheManager = new ConactingTheManager();
            conactingTheManager.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string id = dataGridView1.SelectedCells[0].Value.ToString();
            }
        }
    }
}
