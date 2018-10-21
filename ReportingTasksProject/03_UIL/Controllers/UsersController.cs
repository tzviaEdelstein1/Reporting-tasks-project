﻿using System;
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
        // GET: api/Users
        public HttpResponseMessage Get()

        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<User>>(LogicUser.GetAllUsers(), new JsonMediaTypeFormatter())
            };
        }
        // GET: api/Users/5
        //public HttpResponseMessage Get(int id)
        //{
        //    return new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new ObjectContent<String>(LogicUser.GetUser(id), new JsonMediaTypeFormatter())
        //    };
        //}
        // GET: api/Users/wewe/11234
        [Route("users/{userName}/{password}")]
        public HttpResponseMessage Get(string userName,string password)

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
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,"error");
        }
        // POST: api/Users
        public HttpResponseMessage Post([FromBody]User value)
        {
            if (ModelState.IsValid)
            {
                return (LogicUser.AddUser(value)) ?
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

        //    // PUT: api/Users/5
        public HttpResponseMessage Put([FromBody]User value)
        {

            if (ModelState.IsValid)
            {
                return (LogicUser.UpdateUser(value)) ?
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
        public HttpResponseMessage Delete(int id)
        {
            return (LogicUser.RemoveUser(id)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not remove from DB", new JsonMediaTypeFormatter())
                    };
        }
    }
}
