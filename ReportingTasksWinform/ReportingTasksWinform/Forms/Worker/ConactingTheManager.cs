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
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/SendEmail/"+ textBox1.Text);
                response = (HttpWebResponse)request.GetResponse();
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(content);
                MessageBox.Show("success");

            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/SendEmail/SendEmail" + Global.UserId+"/"+textBox1.Text);
                response = (HttpWebResponse)request.GetResponse();
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                MessageBox.Show("success");

            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }

        }

        private void ConactingTheManager_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
