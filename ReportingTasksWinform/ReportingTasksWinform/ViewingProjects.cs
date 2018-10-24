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
using System.Windows.Forms;

namespace ReportingTasksWinform
{
    public partial class ViewingProjects : Form
    {
        List<User> workersToProject = new List<User>();
        List<Project> ProjectsForteamLeader = new List<Project>();
        List<ActualHours> actualHours = new List<ActualHours>();
        public ViewingProjects()
        {
            InitializeComponent();
        }

        private void ViewingProjects_Load(object sender, EventArgs e)
        {

            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            //get the projects for team leader
            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Projects/" + Global.UserId);
                response = (HttpWebResponse)request.GetResponse();
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                ProjectsForteamLeader = JsonConvert.DeserializeObject<List<Project>>(content);
                MessageBox.Show("success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
            comboBoxAllYourProjects.SelectedIndexChanged -= new EventHandler(comboBoxAllYourProjects_SelectedIndexChanged);
            comboBoxAllYourProjects.DataSource = ProjectsForteamLeader;
            comboBoxAllYourProjects.DisplayMember = "ProjectName";
            comboBoxAllYourProjects.ValueMember = "ProjectId";
            comboBoxAllYourProjects.SelectedIndexChanged += comboBoxAllYourProjects_SelectedIndexChanged;


        }

        private void comboBoxAllYourProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelClientName.Text = (comboBoxAllYourProjects.SelectedItem as Project).ClientName;
            labelDevelopersHours.Text = (comboBoxAllYourProjects.SelectedItem as Project).DevelopersHours.ToString();
            labelFinishDate.Text = (comboBoxAllYourProjects.SelectedItem as Project).FinishDate.ToString();
            labelQaHours.Text = (comboBoxAllYourProjects.SelectedItem as Project).QaHours.ToString();
            labelStartDate.Text = (comboBoxAllYourProjects.SelectedItem as Project).StartDate.ToString();
            labelUiUxHours.Text = (comboBoxAllYourProjects.SelectedItem as Project).UiUxHours.ToString();
            labelProjectName.Text = (comboBoxAllYourProjects.SelectedItem as Project).ProjectName;

            //get the workers to project
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/WorkerToProject/GetWorkerbyProjectName/" + (comboBoxAllYourProjects.SelectedItem as Project).ProjectName);
                response = (HttpWebResponse)request.GetResponse();
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                workersToProject = JsonConvert.DeserializeObject<List<User>>(content);
                MessageBox.Show("success");
                listBox1.DataSource = workersToProject;
                listBox1.DisplayMember = "UserName";
                listBox1.ValueMember = "UserId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }

            //get the hours to project
            try
            {
                double count = 0;
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/GetActualHoursByProjectId/" +comboBoxAllYourProjects.SelectedValue);
                response = (HttpWebResponse)request.GetResponse();
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                actualHours = JsonConvert.DeserializeObject<List<ActualHours>>(content);

                tableLayoutPanel1.RowStyles.Clear();  //first you must clear rowStyles
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.ColumnStyles.Clear();
                for (int i = 0; i < workersToProject.Count; i++)
                {
                    Label l1 = new Label();
                    Label l2 = new Label();
                    l1.Text = workersToProject[i].UserName;
                    count = 0;
                   if (actualHours.Count > 0)
                        foreach (var item in actualHours)
                        {
                            if(item.UserId==workersToProject[i].UserId)
                            {
                                count += item.CountHours;
                            }
                        }
                    l2.Text = count.ToString();
                    tableLayoutPanel1.Controls.Add(l1, 0, i);  // add button in column0
                    tableLayoutPanel1.Controls.Add(l2, 1, i);  // add button in column1

                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); // 30 is the rows space
                }
            }
            catch (Exception)
            {

                MessageBox.Show("error");
            }





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
