using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;
using MySql.Data.MySqlClient;

namespace _02_BLL
{
    public class LogicHours
    {
        public static List<ActualHours> GetActualHoursByProjectName(string ProjectName)
        {
            string query = $"SELECT * FROM tasks.actual_hours a JOIN tasks.projects p ON a.project_id=p.project_id where p.project_name={ProjectName}";
            Func<MySqlDataReader, List<ActualHours>> func = (reader) =>
            {
                List<ActualHours> actualHours = new List<ActualHours>();
                while (reader.Read())
                {
                    actualHours.Add(new ActualHours
                    {
                        ActualHoursId = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        ProjectId = reader.GetInt32(2),
                        CountHours = reader.GetInt32(3),
                        date = reader.GetDateTime(4),


                    });
                }
                return actualHours;
            };

            return DBaccess.RunReader(query, func);
        }

        public static List<ActualHours> GetActualHoursByUserIdOnMonth(string UserName, int month, int year)
        {
            string query = $"SELECT * FROM tasks.actual_hours a JOIN tasks.users u ON a.user_id=u.user_id where (u.user_name={UserName} and MONTH(a.work_date)={month} and YEAR(a.work_date)={year});";

            Func<MySqlDataReader, List<ActualHours>> func = (reader) =>
            {
                List<ActualHours> actualHours = new List<ActualHours>();
                while (reader.Read())
                {
                    actualHours.Add(new ActualHours
                    {
                        ActualHoursId = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        ProjectId = reader.GetInt32(2),
                        CountHours = reader.GetInt32(3),
                        date = reader.GetDateTime(4),


                    });
                }
                return actualHours;
            };

            return DBaccess.RunReader(query, func);
        }

        public static bool AddActualHours(ActualHours actualHours)
        {
           

            string query = $"INSERT INTO `tasks`.`actual_hours`(`user_id`, `project_id`, `count_houers`, `work_date`) VALUES ('{actualHours.UserId}','{actualHours.ProjectId}','{actualHours.CountHours}',{actualHours.date})";
            return DBaccess.RunNonQuery(query) == 1;
        }

        public static List<ActualHours> GetActualHoursByUserKindToProject(string projectName, string UserKindName)
        {
            string query = $"SELECT * FROM tasks.actual_hours a JOIN tasks.projects p ON a.project_id=p.project_id WHERE p.project_name = {projectName} AND a.user_id in (SELECT u.user_id FROM tasks.users u join tasks.user_kinds k on u.user_kind_id = k.user_kinds_id WHERE k.user_kinds_name = {UserKindName})";

            Func<MySqlDataReader, List<ActualHours>> func = (reader) =>
            {
                List<ActualHours> actualHours = new List<ActualHours>();
                while (reader.Read())
                {
                    actualHours.Add(new ActualHours
                    {
                        ActualHoursId = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        ProjectId = reader.GetInt32(2),
                        CountHours = reader.GetInt32(3),
                        date = reader.GetDateTime(4),


                    });
                }
                return actualHours;
            };

            return DBaccess.RunReader(query, func);
        }
    }
}