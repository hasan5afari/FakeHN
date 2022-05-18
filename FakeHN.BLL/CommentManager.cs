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
            CommentDao userDao = new CommentDao();
            return userDao.getPostComments(postid);
        }

        public bool removePostComments(int postid)
        {
            CommentDao commentDao = new CommentDao();
            return commentDao.removePostComments(postid);
        }
    }
}
