using ReportingTasksWinform.Forms.Manager;
using ReportingTasksWinform.Reqests;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ReportingTasksWinform
{
    public partial class EnterManager : Form
    {
        Login login;
        public EnterManager(Login login)
        {
            InitializeComponent();
            this.login = login;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserRequsts.Logout();
            this.Close();
            login.Opacity = 100;
            login.ShowInTaskbar = true;

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddProject addProject = new AddProject();
            addProject.Show();

        }
        private void Reports_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
        }

        private void EditUser_Click(object sender, EventArgs e)
        {
            EditUser editUser = new EditUser();
            editUser.Show();
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            RemoveUser removeUser = new RemoveUser();
            removeUser.Show();

        }
    }
}
