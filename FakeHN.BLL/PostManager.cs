using FakeHN.DAL;
using FakeHN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeHN.BLL
{
    public partial class PostManager
    {
        public Post[] getTop3()
        {
            try
            {
                PostDao postDao = new PostDao();
                return postDao.getTop3();
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> PostManager -> getTop3() -> " + ex.Message_);
            }
        }

        public List<Post> getAllPosts()
        {
            try
            {
                PostDao postDao = new PostDao();
                return postDao.getAllPosts();
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> PostManager -> getAllPosts() -> " + ex.Message_);
            }

        }

        public List<Post> getUserPosts(int userid)
        {
            try
            {
                PostDao postDao = new PostDao();
                return postDao.getUserPosts(userid);    
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> PostManager -> getUserPosts() -> " + ex.Message_);
            }
            
        }


        public bool removePost(int postid)
        {
            try
            {
                PostDao postDao = new PostDao();
                return postDao.removePost(postid);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> PostManager -> removePost() -> " + ex.Message_);
            }
            
        }

        public Post getPost(int postid)
        {
            try
            {
                PostDao postDao = new PostDao();
                return postDao.getPost(postid);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> PostManager -> getPost() -> " + ex.Message_);
            }

        }

        public bool updatePost(Post post)
        {
            try
            {
                PostDao postDao = new PostDao();
                return postDao.updatePost(post);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> PostManager -> updatePost() -> " + ex.Message_);
            }

        }

        public bool savePost(Post post)
        {
            try
            {
                PostDao postDao = new PostDao();
                return postDao.savePost(post);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> PostManager -> savePost() -> " + ex.Message_);
            }

        }

        public bool addVote(int postid, int authorid)
        {
            try
            {
                PostDao postDao = new PostDao();
                return postDao.addVote(postid, authorid);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> PostManager -> addVote() -> " + ex.Message_);
            }
            
        }

        public bool removeVote(int postid, int authorid)
        {
            try
            {
                PostDao postDao = new PostDao();
                return postDao.removeVote(postid, authorid);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> PostManager -> removeVote() -> " + ex.Message_);
            }
            
        }

        public bool userVoted(Post post, User user)
        {
            try
            {
                PostDao postDao = new PostDao();
                return postDao.userVoted(post, user);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> PostManager -> userVoted() -> " + ex.Message_);
            }
            
        }

        public bool removeUserVotes(int userid)
        {
            try
            {
                PostDao postDao = new PostDao();
                return postDao.removeUserVotes(userid);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> PostManager -> removeUserVotes() -> " + ex.Message_);
            }
            
        }
    }
}
