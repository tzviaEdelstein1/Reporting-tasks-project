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
  public  class LogicAccess
    {

        public static List<Access> GetAllAccess()
        {
            try
            {
                string query = $"SELECT * FROM tasks.access";
                Func<MySqlDataReader, List<Access>> func = (reader) =>
                {
                    List<Access> access = new List<Access>();
                    while (reader.Read())
                    {
                        access.Add(new Access
                        {
                            AccessId = reader.GetInt32(0),
                            AccessName = reader.GetString(1),
                        });
                    }
                    return access;
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
