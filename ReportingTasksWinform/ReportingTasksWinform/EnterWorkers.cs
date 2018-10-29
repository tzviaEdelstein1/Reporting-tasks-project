using Newtonsoft.Json;
using ReportingTasksWinform.Models;
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


            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Projects/GetProjectsAndHoursByUserId/" + Global.UserId);
                response = (HttpWebResponse)request.GetResponse();
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                projectDetails = JsonConvert.DeserializeObject<List<Unknown>>(content);
                dataGridView1.DataSource = projectDetails;
                MessageBox.Show("success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }


            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Projects/GetProjectsAndHoursByUserIdAccordingTheMonth/" + Global.UserId);
                response = (HttpWebResponse)request.GetResponse();
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                projectDetailsByDate = JsonConvert.DeserializeObject<List<Unknown>>(content);
                fillChart();
                MessageBox.Show("success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
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
                    projectId= dataGridView1.CurrentRow.Cells["Id"].FormattedValue.ToString();
                }
            }
            else
            {
               TimeSpan span= DateTime.Now-startDate;
                var a = span.Hours;
                var z = span.Minutes;
                var x = span.Seconds;
                double time = a + z / 60 + x / 60 / 60;
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
            ActualHours actualHours = new ActualHours() { CountHours =2, date = DateTime.Now, UserId = Global.UserId, ProjectId =Convert.ToInt32(projectId) };
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/Hours/" + Global.UserId);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(actualHours);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                MessageBox.Show("sucsess");
            }
            catch (Exception ex)
            {

                MessageBox.Show("error", ex.Message.ToString());

            }
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
