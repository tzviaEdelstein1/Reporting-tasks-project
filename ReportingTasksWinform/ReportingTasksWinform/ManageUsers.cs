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
    public partial class ManageUsers : Form
    {
        List<User> allUsers = new List<User>();
        List<User> teamLeaders = new List<User>();
        List<UserKind> usersKind = new List<UserKind>();
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            //fill comboBox with team leaders
            try { 
            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Users/GetTeamLeaders");
            response = (HttpWebResponse)request.GetResponse();
            content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            teamLeaders = JsonConvert.DeserializeObject<List<User>>(content);
            }
            catch(Exception ex)
            { MessageBox.Show(ex.ToString());}
            comboBoxTeamLeader.DataSource = teamLeaders;
            comboBoxTeamLeader.ValueMember = "UserId";
            comboBoxTeamLeader.DisplayMember = "UserName";
            //fill comboBox with userKinds
            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/UserKinds");
            response = (HttpWebResponse)request.GetResponse();
            content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            usersKind = JsonConvert.DeserializeObject<List<UserKind>>(content);
            comboBoxUserKind.DataSource = usersKind;
            comboBoxUserKind.ValueMember = "KindUserId";
            comboBoxUserKind.DisplayMember = "KindUserName";

            //get all the workers

            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Users/GetAllUsers");
            response = (HttpWebResponse)request.GetResponse();
            content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            allUsers = JsonConvert.DeserializeObject<List<User>>(content);
            comboBoxUserKind.DataSource = allUsers;
            comboBoxUserKind.ValueMember = "UserId";
            comboBoxUserKind.DisplayMember = "UserName";

        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            string result = "";
            User user = new User() { UserEmail = textBoxEmail.Text, Password = textBoxPassword.Text, UserName = textBoxUserName.Text, TeamLeaderId = (int)comboBoxTeamLeader.SelectedValue, UserKindId = (int)comboBoxUserKind.SelectedValue };
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/Users/12");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(user);
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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxAllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {/////////////////in the middle update
            textBoxEmail.Text = (comboBoxAllUsers.SelectedItem as User).UserEmail;
            textBoxPassword.Text = (comboBoxAllUsers.SelectedItem as User).Password;
            //UserName = textBoxUserName.Text, 
            //TeamLeaderId = (int)comboBoxTeamLeader.SelectedValue,
            //UserKindId = (int)comboBoxUserKind.SelectedValue };
    }
    }
}
