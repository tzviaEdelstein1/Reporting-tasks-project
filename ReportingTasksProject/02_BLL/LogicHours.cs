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
        
        public static List<ActualHours> GetActualHoursByUserId(int userId)
        {
            string query = $"SELECT * FROM tasks.actual_hours where user_id={userId}";
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


        public static bool AddActualHours(ActualHours actualHours,int userId)
        {
                string query = $"INSERT INTO `tasks`.`actual_hours`(`user_id`, `project_id`, `count_houers`, `date`) VALUES ('{actualHours.UserId}','{actualHours.ProjectId}','{actualHours.CountHours}','{actualHours.date.Year}-{actualHours.date.Month}-{actualHours.date.Day}')";
                return DBaccess.RunNonQuery(query) == 1;
           
           
        }


    }
}