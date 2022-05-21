using FakeHN.DAL;
using FakeHN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeHN.BLL
{
    public partial class CommentManager
    {
        public List<Comment> getPostComments(int postid)
        {
            try
            {
                CommentDao userDao = new CommentDao();
                return userDao.getPostComments(postid);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> CommentManager -> getPostComments() -> " + ex.Message_);
            }
        }

        public bool removePostComments(int postid)
        {
            try
            { 
                CommentDao commentDao = new CommentDao();
                return commentDao.removePostComments(postid);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> CommentManager -> removePostComments() -> " + ex.Message_);
            }
        }

        public bool addComment(Comment comment)
        {
            try
            {
                CommentDao commentDao = new CommentDao();
                return commentDao.addComment(comment);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> CommentManager -> addComment() -> " + ex.Message_);
            }
        }

        public bool removeUserComments(int userid)
        {
            try
            {
                CommentDao commentDao = new CommentDao();
                return commentDao.removeUserComments(userid);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> CommentManager -> removeUserComments() -> " + ex.Message_);
            }
        }
    }
}
