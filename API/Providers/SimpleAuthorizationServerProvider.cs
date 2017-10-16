using Tickets.Model;
using Tickets.Proxy;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Tickets.API.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
#pragma warning disable 1998
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
#pragma warning restore 1998
        {

            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            EnsureAccessControlAllowOriginHeader(context);

            AspNetUser user;
            string jsonResponseData;
            IEnumerable<string> roles;

            
            user = await ProxyManager.AspNetUserManager.FindUser(context.UserName, context.Password);
            if (user == null)
            {
                SetContextError(context, "InvalidGrant", "The user name or password is incorrect.");
                return;
            }
                
            /*UserListingItem userListingItem = Mapper.Map<OcsIdentityUser, UserListingItem>(user);
            PrepareProfileData(user, userListingItem);
            jsonResponseData = JsonHelpers.Serialize(userListingItem);
            roles = await repository.FindRoles(user.Id);*/
        
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            AddUserRoleClaims(user, identity);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("user_id", user.Id.ToString(CultureInfo.InvariantCulture)));

            string[] rolesArr = identity.Claims.Where(c=>c.Type == ClaimTypes.Role).Select(c=>c.Value).ToArray();
            //string rolesStr = (rolesArr.Count()>0)?string.Format("Roles:[{0}]",string.Join(",",rolesArr)):"";

            context.Validated(new AuthenticationTicket(identity,
                new AuthenticationProperties(new Dictionary<string, string>
                {
                    /*{
                        "data", //jsonResponseData
                    },*/
                    { "roles", string.Join(",",rolesArr)}
                })));

        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            if (originalClient != currentClient)
            {
                context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                return Task.FromResult<object>(null);
            }

            // Change auth ticket for refresh token requests
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

            var newClaim = newIdentity.Claims.Where(c => c.Type == "newClaim").FirstOrDefault();
            if (newClaim != null)
            {
                newIdentity.RemoveClaim(newClaim);
            }
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        private static void EnsureAccessControlAllowOriginHeader(OAuthGrantResourceOwnerCredentialsContext context)
        {
            const string accessControlAllowOriginHttpHeaderKey = "Access-Control-Allow-Origin";
            IHeaderDictionary headers = context.OwinContext.Response.Headers;
            KeyValuePair<string, string[]> header =
                headers.FirstOrDefault(h => string.Equals(h.Key, accessControlAllowOriginHttpHeaderKey));
            if (header.Equals(default(KeyValuePair<string, string[]>)))
            {
                headers.Add(accessControlAllowOriginHttpHeaderKey, new[] { "*" });
            }
        }

        private void SetContextError(OAuthValidateClientAuthenticationContext context, string errorCode, string message)
        {
            context.SetError((errorCode).ToString(CultureInfo.InvariantCulture), message);
        }

        private void SetContextError(OAuthGrantResourceOwnerCredentialsContext context, string errorCode, string message)
        {
            context.SetError((errorCode).ToString(CultureInfo.InvariantCulture), message);
        }

        private void AddUserRoleClaims(AspNetUser user, ClaimsIdentity identity)
        {
            // A user could be a member of multiple roles
            foreach (var claim in user.AspNetUserClaim)
            {
                identity.AddClaim(new Claim(claim.ClaimType, claim.ClaimValue));
            }
        }

    }
}