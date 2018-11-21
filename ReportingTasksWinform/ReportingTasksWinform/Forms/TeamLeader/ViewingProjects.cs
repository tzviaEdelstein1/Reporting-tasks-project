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
using System.Windows.Forms;

namespace ReportingTasksWinform
{
    public partial class ViewingProjects : Form
    {
       
        List<WorkerToProject> workerToProjects = new List<WorkerToProject>();
        List<User> usersToProject = new List<User>();
        List<Project> ProjectsForteamLeader = new List<Project>();
        List<ActualHours> actualHours = new List<ActualHours>();
        List<Unknown> projectsAndHours = new List<Unknown>();
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
            ProjectsForteamLeader = ProjectsRequst.GetProjectsByTeamLeaderId();
            if (ProjectsForteamLeader != null)
            {
                comboBoxAllYourProjects.SelectedIndexChanged -= new EventHandler(comboBoxAllYourProjects_SelectedIndexChanged);
                comboBoxAllYourProjects.DataSource = ProjectsForteamLeader;
                comboBoxAllYourProjects.DisplayMember = "ProjectName";
                comboBoxAllYourProjects.ValueMember = "ProjectId";
                comboBoxAllYourProjects.SelectedIndexChanged += comboBoxAllYourProjects_SelectedIndexChanged;
            }
            

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
            labelTeamLeader.Text = (comboBoxAllYourProjects.SelectedItem as Project).User.UserName;
            labelIsActive.Text = (comboBoxAllYourProjects.SelectedItem as Project).IsActive.ToString();
            projectsAndHours = ProjectsRequst.GetProjectsAndHoursByProjectId((int)comboBoxAllYourProjects.SelectedValue);
            dataGridView1.DataSource = projectsAndHours;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnIsActive_Click(object sender, EventArgs e)
        {

        }
    }
}
