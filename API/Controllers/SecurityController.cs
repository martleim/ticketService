using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tickets.Model;
using Tickets.Proxy;

namespace Tickets.API.Controllers
{
    public class SecurityController : BaseController
    {

        [HttpPost]
        [Route("Security/Register")]
        public IHttpActionResult Transactions(AspNetUser user)
        {
            //ProxyManager.AspNetUserManager.(user);
            return Ok();
        }

    }
}
