using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Business.Security
{
    class PasswordHasher : IPasswordHasher
    {
        public PasswordHasher(IPasswordEncoder passwordEncoder)
        {
            PasswordEncoder = passwordEncoder;
        }

        private IPasswordEncoder PasswordEncoder { get; set; }

        public string HashPassword(string password)
        {
            return PasswordEncoder.Encode(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            bool isEqual = string.Equals(hashedPassword, PasswordEncoder.Encode(providedPassword),
                StringComparison.Ordinal);
            if (isEqual)
            {
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;
        }

    }
}
