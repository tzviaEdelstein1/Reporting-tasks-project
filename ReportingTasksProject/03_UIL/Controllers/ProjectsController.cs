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
        // GET: api/Projects
        public HttpResponseMessage Get()

        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Project>>(LogicProjects.GetAllProjects(), new JsonMediaTypeFormatter())
            };
        }
        //get the projects by teamleader id
        [Route("api/Projects/{teamLeaderId}")]
        [HttpGet]
        public HttpResponseMessage Get(int teamLeaderId)
        {
            List<Project> projects = LogicProjects.GetAllProjects();
            projects = projects.Where(u => u.TeamLeaderId == teamLeaderId).ToList();
            if(projects.Count>0)
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Project>>( projects, new JsonMediaTypeFormatter())
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
        [Route("api/Projects/{userId}")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Project value, [FromUri]int userId)
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

        //    // PUT: api/Projects
        [Route("api/Projects/{userId}")]
        public HttpResponseMessage Put([FromBody]Project value, [FromUri]int userId)
        {

            if (ModelState.IsValid)
            {
                return (LogicProjects.UpdateProject(value, userId)) ?
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


    }
}
