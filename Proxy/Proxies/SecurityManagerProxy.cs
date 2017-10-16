using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Common;
using Tickets.Model;

namespace Tickets.Proxy.Proxies
{
    public class SecurityManagerProxy : BaseProxy, ISecurityManager
    {
        public void AddUser(params User[] users)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(params User[] users)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(params User[] users)
        {
            throw new NotImplementedException();
        }
    }
}
