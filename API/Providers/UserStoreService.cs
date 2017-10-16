using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tickets.API.Providers
{
    using Microsoft.AspNet.Identity;
    using Tickets.Model;
    using System.Threading.Tasks;
    using Proxy;
    public class UserStoreService
             : IUserStore<AspNetUser,int>, IUserPasswordStore<AspNetUser,int>
    {

        public Task CreateAsync(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public Task<AspNetUser> FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<AspNetUser> FindByNameAsync(string userName)
        {
            
            return Task.Run(()=> ProxyManager.AspNetUserManager.GetByUserName(userName));
        }

        public Task UpdateAsync(AspNetUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //context.Dispose();
        }

        public Task<string> GetPasswordHashAsync(AspNetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(AspNetUser user)
        {
            return Task.FromResult(user.Password != null);
        }

        public Task SetPasswordHashAsync(AspNetUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        
    }
}