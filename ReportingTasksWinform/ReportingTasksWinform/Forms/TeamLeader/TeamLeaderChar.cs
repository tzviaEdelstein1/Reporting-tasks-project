using ReportingTasksWinform.Models;
using ReportingTasksWinform.Reqests;
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
    public partial class TeamLeaderChar : Form
    {
        public TeamLeaderChar()
        {
            InitializeComponent();
        }
        List<Unknown> workersHours;
        private void TeamLeaderChar_Load(object sender, EventArgs e)
        {
            //get the projects and houers for team leaders

            workersHours = ProjectsRequst.GetProjectsAndHoursByTeamLeaderId();
            if (workersHours != null)
                fillChart();
        }

        private void fillChart()
        {
            Dictionary<string, int> allocatedHours = new Dictionary<string, int>();
            List<float> workedHours = new List<float>();
            if (workersHours != null)
            {
                foreach (var item in workersHours)
                {
                    allocatedHours.Add(item.Name, Convert.ToInt32(item.allocatedHours));
                    //if (item.Hours !=)
                    workedHours.Add((float)item.Hours);
                    //else workedHours.Add(0);
                }
                chart1.Series[0].Points.DataBindXY(allocatedHours.Keys, allocatedHours.Values);
                chart1.Series[1].Points.DataBindXY(allocatedHours.Keys, workedHours);
            }
        }

   
    }
}
