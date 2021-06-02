using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUserDao
    {
        ICollection<User> GetAllUsers();

        bool AddUser(User user);

        bool ChangeRoleUser(string name, string role);
    }
}
