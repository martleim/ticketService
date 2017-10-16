using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Common;
using Tickets.Model;
using Tickets.Proxy.SecurityServiceReference;

namespace Tickets.Proxy.Proxies
{
    public class AspNetUserManagerProxy : BaseProxy, IAspNetUserManager
    {
        public Task<AspNetUser> FindUser(string userName, string password)
        {
            return Task.Run(() => (new SecurityServiceClient()).FindUser(userName, password));
        }

        public AspNetUser GetByUserName(string username)
        {
            return (new SecurityServiceClient()).GetByUserName(username);
        }
    }
}
