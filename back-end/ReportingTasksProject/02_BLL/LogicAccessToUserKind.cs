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
  public  class LogicAccessToUserKind
    {
        public static List<UserKindToAccess> GetAllUserKindToAccess()
        {
            try
            {
                string query = $"SELECT * FROM tasks.userkind_to_access";
                Func<MySqlDataReader, List<UserKindToAccess>> func = (reader) =>
                {
                    List<UserKindToAccess> userKindToAccess = new List<UserKindToAccess>();
                    while (reader.Read())
                    {
                        userKindToAccess.Add(new UserKindToAccess
                        {
                            UserKindToAccessId = reader.GetInt32(0),
                            userKindId = reader.GetInt32(1),
                            AccessId = reader.GetInt32(2),
                        });
                    }
                    return userKindToAccess;
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
