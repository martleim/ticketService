using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tickets.Business.Security;
using Tickets.Common;
using Tickets.DataAccess.PartialRepositories;
using Tickets.Model;

namespace Tickets.Business
{
    public class AspNetUserManager : BaseManager, IAspNetUserManager
    {
        private Tickets.Business.Security.AspNetUserManager _userManager;

        public AspNetUserManager()
        {
            _userManager = new Tickets.Business.Security.AspNetUserManager(new AspNetUserStore(), new Tickets.Business.Security.PasswordHasher(new SHA256ManagedPasswordEncoder()));
        }

        public async Task<IdentityResult> RegisterUser(AspNetUser user)
        {

            var result = await _userManager.CreateAsync(user, user.Password);

            return result;
        }

        public async Task<AspNetUser> FindUser(string userName, string password)
        {

            Tickets.Helpers.Logger.Instance.Info(string.Format("Login attempt at: {0} | Username: {1}", DateTime.Now, userName));
            AspNetUser user = await _userManager.FindAsync(userName, password);
            if (user == null)
            {
                Tickets.Helpers.Logger.Instance.Warn(string.Format("Login attempt failed: {0} | Username: {1}", DateTime.Now, userName));
            }
            else
            {
                Tickets.Helpers.Logger.Instance.Info(string.Format("Login attempt successful at: {0} | Username: {1}", DateTime.Now, userName));
            }

            return user;
        }

        public async Task<AspNetUser> FindAsync(UserLoginInfo loginInfo)
        {
            AspNetUser user = await _userManager.FindAsync(loginInfo);

            return user;
        }

        public async Task<IdentityResult> CreateAsync(AspNetUser user)
        {
            var result = await _userManager.CreateAsync(user);

            return result;
        }

        public async Task<IdentityResult> AddLoginAsync(int userId, UserLoginInfo login)
        {
            var result = await _userManager.AddLoginAsync(userId, login);

            return result;
        }

        public virtual Task<AspNetUser> GetSingleAsync(Func<AspNetUser, bool> where,
            params Expression<Func<AspNetUser, object>>[] navigationProperties)
        {
            using (AspNetUserRepository repository = new AspNetUserRepository())
            {
                repository.ProxyCreationEnabled = false;
                return repository.GetSingleAsync(where, navigationProperties);
            }
        }

        public AspNetUser GetByUserName(string username)
        {
            using (AspNetUserRepository repository = new AspNetUserRepository())
            {
                repository.ProxyCreationEnabled = false;
                return repository.GetSingle(u => u.UserName == username);
            }
        }

        override public void Dispose()
        {
            _userManager.Dispose();
        }
    }

}
