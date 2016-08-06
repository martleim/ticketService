using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Tickets.API.Controllers
{
    public class BaseController : ApiController
    {
        protected int GetLoggedUserId() {
            return 0;
        }

    }
}
