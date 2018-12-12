using Newtonsoft.Json;
using ReportingTasksWinform.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ReportingTasksWinform.Forms
{
    public partial class VerifyPassword : Form
    {
        string userName;
        public VerifyPassword(string userName)
        {
            InitializeComponent();
            this.userName = userName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;

            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Users/VerifyPassword/" + tbPassword.Text+"/"+userName);
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("ok");
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                User user = JsonConvert.DeserializeObject<User>(content);
                this.Close();
                EditPassword editPassword = new EditPassword(user);
                editPassword.Show();
             
            }
            else
                MessageBox.Show("error");
        }

    }
}
