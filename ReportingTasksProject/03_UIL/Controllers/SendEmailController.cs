using _02_BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Mail;
using System.Web.Http;

namespace _03_UIL.Controllers
{
    public class SendEmailController : ApiController
    {

        [HttpGet]
        [Route("api/SendEmail/SendEmail{userId}")]
        public HttpResponseMessage SendEmail(int userId)    
        {
            List<User>users=LogicSendEmail.SendEmail(userId);
           
                string subject = "Email Subject";
                string body = "Email body";
            //users.FirstOrDefault(user => user.UserId == userId).UserEmail;
            string FromMail = "zvia.edl@gmail.com";
            string emailTo = "Tzvia.edelstein@seldatinc.com";
                // users.FirstOrDefault(user => user.UserKindId == 1).UserEmail;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(FromMail);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;

                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("zvia.edl@gmail.com", "0533121407");
                SmtpServer.EnableSsl = false;
                SmtpServer.Send(mail);
       


            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<User>>(LogicUser.GetTeamLeaders(), new JsonMediaTypeFormatter())
            };
        }

    }
}
