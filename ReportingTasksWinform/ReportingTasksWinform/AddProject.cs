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
using System.Web.Script.Serialization;
using ReportingTasksWinform.Models;
using Newtonsoft.Json;

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
          
            string result = "";
            Project project = new Project()
            {
                ProjectName = textBoxNameProject.Text,
                ClientName = textBoxClientName.Text,
                DevelopersHours = (int)numericDevelopersHours.Value,
                QaHours = (int)numericQaHours.Value,
                UiUxHours = (int)numericUiUxhours.Value,
                TeamLeaderId =(int)comboBoxTeamLeader.SelectedValue,
                FinishDate = dateFinish.Value,
                StartDate = dateStart.Value

            };


            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/Projects/"+Global.UserId);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(project);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {

                    {
                        result = streamReader.ReadToEnd();
                        Project pro = JsonConvert.DeserializeObject<Project>(result);
                        if (result != "")
                        {
                            MessageBox.Show("ok");
                            addWorkersToProject(pro.ProjectId);

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

        private void addWorkersToProject(int projectId)
        {
            WorkerToProject workerToProject = new WorkerToProject();
            foreach (var item in listBoxUsers.SelectedItems)
            {
                workerToProject.UserId = (item as User).UserId;
                workerToProject.ProjectId =projectId;
               
                string result = "";
              
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/WorkerToProject/"+Global.UserId);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(workerToProject);
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

        }

        private void AddProject_Load(object sender, EventArgs e)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
           //fill comboBox With teamLeaders
             request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Users/GetTeamLeaders");
             response = (HttpWebResponse)request.GetResponse();
             content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            teamLeaders = JsonConvert.DeserializeObject<List<User>>(content);
            comboBoxTeamLeader.DataSource = teamLeaders;
            comboBoxTeamLeader.ValueMember = "UserId";
            comboBoxTeamLeader.DisplayMember = "UserName";

            //get all the another workers

             request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Users/GetAllUsers");
             response = (HttpWebResponse)request.GetResponse();
             content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            allUsers = JsonConvert.DeserializeObject<List<User>>(content);
  

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        
        }

        private void comboBoxTeamLeader_SelectedIndexChanged(object sender, EventArgs e)
        { var teamLeaderId = (comboBoxTeamLeader.SelectedItem as User).UserId;
            usersToChoose = allUsers.Where(u => u.TeamLeaderId != teamLeaderId && u.UserId != teamLeaderId).ToList();
            listBoxUsers.DataSource = usersToChoose;
            listBoxUsers.DisplayMember = "UserName";
        }
    }
}
