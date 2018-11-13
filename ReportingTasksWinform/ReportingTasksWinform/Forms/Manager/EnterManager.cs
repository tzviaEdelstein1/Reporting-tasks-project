using ReportingTasksWinform.Forms.Manager;
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
        private void AddNewTab(Form frm)
        {

            TabPage tab = new TabPage(frm.Text);

            frm.TopLevel = false;

            frm.Parent = tab;

            frm.Visible = true;

            tabControl1.TabPages.Add(tab);

            frm.Location = new Point((tab.Width - frm.Width) / 2, (tab.Height - frm.Height) / 2);

            tabControl1.SelectedTab = tab;

        }

        private void EnterManager_Load(object sender, EventArgs e)
        {
            AddProject addProject = new AddProject();
            AddNewTab(addProject);
            ManageUsers manageUsers = new ManageUsers();
            AddNewTab(manageUsers);
            ManagementTeam managementTeam = new ManagementTeam();
            AddNewTab(managementTeam);
            ManageReports manageReports = new ManageReports();
            AddNewTab(manageReports);
            Reports reports = new Reports();
            AddNewTab(reports);
        }
    }
}
