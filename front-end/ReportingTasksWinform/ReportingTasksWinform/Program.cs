using ReportingTasksWinform.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportingTasksWinform
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static bool OpenDetailFormOnClose { get; set; }
        [STAThread]
        static void Main()
        {
            OpenDetailFormOnClose = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

            if (OpenDetailFormOnClose)
            {
                Application.Run(new VerifyEmail());
            }
        }
    }
}
