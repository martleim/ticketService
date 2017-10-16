using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tickets.Business;
using Tickets.Model;

namespace Tickets.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SecurityService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SecurityService.svc or SecurityService.svc.cs at the Solution Explorer and start debugging.
    public class SecurityService : ISecurityService
    {
        public void AddUser(AspNetUser user)
        {
            new SecurityBusinessManager().AddUser(new AspNetUser[] { user });
        }

        public IList<AspNetUser> GetAllUsers()
        {
            return new SecurityBusinessManager().GetAllUsers();
        }

        public AspNetUser GetUserByEmail(string email)
        {
            return new SecurityBusinessManager().GetUserByEmail(email);
        }

        public void RemoveUser(AspNetUser user)
        {
            new SecurityBusinessManager().RemoveUser(new AspNetUser[] { user });
        }

        public void UpdateUser(AspNetUser user)
        {
            new SecurityBusinessManager().UpdateUser(new AspNetUser[] { user });
        }

        public AspNetUser FindUser(string userName, string password)
        {
            return FindUserAsync(userName, password).Result;
        }

        private async Task<AspNetUser> FindUserAsync(string userName, string password)
        {
            using (AspNetUserManager manager = new AspNetUserManager())
            {

                return await manager.FindUser(userName, password);
            }
        }

        public AspNetUser GetByUserName(string username)
        {
            using (AspNetUserManager manager = new AspNetUserManager())
            {
                return manager.GetByUserName(username);
            }
        }
    }
}
