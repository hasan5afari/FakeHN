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

        public List<Post> getAllPosts()
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

        public List<Post> getUserPosts(int userid)
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

        public bool removePost(int postid)
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

        public Post getPost(int postid)
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

        public bool updatePost(Post post)
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

        public bool savePost(Post post)
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

        public bool addVote(int postid, int authorid)
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
                return true;
            else
                return false;
        }

        public bool removeVote(int postid, int authorid)
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
                return true;
            else
                return false;
        }

        public bool userVoted(Post post, User user)
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
                return true;
            else
                return false;
        }

        public bool removeUserVotes(int userid)
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
                return true;
            else
                return false;
        }
    }
}
