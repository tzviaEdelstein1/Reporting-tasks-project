using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using ReportingTasksWinform.Models;

namespace ReportingTasksWinform
{
    public partial class AddProject : Form
    {
        public AddProject()
        {
            InitializeComponent();
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            string result = "";
            Project project = new Project()
            {
                ProjectName = textBoxNameProject.Text,
                ClientName = textBoxClientName.Text,
                DevelopersHours = (int)numericDevelopersHours.Value,
                QaHours = (int)numericQaHours.Value,
                UiUxHours = (int)numericUiUxhours.Value,
                TeamLeaderId = 1,
                FinishDate = dateFinish.Value,
                StartDate = dateStart.Value

            };


            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/Projects/12");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(project);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {

                    {
                        result = streamReader.ReadToEnd();
                        if (result == "true")
                        {
                            MessageBox.Show("ok");
                            //ChoosePartner choosePartner = new ChoosePartner(user.UserName);
                            //choosePartner.Show();


                        }
                        else
                        { MessageBox.Show(result); }
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("error", ex.Message.ToString());

            }


        }
    }
}
