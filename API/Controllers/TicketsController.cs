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
    public class TicketsController : BaseController
    {

        [HttpGet]
        public IHttpActionResult Events()
        {
            return Ok(new TicketsManagerProxy().GetAllEvents());
        }

        [HttpGet]
        public IHttpActionResult Sessions(int eventId)
        {
            return Ok(new TicketsManagerProxy().GetAllEventSessions(eventId));
        }

        [HttpGet]
        public IHttpActionResult Tickets(int sessionId)
        {
            return Ok(new TicketsManagerProxy().GetAllSessionTickets(sessionId));
        }

        [HttpGet]
        public IHttpActionResult Transactions()
        {
            return Ok(new TicketsManagerProxy().GetAllUserTransactions(GetLoggedUserId()));
        }

        [HttpPost]
        public IHttpActionResult Transactions(Transaction transaction)
        {
            transaction.UserId = GetLoggedUserId();
            new TicketsManagerProxy().AddTransaction(transaction);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Transactions(int transactionId, Transaction transaction)
        {
            transaction.Id = transactionId;
            new TicketsManagerProxy().UpdateTransaction(transaction);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Transactions(int transactionId)
        {
            Transaction transaction = new Transaction() { Id = transactionId };
            new TicketsManagerProxy().RemoveTransaction(transaction);
            return Ok();
        }

    }
}
