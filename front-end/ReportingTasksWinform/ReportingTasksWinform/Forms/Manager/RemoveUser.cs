using ReportingTasksWinform.Models;
using ReportingTasksWinform.Reqests;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace ReportingTasksWinform.Forms.Manager
{
    public partial class RemoveUser : Form
    {
        List<User> allUsers = new List<User>();
        List<User> teamLeaders = new List<User>();

        User user;
        List<UserKind> usersKind = new List<UserKind>();

        public RemoveUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idUser = (int)comboBox1.SelectedValue;

            UserRequsts.RemoveUser(idUser);
            this.Close();
        }

        private void RemoveUser_Load(object sender, EventArgs e)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;

            teamLeaders = UserRequsts.GetAllTeamLeaders();


            //fill comboBox with userKinds
            usersKind = UsersKindRequst.GetAllUsersKind();


            //get all the workers and fill the combobox
            allUsers = UserRequsts.GetAllUsers();

            comboBox1.DataSource = allUsers;
            comboBox1.ValueMember = "UserId";
            comboBox1.DisplayMember = "UserName";

        }

    }
}
