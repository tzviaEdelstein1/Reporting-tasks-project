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
        [Route("api/Users/CheckIfTeamIsAbleToDelete/{userId}")]
        public HttpResponseMessage CheckIfTeamIsAbleToDelete(int userId)

        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<bool>(LogicUser.CheckIfTeamIsAbleToDelete(userId), new JsonMediaTypeFormatter())
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


                SendEmail(user);
                return new HttpResponseMessage(HttpStatusCode.OK);

            }

            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "error");

        }

        [HttpGet]
        [Route("api/Users/VerifyPassword/{password}/{userName}")]
        public HttpResponseMessage VerifyPassword(string password, string userName)
        {
            List<User> users = LogicUser.GetAllUsers();
            User user = users.FirstOrDefault(u => u.UserName == userName);
            var verifyPassword = user.VerifyPassword;
            if (password == verifyPassword)
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<User>(user, new JsonMediaTypeFormatter())
                };
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "error");

        }
        private void SendEmail(User user)
        {
            string email = user.UserEmail;
            List<User> users = LogicUser.GetAllUsers();
            try
            {
                string subject = "Email Subject";

                user.VerifyPassword = CreatePassword(6); ;
                LogicUser.UpdateUser(user, user.UserId);
                string FromMail = "reporting.manage@gmail.com";
                string emailTo = email;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(FromMail);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = user.VerifyPassword;
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
        [HttpGet]
        [Route("api/users/Login/{userName}/{password}")]
        public HttpResponseMessage Login(string userName, string password)
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
            return Request.CreateResponse(HttpStatusCode.OK, "user is not exists");
        }
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
        [HttpPost]
        [Route("api/Users/AddUser/{userId}")]
        public HttpResponseMessage AddUser([FromBody]User value, [FromUri]int userId)
        {
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("userId"))
            {
                string token = headers.GetValues("userId").First();
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, new JsonMediaTypeFormatter());
            // Set headers for paging
            response.Headers.Add("secret", "nn");
            if (ModelState.IsValid)
            {
                return (LogicUser.AddUser(value, userId)) ?
                  response:
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
        [Route("api/Users/UpdateUser/{userId}")]
        public HttpResponseMessage UpdateUser([FromBody]User value, [FromUri]int userId)
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
        [HttpDelete]
        [Route("api/Users/Delete/{id}/{userId}")]
        public HttpResponseMessage Delete(int id, int userId)
        {
            return (LogicUser.RemoveUser(id, userId)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not remove from DB", new JsonMediaTypeFormatter())
                    };
        }
        [HttpGet]
        [Route("api/Users/GetUserById/{userId}")]

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
