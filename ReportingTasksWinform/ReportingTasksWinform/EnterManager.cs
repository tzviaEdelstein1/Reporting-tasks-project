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

        private void AddProject_Click(object sender, EventArgs e)
        {

        }

        private void EnterManager_Load(object sender, EventArgs e)
        {
        //    loadAddProject();
        //    AddProject frmChild = new AddProject();
        //AddNewTab(frmChild);
        }

        private void loadAddProject()
        {
            throw new NotImplementedException();
        }

        private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        //private void AddNewTab(Form frm)
        //{

        //    TabPage tab = new TabPage(frm.Text);

        //    frm.TopLevel = false;

        //    frm.Parent = tab;

        //    frm.Visible = true;

        //    tabControl.TabPages.Add(tab);

        //    frm.Location = new Point((tab.Width - frm.Width) / 2, (tab.Height - frm.Height) / 2);

        //    tabControl.SelectedTab = tab;

        //}
    }
}
