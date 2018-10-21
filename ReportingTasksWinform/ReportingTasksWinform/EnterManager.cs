using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportingTasksWinform
{
    public partial class EnterManager : Form
    {
        public EnterManager()
        {
            InitializeComponent();
        }


        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            AddProject addProject = new AddProject();
            addProject.Show();
        }

        private void buttonManageUsers_Click(object sender, EventArgs e)
        {
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.Show();
        }

        private void buttonManagementTeam_Click(object sender, EventArgs e)
        {
            ManagementTeam managementTeam = new ManagementTeam();
            managementTeam.Show();
        }

        private void buttonManageReports_Click(object sender, EventArgs e)
        {
            ManageReports manageReports = new ManageReports();
            manageReports.Show();
        }
    }
}
