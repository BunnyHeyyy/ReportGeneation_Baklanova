using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ReportGeneration_Baklanova.Classes.Common;

namespace ReportGeneration_Baklanova.Classes
{
    public class StudentContext : Student
    {
        public StudentContext(int Id, string FirstName, string Lastname, int IdGroup, bool Expelled, DateTime DateExpelled)
            : base(Id, FirstName, Lastname, IdGroup, Expelled, DateExpelled) { }

        public static List<StudentContext> AllStudents()
        {
            List<StudentContext> allStudent = new List<StudentContext>();

            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader DBStudents = Connection.Query("SELECT * FROM `student` ORDER BY `Name`;", connection);
            while (DBStudents.Read())
            {
                allStudent.Add(new StudentContext(
                    DBStudents.GetInt32(0),
                    DBStudents.GetString(1),
                    DBStudents.GetString(2),
                    DBStudents.GetInt32(3),

                    DBStudents.GetBoolean(4),
                    DBStudents.IsDBNull(5) ? DateTime.Now : DBStudents.GetDateTime(5)
                    ));
            }
            Connection.CloseConnection(connection);

            return allStudent;
        }
    }
}
