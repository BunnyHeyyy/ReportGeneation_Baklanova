using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportGeneration_Baklanova.Models;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ReportGeneration_Baklanova.Classes.Common;

namespace ReportGeneration_Baklanova.Classes
{
    public class DisciplineContext : Discipline
    {
        public DisciplineContext(int Id, string Name, int IdGroup) : base(Id, Name, IdGroup)
      { }
            public static List<DisciplineContext> AllDisciplines() {
            List<DisciplineContext> allDisciplines = new List<DisciplineContext>();

            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader DBDisciplines = Connection.Query("SELECT * FROM `discipline` ORDER BY `Name`;", connection);
            while(DBDisciplines.Read()) {
                allDisciplines.Add(new DisciplineContext(
                    DBDisciplines.GetInt32(0),
                    DBDisciplines.GetString(1),
                    DBDisciplines.GetInt32(2)
                    ));
            }
            Connection.CloseConnection(connection);
            
            return AllDisciplines;
        }
        
    }
}
