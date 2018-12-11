using Newtonsoft.Json;
using ReportingTasksWinform.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ReportingTasksWinform
{
    public partial class ConactingTheManager : Form
    {
        List<User> users;
        public ConactingTheManager()
        {
            InitializeComponent();
        }


        private void buttonSendEmail_Click(object sender, EventArgs e)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/SendEmail/SendEmail/" + textBox1.Text);
                response = (HttpWebResponse)request.GetResponse();
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(content);
                MessageBox.Show("success");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }

        }

    }
}
