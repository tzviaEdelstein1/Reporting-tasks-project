using _01_BOL;
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
    public class LogicTreeTable
    {
        static List<TreeTable> treeTables = new List<TreeTable>();
        public static List<TreeTable> GetAllTreeTable()
        {
            string query = $"SELECT p.*,user_id,user_name FROM tasks.projects P  JOIN tasks.users u ON u.user_id=p.team_leader_id ";
            Func<MySqlDataReader, List<TreeTable>> func = (reader) =>
            {
                treeTables = new List<TreeTable>();
                while (reader.Read())
                {
                    treeTables.Add(new TreeTable
                    {
                        Project = new Project()
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
                            IsActive = reader.GetBoolean(9),
                            User = new User() { UserId = reader.GetInt32(10), UserName = reader.GetString(11) }
                        }

                    });
                }
                return treeTables;
            };

            DBaccess.RunReader(query, func);
            FillHoursToTreeTable();
            return treeTables;
        }
        public static void FillHoursToTreeTable()
        {
            foreach (var item in treeTables)
            {
                string query = $"SELECT hours,user_kinds_name,u.user_name,u.user_id ,us.user_name teamLeadername FROM tasks.worker_to_project W JOIN tasks.users u ON w.user_id=u.user_id JOIN tasks.user_kinds uk ON u.user_kind_id=uk.user_kinds_id  JOIN tasks.users us ON u.team_leader_id=us.user_id where project_id={item.Project.ProjectId}";
                Func<MySqlDataReader, List<TreeTable>> func = (reader) =>
                {
                    item.DetailsWorkerInProjects = new List<DetailsWorkerInProjects>();
                    while (reader.Read())
                    {
                        item.DetailsWorkerInProjects.Add(new DetailsWorkerInProjects()
                        {
                            Hours = reader.GetInt32(0),
                            Kind = reader.GetString(1),
                            Name = reader.GetString(2),
                            UserId = reader.GetInt32(3),
                            TeamLeaderName = reader.GetString(4)
                        });
                    }
                    return treeTables;
                };

                DBaccess.RunReader(query, func);
            }
            FillActualHoursToTreeTable();
        }

        public static void FillActualHoursToTreeTable()
        {
            foreach (var item in treeTables)
            {
                foreach (var item1 in item.DetailsWorkerInProjects)
                {
                    string query = $"SELECT * FROM tasks.actual_hours where project_id={item.Project.ProjectId} and user_id={item1.UserId}";
                    Func<MySqlDataReader, List<TreeTable>> func = (reader) =>
                    {
                        item1.ActualHours = new List<ActualHours>();
                        while (reader.Read())
                        {
                            item1.ActualHours.Add(new ActualHours()
                            {
                                ActualHoursId = reader.GetInt32(0),
                                UserId = reader.GetInt32(1),
                                ProjectId = reader.GetInt32(2),
                                CountHours = reader.GetInt32(3),
                                date = reader.GetDateTime(4)

                            });
                        }
                        return treeTables;
                    };

                    DBaccess.RunReader(query, func);
                }
            }
        }
    }


}
