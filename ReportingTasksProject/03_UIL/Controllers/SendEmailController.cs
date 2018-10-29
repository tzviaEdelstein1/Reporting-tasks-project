using _02_BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Mail;
using System.Net.Mime;
using System.Web.Http;

namespace _03_UIL.Controllers
{
    public class SendEmailController : ApiController
    {

        [HttpGet]
        [Route("api/SendEmail/{userId}/{emailBody}")]
        public void SendEmail(int userId,string emailBody)    
        {
            //List<User>users=LogicSendEmail.SendEmail(userId);
            try
            {
  string subject = "Email Subject";
                string body = emailBody;
            //users.FirstOrDefault(user => user.UserId == userId).UserEmail;
            string FromMail = "reporting.manage@gmail.com";
            string emailTo = "zvia.edl@gmail.com";
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

             var x= ex.Message;
            }
             
        }


        public void sendEmail()
        {


            try
            {
                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress("zvia.edl@gmail.com", "To Name"));

                // From
                mailMsg.From = new MailAddress("reporting.manage@gmail.com", "From Name");

                // Subject and multipart/alternative Body
                mailMsg.Subject = "subject";
                string text = "text body";
                string html = @"<p>html body</p>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("reporting.manage@gmail.com", "0533121776");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
