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
using _02_BLL;
namespace _03_UIL.Controllers
{
    public class SendEmailController : ApiController
    {


        [HttpGet]
        [Route("api/SendEmail/{emailBody}")]
        public void SendEmail(string emailBody)
        {//לטפל בזה שיגיע למנהל עצמו...
            //List<User>users=LogicSendEmail.SendEmail(userId);

            _02_BLL.LogicEmail.SendEmail("Email Subject", emailBody, "zvia.edl@gmail.com");
        }



    }
}
