using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using BOL;
using _02_BLL;
using System.Text;
using System.Net.Mail;

namespace _03_UIL.Controllers
{
    public class UsersController : ApiController
    {
        static User user = new User();
        static string body;
        [HttpGet]
        [Route("api/Users/GetAllUsers")]
        public HttpResponseMessage GetAllUsers()

       {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<User>>(LogicUser.GetAllUsers(), new JsonMediaTypeFormatter())
            };
        }
        [HttpPut]
        [Route("api/Users/CheckUserIp")]
        public HttpResponseMessage CheckUserIp([FromBody] string ip)
        {
            List<User> users = LogicUser.GetAllUsers();
            user = users.FirstOrDefault(u => u.UserIP == ip);

            if (user != null)
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<User>(user, new JsonMediaTypeFormatter())
                };

            }

            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "error");

        }
        [HttpGet]
        [Route("api/Users/GetUsersForTeamLeader/{TeamLeaderId}")]
        public HttpResponseMessage GetUsersForTeamLeader(int TeamLeaderId)

        {
            List<User> users = LogicUser.GetAllUsers().Where(u => u.TeamLeaderId == TeamLeaderId).ToList();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<User>>(users, new JsonMediaTypeFormatter())
            };
        }
        [HttpGet]
        [Route("api/Users/GetTeamLeaders")]
        public HttpResponseMessage GetTeamLeaders()

        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<User>>(LogicUser.GetTeamLeaders(), new JsonMediaTypeFormatter())
            };
        }

        [HttpGet]
        [Route("api/Users/VerifyEmail/{userName}")]
        public HttpResponseMessage VerifyEmail(string userName)
        {
            List<User> users = LogicUser.GetAllUsers();
            user = users.FirstOrDefault(u => u.UserName == userName);

            if (user != null)
            {
                string email = user.UserEmail;

                SendEmail(email);
                return new HttpResponseMessage(HttpStatusCode.OK);

            }

            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "error");

        }

        [HttpGet]
        [Route("api/Users/VerifyPassword/{password}")]
        public HttpResponseMessage VerifyPassword(string password)
        {
            if (password == body)
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<User>(user,new JsonMediaTypeFormatter())
                };
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "error");

        }
        private void SendEmail(string email)
        {
            List<User> users = LogicUser.GetAllUsers();
            try
            {
                string subject = "Email Subject";

                body = CreatePassword(6); ;

                string FromMail = "reporting.manage@gmail.com";
                string emailTo = email;
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

        // GET: api/Users/wewe/11234
        [Route("users/{userName}/{password}")]
        public HttpResponseMessage Get(string userName, string password)

        {
            User user = new User();
            List<User> users = LogicUser.SignIn(userName, password);
            if (users.Count > 0)
            {
                user = users[0];
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<User>(user, new JsonMediaTypeFormatter())
                };
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "error");
        }
        // GET: api/Users/wewe/11234
        [HttpPut]
        [Route("api/users/Logout/{userId}")]
        public HttpResponseMessage Logout(int userId)

        {
            return (LogicUser.UpdateUserIp(userId)) ?
                      new HttpResponseMessage(HttpStatusCode.OK) :
                      new HttpResponseMessage(HttpStatusCode.BadRequest)
                      {
                          Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                      };
        }
        // POST: api/Users
        [HttpPost]
        [Route("api/Users/{userId}")]
        public HttpResponseMessage Post([FromBody]User value, [FromUri]int userId)
        {
            if (ModelState.IsValid)
            {
                return (LogicUser.AddUser(value, userId)) ?
                   new HttpResponseMessage(HttpStatusCode.Created) :
                   new HttpResponseMessage(HttpStatusCode.BadRequest)
                   {
                       Content = new ObjectContent<String>("Can not add to DB", new JsonMediaTypeFormatter())
                   };
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<List<string>>(ErrorList, new JsonMediaTypeFormatter())
            };

        }

        [HttpPut]
        [Route("api/Users/{userId}")]
        public HttpResponseMessage Put([FromBody]User value, [FromUri]int userId)
        {

            if (ModelState.IsValid)
            {
                return (LogicUser.UpdateUser(value, userId)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                    };
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<List<string>>(ErrorList, new JsonMediaTypeFormatter())
            };
        }
        [HttpPut]
        [Route("api/Users/EditPassword")]
        public HttpResponseMessage EditPassword([FromBody]User value)
        {

            if (ModelState.IsValid)
            {
                return (LogicUser.UpdatePassword(value)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                    };
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<List<string>>(ErrorList, new JsonMediaTypeFormatter())
            };
        }
        //    // DELETE: api/Users/5
        [HttpDelete]
        [Route("api/Users/{id}/{userId}")]
        public HttpResponseMessage Delete(int id, int userId)
        {
            return (LogicUser.RemoveUser(id, userId)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not remove from DB", new JsonMediaTypeFormatter())
                    };
        }

        [Route("api/Users/GetUserById/{userId}")]
        [HttpGet]
        public HttpResponseMessage GetUserById(int userId)
        {


            User user = new User();
            List<User> users = LogicUser.GetUserById(userId);
            if (users.Count > 0)
            {
                user = users[0];
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<User>(user, new JsonMediaTypeFormatter())
                };
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "error");

        }

        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }


    }
}
