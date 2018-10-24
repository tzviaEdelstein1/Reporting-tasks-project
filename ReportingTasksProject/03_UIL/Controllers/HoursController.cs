using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BOL;
using _02_BLL;
using System.Net.Http.Formatting;

namespace _03_UIL.Controllers
{
    public class HoursController : ApiController
    {

        // Get - get actual hours count to project requierd data: * ProjectId If the ProjectId is exist, we will return all the hours that belong to it, Else - we will return matching error.
        [HttpGet]
        [Route("api/GetActualHoursByProjectId/{projectId}")]
        public HttpResponseMessage GetActualHoursByProjectId(string projectId)

        {//- לבדוק מחזיר  null למה?
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<ActualHours>>(LogicHours.GetActualHoursByProjectId(projectId), new JsonMediaTypeFormatter())
            };
        }


        // Get - get hours on month to user requierd data: * UserId If the UserId is exist, we will return all the hours that belong to him, Else - we will return matching error.
        //צריך לשנות ברידמי ולבדוק
        [HttpGet]
        [Route("api/GetActualHoursByUserIdOnMonth/{UserName}/{month}/{year}")]
        public HttpResponseMessage GetActualHoursByUserIdOnMonth(string UserName, int month,int year)

        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<ActualHours>>(LogicHours.GetActualHoursByUserIdOnMonth(UserName, month,year), new JsonMediaTypeFormatter())
            };
        }


        // POST: api/Hours
        [HttpPost]
        [Route("api/Hours/{userId}")]
        public HttpResponseMessage Post([FromBody]ActualHours value,[FromUri]int userId)
        {//לבדוק אם עובד
            if (ModelState.IsValid)
            {
                return (LogicHours.AddActualHours(value, userId)) ?
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

        //Get - get hours to project by user kind (Example:get all the QA hours that have done to project 1) requierd data: * ProjectId * UserKindId 
        //We will select and return all the hours that belongs to this project (project id is equals to ProjectId) and their user(get it by user id) kind is UserKindId. If we wont find we will return matching error;
        [HttpGet]
        [Route("api/GetActualHoursByUserKindToProject/{ProjectName}/{UserKindName}")]
        public HttpResponseMessage GetActualHoursByUserKindToProject(string ProjectName, string UserKindName)

        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<ActualHours>>(LogicHours.GetActualHoursByUserKindToProject(ProjectName, UserKindName), new JsonMediaTypeFormatter())
            };
        }


    }
}
