using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Tickets.Business;
using Tickets.Model;

namespace Tickets.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SecurityService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SecurityService.svc or SecurityService.svc.cs at the Solution Explorer and start debugging.
    public class SecurityService : ISecurityService
    {
        public void AddUser(User user)
        {
            new SecurityBusinessManager().AddUser(new User[] { user });
        }

        public IList<User> GetAllUsers()
        {
            return new SecurityBusinessManager().GetAllUsers();
        }

        public User GetUserByEmail(string email)
        {
            return new SecurityBusinessManager().GetUserByEmail(email);
        }

        public void RemoveUser(User user)
        {
            new SecurityBusinessManager().RemoveUser(new User[] { user });
        }

        public void UpdateUser(User user)
        {
            new SecurityBusinessManager().UpdateUser(new User[] { user });
        }
    }
}
