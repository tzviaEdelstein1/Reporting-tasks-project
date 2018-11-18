﻿using _01_BOL;
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
    public class TreeTableController : ApiController
    {

        // GET: api/TreeTable
        public HttpResponseMessage Get()

        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<TreeTable>>(LogicTreeTable.GetAllTreeTable(), new JsonMediaTypeFormatter())
            };
        }
    }
}