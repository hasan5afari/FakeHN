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
    public partial class CommentDao
    {
        private const string connectionString = "Data Source=DESKTOP-5A7KHGH\\SQLSERVER2022;Initial Catalog=FakeHN;Integrated Security=true;";
        public List<Comment> getPostComments(int postid)
        {
            try
            {
                List<Comment> comments = new List<Comment>();

                // connect to SQL
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                // SQL command
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Comments_getPostComments";
                SqlParameter postidParameter = sqlCommand.Parameters.Add("@postid", SqlDbType.Int);
                postidParameter.Value = postid.ToString();

                // SQL read data
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Comment comment = new Comment();
                        comment.commentid = Convert.ToInt32(reader["commentid"]);
                        comment.authorid = Convert.ToInt32(reader["authorid"]);
                        comment.postid = Convert.ToInt32(reader["postid"]);
                        comment.body = Convert.ToString(reader["body"]);
                        comments.Add(comment);
                    }
                }

                sqlConnection.Close();

                return comments;
            }
            catch (Exception ex)
            {
                throw new DalException("DAL -> CommentDao -> getPostComments() -> " + ex.Message);
            }
        }

        public bool removePostComments(int postid)
        {
            try
            {
                bool operationCompleted = true;

                List<Comment> postComments = getPostComments(postid);
                if (postComments.Count > 0)
                {
                    // connect to SQL
                    SqlConnection sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();

                    // SQL command
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader;

                    for (int i = 0; i < postComments.Count; i++)
                    {
                        sqlCommand.CommandText = "Comments_removeComment";
                        SqlParameter commentidParameter = sqlCommand.Parameters.Add("@commentid", SqlDbType.Int);
                        commentidParameter.Value = postComments[i].commentid.ToString();

                        reader = sqlCommand.ExecuteReader();
                        reader.Read();

                        if (reader.RecordsAffected <= 0)
                        {
                            operationCompleted = false;
                            break;
                        }

                        reader.Close();
                    }

                    sqlConnection.Close();
                }

                return operationCompleted;
            }
            catch (Exception ex)
            {
                throw new DalException("DAL -> CommentDao -> removePostComments() -> " + ex.Message);
            }
        }

        public bool addComment(Comment comment)
        {
            try
            {
                // connect to SQL
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                // SQL command
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Comments_addComment";
                SqlParameter authoridParameter = sqlCommand.Parameters.Add("@authorid", SqlDbType.Int);
                SqlParameter postidParameter = sqlCommand.Parameters.Add("@postid", SqlDbType.Int);
                SqlParameter bodyParameter = sqlCommand.Parameters.Add("@body", SqlDbType.Text);
                authoridParameter.Value = comment.authorid.ToString();
                postidParameter.Value = comment.postid.ToString();
                bodyParameter.Value = comment.body;

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
                throw new DalException("DAL -> CommentDao -> addComment() -> " + ex.Message);
            }
        }

        public bool removeUserComments(int userid)
        {
            try
            {
                // connect to SQL
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                // SQL command
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Comments_removeUserComments";
                SqlParameter authoridParameter = sqlCommand.Parameters.Add("@authorid", SqlDbType.Int);
                authoridParameter.Value = userid.ToString();

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
                throw new DalException("DAL -> CommentDao -> removeUserComments() -> " + ex.Message);
            }
        }
    }
}
