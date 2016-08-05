using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tickets.DomainModel;

namespace Tickets.API.Controllers
{
    public class TransactionController : ApiController
    {

        public HttpResponseMessage Post(Transaction transaction)
        {
            return null;
        }

    }
}
