using ReportingTasksWinform.Models;
using ReportingTasksWinform.Reqests;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ReportingTasksWinform.Forms
{
    public partial class EditPassword : Form
    {
        User user;
        public EditPassword(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.user.Password = UserRequsts.sha256(tbPassword.Text);
            UserRequsts.UpdatePassword(user);
            this.Close();

        }

    }
}
