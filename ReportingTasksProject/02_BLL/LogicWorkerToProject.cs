using BOL;
using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BLL
{
    public class LogicWorkerToProject
    {

        public static List<Project> GetProjectsbyUserName(string userName)
        {

            string query = $"SELECT * FROM tasks.projects p JOIN tasks.worker_to_project w on p.project_id = w.project_id WHERE w.user_id =(SELECT user_id FROM tasks.users WHERE user_name='{userName}')";
            Func<MySqlDataReader, List<Project>> func = (reader) =>
            {
                List<Project> projects = new List<Project>();
                while (reader.Read())
                {
                    projects.Add(new Project
                    {
                        ProjectId = reader.GetInt32(0),
                        ProjectName = reader.GetString(1),
                        ClientName = reader.GetString(2),
                        TeamLeaderId = reader.GetInt32(3),
                        DevelopersHours = reader.GetInt32(4),
                        QaHours = reader.GetInt32(5),
                        UiUxHours = reader.GetInt32(6),
                        StartDate = reader.GetDateTime(7),
                        FinishDate = reader.GetDateTime(8),
                    });
                }
                return projects;
            };

            return DBaccess.RunReader(query, func);


        }
        public static List<User> GetWorkerbyProjectName(string projectName)
        {
            string query = $"SELECT * FROM tasks.users u JOIN tasks.worker_to_project w on u.user_id = w.user_id WHERE w.project_id =(SELECT project_id FROM tasks.projects WHERE project_name='{projectName}' )";
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        UserId = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        UserEmail = reader.GetString(2),
                        Password = reader.GetString(3),
                        TeamLeaderId = reader.GetInt32(4),
                        UserKindId = reader.GetInt32(5),
                    });
                }
                return users;
            };

            return DBaccess.RunReader(query, func);
        }
        
            public static List<WorkerToProject> GetWorkersToProjectByProjectId(int projectId)
        {
            string query = $"SELECT * FROM tasks.worker_to_project WHERE project_id={projectId}";
            Func<MySqlDataReader, List<WorkerToProject>> func = (reader) =>
            {
                List<WorkerToProject> workerToProjects = new List<WorkerToProject>();
                while (reader.Read())
                {
                    workerToProjects.Add(new WorkerToProject
                    {
                        WorkerToProjectId = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        ProjectId = reader.GetInt32(2),
                        Hours = reader.GetInt32(3),
   
                    });
                }
                return workerToProjects;
            };

            return DBaccess.RunReader(query, func);
        }
        public static List<WorkerToProject> GetWorkersToProjectByUserId(int userId)
        {
            string query = $"SELECT * FROM tasks.worker_to_project WHERE user_id={userId};";
            Func<MySqlDataReader, List<WorkerToProject>> func = (reader) =>
            {
                List<WorkerToProject> workerToProjects = new List<WorkerToProject>();
                while (reader.Read())
                {
                    workerToProjects.Add(new WorkerToProject
                    {
                        WorkerToProjectId = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        ProjectId = reader.GetInt32(2),
                        Hours = reader.GetInt32(3),

                    });
                }
                return workerToProjects;
            };

            return DBaccess.RunReader(query, func);
        }

        public static bool AddWorkerToProject(WorkerToProject workerToProject,int userId)
        {
            string queryChecking = $" select * from tasks.userkind_to_access where(access_id=2 and user_kind_id=(select user_kind_id from tasks.users where (user_id={userId})))";
            var isAbleTo = DBaccess.RunScalar(queryChecking);
            if (isAbleTo != null)

            {
                string query = $" INSERT INTO `tasks`.`worker_to_project` (`user_id`, `project_id`) VALUES ({workerToProject.UserId},{workerToProject.ProjectId})";
                return DBaccess.RunNonQuery(query) == 1;
            }
            else
                return false;
        }
        public static bool UpdateWorkerToProject(WorkerToProject workerToProject)
        {//אין בדיקת הרשאות
            string query = $"UPDATE tasks.worker_to_project SET user_id='{workerToProject.UserId}',project_id='{workerToProject.ProjectId}',hours={workerToProject.Hours} WHERE worker_to_project_id={workerToProject.WorkerToProjectId}";
            return DBaccess.RunNonQuery(query) == 1;
        }

        public static bool RemoveWorkerToProject(int id)
        {//אין בדיקת הרשאות
            string query = $"DELETE FROM tasks.worker_to_project WHERE  project_id={id}";
            return DBaccess.RunNonQuery(query) == 1;
        }
       
        public static bool AddWorkersByTeamLeaderId(int projectId,int userId)
        {//אין בדיקת הרשאות


                string query = $" INSERT INTO `tasks`.`worker_to_project` (`user_id`, `project_id`) VALUES ('{userId}','{projectId}')";
                return DBaccess.RunNonQuery(query) == 1;

       

         
          
        }

        public static List<User> getUsersByTeamLeaderId(int teamLeaderId)
        {
            string query = $"SELECT * FROM tasks.users WHERE team_leader_id={teamLeaderId}";
            Func<MySqlDataReader, List<User>> func = (reader) =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        UserId = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        UserEmail = reader.GetString(2),
                        Password = reader.GetString(3),
                        TeamLeaderId = reader.GetInt32(4),
                        UserKindId = reader.GetInt32(5),
                    });
                }
                return users;
            };

            return DBaccess.RunReader(query, func);
        }
    }
}
