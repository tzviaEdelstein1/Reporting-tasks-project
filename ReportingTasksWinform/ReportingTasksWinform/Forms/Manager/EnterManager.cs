using ReportingTasksWinform.Forms.Manager;
using ReportingTasksWinform.Models;
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
        AddProject addProject;
        ManageUsers manageUsers;
        ManagementTeam managementTeam;
        ManageReports manageReports;
        Reports reports;
        UpdateProjectState updateProjectState;
        public EnterManager()
        {
            InitializeComponent();
        }       
        private void AddNewTab(Form frm)
        {

            TabPage tab = new TabPage(frm.Text);

            frm.TopLevel = false;

            frm.Parent = tab;
            tab.Click += Tab_Click;
        
            frm.Visible = true;

            tabControl1.TabPages.Add(tab);

            frm.Location = new Point((tab.Width - frm.Width) / 2, (tab.Height - frm.Height) / 2);

            tabControl1.SelectedTab = tab;

        }

        private void Tab_Click(object sender, EventArgs e)
        {
            
        }

        private void EnterManager_Load(object sender, EventArgs e)
        {
             addProject = new AddProject();
            AddNewTab(addProject);
             manageUsers = new ManageUsers();
            AddNewTab(manageUsers);
             managementTeam = new ManagementTeam();
            AddNewTab(managementTeam);
             manageReports = new ManageReports();
            AddNewTab(manageReports);
           
             updateProjectState = new UpdateProjectState(addProject);
            AddNewTab(updateProjectState);
            //tabControl1.Selecting += TabControl1_Selecting;
        }


        //private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        //{

        //    addProject = new AddProject();
        //  manageUsers = new ManageUsers();
        
        //  managementTeam = new ManagementTeam();
           
        //  manageReports = new ManageReports();
        
        //   reports = new Reports();
          
        //   updateProjectState = new UpdateProjectState(addProject);
       
        //}

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Global.UserId =0;
            Global.UserName = null;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reports = new Reports();
            reports.Show();
        }
    }
}
