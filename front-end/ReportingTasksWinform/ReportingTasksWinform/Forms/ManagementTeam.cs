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
    public partial class ManagementTeam : Form
    {
        List<User> teamLeaders = new List<User>();
        public ManagementTeam()
        {
            InitializeComponent();
        }

        private void ManagementTeam_Load(object sender, EventArgs e)
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
        }
    }
}
