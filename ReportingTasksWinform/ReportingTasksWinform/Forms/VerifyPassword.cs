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
using System.Windows.Forms;

namespace ReportingTasksWinform.Forms
{
    public partial class VerifyPassword : Form
    {
        public VerifyPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Users/VerifyPassword/" + tbPassword.Text);
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
