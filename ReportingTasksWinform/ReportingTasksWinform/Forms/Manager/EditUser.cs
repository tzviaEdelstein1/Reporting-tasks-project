using ReportingTasksWinform.Models;
using ReportingTasksWinform.Reqests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ReportingTasksWinform.Forms.Manager
{
    public partial class EditUser : Form
    {
        public EditUser()
        {
            InitializeComponent();
        }

        User user;
        List<User> allUsers = new List<User>();
        List<User> teamLeaders = new List<User>();
        List<UserKind> usersKind = new List<UserKind>();
        private void EditUser_Load(object sender, EventArgs e)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;

            teamLeaders = UserRequsts.GetAllTeamLeaders();
            //fill comboBox with team leaders    
            comboBoxTeamLeaderEdit.DataSource = teamLeaders;
            comboBoxTeamLeaderEdit.ValueMember = "UserId";
            comboBoxTeamLeaderEdit.DisplayMember = "UserName";


            //fill comboBox with userKinds
            usersKind = UsersKindRequst.GetAllUsersKind();
            comboBoxUserKindEdit.DataSource = usersKind;
            comboBoxUserKindEdit.ValueMember = "KindUserId";
            comboBoxUserKindEdit.DisplayMember = "KindUserName";

            //get all the workers and fill the combobox
            allUsers = UserRequsts.GetAllUsers();
            comboBoxAllUsers.SelectedIndexChanged -= new EventHandler(ComboBoxAllUsers_SelectedIndexChanged);
            comboBoxAllUsers.DataSource = allUsers;
            comboBoxAllUsers.ValueMember = "UserId";
            comboBoxAllUsers.DisplayMember = "UserName";

            comboBoxAllUsers.SelectedIndexChanged += ComboBoxAllUsers_SelectedIndexChanged;
        }


        private void ComboBoxAllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxEmailEdit.Text = (comboBoxAllUsers.SelectedItem as User).UserEmail;

            textBoxUserNameEdit.Text = (comboBoxAllUsers.SelectedItem as User).UserName;
            comboBoxTeamLeaderEdit.SelectedValue = (comboBoxAllUsers.SelectedItem as User).TeamLeaderId;
            comboBoxUserKindEdit.SelectedValue = (comboBoxAllUsers.SelectedItem as User).UserKindId;
        }
        private void buttonUpdate_Click_1(object sender, EventArgs e)
        { var teamLeader=0;
            if (comboBoxTeamLeaderEdit.SelectedValue != null)
                teamLeader = (int)comboBoxTeamLeaderEdit.SelectedValue;
            else
                teamLeader = 0;
            user = new User() { UserEmail = textBoxEmailEdit.Text, UserName = textBoxUserNameEdit.Text, TeamLeaderId =teamLeader, UserKindId = (int)comboBoxUserKindEdit.SelectedValue };
            user.UserId = (int)comboBoxAllUsers.SelectedValue;
            var validationContext = new ValidationContext(user, null, null);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(user, validationContext, results, true))
            {
                if (UserRequsts.UpdateUser(user))
                {
                    MessageBox.Show("update success");
                    this.Close();
                }
                else
                    MessageBox.Show("update filed");
             

            }
            else
            {
                MessageBox.Show(string.Join(",\n", results.Select(p => p.ErrorMessage)));
            }

        }

        private void comboBoxAllUsers_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
