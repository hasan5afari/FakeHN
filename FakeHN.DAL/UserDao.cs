using FakeHN.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeHN.DAL
{
    public partial class UserDao
    {
        private const string connectionString = "Data Source=DESKTOP-5A7KHGH\\SQLSERVER2022;Initial Catalog=FakeHN;Integrated Security=true;";
        public User getUser(int userid)
        {
            User user = new User();

            // connect to SQL
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            // SQL command
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "Users_getUser";
            SqlParameter useridParameter = sqlCommand.Parameters.Add("@userid", SqlDbType.Int);
            useridParameter.Value = userid.ToString();

            // SQL read data
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            user.userid = Convert.ToInt32(reader["userid"]);
            user.username = Convert.ToString(reader["username"]);
            user.password = Convert.ToString(reader["password"]);
            user.name = Convert.ToString(reader["name"]);
            user.family = Convert.ToString(reader["family"]);

            sqlConnection.Close();

            return user;
        }

        public bool usernameExists(string username)
        {
            // connect to SQL
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            // SQL command
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "Users_usernameExists";
            SqlParameter usernameParameter = sqlCommand.Parameters.Add("@username", SqlDbType.Char);
            usernameParameter.Value = username;

            // SQL read data
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                return true;
            }

            return false;
        }

        public User isValidUser(string username, string password)
        {
            User user = null;

            // connect to SQL
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            // SQL command
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "Users_isValidUser";
            SqlParameter usernameParameter = sqlCommand.Parameters.Add("@username", SqlDbType.Char);
            SqlParameter passwordParameter = sqlCommand.Parameters.Add("@password", SqlDbType.Char);
            usernameParameter.Value = username;
            passwordParameter.Value = password;

            // SQL read data
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                user = new User();
                user.userid = Convert.ToInt32(reader["userid"]);
                user.username = Convert.ToString(reader["username"]);
                user.password = Convert.ToString(reader["password"]);
                user.name = Convert.ToString(reader["name"]);
                user.family = Convert.ToString(reader["family"]);
            }

            return user;
        }

        public bool registerUser(User user)
        {
            // connect to SQL
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            // SQL command
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "Users_registerUser";
            SqlParameter usernameParameter = sqlCommand.Parameters.Add("@username", SqlDbType.Char);
            SqlParameter passwordParameter = sqlCommand.Parameters.Add("@password", SqlDbType.Char);
            SqlParameter nameParameter = sqlCommand.Parameters.Add("@name", SqlDbType.Char);
            SqlParameter familyParameter = sqlCommand.Parameters.Add("@family", SqlDbType.Char);
            usernameParameter.Value = user.username;
            passwordParameter.Value = user.password;
            nameParameter.Value = user.name;
            familyParameter.Value = user.family;

            // SQL execute
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();

            if (reader.RecordsAffected != 0)
                return true;
            else
                return false;
        }
    }
}
