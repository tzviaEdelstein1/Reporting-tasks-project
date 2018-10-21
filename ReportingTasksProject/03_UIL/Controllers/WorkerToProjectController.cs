﻿using _02_BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace _03_UIL.Controllers
{
    public class WorkerToProjectController : ApiController
    {  [HttpGet]
        [Route("WorkerToProject/GetProjectsbyUserName/{userName}")]
        public HttpResponseMessage GetProjectsbyUserName(string userName)

        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Project>>(LogicWorkerToProject.GetProjectsbyUserName(userName), new JsonMediaTypeFormatter())
            };
        }
        [HttpGet]
        [Route("WorkerToProject/GetWorkerbyProjectName/{projectname}")]
        public HttpResponseMessage GetWorkerbyProjectName(string projectname)

        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<User>>(LogicWorkerToProject.GetWorkerbyProjectName(projectname), new JsonMediaTypeFormatter())
            };
        }
        // POST: api/Users
        public HttpResponseMessage Post([FromBody]WorkerToProject value)
        {
            if (ModelState.IsValid)
            {
                return (LogicWorkerToProject.AddWorkerToProject(value)) ?
                   new HttpResponseMessage(HttpStatusCode.Created) :
                   new HttpResponseMessage(HttpStatusCode.BadRequest)
                   {
                       Content = new ObjectContent<String>("Can not add to DB", new JsonMediaTypeFormatter())
                   };
            };

            List<string> ErrorList = new List<string>();
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<List<string>>(ErrorList, new JsonMediaTypeFormatter())
            };

        }
        // PUT: api/ WorkerToProject
        public HttpResponseMessage Put([FromBody]WorkerToProject value)
        {

            if (ModelState.IsValid)
            {
                return (LogicWorkerToProject.UpdateWorkerToProject(value)) ?
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
        // DELETE: api/WorkerToProject/5
        public HttpResponseMessage Delete(int id)
        {
            return (LogicWorkerToProject.RemoveWorkerToProject(id)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not remove from DB", new JsonMediaTypeFormatter())
                    };
        }


    }
}
