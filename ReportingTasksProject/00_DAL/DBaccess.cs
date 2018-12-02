using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace DAL
{
    public static class DBaccess
    {

        static MySqlConnection Connection = new MySqlConnection(@"SERVER=127.0.0.1;PORT=3306;pwd=1234;UID=root;persistsecurityinfo=True;DATABASE=tasks;SslMode = none");

        public static int? RunNonQuery(string query)
        {
            lock (Connection)
            {
                try
                {
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand(query, Connection);
                    return command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    if (Connection.State != System.Data.ConnectionState.Closed)
                    {
                        Connection.Close();
                    }
                }
            }


        }

        public static object RunScalar(string query)
        {
            lock (Connection)
            {
                try
                {
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand(query, Connection);
                    return command.ExecuteScalar();
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    if (Connection.State != System.Data.ConnectionState.Closed)
                    {
                        Connection.Close();
                    }
                }
            }


        }

        public static List<T> RunReader<T>(string query, Func<MySqlDataReader, List<T>> func)
        {
            lock (Connection)
            {
                try
                {
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand(query, Connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    return func(reader);
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (Connection.State != System.Data.ConnectionState.Closed)
                    {
                        Connection.Close();
                    }
                }

            }

        }
        public static T RunOneReader<T>(string query, Func<MySqlDataReader, T> func)
        {
            lock (Connection)
            {
                try
                {
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand(query, Connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    return func(reader);
                }
                catch (Exception)
                {
                    return default(T);
                }
                finally
                {
                    if (Connection.State != System.Data.ConnectionState.Closed)
                    {
                        Connection.Close();
                    }
                }
            }


        }

    }
}
