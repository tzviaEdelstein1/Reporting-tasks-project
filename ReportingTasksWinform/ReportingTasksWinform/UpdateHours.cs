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
    public partial class UpdateHours : Form
    {
        List<User> usersUnderTeamLeader;
        List<Project> ProjectsForteamLeader;
        List<Project> ProjectsForUser;
        List<Project> commonProjectsInTheList=new List<Project>();
        WorkerToProject workerToProject;
        public UpdateHours()
        {
            InitializeComponent();
        }

        private void UpdateHours_Load(object sender, EventArgs e)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Users/GetUsersForTeamLeader/" + Global.UserId);
                response = (HttpWebResponse)request.GetResponse();
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                usersUnderTeamLeader = JsonConvert.DeserializeObject<List<User>>(content);
                comboBoxUsers.SelectedIndexChanged -= new EventHandler(comboBoxUsers_SelectedIndexChanged);
                comboBoxUsers.DataSource = usersUnderTeamLeader;
                comboBoxUsers.ValueMember = "UserId";
                comboBoxUsers.DisplayMember = "UserName";
                comboBoxUsers.SelectedIndexChanged += comboBoxUsers_SelectedIndexChanged;

            }
            catch (Exception)
            {

                MessageBox.Show("eror");
            }
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

          


        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Projects/GetProjectsByUserId/"+comboBoxUsers.SelectedValue);
                response = (HttpWebResponse)request.GetResponse();
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                ProjectsForUser = JsonConvert.DeserializeObject<List<Project>>(content);
                if (ProjectsForUser != null)
                {
                    for (int i = 0; i < ProjectsForteamLeader.Count; i++)
                    {
                        for (int j = 0; j < ProjectsForUser.Count; j++)
                        {
                            if(ProjectsForteamLeader[i].ProjectId==ProjectsForUser[j].ProjectId)
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
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }

           
        }

        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            //get the current worker to peoject for update
            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/WorkerToProject/GetWorkerToProjectByPidAndUid/" + comboBoxUsers.SelectedValue + "/" + comboBoxProjects.SelectedValue);
                response = (HttpWebResponse)request.GetResponse();
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                workerToProject = JsonConvert.DeserializeObject<WorkerToProject>(content);


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
            //ActualHours actualHours = new ActualHours() { CountHours =(double)numericCountHours.Value,ProjectId=(int)comboBoxProjects.SelectedValue, date = dateTimePicker1.Value, UserId = (int)comboBoxUsers.SelectedValue };

            //update the worker to project with the houers
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/WorkerToProject");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(workerToProject);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    {
                        var result = streamReader.ReadToEnd();
                        MessageBox.Show("Test");
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("error");

            }

        }
    }
}
