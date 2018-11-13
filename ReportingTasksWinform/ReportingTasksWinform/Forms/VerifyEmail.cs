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
    public partial class VerifyEmail : Form
    {
        public VerifyEmail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Users/VerifyEmail/" + tbUserName.Text);
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("ok");
                this.Close();
                VerifyPassword verifyPassword = new VerifyPassword();
                verifyPassword.Show();
             
            }
            else
                MessageBox.Show("error");
        }
    }
}
