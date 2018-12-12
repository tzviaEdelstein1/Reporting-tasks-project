using ReportingTasksWinform.Reqests;
using System;
using System.Windows.Forms;

namespace ReportingTasksWinform
{
    public partial class EnterTeamLeader : Form
    {
        Login login;

        public EnterTeamLeader(Login login)
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

        private void menuChar_Click(object sender, EventArgs e)
        {

            TeamLeaderChar teamLeaderChar = new TeamLeaderChar();
            teamLeaderChar.Show();
        }

        private void updateHours_Click(object sender, EventArgs e)
        {
            UpdateHours update = new UpdateHours();
            update.Show();
        }

        private void viewingProjects_Click(object sender, EventArgs e)
        {
            ViewingProjects viewing = new ViewingProjects();
            viewing.Show();
        }
    }
}
