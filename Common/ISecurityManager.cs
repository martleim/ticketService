using System.Collections.Generic;
using Tickets.Model;

namespace Tickets.Common
{
    public interface ISecurityManager
    {
        IList<User> GetAllUsers();
        User GetUserByEmail(string email);
        void AddUser(params User[] users);
        void UpdateUser(params User[] users);
        void RemoveUser(params User[] users);

    }
}