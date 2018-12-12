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
    public class UserKindsController : ApiController
    {  
        [HttpGet]
        [Route("api/UserKinds/Get")]
        public HttpResponseMessage Get()

        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<UserKind>>(LogicUserKinds.GetAllUserKinds(), new JsonMediaTypeFormatter())
            };
        }
    }
}
