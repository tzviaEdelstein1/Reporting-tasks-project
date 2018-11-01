using Newtonsoft.Json;
using ReportingTasksWinform.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReportingTasksWinform.Reqests
{
    public class UsersKindRequst
    {

        public static List<UserKind> GetAllUsersKind()
        {
            List<UserKind> usersKind = new List<UserKind>();
            HttpWebRequest request;
            HttpWebResponse response;
            string content;

            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/UserKinds");
            response = (HttpWebResponse)request.GetResponse();
            content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            usersKind = JsonConvert.DeserializeObject<List<UserKind>>(content);
            return usersKind;
        }
    }
}
