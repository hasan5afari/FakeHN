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

        public List<User> getAllUsers()
        {
            UserDao userDao = new UserDao();
            return userDao.getAllUsers();
        }

        public User isValidUser(string username, string password)
        {
            UserDao userDao = new UserDao();
            return userDao.isValidUser(username, password);
        }

        public bool usernameExists(string username)
        {
            UserDao userDao = new UserDao();
            return userDao.usernameExists(username);
        }

        public bool registerUser(User user)
        {
            UserDao userDao = new UserDao();
            return userDao.registerUser(user);
        }

        public bool removeUser(int userid)
        {
            UserDao userDao = new UserDao();
            return userDao.removeUser(userid);
        }

        public bool updateUser(User user)
        {
            UserDao userDao = new UserDao();
            return userDao.updateUser(user);
        }
    }
}
