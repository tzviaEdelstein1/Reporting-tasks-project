using Newtonsoft.Json;
using ReportingTasksWinform.Forms;
using ReportingTasksWinform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportingTasksWinform
{
    public partial class Login : Form
    {
        User user;

        public Login()
        {
            InitializeComponent();
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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/users/" + userName + "/" + password);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    user = JsonConvert.DeserializeObject<User>(content);
                }


                Global.UserName = user.UserName;
                Global.UserId = user.UserId;
                MessageBox.Show(user.UserName);
                textBoxUserName.Text = "";
                textBoxPassword.Text = "";
                if (user.UserKindId == 1)

                {
                    EnterManager enterManager = new EnterManager();
                    enterManager.Show();
                }
                if (user.UserKindId == 2)

                {
                    EnterTeamLeader enterTeamLeader = new EnterTeamLeader();
                    enterTeamLeader.Show();
                }
                if (user.UserKindId == 3 || user.UserKindId == 4 || user.UserKindId == 5)

                {
                    EnterWorkers enterWorkers = new EnterWorkers();
                    enterWorkers.Show();
                }
            }

            catch (Exception)
            {

                MessageBox.Show("the user is not exists");
            }

        }

        private void buttonEditPassword_Click(object sender, EventArgs e)
        {
            VerifyEmail verifyEmail = new VerifyEmail();
            verifyEmail.Show();


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
