using Newtonsoft.Json;
using ReportingTasksWinform.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ReportingTasksWinform.Reqests
{
    public class ProjectsRequst
    {
        public static Project AddProject(Project project)
        {
            string result = "";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/Projects/" + Global.UserId);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(project);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {

                    {
                        result = streamReader.ReadToEnd();
                        Project pro = JsonConvert.DeserializeObject<Project>(result);
                        if (result != "")
                        {
                            MessageBox.Show("ok");
                            return pro;

                        }
                        else
                        { return null; }
                    }

                }
            }
            catch (Exception ex)
            {

                return null;

            }


        }
        public static List<Project> GetProjectsByTeamLeaderId()
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;

            List<Project> ProjectsForteamLeader = new List<Project>();
            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Projects/" + Global.UserId);
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    ProjectsForteamLeader = JsonConvert.DeserializeObject<List<Project>>(content);
 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
            return ProjectsForteamLeader;
        }
        public static List<Project>GetAllProjects()
        {
            List<Project> AllProjects = new List<Project>();
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
           
            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Projects");
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    AllProjects = JsonConvert.DeserializeObject<List<Project>>(content);
                    MessageBox.Show("success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
            return AllProjects;
        }
        public static List<Project> GetActiveProjects()
        {
            List<Project> ActiveProjects = new List<Project>();
            HttpWebRequest request;
            HttpWebResponse response;
            string content;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Projects/GetActiveProjects");
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    ActiveProjects = JsonConvert.DeserializeObject<List<Project>>(content);
                    MessageBox.Show("success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
            return ActiveProjects;
        }
        public static List<Unknown> GetProjectsAndHoursByTeamLeaderId()
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            List<Unknown> workersHours = new List<Unknown>();
            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Projects/GetProjectsAndHoursByTeamLeaderId/" + Global.UserId);
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                workersHours = JsonConvert.DeserializeObject<List<Unknown>>(content);
            }
            return workersHours;

        }
        public static List<Unknown> GetProjectsAndHoursByUserId()
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            List<Unknown> projectDetails = new List<Unknown>();
            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Projects/GetProjectsAndHoursByUserId/" + Global.UserId);
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                projectDetails = JsonConvert.DeserializeObject<List<Unknown>>(content);
            }
            return projectDetails;
        }
        public static List<Unknown> GetProjectsAndHoursByUserIdAccordingTheMonth()
        {

            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            List<Unknown> projectDetailsByDate = new List<Unknown>(); 
            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Projects/GetProjectsAndHoursByUserIdAccordingTheMonth/" + Global.UserId);
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                projectDetailsByDate = JsonConvert.DeserializeObject<List<Unknown>>(content);
            }

            return projectDetailsByDate;
        }

        public static List<Project> GetProjectsByUserId(int idUser)
        {
            List<Project> ProjectsForUser = new List<Project>();
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Projects/GetProjectsByUserId/" + idUser);
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                ProjectsForUser = JsonConvert.DeserializeObject<List<Project>>(content);
            }
            return ProjectsForUser;
        }
        public static List<Unknown> GetProjectsAndHoursByProjectId(int idProject)
        {
            List<Unknown> ProjectsAndHours = new List<Unknown>();
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Projects/GetProjectsAndHoursByProjectId/" + idProject);
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                ProjectsAndHours = JsonConvert.DeserializeObject<List<Unknown>>(content);
            }
            return ProjectsAndHours;

        }
        public static bool UpdateProject(Project project)
        {

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/Projects/" + Global.UserId);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(project);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    {
                        var result = streamReader.ReadToEnd();
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                            return true;
                        else
                            return false;
                    }

                }
            }
            catch (Exception ex)
            {

                return false;

            }
        }
    }
}
