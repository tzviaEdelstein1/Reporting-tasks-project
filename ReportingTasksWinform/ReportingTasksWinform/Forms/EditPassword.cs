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
            this.user.Password =UserRequsts.sha256(tbPassword.Text);
            UserRequsts.UpdatePassword(user);
            this.Close();
        }
    }
}
