using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace _02_BLL
{
    public class LogicUser
    {
        public static List<User> GetAllUsers()
        {
            try
            {
                string query = $"SELECT * FROM tasks.users";
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
            catch (Exception ex)
            {
                var x = ex.StackTrace;
                throw ex;
            }
        }



        //public static string GetUser(int id)
        //{
        //    string query = $"SELECT user FROM tasks.users WHERE user_id={id}";

        //    Func<MySqlDataReader, User> func = (reader) =>
        //    {
        //        User user = new User();
        //      if(reader.Read())
        //        {

        //            user.UserName = reader.GetString(1);
        //            user.UserEmail = reader.GetString(2);
        //            user.UserKindId = reader.GetInt32(5);
        //            user.Password = reader.GetString(3);
        //            user.TeamLeaderId = reader.GetInt32(4);

        //        }
        //        return user;

        //    };

        //    return DBaccess.RunOneReader(query, func);
        //}

        public static bool RemoveUser(int id)
        {
            string query = $"DELETE FROM tasks.users  WHERE  user_id={id}";
            return DBaccess.RunNonQuery(query) == 1;
        }

        public static bool UpdateUser(User user)
        {
            string query = $"UPDATE tasks.users SET user_name='{user.UserName}', user_email='{user.UserEmail}',password='{user.Password}',team_leader_id={user.TeamLeaderId},user_kind_id={user.UserKindId} WHERE user_id={user.UserId}";
            return DBaccess.RunNonQuery(query) == 1;
        }

        public static bool AddUser(User user)
        {

            string query = $"INSERT INTO tasks.users(`user_name`, `user_email`, `password`, `team_leader_id`, `user_kind_id`) VALUES ('{user.UserName}','{user.UserEmail}','{user.Password}',{user.TeamLeaderId},{user.UserKindId})";
            return DBaccess.RunNonQuery(query) == 1;
        }

        public static List<User> SignIn(string userName, string password)
        {
            string query = $"SELECT * FROM tasks.users WHERE user_name='{userName}'and password='{password}'";
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
