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
    public partial class EnterTeamLeader : Form
    {
        public EnterTeamLeader()
        {
            InitializeComponent();
        }

        private void buttonViewingProjects_Click(object sender, EventArgs e)
        {
            ViewingProjects viewingProjects = new ViewingProjects();
            viewingProjects.Show();
        }

        private void buttonUpdatHours_Click(object sender, EventArgs e)
        {
            UpdateHours updateHours = new UpdateHours();
            updateHours.Show();
        }

        private void buttonChar_Click(object sender, EventArgs e)
        {
            TeamLeaderChar teamLeaderChar = new TeamLeaderChar();
            teamLeaderChar.Show();
        }
    }
}
