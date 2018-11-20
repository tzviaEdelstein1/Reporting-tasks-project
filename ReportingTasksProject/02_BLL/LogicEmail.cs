using BOL;
using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace _02_BLL
//הוספתי
{
    public class LogicEmail
    {
        public static async Task BeginTimer()
        {
            SendAlerts();
            Timer timer = new Timer(86400000);//1000*60*60*24=86400000
            timer.Elapsed += async (timerSender, timerEvent) => SendAlerts();
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        public static async void SendAlerts()
        {


            List<Project> projects = new List<Project>();

            DateTime date = DateTime.Today.AddDays(1);

            string tommorowDate = $"'{date.Year}-{date.Month}-{date.Day}'";
            List<string> emails = new List<string>();
            string query = $"SELECT * FROM tasks.projects where finish_date={tommorowDate} and is_active=1";
            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {

                while (reader.Read())
                {
                    projects.Add(new Project
                    {
                        ProjectId = reader.GetInt32(0),
                        ProjectName = reader.GetString(1),
                        ClientName = reader.GetString(2),
                        TeamLeaderId = reader.GetInt32(3),
                        DevelopersHours = reader.GetInt32(4),
                        QaHours = reader.GetInt32(5),
                        UiUxHours = reader.GetInt32(6),
                        StartDate = reader.GetDateTime(7),
                        FinishDate = reader.GetDateTime(8),
                    });
                }
                return projects;
            };

            DBaccess.RunReader(query, func);

            foreach (var item in projects)
            {
                string query2 = $"SELECT U.user_email FROM tasks.users U JOIN tasks.worker_to_project WP ON U.user_id=WP.user_id WHERE WP.project_id={item.ProjectId} and WP.hours >(SELECT sum(count_houers) FROM tasks.actual_hours where user_id=U.user_id and project_id={item.ProjectId})";

                Func<MySqlDataReader, List<string>> func2 = (reader) =>
                {

                    while (reader.Read())
                    {
                        emails.Add(reader.GetString(0));
                    }
                    return emails;
                };

                DBaccess.RunReader(query2, func2);
            }

            foreach (var item in emails)
            {
                SendEmail("Alert!!", "your tasks deadline is tommorow!! please finish the task", item);
            }

        }
       public static void SendEmail(string subject, string body, string to)
        {
            try
            {


                string FromMail = "reporting.manage@gmail.com";
                string emailTo = to;
                // users.FirstOrDefault(user => user.UserKindId == 1).UserEmail;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(FromMail);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("reporting.manage@gmail.com", "0533121776");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {

                var x = ex.Message;
            }
        }
    }
}
