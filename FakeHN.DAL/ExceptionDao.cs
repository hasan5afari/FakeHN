using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeHN.DAL
{
    public partial class ExceptionDao
    {
        private const string connectionString = "Data Source=DESKTOP-5A7KHGH\\SQLSERVER2022;Initial Catalog=FakeHN;Integrated Security=true;";

        public bool saveException(string message)
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            // connect to SQL
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "Exceptions_saveException";
            SqlParameter messageParameter = sqlCommand.Parameters.Add("@message", SqlDbType.Char);
            messageParameter.Value = message.ToString().Trim();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();

            sqlConnection.Close();

            if (reader.RecordsAffected != 0)
            {
                sqlConnection.Close();
                return true;
            }
            else
            { 
                sqlConnection.Close();
                return false;
            }
        }
    }
}
