using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace BLL
{
    public interface IUserLogic
    {
        ICollection<User> GetAllUsers();

        bool AddUser(User user);
        bool ChangeRoleUser(string name, string role);
    }
}
