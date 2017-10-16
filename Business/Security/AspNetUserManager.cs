using Tickets.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Business.Security
{
    public class AspNetUserManager : UserManager<AspNetUser,int>
    {
        public AspNetUserManager(AspNetUserStore store, IPasswordHasher passwordHasher)
            : base(store)
        {
            PasswordHasher = passwordHasher;
            store.PasswordHasher = passwordHasher;
        }

        public override Task<AspNetUser> FindAsync(string userName, string password)
        {
            return ((AspNetUserStore)Store).FindAsync(userName,password);
        }
    }
}
