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
   public class LogicSendEmail
    {
        public static List<User>SendEmail(int userId)
        {
            string query = $"SELECT * FROM tasks.users WHERE user_id={userId} OR user_kind_id=1";
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
