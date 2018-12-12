using ReportingTasksWinform.Models;
using ReportingTasksWinform.Reqests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ReportingTasksWinform.Forms.Manager
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }


        User user;
        List<User> allUsers = new List<User>();
        List<User> teamLeaders = new List<User>();
        List<UserKind> usersKind = new List<UserKind>();

        private void AddUser_Load(object sender, EventArgs e)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;

            teamLeaders = UserRequsts.GetAllTeamLeaders();

            //fill comboBox with team leaders
            comboBoxTeamLeader.DataSource = teamLeaders;
            comboBoxTeamLeader.ValueMember = "UserId";
            comboBoxTeamLeader.DisplayMember = "UserName";


            //fill comboBox with userKinds
            usersKind = UsersKindRequst.GetAllUsersKind();
            comboBoxUserKind.DataSource = usersKind;
            comboBoxUserKind.ValueMember = "KindUserId";
            comboBoxUserKind.DisplayMember = "KindUserName";


            //get all the workers and fill the combobox
            allUsers = UserRequsts.GetAllUsers();

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
                this.Close();
            }
            else
            {
                MessageBox.Show(string.Join(",\n", results.Select(p => p.ErrorMessage)));
            }

        }


        private void buttonAddUser_Click_1(object sender, EventArgs e)
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
    }
}
