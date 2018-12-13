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


        [HttpPost]
        [Route("api/ActualHours/AddActualHours/{userId}")]
        public HttpResponseMessage AddActualHours([FromBody]ActualHours value,[FromUri]int userId)
        {
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

            //if the code reached this part - the ActualHours is not valid
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
