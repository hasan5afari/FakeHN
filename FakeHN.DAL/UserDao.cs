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
            try
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
            catch (Exception ex)
            {
                throw new DalException("DAL -> UserDao -> getUser() -> " + ex.Message);
            }
        }

        public List<User> getAllUsers()
        {
            try
            {
                List<User> users = new List<User>();

                // connect to SQL
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                // SQL command
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Users_getAllUsers";

                // SQL read data
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.userid = Convert.ToInt32(reader["userid"]);
                        user.username = Convert.ToString(reader["username"]);
                        user.password = Convert.ToString(reader["password"]);
                        user.name = Convert.ToString(reader["name"]);
                        user.family = Convert.ToString(reader["family"]);
                        users.Add(user);
                    }
                }

                sqlConnection.Close();

                return users;
            }
            catch (Exception ex)
            {
                throw new DalException("DAL -> UserDao -> getAllUsers() -> " + ex.Message);
            }
        }

        public bool usernameExists(string username)
        {
            try
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
                    sqlConnection.Close();
                    return true;
                }

                sqlConnection.Close();
                return false;
            }
            catch (Exception ex)
            {
                throw new DalException("DAL -> UserDao -> usernameExists() -> " + ex.Message);
            }
        }

        public User isValidUser(string username, string password)
        {
            try
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

                sqlConnection.Close();

                return user;
            }
            catch (Exception ex)
            {
                throw new DalException("DAL -> UserDao -> isValidUser() -> " + ex.Message);
            }
        }

        public bool registerUser(User user)
        {
            try
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
            catch (Exception ex)
            {
                throw new DalException("DAL -> UserDao -> registerUser() -> " + ex.Message);
            }
        }

        public bool removeUser(int userid)
        {
            try
            {
                bool operationCompleted = true;

                // connect to SQL
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                // SQL command
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Users_removeUser";
                SqlParameter postidParameter = sqlCommand.Parameters.Add("@userid", SqlDbType.Int);
                postidParameter.Value = userid.ToString();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();

                if (reader.RecordsAffected == 0)
                {
                    operationCompleted = false;
                }

                sqlConnection.Close();

                return operationCompleted;
            }
            catch (Exception ex)
            {
                throw new DalException("DAL -> UserDao -> removeUser() -> " + ex.Message);
            }
        }

        public bool updateUser(User user)
        {
            try
            {

                bool operationCompleted = true;

                // connect to SQL
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                // SQL command
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Users_updateUser";
                SqlParameter useridParameter = sqlCommand.Parameters.Add("@userid", SqlDbType.Int);
                SqlParameter usernameParameter = sqlCommand.Parameters.Add("@username", SqlDbType.Char);
                SqlParameter passwordParameter = sqlCommand.Parameters.Add("@password", SqlDbType.Char);
                SqlParameter nameParameter = sqlCommand.Parameters.Add("@name", SqlDbType.Char);
                SqlParameter familyParameter = sqlCommand.Parameters.Add("@family", SqlDbType.Char);
                useridParameter.Value = user.userid.ToString().Trim();
                usernameParameter.Value = user.username.ToString().Trim();
                passwordParameter.Value = user.password.ToString().Trim();
                nameParameter.Value = user.name.ToString().Trim();
                familyParameter.Value = user.family.ToString().Trim();

                // SQL read data
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();

                if (reader.RecordsAffected == 0)
                {
                    operationCompleted = false;
                }

                sqlConnection.Close();

                return operationCompleted;
            }
            catch (Exception ex)
            {
                throw new DalException("DAL -> PostDao -> updateUser() -> " + ex.Message);
            }
        }
    }
}
