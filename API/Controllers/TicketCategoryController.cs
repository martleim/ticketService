using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tickets.Proxy;

namespace Tickets.API.Controllers
{
    public class TicketyController : ApiController
    {

        public HttpResponseMessage Get()
        {
            return null;// new TicketsManagerProxy().ge
        }

    }
}
