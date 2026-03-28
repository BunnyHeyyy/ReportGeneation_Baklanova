using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ReportGeneration_Baklanova.Classes.Common;

namespace ReportGeneration_Baklanova.Classes
{
    public class WorkContext : Work
    {
        public WorkContext(int Id, int IdDiscipline, int IdType, DateTime Date, string Name, int Semester) : 
            base(Id, IdDiscipline, IdType, Date, Name, Semester) { }

        public static List<WorkContext> AllWorks()
        {
            List<WorkContext> allWorks = new List<WorkContext>();

            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader DBWorks = Connection.Query("SELECT * FROM `work` ORDER BY `Date`;", connection);
            while (DBWorks.Read())
            {
                allWorks.Add(new WorkContext(
                    DBWorks.GetInt32(0),
                    DBWorks.GetInt32(1),
                    DBWorks.GetInt32(2),
                    DBWorks.GetDateTime(3),
                    DBWorks.GetString(4),
                    DBWorks.GetInt32(5)
                    ));
            }
            Connection.CloseConnection(connection);

            return allWorks;
        }
    }
}
