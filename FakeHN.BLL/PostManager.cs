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
            PostDao postDao = new PostDao();
            return postDao.getTop3();
        }

        public List<Post> getAllPosts()
        {
            PostDao postDao = new PostDao();
            return postDao.getAllPosts();
        }

        public List<Post> getUserPosts(int userid)
        {
            PostDao postDao = new PostDao();
            return postDao.getUserPosts(userid);
        }


        public bool removePost(int postid)
        {
            PostDao postDao = new PostDao();
            return postDao.removePost(postid);
        }

        public Post getPost(int postid)
        {
            PostDao postDao = new PostDao();
            return postDao.getPost(postid);
        }

        public bool updatePost(Post post)
        {
            PostDao postDao = new PostDao();
            return postDao.updatePost(post);
        }

        public bool savePost(Post post)
        {
            PostDao postDao = new PostDao();
            return postDao.savePost(post);
        }

        public bool addVote(int postid, int authorid)
        {
            PostDao postDao = new PostDao();
            return postDao.addVote(postid, authorid);
        }

        public bool removeVote(int postid, int authorid)
        {
            PostDao postDao = new PostDao();
            return postDao.removeVote(postid, authorid);
        }

        public bool userVoted(Post post, User user)
        {
            PostDao postDao = new PostDao();
            return postDao.userVoted(post, user);
        }

        public bool removeUserVotes(int userid)
        {
            PostDao postDao = new PostDao();
            return postDao.removeUserVotes(userid);
        }
    }
}
