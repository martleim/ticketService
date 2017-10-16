using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DataAccess.PartialRepositories;
using Tickets.Helpers;
using Tickets.Model;

namespace Tickets.Business.Security
{
    public class AspNetUserStore : IUserStore<AspNetUser,int>, IUserPasswordStore<AspNetUser,int>
    {
        public IPasswordHasher PasswordHasher { get; set; }
        public Task CreateAsync(AspNetUser user)
        {
            return Task.Factory.StartNew(() =>
            {
                using (AspNetUserRepository repository = new AspNetUserRepository())
                {
                    user.Updated = DateTime.Now;
                    user.Password = PasswordHasher.HashPassword(user.Password);
                    repository.Add(user);
                }

            });
            
        }

        public Task DeleteAsync(AspNetUser user)
        {
            return Task.Factory.StartNew(() =>
            {
                using (AspNetUserRepository repository = new AspNetUserRepository())
                {
                    repository.Remove(user);
                }

            });
        }

        public Task<AspNetUser> FindByIdAsync(int userId)
        {
            return Task<AspNetUser>.Factory.StartNew(() =>
            {
                using (AspNetUserRepository repository = new AspNetUserRepository())
                {
                    var result=repository.GetSingle(user=>user.Id==userId);
                    return result;
                }

            });
        }

        public Task<AspNetUser> FindByNameAsync(string userName)
        {
            return Task<AspNetUser>.Factory.StartNew(() =>
            {
                using (AspNetUserRepository repository = new AspNetUserRepository())
                {
                    var result = repository.GetSingle(user => user.UserName == userName);
                    return result;
                }

            });
        }

        public Task<AspNetUser> FindAsync(string userName, string password)
        {
            return Task<AspNetUser>.Factory.StartNew(() =>
            {
                using (AspNetUserRepository repository = new AspNetUserRepository())
                {
                    //repository.LazyLoadingEnabled = false;
                    repository.ProxyCreationEnabled = false;
                    password = PasswordHasher.HashPassword(password);
                    var result = repository.GetSingle(user => user.UserName == userName && user.Password == password, user=>user.AspNetUserClaim, user => user.AspNetUserClaim);
                    //return result;
                    return (AspNetUser)DeepCopy.CloneInternal(result, 2);
                }

            });
        }

        public Task UpdateAsync(AspNetUser user)
        {
            return Task.Factory.StartNew(() =>
            {
                using (AspNetUserRepository repository = new AspNetUserRepository())
                {
                    user.Updated = DateTime.Now;
                    //user.Password = GetPassword(user);
                    repository.Update(new AspNetUser[]{ user });
                }

            });
        }

        public void Dispose()
        {
            
        }

        public Task SetPasswordHashAsync(AspNetUser user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(AspNetUser user)
        {
            return Task.FromResult(PasswordHasher.HashPassword(user.Password));
        }

        public Task<bool> HasPasswordAsync(AspNetUser user)
        {
            throw new NotImplementedException();
        }

    }
}
