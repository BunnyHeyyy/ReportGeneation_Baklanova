using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ReportGeneration_Baklanova.Classes.Common;

namespace ReportGeneration_Baklanova.Classes
{
    public class EvaluationContext : Evaluation
    {
        public EvaluationContext(int Id, int IdWork, int IdStudent, string Value, string Lateness) :
            base(Id, IdWork, IdStudent, Value, Lateness) { }

        public static List<EvaluationContext> AllEvaluations()
        {
            List<EvaluationContext> allEvaluations = new List<EvaluationContext>();

            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader DBEvaluations = Connection.Query("SELECT * FROM `evaluation`", connection);
            while (DBEvaluations.Read())
            {
                allEvaluations.Add(new EvaluationContext(
                    DBEvaluations.GetInt32(0),
                    DBEvaluations.GetInt32(1),
                    DBEvaluations.GetInt32(2),
                    DBEvaluations.GetString(3),
                    DBEvaluations.GetString(4)
                    ));

            }
            Connection.CloseConnection(connection);

            return allEvaluations;
        }
    }
}
