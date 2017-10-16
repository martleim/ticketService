using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Model;

namespace Tickets.Common
{
    public interface IAspNetUserManager
    {

        Task<AspNetUser> FindUser(string userName, string password);
        AspNetUser GetByUserName(string username);

    }
}
