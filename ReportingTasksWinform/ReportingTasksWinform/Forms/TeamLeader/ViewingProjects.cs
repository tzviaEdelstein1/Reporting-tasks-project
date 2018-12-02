using ReportingTasksWinform.Models;
using ReportingTasksWinform.Reqests;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace ReportingTasksWinform
{
    public partial class ViewingProjects : Form
    {
        List<ActualHours> actualHours = new List<ActualHours>();
        List<Unknown> projectsAndHours = new List<Unknown>();
        List<Project> ProjectsForteamLeader = new List<Project>();
        List<User> usersToProject = new List<User>();

        List<WorkerToProject> workerToProjects = new List<WorkerToProject>();

        public ViewingProjects()
        {
            InitializeComponent();
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
            projectsAndHours = ProjectsRequst.GetProjectsAndHoursByProjectId((int)comboBoxAllYourProjects.SelectedValue);
            dataGridView1.DataSource = projectsAndHours;

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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
