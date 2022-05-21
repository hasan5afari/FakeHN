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
            try
            {
                UserDao userDao = new UserDao();
                return userDao.getUser(userid);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> UserManager -> getUser() -> " + ex.Message_);
            }
        }

        public List<User> getAllUsers()
        {
            try
            {
                UserDao userDao = new UserDao();
                return userDao.getAllUsers();
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> UserManager -> getAllUsers() -> " + ex.Message_);
            }
        }

        public User isValidUser(string username, string password)
        {
            try
            {
                UserDao userDao = new UserDao();
                return userDao.isValidUser(username, password);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> UserManager -> isValidUser() -> " + ex.Message_);
            }
        }

        public bool usernameExists(string username)
        {
            try
            {
                UserDao userDao = new UserDao();
                return userDao.usernameExists(username);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> UserManager -> usernameExists() -> " + ex.Message_);
            }
        }

        public bool registerUser(User user)
        {
            try
            {
                UserDao userDao = new UserDao();
                return userDao.registerUser(user);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> UserManager -> registerUser() -> " + ex.Message_);
            }
        }

        public bool removeUser(int userid)
        {
            try
            {
                UserDao userDao = new UserDao();
                return userDao.removeUser(userid);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> UserManager -> removeUser() -> " + ex.Message_);
            }
        }

        public bool updateUser(User user)
        {
            try
            {
                UserDao userDao = new UserDao();
                return userDao.updateUser(user);
            }
            catch (DalException ex)
            {
                throw new BllException("BLL -> UserManager -> updateUser() -> " + ex.Message_);
            }
        }
    }
}
