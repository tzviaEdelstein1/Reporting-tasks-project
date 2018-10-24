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
                    comboBoxProjects.DataSource = commonProjectsInTheList;
                    comboBoxProjects.DisplayMember = "ProjectName";
                    comboBoxProjects.ValueMember = "ProjectId";
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

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ActualHours actualHours = new ActualHours() { CountHours =(double)numericCountHours.Value,ProjectId=(int)comboBoxProjects.SelectedValue, date = dateTimePicker1.Value, UserId = (int)comboBoxUsers.SelectedValue };
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
                string result;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {

                    {
                        result = streamReader.ReadToEnd();
                      
                        if (result != "")
                        {
                           
                        }
                        else
                        { MessageBox.Show(result); }
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("error", ex.Message.ToString());

            }
        }
    }
}
