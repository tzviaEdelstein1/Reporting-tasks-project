using Newtonsoft.Json;
using ReportingTasksWinform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using ReportingTasksWinform.Reqests;
using System.ComponentModel.DataAnnotations;

namespace ReportingTasksWinform
{
    public partial class ManageUsers : Form
    {


        User user;
        List<User> allUsers = new List<User>();
        List<User> teamLeaders = new List<User>();
        List<UserKind> usersKind = new List<UserKind>();
        public ManageUsers()
        {
            InitializeComponent();

        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {

            HttpWebRequest request;
            HttpWebResponse response;
            string content;

            teamLeaders = UserRequsts.GetAllTeamLeaders();
            //fill comboBox with team leaders
            comboBoxTeamLeader.DataSource = teamLeaders;
            comboBoxTeamLeader.ValueMember = "UserId";
            comboBoxTeamLeader.DisplayMember = "UserName";
            comboBoxTeamLeaderEdit.DataSource = teamLeaders;
            comboBoxTeamLeaderEdit.ValueMember = "UserId";
            comboBoxTeamLeaderEdit.DisplayMember = "UserName";


            //fill comboBox with userKinds
            usersKind = UsersKindRequst.GetAllUsersKind();
            comboBoxUserKind.DataSource = usersKind;
            comboBoxUserKind.ValueMember = "KindUserId";
            comboBoxUserKind.DisplayMember = "KindUserName";
            comboBoxUserKindEdit.DataSource = usersKind;
            comboBoxUserKindEdit.ValueMember = "KindUserId";
            comboBoxUserKindEdit.DisplayMember = "KindUserName";

            //get all the workers and fill the combobox
            allUsers = UserRequsts.GetAllUsers();
            comboBoxAllUsers.SelectedIndexChanged -= new EventHandler(ComboBoxAllUsers_SelectedIndexChanged);
            comboBoxAllUsers.DataSource = allUsers;
            comboBoxAllUsers.ValueMember = "UserId";
            comboBoxAllUsers.DisplayMember = "UserName";
            comboBoxAllUsersRemove.DataSource = allUsers;
            comboBoxAllUsersRemove.ValueMember = "UserId";
            comboBoxAllUsersRemove.DisplayMember = "UserName";
            comboBoxAllUsers.SelectedIndexChanged += ComboBoxAllUsers_SelectedIndexChanged;
        }

        private void ComboBoxAllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxEmailEdit.Text = (comboBoxAllUsers.SelectedItem as User).UserEmail;

            textBoxUserNameEdit.Text = (comboBoxAllUsers.SelectedItem as User).UserName;
            comboBoxTeamLeaderEdit.SelectedValue = (comboBoxAllUsers.SelectedItem as User).TeamLeaderId;
            comboBoxUserKindEdit.SelectedValue = (comboBoxAllUsers.SelectedItem as User).UserKindId;
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {


          
            int teamLeaderid;
            if (comboBoxTeamLeader.SelectedIndex > -1)
            {
                var password = sha256(textBoxPassword.Text);
                user = new User() { UserEmail = textBoxEmail.Text, Password = password, UserName = textBoxUserName.Text, TeamLeaderId = (int)comboBoxTeamLeader.SelectedValue, UserKindId = (int)comboBoxUserKind.SelectedValue };
                FillUserDetails();
            }
            else if ((int)comboBoxUserKind.SelectedValue != 2 && (int)comboBoxUserKind.SelectedValue != 1)
            {
                MessageBox.Show("choose team leader");
            }
            else
            {
                var password = sha256(textBoxPassword.Text);

                user = new User() { UserEmail = textBoxEmail.Text, Password = password, UserName = textBoxUserName.Text, UserKindId = (int)comboBoxUserKind.SelectedValue };
                FillUserDetails();
            }
        }

        static string sha256(string password)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }

        private void FillUserDetails()
        {
            var validationContext = new ValidationContext(user, null, null);
            var results = new List<ValidationResult>();
            if (Validator.TryValidateObject(user, validationContext, results, true))
            {
                if (UserRequsts.AddUser(user))
                    MessageBox.Show("added success");
                else
                    MessageBox.Show("faild");
            }
            else
            {
                MessageBox.Show(string.Join(",\n", results.Select(p => p.ErrorMessage)));
            }

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            user = new User() { UserEmail = textBoxEmailEdit.Text, UserName = textBoxUserNameEdit.Text, TeamLeaderId = (int)comboBoxTeamLeaderEdit.SelectedValue, UserKindId = (int)comboBoxUserKindEdit.SelectedValue };
            user.UserId = (int)comboBoxAllUsers.SelectedValue;
            var validationContext = new ValidationContext(user, null, null);
            var results = new List<ValidationResult>();


            if (Validator.TryValidateObject(user, validationContext, results, true))
            {
                if (UserRequsts.UpdateUser(user))
                    MessageBox.Show("update success");

                else
                    MessageBox.Show("update filed");
            }
            else
            {
                MessageBox.Show(string.Join(",\n", results.Select(p => p.ErrorMessage)));
            }


        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int idUser = (int)comboBoxAllUsersRemove.SelectedValue;

            UserRequsts.RemoveUser(idUser);
        }

        private void comboBoxAllUsersRemove_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddUser_Click(object sender, EventArgs e)
        {

        }
    }
}

