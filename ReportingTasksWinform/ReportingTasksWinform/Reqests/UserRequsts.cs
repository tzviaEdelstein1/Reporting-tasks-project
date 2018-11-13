using Newtonsoft.Json;
using ReportingTasksWinform.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ReportingTasksWinform.Reqests
{
    public class UserRequsts
    {


        public static List<User> GetAllTeamLeaders()
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            List<User> teamLeaders = new List<User>();
            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Users/GetTeamLeaders");
                response = (HttpWebResponse)request.GetResponse();

                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                teamLeaders = JsonConvert.DeserializeObject<List<User>>(content);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }

            return teamLeaders;
        }

        public static List<User> GetAllUsers()
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            List<User> allUsers = new List<User>();
            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Users/GetAllUsers");
            response = (HttpWebResponse)request.GetResponse();
            content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            allUsers = JsonConvert.DeserializeObject<List<User>>(content);

            return allUsers;
        }
        public static List<User> GetUsersForTeamLeader()
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            List<User> usersUnderTeamLeader = new List<User>();
            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/Users/GetUsersForTeamLeader/" + Global.UserId);
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                usersUnderTeamLeader = JsonConvert.DeserializeObject<List<User>>(content);
            }
            else
                MessageBox.Show("error");
            return usersUnderTeamLeader;
        }

        public static bool UpdateUser(User user)
        {

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/Users/" + Global.UserId);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(user);
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
        public static bool UpdatePassword(User user)
        {

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/Users/EditPassword");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(user);
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
                        {
                            MessageBox.Show("update password succes");
                            return true;
                           
                        }
                            
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
        public static bool AddUser(User user)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/Users/" + Global.UserId);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(user);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;

            }
        }
        public static bool RemoveUser(int idUser)
        {
            try
            {
                WebRequest request = WebRequest.Create("http://localhost:56028/api/Users/" + idUser + "/" + Global.UserId);
                request.Method = "DELETE";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error in remove");
                return false;
            }
        }

       public static string sha256(string password)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}
