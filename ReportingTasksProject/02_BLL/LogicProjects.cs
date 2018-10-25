﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_BOL;
using BOL;
using DAL;
using MySql.Data.MySqlClient;
namespace _02_BLL
{
    public class LogicProjects
    {
        public static List<Project> GetAllProjects()

        {
            try
            {
                string query = $"SELECT * FROM tasks.projects";
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
            catch (Exception ex)
            {
                var x = ex.StackTrace;
                throw ex;
            }
        }

        public static List<Project> GetProjectsByUserId(int userId)

        {
            try
            {
                string query = $"SELECT * FROM tasks.projects p JOIN TASKS.worker_to_project w ON p.project_id=w.project_id WHERE user_id={userId}";
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
            catch (Exception ex)
            {
                var x = ex.StackTrace;
                throw ex;
            }
        }
        public static List<Unknown> GetProjectsAndHoursByUserId(int userId)

        {
            try
            {
                string query = $"SELECT p.project_id ,project_name, hours,count( count_houers)" +
 $"FROM tasks.users u JOIN TASKS.worker_to_project w ON u.user_id = w.user_id JOIN tasks.projects p ON w.project_id = w.project_id JOIN tasks.actual_hours a ON p.project_id = a.project_id" +
 $" WHERE w.user_id = 9 group by w.user_id,project_name,hours,p.project_id";
                Func<MySqlDataReader, List<Unknown>> func = (reader) =>
                {
                    List<Unknown> projects = new List<Unknown>();
                    while (reader.Read())
                    {
                        projects.Add(new Unknown
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Hours = reader.GetDouble(2),
                            allocatedHours = reader.GetDouble(3)
                        });
                    }
                    return projects;
                };

                return DBaccess.RunReader(query, func);
            }
            catch (Exception ex)
            {
                var x = ex.StackTrace;
                throw ex;
            }
        }

        public static bool AddProject(Project project, int userId)
        {
            string queryChecking = $" select * from tasks.userkind_to_access where(access_id=2 and user_kind_id=(select user_kind_id from tasks.users where (user_id={userId})))";
            var isAbleTo = DBaccess.RunScalar(queryChecking);
            if (isAbleTo != null)

            {

                string query = $"INSERT INTO tasks.projects  " +
                               $"(`project_name`, `client_name`, `team_leader_id`, `develope_hours`,`qa_hours`,`ui/ux_hours`,`start_date`,`finish_date`)" +
                               $" VALUES ('{project.ProjectName}','{project.ClientName}'," +
                               $"'{project.TeamLeaderId}',{project.DevelopersHours},{project.QaHours},{project.UiUxHours}," +
                               $"'{project.StartDate.Year}-{project.StartDate.Month}-{project.StartDate.Day}','{project.FinishDate.Year}-{project.FinishDate.Month}-{project.FinishDate.Day}')";
                //string query = $"INSERT INTO tasks.projects(`project_name`, `client_name`, `team_leader_id`, `develope_hours`,`qa_hours`,`ui/ux_hours`,`start_date`,`finish_date`) VALUES ('{project.ProjectName}','{project.ClientName}','{project.TeamLeaderId}','{project.DevelopersHours}','{project.QaHours}','{project.UiUxHours}','{project.StartDate}','{project.FinishDate}')";
                return DBaccess.RunNonQuery(query) == 1;

            }
            else return false;



        }
        public static bool UpdateProject(Project project, int userId)
        {

            string queryChecking = $" select * from tasks.userkind_to_access where(access_id=2 and user_kind_id=(select user_kind_id from tasks.users where (user_id={userId})))";
            var isAbleTo = DBaccess.RunScalar(queryChecking);
            if (isAbleTo != null)

            {
                string query = $"UPDATE tasks.projects SET  project_name='{project.ProjectName}',client_name='{project.ClientName}',team_leader_id={project.TeamLeaderId},develope_hours={project.DevelopersHours},qa_hours={project.QaHours},ui/ux_hours={project.UiUxHours},start_date='{project.StartDate}',finish_date='{project.FinishDate}' WHERE (project_id={project.ProjectId})";
                return DBaccess.RunNonQuery(query) == 1;
            }
            else return false;

        }
        public static int getProjectId(string projectName)
        {
            string query = $"SELECT project_id FROM tasks.projects WHERE project_name='{projectName}'";
            return (int)DBaccess.RunScalar(query);
        }




    }
}
