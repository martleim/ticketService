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
        public void AddUser(params AspNetUser[] users)
        {
            throw new NotImplementedException();
        }

        public IList<AspNetUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public AspNetUser GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(params AspNetUser[] users)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(params AspNetUser[] users)
        {
            throw new NotImplementedException();
        }
    }
}
