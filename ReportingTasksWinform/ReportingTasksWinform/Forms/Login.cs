using Newtonsoft.Json;
using ReportingTasksWinform.Forms;
using ReportingTasksWinform.Models;
using ReportingTasksWinform.Reqests;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ReportingTasksWinform
{
    public partial class Login : Form
    {
        User user;
        string ip = string.Empty;
        public Login()
        {
            InitializeComponent();
            ip = GetLocalIPAddress();
            user = UserRequsts.checkUserIp(ip);
            if (user != null)
            {
                checkState();
            }
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        static string sha256(string password)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {

            string userName = textBoxUserName.Text;
            string password = sha256(textBoxPassword.Text);
            try
            {
          //  HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:8080/ReportingTasksPhp/Controllers/index.php/users/Login/"+ userName +"/" + password);
          HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/users/Login/" + userName + "/" + password);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = new StreamReader(response.GetResponseStream()).ReadToEnd();


                    user = JsonConvert.DeserializeObject<User>(content);
                }


                MessageBox.Show(user.UserName);
                textBoxUserName.Text = string.Empty;
                textBoxPassword.Text = string.Empty;
                checkState();
                ip = GetLocalIPAddress();
                user.UserIP = ip;
                UserRequsts.UpdateUser(user);
            }

            catch (Exception)
            {

                MessageBox.Show("the user is not exists");
            }

        }
        private void checkState()
        {
            this.Opacity = 0.0f;

            this.ShowInTaskbar = false;
            Global.UserName = user.UserName;
            Global.UserId = user.UserId;
            if (user.UserKindId == 1)

            {
                EnterManager enterManager = new EnterManager(this);
                enterManager.Show();
            }
            if (user.UserKindId == 2)

            {
                EnterTeamLeader enterTeamLeader = new EnterTeamLeader(this);
                enterTeamLeader.Show();
            }
            if (user.UserKindId == 3 || user.UserKindId == 4 || user.UserKindId == 5)

            {
                EnterWorkers enterWorkers = new EnterWorkers(this);
                enterWorkers.Show();
            }
        }
        private void buttonEditPassword_Click(object sender, EventArgs e)
        {
            VerifyEmail verifyEmail = new VerifyEmail();
            verifyEmail.Show();


        }
    }
}
