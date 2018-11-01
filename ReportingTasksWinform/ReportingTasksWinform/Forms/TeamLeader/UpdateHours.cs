using Newtonsoft.Json;
using ReportingTasksWinform.Models;
using ReportingTasksWinform.Reqests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    public partial class UpdateHours : Form
    {
        List<User> usersUnderTeamLeader;
        List<Project> ProjectsForteamLeader;
        List<Project> ProjectsForUser;
        List<Project> commonProjectsInTheList = new List<Project>();
        WorkerToProject workerToProject;
        public UpdateHours()
        {
            InitializeComponent();
        }

        private void UpdateHours_Load(object sender, EventArgs e)
        {
            usersUnderTeamLeader = UserRequsts.GetUsersForTeamLeader();
            if (usersUnderTeamLeader != null)
            {
                comboBoxUsers.SelectedIndexChanged -= new EventHandler(comboBoxUsers_SelectedIndexChanged);
                comboBoxUsers.DataSource = usersUnderTeamLeader;
                comboBoxUsers.ValueMember = "UserId";
                comboBoxUsers.DisplayMember = "UserName";
                comboBoxUsers.SelectedIndexChanged += comboBoxUsers_SelectedIndexChanged;
            }           
                ProjectsForteamLeader = ProjectsRequst.GetProjectsByTeamLeaderId();              
        }
        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
          
                ProjectsForUser = ProjectsRequst.GetProjectsByUserId((int)comboBoxUsers.SelectedValue);
                if (ProjectsForUser != null)
                {
                    for (int i = 0; i < ProjectsForteamLeader.Count; i++)
                    {
                        for (int j = 0; j < ProjectsForUser.Count; j++)
                        {
                            if (ProjectsForteamLeader[i].ProjectId == ProjectsForUser[j].ProjectId)
                            {
                                commonProjectsInTheList.Add(ProjectsForteamLeader[i]);
                            }
                        }

                    }
                    //var results = ProjectsForteamLeader.Join(ProjectsForUser, ptl => ptl.ProjectId, p => p.ProjectId, (post, meta) => new { Post = post, Meta = meta });
                    comboBoxProjects.SelectedIndexChanged -= new EventHandler(comboBoxProjects_SelectedIndexChanged);
                    comboBoxProjects.DataSource = commonProjectsInTheList;
                    comboBoxProjects.DisplayMember = "ProjectName";
                    comboBoxProjects.ValueMember = "ProjectId";
                    comboBoxProjects.SelectedIndexChanged += comboBoxProjects_SelectedIndexChanged;
                    numericCountHours.Value = 0;
                    MessageBox.Show("success");
                }
                else
                {
                    comboBoxProjects.DataSource = null;
                }

                  

        }

        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {

            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            //get the current worker to project for update
            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/WorkerToProject/GetWorkerToProjectByPidAndUid/" + comboBoxUsers.SelectedValue + "/" + comboBoxProjects.SelectedValue);
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    workerToProject = JsonConvert.DeserializeObject<WorkerToProject>(content);
                }

            }
            catch (Exception)
            {

                MessageBox.Show("eror");
            }
            numericCountHours.Value = workerToProject.Hours;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            workerToProject.Hours = (int)numericCountHours.Value;

            //update the worker to project with the houers

            //check if is valid
            var validationContext = new ValidationContext(workerToProject, null, null);
            var results = new List<ValidationResult>();


            if (Validator.TryValidateObject(workerToProject, validationContext, results, true))
            {
                if (WokrerToProjectRequst.UpdateWorkerToProject(workerToProject))
                    MessageBox.Show("update success");

                else
                    MessageBox.Show("update filed");
            }
            else
            {
                MessageBox.Show(string.Join(",\n", results.Select(p => p.ErrorMessage)));
            }
        }
    }
}
