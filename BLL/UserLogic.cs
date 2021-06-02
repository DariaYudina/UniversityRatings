using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao userDao;

        public UserLogic(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public bool AddUser(User user)
        {
            try
            {
                return this.userDao.AddUser(user);
            }
            catch
            {
                throw new Exception("layer = BLL, class = UserLogic, method = AddUser");
            }
        }

        public bool ChangeRoleUser(string name, string role)
        {
            try
            {
                return this.userDao.ChangeRoleUser(name, role);
            }
            catch
            {
                throw new Exception("layer = BLL, class = UserLogic, method = ChangeRoleUser");
            }
        }

        public ICollection<User> GetAllUsers()
        {
            try
            {
                return this.userDao.GetAllUsers();
            }
            catch
            {
                throw new Exception("layer = BLL, class = UserLogic, method = GetAllUsers");
            }
        }
    }
}
