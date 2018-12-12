using ReportingTasksWinform.Models;
using ReportingTasksWinform.Reqests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace ReportingTasksWinform
{
    public partial class EnterWorkers : Form
    {
        int count = 0;
        string countTimer;
        TimeSpan d;
        DateTime endDate;
        Login login;
        List<Project> AllYourProjects;
        List<Unknown> projectDetails = new List<Unknown>();
        List<Unknown> projectDetailsByDate;
        int projectId;
        DateTime startDate;
        double time;

        Timer tmr = null;

        public EnterWorkers(Login login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void addActulHoursToWorker()
        {  //-----------------------------צריך לסכום את מספר השעות!!!!!!!!!!!!------------
            ActualHours actualHours = new ActualHours() { CountHours = time, date = DateTime.Now, UserId = Global.UserId, ProjectId = projectId };
            HoursRequst.AddActualHours(actualHours);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserRequsts.Logout();
            this.Close();
            login.Opacity = 100;
            login.ShowInTaskbar = true;
        }

        private void buttonContacting_Click(object sender, EventArgs e)
        {
            ConactingTheManager conactingTheManager = new ConactingTheManager();
            conactingTheManager.Show();
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
                projectId =(int)comboBoxAllYourProjects.SelectedValue;
                //if (dataGridView1.SelectedCells.Count > 0)
                //{
                //    projectId = dataGridView1.CurrentRow.Cells["Id"].FormattedValue.ToString();
                //}
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
                load();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string id = dataGridView1.SelectedCells[0].Value.ToString();
            }
        }

        private void EnterWorkers_Load(object sender, EventArgs e)
        {
            AllYourProjects = ProjectsRequst.GetProjectsByUserId(Global.UserId);
            if (AllYourProjects != null)
            {
                comboBoxAllYourProjects.SelectedIndexChanged -= new EventHandler(comboBoxAllYourProjects_SelectedIndexChanged);
                comboBoxAllYourProjects.DataSource = AllYourProjects;
                comboBoxAllYourProjects.DisplayMember = "ProjectName";
                comboBoxAllYourProjects.ValueMember = "ProjectId";
                comboBoxAllYourProjects.SelectedIndexChanged += comboBoxAllYourProjects_SelectedIndexChanged;
            }

            load();
        }
        private void load()
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

                    workedHours.Add((float)item.Hours);

                }
                chart1.Series[1].Points.DataBindXY(allocatedHours.Keys, allocatedHours.Values);
                chart1.Series[0].Points.DataBindXY(allocatedHours.Keys, workedHours);
            }
        }

        private void StartTimer()
        {
            tmr = new Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d = DateTime.Now - startDate;
            labelTimer.Text = d.ToString(@"hh\:mm\:ss");
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString();
        }

        private void comboBoxAllYourProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
