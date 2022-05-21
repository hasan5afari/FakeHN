using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using FakeHN.Entities;

namespace FakeHN.DAL
{
    public partial class PostDao
    {
        private const string connectionString = "Data Source=DESKTOP-5A7KHGH\\SQLSERVER2022;Initial Catalog=FakeHN;Integrated Security=true;";

        public Post[] getTop3()
        {
            try
            {
                Post[] posts = new Post[3];

                // connect to SQL
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                // SQL command
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Posts_getTop3";

                // SQL read data
                int counter = 0;
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Post post = new Post();
                        post.postid = Convert.ToInt32(reader["postid"]);
                        post.authorid = Convert.ToInt32(reader["authorid"]);
                        post.upvotes = Convert.ToInt32(reader["upvotes"]);
                        post.body = Convert.ToString(reader["body"]);
                        post.createdOn = Convert.ToString(reader["createdOn"]);
                        posts[counter++] = post;
                    }
                }

                sqlConnection.Close();

                return posts;
            }
            catch (Exception ex)
            {
                throw new DalException("DAL -> PostDao -> getTop3() -> " + ex.Message);
            }
        }

        public List<Post> getAllPosts()
        {
            try
            {
                List<Post> posts = new List<Post>();

                // connect to SQL
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                // SQL command
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Posts_getAllPosts";

                // SQL read data
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Post post = new Post();
                        post.postid = Convert.ToInt32(reader["postid"]);
                        post.authorid = Convert.ToInt32(reader["authorid"]);
                        post.upvotes = Convert.ToInt32(reader["upvotes"]);
                        post.body = Convert.ToString(reader["body"]);
                        post.createdOn = Convert.ToString(reader["createdOn"]);
                        posts.Add(post);
                    }
                }

                sqlConnection.Close();

                return posts;
            }
            catch (Exception ex)
            {
                throw new DalException("DAL -> PostDao -> getAllPosts() -> " + ex.Message);
            }
        }

        public List<Post> getUserPosts(int userid)
        {
            try
            {
                List<Post> posts = new List<Post>();

                // connect to SQL
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                // SQL command
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Posts_getUserPosts";
                SqlParameter useridParameter = sqlCommand.Parameters.Add("@userid", SqlDbType.Int);
                useridParameter.Value = userid.ToString();

                // SQL read data
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Post post = new Post();
                        post.postid = Convert.ToInt32(reader["postid"]);
                        post.authorid = Convert.ToInt32(reader["authorid"]);
                        post.upvotes = Convert.ToInt32(reader["upvotes"]);
                        post.body = Convert.ToString(reader["body"]);
                        post.createdOn = Convert.ToString(reader["createdOn"]);
                        posts.Add(post);
                    }
                }

                sqlConnection.Close();

                return posts;
            }
            catch (Exception ex)
            {
                throw new DalException("DAL -> PostDao -> getUserPosts() -> " + ex.Message);
            }
        }

        public bool removePost(int postid)
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
                sqlCommand.CommandText = "Posts_removePost";
                SqlParameter postidParameter = sqlCommand.Parameters.Add("@postid", SqlDbType.Int);
                postidParameter.Value = postid.ToString();

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
                throw new DalException("DAL -> PostDao -> removePost() -> " + ex.Message);
            }
        }

        public Post getPost(int postid)
        {
            try
            {
                Post post = new Post();

                // connect to SQL
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                // SQL command
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Posts_getPost";
                SqlParameter postidParameter = sqlCommand.Parameters.Add("@postid", SqlDbType.Int);
                postidParameter.Value = postid.ToString();

                // SQL read data
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();

                post.postid = Convert.ToInt32(reader["postid"]);
                post.authorid = Convert.ToInt32(reader["authorid"]);
                post.upvotes = Convert.ToInt32(reader["upvotes"]);
                post.body = Convert.ToString(reader["body"]);
                post.createdOn = Convert.ToString(reader["createdOn"]);

                sqlConnection.Close();

                return post;
            }
            catch (Exception ex)
            {
                throw new DalException("DAL -> PostDao -> getPost() -> " + ex.Message);
            }
        }

        public bool updatePost(Post post)
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
                sqlCommand.CommandText = "Posts_updatePost";
                SqlParameter postidParameter = sqlCommand.Parameters.Add("@postid", SqlDbType.Int);
                SqlParameter authoridParameter = sqlCommand.Parameters.Add("@authorid", SqlDbType.Int);
                SqlParameter upvotesParameter = sqlCommand.Parameters.Add("@upvotes", SqlDbType.Int);
                SqlParameter bodyParameter = sqlCommand.Parameters.Add("@body", SqlDbType.Text);
                SqlParameter createdOnParameter = sqlCommand.Parameters.Add("@createdOn", SqlDbType.DateTime);
                postidParameter.Value = post.postid.ToString();
                authoridParameter.Value = post.authorid.ToString();
                upvotesParameter.Value = post.upvotes.ToString();
                bodyParameter.Value = post.body;
                createdOnParameter.Value = post.createdOn;

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
                throw new DalException("DAL -> PostDao -> updatePost() -> " + ex.Message);
            }
        }

        public bool savePost(Post post)
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
                sqlCommand.CommandText = "Posts_savePost";
                SqlParameter authoridParameter = sqlCommand.Parameters.Add("@authorid", SqlDbType.Int);
                SqlParameter upvotesParameter = sqlCommand.Parameters.Add("@upvotes", SqlDbType.Int);
                SqlParameter bodyParameter = sqlCommand.Parameters.Add("@body", SqlDbType.Text);
                SqlParameter createdOnParameter = sqlCommand.Parameters.Add("@createdOn", SqlDbType.DateTime);
                authoridParameter.Value = post.authorid.ToString();
                upvotesParameter.Value = post.upvotes.ToString();
                bodyParameter.Value = post.body;
                createdOnParameter.Value = post.createdOn;

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
                throw new DalException("DAL -> PostDao -> savePost() -> " + ex.Message);
            }
        }

        public bool addVote(int postid, int authorid)
        {
            try
            {
                // connect to SQL
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                // SQL command
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Votes_addVote";
                SqlParameter postidParameter = sqlCommand.Parameters.Add("@postid", SqlDbType.Int);
                SqlParameter authoridParameter = sqlCommand.Parameters.Add("@authorid", SqlDbType.Int);
                postidParameter.Value = postid.ToString();
                authoridParameter.Value = authorid.ToString();

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
                throw new DalException("DAL -> PostDao -> addVote() -> " + ex.Message);
            }
        }

        public bool removeVote(int postid, int authorid)
        {
            try
            {
                // connect to SQL
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                // SQL command
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Votes_removeVote";
                SqlParameter postidParameter = sqlCommand.Parameters.Add("@postid", SqlDbType.Int);
                SqlParameter authoridParameter = sqlCommand.Parameters.Add("@authorid", SqlDbType.Int);
                postidParameter.Value = postid.ToString();
                authoridParameter.Value = authorid.ToString();

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
                throw new DalException("DAL -> PostDao -> removeVote() -> " + ex.Message);
            }
        }

        public bool userVoted(Post post, User user)
        {
            try
            {
                // connect to SQL
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                // SQL command
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Votes_userVoted";
                SqlParameter postidParameter = sqlCommand.Parameters.Add("@postid", SqlDbType.Int);
                SqlParameter authoridParameter = sqlCommand.Parameters.Add("@authorid", SqlDbType.Int);
                postidParameter.Value = post.postid.ToString();
                authoridParameter.Value = user.userid.ToString();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
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
                throw new DalException("DAL -> PostDao -> userVoted() -> " + ex.Message);
            }
        }

        public bool removeUserVotes(int userid)
        {
            try
            {
                // connect to SQL
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                // SQL command
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Votes_removeUserVotes";
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
                throw new DalException("DAL -> PostDao -> removeUserVotes() -> " + ex.Message);
            }
        }
    }
}
