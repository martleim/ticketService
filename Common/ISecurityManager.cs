using System.Collections.Generic;
using Tickets.Model;

namespace Tickets.Common
{
    public interface ISecurityManager
    {
        IList<AspNetUser> GetAllUsers();
        AspNetUser GetUserByEmail(string email);
        void AddUser(params AspNetUser[] users);
        void UpdateUser(params AspNetUser[] users);
        void RemoveUser(params AspNetUser[] users);

    }
}