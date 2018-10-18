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
    public class LogicUserKinds
    {
        public static List<UserKind> GetAllUserKinds()
        {
            try
            {
                string query = $"SELECT * FROM tasks.user_kinds";
                Func<MySqlDataReader, List<UserKind>> func = (reader) =>
                {
                    List<UserKind> usersKind = new List<UserKind>();
                    while (reader.Read())
                    {
                        usersKind.Add(new UserKind
                        {
                            KindUserId = reader.GetInt32(0),
                            KindUserName = reader.GetString(1),
                           
                        });
                    }
                    return usersKind;
                };

                return DBaccess.RunReader(query, func);
            }
            catch (Exception ex)
            {
                var x = ex.StackTrace;
                throw ex;
            }
        }
    }
}
