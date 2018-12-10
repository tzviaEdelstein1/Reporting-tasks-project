using ReportingTasksWinform.Models;
using ReportingTasksWinform.Reqests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ReportingTasksWinform
{
    public partial class AddProject : Form
    {
        List<User> teamLeaders = new List<User>();
        List<User> allUsers = new List<User>();
        List<User> usersToChoose = new List<User>();
        public AddProject()
        {
            InitializeComponent();
        }
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {

            Project project = new Project()
            {
                ProjectName = textBoxNameProject.Text,
                ClientName = textBoxClientName.Text,
                DevelopersHours = (int)numericDevelopersHours.Value,
                QaHours = (int)numericQaHours.Value,
                UiUxHours = (int)numericUiUxhours.Value,
                TeamLeaderId = (int)comboBoxTeamLeader.SelectedValue,
                FinishDate = dateFinish.Value,
                StartDate = dateStart.Value

            };
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(project, null, null);
            Project pro;
            if (Validator.TryValidateObject(project, validationContext, results, true))
            {
                pro = ProjectsRequst.AddProject(project);
                if (pro != null)
                {
                  
                    addWorkersToProject(pro.ProjectId);
                    this.Close();
                }
                else
                    MessageBox.Show("update filed");
           
            }
            else
            {
                MessageBox.Show(string.Join(",\n", results.Select(p => p.ErrorMessage)));
            }

        }
        private void addWorkersToProject(int projectId)
        {
            WorkerToProject workerToProject = new WorkerToProject();
            foreach (var item in listBoxUsers.SelectedItems)
            {
                workerToProject.UserId = (item as User).UserId;
                workerToProject.ProjectId = projectId;
                WokrerToProjectRequst.AddWorkerToProject(workerToProject);
            }

        }
        private void AddProject_Load(object sender, EventArgs e)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            //fill comboBox With teamLeaders
            teamLeaders = UserRequsts.GetAllTeamLeaders();
            comboBoxTeamLeader.DataSource = teamLeaders;
            comboBoxTeamLeader.ValueMember = "UserId";
            comboBoxTeamLeader.DisplayMember = "UserName";

            //get all the another workers
            allUsers = UserRequsts.GetAllUsers();


        }
        private void comboBoxTeamLeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            var teamLeaderId = (comboBoxTeamLeader.SelectedItem as User).UserId;
            usersToChoose = allUsers.Where(u => u.TeamLeaderId != teamLeaderId && u.UserId != teamLeaderId&&u.UserKindId!=1).ToList();
            listBoxUsers.DataSource = usersToChoose;
            listBoxUsers.DisplayMember = "UserName";
        }
    }
}
