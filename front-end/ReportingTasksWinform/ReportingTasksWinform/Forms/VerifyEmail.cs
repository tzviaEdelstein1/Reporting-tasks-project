using System;
using System.Linq;
using System.Net;
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
                VerifyPassword verifyPassword = new VerifyPassword(tbUserName.Text);
                this.Close();
               
                verifyPassword.Show();

            }
            else
                MessageBox.Show("error");
        }
    }
}
