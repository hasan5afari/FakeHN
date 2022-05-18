using FakeHN.DAL;
using FakeHN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeHN.BLL
{
    public partial class UserManager
    {
        public User getUser(int userid)
        {
            UserDao userDao = new UserDao();
            return userDao.getUser(userid);
        }

        public User isValidUser(string username, string password)
        {
            UserDao userDao = new UserDao();
            return userDao.isValidUser(username, password);
        }
    }
}
