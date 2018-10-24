using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using BOL;
using _02_BLL;

namespace _03_UIL.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("api/Users/GetAllUsers")]
        public HttpResponseMessage GetAllUsers()

        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<User>>(LogicUser.GetAllUsers(), new JsonMediaTypeFormatter())
            };
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
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "error");
        }

        // POST: api/Users
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


    }
}
