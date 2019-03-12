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
                        UserIP=reader.GetString(6),
                        VerifyPassword=reader.GetString(7)
                   
                    });
                }
                return users;
            };

            return DBaccess.RunReader(query, func);
        }
   
        public static bool CheckUserIp(string userIp)
        {
            string query = $"select user_ip from  tasks.users where user_ip={userIp}";
            return DBaccess.RunNonQuery(query) == 1;
        }
        public static bool CheckIfTeamIsAbleToDelete(int userId)
        {
            string query = $" SELECT if( count(*)>0,1,0) " +
             $"from  tasks.users u join tasks.projects p on u.user_id=p.team_leader_id" +
             $" where p.team_leader_id={userId}";
            return  DBaccess.RunScalar(query).ToString()=="1";
        }

        public static List<User> GetUserById(int userId)
        {
            string query = $"SELECT * FROM tasks.users WHERE user_id={userId}";
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

        public static List<User> GetTeamLeaders()
        {
            string query = $"SELECT * FROM tasks.users WHERE user_kind_id=2";
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

        public static bool RemoveUser(int id, int userId)
        {
            string queryChecking = $" select * from tasks.userkind_to_access where(access_id=2 and user_kind_id=(select user_kind_id from tasks.users where (user_id={userId})))";
            var isAbleTo = DBaccess.RunScalar(queryChecking);
            if (isAbleTo != null)
            {
                //delete the rows in actualHours
                string query1 = $"DELETE FROM tasks.actual_hours WHERE user_id={id}";
                DBaccess.RunNonQuery(query1);

                //delete the rows in worker to project table 

                 query1 = $"DELETE FROM tasks.worker_to_project  WHERE  user_id={id}";
                     DBaccess.RunNonQuery(query1) ;
                                                           
                string query = $"DELETE FROM tasks.users  WHERE  user_id={id}";
                return DBaccess.RunNonQuery(query) == 1;
            }
            else return false;
        }

        public static bool UpdateUserIp(int userId)
        {
         
                string query = $"UPDATE tasks.users SET user_ip='0' WHERE user_id={userId}";
                return DBaccess.RunNonQuery(query) == 1;
  
        }

        public static bool UpdateUser(User user, int userId)
        {       
                string query = $"UPDATE tasks.users SET user_name='{user.UserName}', user_email='{user.UserEmail}',password='{user.Password}',team_leader_id={user.TeamLeaderId},user_kind_id={user.UserKindId},user_ip='{user.UserIP}', verify_password='{user.VerifyPassword}' WHERE user_id={user.UserId}";
                return DBaccess.RunNonQuery(query) == 1;
        }
        public static bool UpdatePassword(User user)
        {        
                string query = $"UPDATE tasks.users SET password='{user.Password}'WHERE user_id={user.UserId}";
                return DBaccess.RunNonQuery(query) == 1;    
        }
        public static bool AddUser(User user, int userId)
        {
            string queryChecking = $" select * from tasks.userkind_to_access where(access_id=2 and user_kind_id=(select user_kind_id from tasks.users where (user_id={userId})))";
            var isAbleTo = DBaccess.RunScalar(queryChecking);
            if (isAbleTo != null)

            {
                string query = $"INSERT INTO tasks.users(`user_name`, `user_email`, `password`, `team_leader_id`, `user_kind_id`) VALUES ('{user.UserName}','{user.UserEmail}','{user.Password}',{user.TeamLeaderId},{user.UserKindId})";
                return DBaccess.RunNonQuery(query) == 1;
            }
            else return false;
        }

        public static string GetUserId(string userName, string password)
        {
            string query = $"SELECT user_id FROM tasks.users WHERE user_name='{userName}'&&password='{password}'";
            return DBaccess.RunScalar(query).ToString();
        }



    }
}
