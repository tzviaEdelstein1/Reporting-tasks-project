using _01_BOL;
using _02_BLL;
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
    public class ProjectsController : ApiController
    {
        [Route("api/Projects/GetAllProjects")]
        [HttpGet]
        public HttpResponseMessage Get()

        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Project>>(LogicProjects.GetAllProjects(), new JsonMediaTypeFormatter())
            };
        }
        [Route("api/Projects/GetActiveProjects")]
        [HttpGet]
        public HttpResponseMessage GetActiveProjects()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Project>>(LogicProjects.GetAllProjects().Where(p => p.IsActive = true).ToList(), new JsonMediaTypeFormatter())
            };
        }
        //get the projects by teamleader id
        [Route("api/Projects/GetProjectsByTeamId/{teamLeaderId}")]
        [HttpGet]
        public HttpResponseMessage GetProjectsByTeamId(int teamLeaderId)
        {
            List<Project> projects = LogicProjects.GetAllProjects();
            projects = projects.Where(u => u.TeamLeaderId == teamLeaderId).ToList();
            if (projects.Count > 0)
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<List<Project>>(projects, new JsonMediaTypeFormatter())
                };
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new ObjectContent<String>("there is not projects", new JsonMediaTypeFormatter())
                };
            }
        }
        //get the projects by userid 
        [Route("api/Projects/GetProjectsByUserId/{userId}")]
        [HttpGet]
        public HttpResponseMessage GetProjectsByUserId(int userId)
        {

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Project>>(LogicProjects.GetProjectsByUserId(userId), new JsonMediaTypeFormatter())
            };
        }
        //get the projects and the hours by user id
        [Route("api/Projects/GetProjectsAndHoursByUserId/{userId}")]
        [HttpGet]
        public HttpResponseMessage GetProjectsAndHoursByUserId(int userId)
        {

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Unknown>>(LogicProjects.GetProjectsAndHoursByUserId(userId), new JsonMediaTypeFormatter())
            };
        }
        //get the projects and the hours by user id according the month
        [Route("api/Projects/GetProjectsAndHoursByUserIdAccordingTheMonth/{userId}")]
        [HttpGet]
        public HttpResponseMessage GetProjectsAndHoursByUserIdAccordingTheMonth(int userId)
        {

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Unknown>>(LogicProjects.GetProjectsAndHoursByUserIdAccordingTheMonth(userId), new JsonMediaTypeFormatter())
            };
        }

        [Route("api/Projects/GetProjectsAndHoursByProjectId/{projectId}")]
        [HttpGet]
        public HttpResponseMessage GetProjectsAndHoursByProjectId(int projectId)
        {

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Unknown>>(LogicProjects.GetProjectsAndHoursByProjectId(projectId), new JsonMediaTypeFormatter())
            };
        }
        //get the projects and the hours by teamleader id
        [Route("api/Projects/GetProjectsAndHoursByTeamLeaderId/{teamLeaderId}")]
        [HttpGet]
        public HttpResponseMessage GetProjectsAndHoursByTeamLeaderId(int teamLeaderId)
        {

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Unknown>>(LogicProjects.GetProjectsAndHoursByTeamLeaderId(teamLeaderId), new JsonMediaTypeFormatter())
            };
        }

        [Route("api/Projects/AddProject/{userId}")]
        [HttpPost]
        public HttpResponseMessage AddProject([FromBody]Project value, [FromUri]int userId)
        {
            if (ModelState.IsValid)
            {
                if (LogicProjects.AddProject(value, userId))
                {
                    List<User> users = LogicWorkerToProject.getUsersByTeamLeaderId(value.TeamLeaderId);

                    var id = LogicProjects.getProjectId(value.ProjectName);
                    value.ProjectId = id;
                    foreach (var item in users)
                    {
                        LogicWorkerToProject.AddWorkersByTeamLeaderId(id, item.UserId);
                    }

                    return Request.CreateResponse(HttpStatusCode.Created, value);
                }

                else
                {
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not add to DB", new JsonMediaTypeFormatter())
                    };
                }
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the project is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<List<string>>(ErrorList, new JsonMediaTypeFormatter())
            };

        }

        [Route("api/Projects/UpdateProject/{userId}")]
        [HttpPut]
        public HttpResponseMessage UpdateProject([FromBody]Project value, [FromUri]int userId)
        {

             return (LogicProjects.UpdateProject(value, userId)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                    };
      
        }


    }
}

