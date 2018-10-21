﻿using BOL;
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
            string query = $"SELECT * FROM tasks.users u JOIN tasks.worker_to_project w on u.user_id = w.user_id WHERE w.project_id =(SELECT project_id FROM tasks.projects WHERE project_name={projectName} )";
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


        public static bool AddWorkerToProject(WorkerToProject workerToProject)
        {
            string query = $" INSERT INTO `tasks`.`worker_to_project` (`user_id`, `project_id`, `hours`) VALUES ('{workerToProject.UserId}','{workerToProject.ProjectId}','{workerToProject.Hours}',)";
            return DBaccess.RunNonQuery(query) == 1;
        }
        public static bool UpdateWorkerToProject(WorkerToProject workerToProject)
        {
            string query = $"UPDATE `tasks`.`worker_to_project SET user_id='{workerToProject.UserId}',project_id='{workerToProject.ProjectId}',hours={workerToProject.Hours})";
            return DBaccess.RunNonQuery(query) == 1;
        }

        public static bool RemoveWorkerToProject(int id)
        {
            string query = $"DELETE FROM tasks.worker_to_project WHERE  project_id={id}";
            return DBaccess.RunNonQuery(query) == 1;
        }

    }
}
