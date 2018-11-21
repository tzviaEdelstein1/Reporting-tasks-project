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

namespace ReportingTasksWinform.Forms.Manager
{
    public partial class UpdateProjectState : Form
    {
        List<CheckBox> checkBoxes = new List<CheckBox>();
        List<Project> projects = new List<Project>();
        AddProject addProject;
        public UpdateProjectState(AddProject addProject)
        {
            InitializeComponent();
            this.addProject = addProject;
            onLoad();
            this.Refresh();
        }

        private void UpdateProjectState_Load(object sender, EventArgs e)
        {

            onLoad();


        }
        private void onLoad()
        {
            projects = ProjectsRequst.GetAllProjects();
            for (int i = 0; i < projects.Count; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = projects[i].ProjectName;
                checkBox.Name = projects[i].ProjectName;
                checkBox.Location = new Point(10, i * 50);
                if (projects[i].IsActive == true)
                {
                    checkBox.Checked = true;
                }

                checkBoxes.Add(checkBox);
            }

            foreach (var item in checkBoxes)
            {
                panel1.Controls.Add(item);
            }

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < projects.Count; i++)
            {
                if (projects[i].IsActive == false && checkBoxes[i].Checked|| projects[i].IsActive == true && !checkBoxes[i].Checked)
                {
                    if (checkBoxes[i].Checked)
                        projects[i].IsActive = true;
                    else
                        projects[i].IsActive = false;
                    projects[i].User = null;
                    if( ProjectsRequst.UpdateProject(projects[i]))
                        MessageBox.Show("update succes");
                   
                }
            }
            addProject.Refresh();

        }
    }
}
