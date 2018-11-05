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
        [Route("api/SendEmail/{emailBody}")]
        public void SendEmail(string emailBody)    
        {
            List<User> users = LogicUser.GetAllUsers();
            try
            {
  string subject = "Email Subject";
                string body = emailBody;
          
            string FromMail = "reporting.manage@gmail.com";
            string emailTo = users.FirstOrDefault(user => user.UserKindId == 1).UserEmail;
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


    }
}
