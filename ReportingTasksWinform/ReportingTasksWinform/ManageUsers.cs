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
        User user;
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
            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Users/GetTeamLeaders");
                response = (HttpWebResponse)request.GetResponse();
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                teamLeaders = JsonConvert.DeserializeObject<List<User>>(content);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            comboBoxTeamLeader.DataSource = teamLeaders;
            comboBoxTeamLeader.ValueMember = "UserId";
            comboBoxTeamLeader.DisplayMember = "UserName";
            comboBoxTeamLeaderEdit.DataSource = teamLeaders;
            comboBoxTeamLeaderEdit.ValueMember = "UserId";
            comboBoxTeamLeaderEdit.DisplayMember = "UserName";


            //fill comboBox with userKinds
            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/UserKinds");
            response = (HttpWebResponse)request.GetResponse();
            content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            usersKind = JsonConvert.DeserializeObject<List<UserKind>>(content);
            comboBoxUserKind.DataSource = usersKind;
            comboBoxUserKind.ValueMember = "KindUserId";
            comboBoxUserKind.DisplayMember = "KindUserName";
            comboBoxUserKindEdit.DataSource = usersKind;
            comboBoxUserKindEdit.ValueMember = "KindUserId";
            comboBoxUserKindEdit.DisplayMember = "KindUserName";

            //get all the workers

            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Users/GetAllUsers");
            response = (HttpWebResponse)request.GetResponse();
            content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            allUsers = JsonConvert.DeserializeObject<List<User>>(content);
            comboBoxAllUsers.SelectedIndexChanged -= new EventHandler(ComboBoxAllUsers_SelectedIndexChanged);
            comboBoxAllUsers.DataSource = allUsers;

            comboBoxAllUsers.ValueMember = "UserId";
            comboBoxAllUsers.DisplayMember = "UserName";
            comboBoxAllUsersRemove.DataSource = allUsers;
            comboBoxAllUsersRemove.ValueMember = "UserId";
            comboBoxAllUsersRemove.DisplayMember = "UserName";
            comboBoxAllUsers.SelectedIndexChanged += ComboBoxAllUsers_SelectedIndexChanged;
        }

        private void ComboBoxAllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxEmailEdit.Text = (comboBoxAllUsers.SelectedItem as User).UserEmail;
            textBoxPasswordEdit.Text = (comboBoxAllUsers.SelectedItem as User).Password;
            textBoxUserNameEdit.Text = (comboBoxAllUsers.SelectedItem as User).UserName;
            comboBoxTeamLeaderEdit.SelectedValue = (comboBoxAllUsers.SelectedItem as User).TeamLeaderId;
            comboBoxUserKindEdit.SelectedValue = (comboBoxAllUsers.SelectedItem as User).UserKindId;
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            string result = "";
          int teamLeaderid;
            if (comboBoxTeamLeader.SelectedIndex > -1)
            {
                user = new User() { UserEmail = textBoxEmail.Text, Password = textBoxPassword.Text, UserName = textBoxUserName.Text, TeamLeaderId = (int)comboBoxTeamLeader.SelectedValue, UserKindId = (int)comboBoxUserKind.SelectedValue };
                FillUserDetails();
            }
            else if ((int)comboBoxUserKind.SelectedValue != 2 && (int)comboBoxUserKind.SelectedValue != 1)
            {
                MessageBox.Show("choose team leader");
            }
            else
            {
                user = new User() { UserEmail = textBoxEmail.Text, Password = textBoxPassword.Text, UserName = textBoxUserName.Text, UserKindId = (int)comboBoxUserKind.SelectedValue };
                FillUserDetails();
            }
         

           
        }

        private void FillUserDetails()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/Users/"+Global.UserId);
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
            user = new User() { UserEmail = textBoxEmailEdit.Text, Password = textBoxPasswordEdit.Text, UserName = textBoxUserNameEdit.Text, TeamLeaderId = (int)comboBoxTeamLeaderEdit.SelectedValue, UserKindId = (int)comboBoxUserKindEdit.SelectedValue };

            user.UserId = (int)comboBoxAllUsers.SelectedValue;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/Users/"+Global.UserId);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(user);
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

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int idUser = (int)comboBoxAllUsersRemove.SelectedValue;

            try
            {
                WebRequest request = WebRequest.Create("http://localhost:56028/api/Users/" + idUser + "/"+Global.UserId);
                request.Method = "DELETE";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            { MessageBox.Show("error"); }
        }

        private void comboBoxAllUsersRemove_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

