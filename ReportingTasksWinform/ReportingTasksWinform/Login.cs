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
    public partial class Login : Form
    {
        User user;

        public Login()
        {
            InitializeComponent();
        }



        private void LoginButton_Click(object sender, EventArgs e)
        {
            string userName = textBoxUserName.Text;
            string password = textBoxPassword.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/users/"+userName+"/"+password);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

            user = JsonConvert.DeserializeObject<User>(content);
            if(user!=null)
            {
            MessageBox.Show(user.UserName);
                if (user.UserKindId == 4)

                {
                    EnterManager enterManager = new EnterManager();
                    enterManager.Show();
                }

            
             }

        }
    }
}
